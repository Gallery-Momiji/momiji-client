using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
namespace Momiji
{
    public partial class frmLog : Form
    {
        public SQL SQLConnection;
        public SQLResult User;

        public frmLog(SQL Link, SQLResult UserIdentifier)
        {
            this.SQLConnection = Link;
            this.User = UserIdentifier;
            InitializeComponent();
        }

        private void frmLog_Load(object sender, EventArgs e)
        {
            MySqlCommand query = new MySqlCommand("select `action`,`timestamp`,`date`, `users`.`name` from `log` INNER JOIN `users` ON `log`.user_id = `users`.id ORDER by `log`.`id` DESC Limit 0, 40  ;", SQLConnection.GetConnection());
            query.Prepare();

            SQLResult results = this.SQLConnection.Query(query);
            int i;
            for (i = 0; i < results.GetNumberOfRows(); i++)
            {
                ListViewItem newItem = new ListViewItem(results.getCell("name", i));
                newItem.SubItems.Add(results.getCell("action", i));
                newItem.SubItems.Add(results.getCell("timestamp", i));
                newItem.SubItems.Add(results.getCell("date", i));

                listView1.Items.Add(newItem);
            }




            SQLConnection.LogAction("Checked Logs", this.User);
            
            
        }

       

  
   
    

    }
}