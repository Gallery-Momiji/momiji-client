using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Momiji
{
    class controlsheet
    {
        private string artistID;
        private SQL SQLConnection;
        private SQLResult User;

        public controlsheet(string artistID, SQL Link, SQLResult UserIdentifier)
        {
            this.artistID = artistID;
            this.SQLConnection = Link;
            this.User = UserIdentifier;
        }


        private string fillArtistInfo(SQLResult artistInfo, int totalItems )
        {
            string template = Properties.Resources.controlsheet.ToString();
            template = template.Replace("%AID%", formatArtistID(this.artistID));
            template = template.Replace("%ARTISTNAME%", artistInfo.getCell("ArtistName", 0));
            template = template.Replace("%ARTISTADDRESS%", artistInfo.getCell("ArtistAddress", 0));
            template = template.Replace("%ARTISTPHONE%", artistInfo.getCell("ArtistPhone", 0));
            template = template.Replace("%ARTISTEMAIL%", artistInfo.getCell("ArtistEmail", 0));
            template = template.Replace("%ARTISTWEBSITE%", artistInfo.getCell("ArtistUrl", 0));
            template = template.Replace("%AGENTNAME%", artistInfo.getCell("ArtistAgentName", 0));
            template = template.Replace("%AGENTADDRESS%", artistInfo.getCell("ArtistAgentAddress", 0));
            template = template.Replace("%AGENTPHONE%", artistInfo.getCell("ArtistAgentPhone", 0));
            template = template.Replace("%AGENTEMAIL%", artistInfo.getCell("ArtistAgentEmail", 0));
            template = template.Replace("%AGENTNOTES%", "");
            template = template.Replace("%NP%", artistInfo.getCell("ArtistPanels", 0));
            template = template.Replace("%NT%", artistInfo.getCell("ArtistTables", 0));
            template = template.Replace("%FEE%", artistInfo.getCell("ArtistDue", 0));
            template = template.Replace("%TTLP%", totalItems.ToString());
            
            return template;

        }

        public void generate(){
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                  saveFileDialog1.Filter = "RTF Files (*.rtf)|*.rtf"  ;
                  saveFileDialog1.FilterIndex = 1 ;
                  saveFileDialog1.RestoreDirectory = true ;
                  saveFileDialog1.Title = "Tell me where to save the control sheet!";
                  saveFileDialog1.FileName = "AN" + this.artistID;
                  
                  //saveFileDialog1.CheckFileExists = true;
                  saveFileDialog1.CheckPathExists = true;

                  if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                  {

                      
                      

                      SQLResult artistInfo = this.getArtistInfo(this.artistID);
                      SQLResult artwork = this.getArtistArtwork(this.artistID);

                      
                      string template = fillArtistInfo(artistInfo, artwork.GetNumberOfRows());
                      int i = 0;

                      int limit = 0;
                      if (artwork.GetNumberOfRows() <= 14)
                      {
                          limit = 14;
                      }
                      else
                      {
                          limit = (14 -(artwork.GetNumberOfRows() % 14)) + artwork.GetNumberOfRows() ;
                      }

                      int PID = 0;
                      bool blank = false;
                      int currentPage = 0;
                      int lastPage = 0;
                      int ActualPID = 0;

                      for (i = 0; i <= limit; i++)
                      {
                          PID = i + 1;
                          blank = PID > artwork.GetNumberOfRows();
                          currentPage = (int)(i / 14);
                          ActualPID = (i % 14) + 1;

                          if (lastPage != currentPage)
                          {
                              try
                              {
                                  System.IO.File.WriteAllText( saveFileDialog1.FileName + ".part" + lastPage.ToString() + ".rtf", template);

                              }
                              catch (Exception d)
                              {
                                  MessageBox.Show("Uh oh! :( I wasn't able to save that file... Your OS had this to say: " + d.Message.ToString(), "EPIC FAILURE!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                              }
                              template = fillArtistInfo(artistInfo, artwork.GetNumberOfRows());
                          }

                          template = template.Replace("%PID" + ActualPID.ToString() + "%", formatPieceID(artistID, PID.ToString()));
                          
                          if (!blank)
                          {
                              string minbid = (artwork.getCell("MerchMinBid", i) == "0" ? "NFS" : "$" + artwork.getCell("MerchMinBid", i));
                              string AAMB = (artwork.getCell("MerchAAMB", i) == "0" ? "NO" : "YES");
                              string QS = (artwork.getCell("MerchQuickSale", i) == "0" ? "NO" : "$" + artwork.getCell("MerchQuickSale", i));


                              template = template.Replace("%PTITLE" + ActualPID.ToString() + "%", artwork.getCell("MerchTitle", i));
                              template = template.Replace("%PMINBID" + ActualPID.ToString() + "%", minbid);
                              template = template.Replace("%PAAMB" + ActualPID.ToString() + "%", AAMB);
                              template = template.Replace("%PQS" + ActualPID.ToString() + "%", QS);
                              template = template.Replace("%PMED" + ActualPID.ToString() + "%", artwork.getCell("MerchMedium", i));

                          }
                          else
                          {
                              template = template.Replace("%PTITLE" + ActualPID.ToString() + "%", "");
                              template = template.Replace("%PMINBID" + ActualPID.ToString() + "%", "");
                              template = template.Replace("%PAAMB" + ActualPID.ToString() + "%", "");
                              template = template.Replace("%PQS" + ActualPID.ToString() + "%", "");
                              template = template.Replace("%PMED" + ActualPID.ToString() + "%", "");


                          }

                          lastPage = currentPage;
                      }



                     

                  }


        }


        private SQLResult getArtistInfo(string ArtistID)
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM `artists` WHERE  `ArtistID`= @ID;", this.SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@ID", ArtistID);

            SQLResult ArtistInfo = this.SQLConnection.Query(query);
            return ArtistInfo;
        }

        private SQLResult getArtistArtwork(string ArtistID)
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM `merchandise` WHERE  `ArtistID`= @ID;", this.SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@ID", ArtistID);

            SQLResult ArtistInfo = this.SQLConnection.Query(query);
            return ArtistInfo;
        }


        private SQLResult getArtistGSArtwork(string ArtistID)
        {
            MySqlCommand query = new MySqlCommand("SELECT * FROM `GSmerchandise` WHERE  `ArtistID`= @ID;", this.SQLConnection.GetConnection());
            query.Prepare();
            query.Parameters.AddWithValue("@ID", ArtistID);

            SQLResult ArtistInfo = this.SQLConnection.Query(query);
            return ArtistInfo;

        }

        private string formatPieceID(string ArtistID, string PieceID)
        {
            string output = formatArtistID(ArtistID);
            output = output + "-";

            int prefixAmt = 3 - (PieceID.Length);
            if (prefixAmt > 0)
            {
                string prefix = new String('0', prefixAmt);
                output = output + prefix + PieceID;
            }
            else
            {
                output = output + PieceID;
            }

            return output;

        }

        private string formatArtistID(string ArtistID)
        {
            int prefixAmt = 3 - (artistID.Length);
            string output = "";
            if (prefixAmt > 0)
            {
                output = new String('0', prefixAmt);
            }
            else
            {
                output = "";
            } 
            output = "AN" + output + artistID;

            return output;
        }

    }
}
