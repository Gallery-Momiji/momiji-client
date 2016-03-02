using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Momiji
{
    class biddingsheet
    {
        private bool mass = false;
        private string ArtistID = "";
        private string PieceID = "";
        private string PieceTitle = "";
        private string PieceMedium = "";
        private string PieceMinBid = "";
        private string PieceQuickSale = "";
        private string PieceAAMB = "";
        private string ArtistName = "";

        private SQL Connection;
        private SQLResult UserID;

        public biddingsheet(string ArtistID,SQL Connection, SQLResult UserID )
        {
            this.ArtistID = ArtistID;
            this.Connection = Connection;
            this.UserID = UserID;
            this.mass = true;
        }

        public biddingsheet(string ArtistID, string PieceID, string PieceTitle, string PieceMedium, string PieceMinBid, 
            string PieceQuickSale, string PieceAAMB, string ArtistName, SQL Connection, SQLResult UserID)
        {
            this.ArtistID = ArtistID;
            this.ArtistName = ArtistName;
            this.PieceID = PieceID;
            this.PieceTitle = PieceTitle;
            this.PieceMedium = PieceMedium;
            this.PieceMinBid = PieceMinBid;
            this.PieceQuickSale = PieceQuickSale;
            this.PieceAAMB = PieceAAMB;

            this.Connection = Connection;
            this.UserID = UserID;
            
            this.mass = false;
        }


        public void process()
        {

            if (this.mass)
            {
                FolderBrowserDialog folder = new FolderBrowserDialog();
                folder.Description = "Choose a folder where I can dump all these Bidding sheets...";
                if (folder.ShowDialog() == DialogResult.OK)
                {
                    frmProcessing progress = new frmProcessing();
                    progress.Show();
                    progress.label1.Text = "Grabbing Artist Info..";

                    MySqlCommand query = new MySqlCommand("SELECT * FROM `artists` WHERE  `ArtistID`= @ID;", this.Connection.GetConnection());
                    query.Prepare();
                    query.Parameters.AddWithValue("@ID", this.ArtistID);

                    SQLResult ArtistInfo =  this.Connection.Query(query);
                    this.Connection.LogAction("Grabbed info from artist #" + this.ArtistID, this.UserID);

                    MySqlCommand merch = new MySqlCommand("SELECT * FROM `merchandise` WHERE `ArtistID` = @ID;", this.Connection.GetConnection());
                    merch.Prepare();
                    merch.Parameters.AddWithValue("@ID", this.ArtistID);

                    SQLResult artistMerch = this.Connection.Query(merch);
                    if (artistMerch.GetNumberOfRows() == 0)
                    {
                        MessageBox.Show("I don't think this artist has anything...", "He ain't got the stuff..", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        string filename = "";
                        progress.label1.Text = "Got the info, Creating files...";
                        int i = 0;
                        for (i = 0; i < artistMerch.GetNumberOfRows(); i++)
                        {
                            filename = "";
                            
                            filename = folder.SelectedPath;

                            progress.label1.Text = "Processing... " + i.ToString() + "/" + artistMerch.GetNumberOfRows().ToString();
                            progress.progressBar1.Value = (int)((i * 100) / artistMerch.GetNumberOfRows());
                            
                            filename = filename + "/" + formatItemCode("AN",artistMerch.getCell("ArtistID",i),artistMerch.getCell("MerchID",i)) + ".rtf";
                             
                            


                            string output = Properties.Resources.bid_sheet.ToString();

                            output = output.Replace("PIECE_ID", formatItemCode("AN", artistMerch.getCell("ArtistID", i), artistMerch.getCell("MerchID",i)));
                            output = output.Replace("ARTIST_ID", ArtistInfo.getCell("ArtistName",0));
                            output = output.Replace("PIECE_TITLE", artistMerch.getCell("MerchTitle",i) );
                            output = output.Replace("PIECE_MEDIUM", artistMerch.getCell("MerchMedium", i));
                            output = output.Replace("PIECE_MINBID", "$" + artistMerch.getCell("MerchMinBid", i));
                            output = output.Replace("PIECE_QS", (artistMerch.getCell("MerchQuickSale", i) == "0" ? "N/A" : "$" + artistMerch.getCell("MerchQuickSale", i)));
                            output = output.Replace("PIECE_MS",  (artistMerch.getCell("MerchAAMB", i) == "0" ? "NO" : "YES"));
                            //output = output.Replace("PIECE_ID", "AN0" + lblArtistID.Text + "-" + txtPieceID.Text);

                            try
                            {
                                System.IO.File.WriteAllText(filename, output);

                            }
                            catch (Exception d)
                            {
                                MessageBox.Show("Uh oh! :( I wasn't able to save that file... Your OS had this to say: " + d.Message.ToString(), "EPIC FAILURE!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                            }
                        
        
                        }

                        progress.Dispose();
                        MessageBox.Show("Done! :D");
                    }

                }
            }
            else
            {
                //Stream myStream ;
                  SaveFileDialog saveFileDialog1 = new SaveFileDialog();

                  saveFileDialog1.Filter = "RTF Files (*.rtf)|*.rtf"  ;
                  saveFileDialog1.FilterIndex = 1 ;
                  saveFileDialog1.RestoreDirectory = true ;
                  saveFileDialog1.Title = "Tell me where to save the Bidding sheet!";
                  saveFileDialog1.FileName = formatItemCode("AN", this.ArtistID, this.PieceID) + ".rtf";
                  saveFileDialog1.AddExtension = true;
                  //saveFileDialog1.CheckFileExists = true;
                  saveFileDialog1.CheckPathExists = true;

                  if(saveFileDialog1.ShowDialog() == DialogResult.OK)
                  {
                      //Properties.Resources.MyFile
                      string output = Properties.Resources.bid_sheet.ToString();
   
                      output = output.Replace("PIECE_ID", formatItemCode("AN", this.ArtistID, this.PieceID));
                      output = output.Replace("ARTIST_ID", this.ArtistName);
                      output = output.Replace("PIECE_TITLE", this.PieceTitle);
                      output = output.Replace("PIECE_MEDIUM", this.PieceMedium);
                      output = output.Replace("PIECE_MINBID", "$" + this.PieceMinBid);
                      output = output.Replace("PIECE_QS", (this.PieceQuickSale == "0" ? "N/A" : "$" + this.PieceQuickSale.ToString()));
                      output = output.Replace("PIECE_MS", (this.PieceAAMB == "1" ? "YES" : "NO" ));
                      //output = output.Replace("PIECE_ID", "AN0" + lblArtistID.Text + "-" + txtPieceID.Text);

                      try
                      {
                          System.IO.File.WriteAllText(saveFileDialog1.FileName, output);

                      }
                      catch (Exception d)
                      {
                           MessageBox.Show("Uh oh! :( I wasn't able to save that file... Your OS had this to say: " + d.Message.ToString(), "EPIC FAILURE!",  MessageBoxButtons.RetryCancel,MessageBoxIcon.Error);
                      }
               
               
                  }


            }
        }

        private string formatItemCode(string prefix, string artistID, string itemID)
        {
            string output = "";
            int AIDZeros = 3 - artistID.Length;
            int IIDZeros = 3 - itemID.Length;

            if (AIDZeros > 0)
            {
                string AIDPREFIX = new String('0', AIDZeros);
                output = prefix + AIDPREFIX + artistID;
            }
            else
            {
                output = prefix + artistID;
            }

            if (IIDZeros > 0)
            {
                string IIDPREFIX = new String('0', IIDZeros);
                output = output + "-" + IIDPREFIX + itemID;

            }
            else
            {
                output = output + "-" + itemID;
            }

            return output;
        }




    }
}
