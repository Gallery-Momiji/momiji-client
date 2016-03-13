using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.Common;
using MySql.Data.MySqlClient;
using MySql.Data.Types;

// TODO : Remove this dependancy, it is used solely for debugging
using System.Windows.Forms;
namespace Momiji
{
    public class SQL
    {
        private string username, password, address, database;
        private int port;
        private MySql.Data.MySqlClient.MySqlConnection link = new MySql.Data.MySqlClient.MySqlConnection();
        private int state = 0;
        private string errorMessage = "";
        private bool dead = false;
        public SQL(string username, string password, string address, string database, int port)
        {
            link.ConnectionString = "Server=" + address + ";Database=" + database + ";Uid=" + username + ";Pwd="+password+";Port=" + port.ToString() + ";";
            this.address = address;
            this.password = password;
            this.username = username;
            this.database = database;
            this.port = port;
            
            try
            {
                link.Open();
            }
            catch (Exception e)
            {
                state = -1;
                this.errorMessage = "MySQL Exception : " + e.Message.ToString();
                this.dead = true;
                return;
            }

            this.errorMessage = link.State.ToString();
            this.state = 1;
            

            

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
                MessageBox.Show("I'm afraid there was an error sending a command to the server! He had the nerve to tell me there was an error! Can you believe that?! At any rate, I'm going to show you some gobelty goop you should show Tiago, so this doesn't happen again!", "Silly server...", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.errorMessage = "Query : " + query.CommandText.ToString() + '\n' + "Query Error : " + e.Message.ToString();
                MessageBox.Show(this.errorMessage);
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
                    MessageBox.Show("Master.. I've made an error while speaking to the server ;3; is it alive? ;3; Is he giving me the silent treatment? ", "Is it time for bai bais awready? D:", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("But before I go! Please tell Tiago about this : " + d.Message.ToString());
                }
                this.dead = true;
                Environment.FailFast("Emergency Stop, sorry!");

            }
        }

       
        public string GetErrorMessage()
        {
            return errorMessage;

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
