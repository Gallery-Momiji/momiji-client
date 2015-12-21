using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Momiji
{
    class GScontrolsheet
    {
        private string artistID;
        private SQL SQLConnection;
        private SQLResult User;

        public GScontrolsheet(string artistID, SQL Link, SQLResult UserIdentifier)
        {
            this.artistID = artistID;
            this.SQLConnection = Link;
            this.User = UserIdentifier;
        }


        private string fillArtistInfo(SQLResult artistInfo, int totalItems )
        {
            string template = Properties.Resources.GScontrolsheet.ToString();
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


            template = template.Replace("%NP%", totalItems.ToString());
            template = template.Replace("%NI%", totalItems.ToString());
            template = template.Replace("%TI%", totalItems.ToString());
            template = template.Replace("%ACP%", artistInfo.getCell("ArtistAPP", 0));
            
            return template;

        }

        public void generate(){
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                  saveFileDialog1.Filter = "RTF Files (*.rtf)|*.rtf"  ;
                  saveFileDialog1.FilterIndex = 1 ;
                  saveFileDialog1.RestoreDirectory = true ;
                  saveFileDialog1.Title = "Tell me where to save the control sheet!";
                  saveFileDialog1.FileName = "PN" + this.artistID;
                  
                  //saveFileDialog1.CheckFileExists = true;
                  saveFileDialog1.CheckPathExists = true;

                  if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                  {

                      
                      

                      SQLResult artistInfo = this.getArtistInfo(this.artistID);
                      SQLResult artwork = this.getArtistGSArtwork(this.artistID);

                      
                      string template = fillArtistInfo(artistInfo, artwork.GetNumberOfRows());
                      int i = 0;

                      int limit = 0;
                      if (artwork.GetNumberOfRows() <= 15)
                      {
                          limit = 15;
                      }
                      else
                      {
                          limit = (15 -(artwork.GetNumberOfRows() % 15)) + artwork.GetNumberOfRows() ;
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
                          currentPage = (int)(i / 15);
                          ActualPID = (i % 15) + 1;

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
                             
                              template = template.Replace("%PTITLE" + ActualPID.ToString() + "%", artwork.getCell("PieceTitle", i));
                              template = template.Replace("%PRICE" + ActualPID.ToString() + "%", "$" + artwork.getCell("PiecePrice", i));
                              template = template.Replace("%PQUAN" + ActualPID.ToString() + "%", artwork.getCell("PieceInitialStock", i));
                              template = template.Replace("%PSDC" + ActualPID.ToString() + "%", (artwork.getCell("MerchTitle", i) == "True" ? "YES" : "NO" ));

                          }
                          else
                          {
                              template = template.Replace("%PTITLE" + ActualPID.ToString() + "%", "");
                              template = template.Replace("%PRICE" + ActualPID.ToString() + "%", "");
                              template = template.Replace("%PQUAN" + ActualPID.ToString() + "%", "");
                              template = template.Replace("%PSDC" + ActualPID.ToString() + "%", "");
                             


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
            output = "PN" + output + artistID;

            return output;
        }

    }
}
