using System;
using System.Collections.Generic;
using System.Text;
using Gtk;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

namespace Momiji
{
    public class SQL
    {
        private string address;
        private MySql.Data.MySqlClient.MySqlConnection link = new MySql.Data.MySqlClient.MySqlConnection();
        private int state = 0;
        private string errorMessage = "";
        private bool dead = false;
        public SQL(string username, string password, string address, string database, string port)
        {
            link.ConnectionString = "Server=" + address + ";Database=" + database + ";Uid=" + username + ";Pwd="+password+";Port=" + port + ";";
            this.address = address;
             
            try
            {
                link.Open();
                this.errorMessage = link.State.ToString();
                this.state = 1;
            }
            catch (Exception e)
            {
                state = -1;
                this.errorMessage = "MySQL Exception : " + e.Message.ToString();

            }

            

        }
        public string getHost()
        {
            return this.address;
        }
        public void Close()
        {
            this.link.Close();
            this.state = -1;
        }

        public SQLResult Query(MySqlCommand query)
        {
            string[,] empty = new string[1, 1];
            if (this.state != 1)
            {
                this.errorMessage = "Not yet connected to MySQL server...";
                return new SQLResult(empty,0,0,false);
            }
            try {

                int rows =0;
                int i = 0;
                MySqlDataReader reader = query.ExecuteReader();
                string[,] results = new string[100, reader.FieldCount+1];

                for (i = 0; i < reader.FieldCount; i++)
                {
                    results[0, i] = reader.GetName(i);
                }

                while (reader.Read())
                {
                    for (i = 0; i < reader.FieldCount; i++)
                    {
                        results[rows+1, i] = reader.GetValue(i).ToString();
                    }

                    rows++;

                }

                SQLResult final = new SQLResult(results, rows+1, reader.FieldCount, true);
                reader.Dispose();
                return final;
            }
            catch (MySqlException e)
            {
                MessageDialog md = new MessageDialog(null,DialogFlags.Modal,
				                 		MessageType.Error,ButtonsType.Ok,
										"Could not connect to server, please give your administrator the following information:\n\n"
				                                     + e.Message.ToString() + "\n\nQuery: " + query.CommandText.ToString());
				md.Run ();
				md.Destroy ();
				this.dead = true;
                return new SQLResult(empty, 0, 0, false);
            }

        }

        public void LogAction(string action, SQLResult user)
        {
            try
            {
                string time = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();
                string date = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Date.Day.ToString();
                string sqlQuery = "INSERT INTO `log` (`user_id`, `action`, `timestamp`, `date`) VALUES (" + user.getCell("id", 0) + ", '" + action + "', '" + time + "', '" + date + "');";

                MySqlCommand log = new MySqlCommand(sqlQuery, this.link);
                log.Prepare();
                this.Query(log);
            }
            catch (Exception d)
            {
                if (!this.dead)
                {
					MessageDialog md = new MessageDialog(null,DialogFlags.Modal,
				                 		MessageType.Error,ButtonsType.Ok,
										"Connection to database has been lost, please try again and inform your administrator if problems persist.\n\n"
					                                     + d.Message);
					md.Run ();
					md.Destroy ();
                }
                this.dead = true;

            }
        }

        public string GetErrorMessage()
        {
            return this.errorMessage;

        }

        public MySqlConnection GetConnection()
        {
            return this.link;
        }

        public int GetState()
        {
            return state;

        }

    }
}
