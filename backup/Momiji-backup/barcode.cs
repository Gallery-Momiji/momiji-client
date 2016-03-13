using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Momiji
{
    class barcode
    {
        private string id = "";
        public barcode(string id)
        {
            this.id = id;
        }


        public void generate(){
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "RTF Files (*.rtf)|*.rtf"  ;
            saveFileDialog1.FilterIndex = 1 ;
            saveFileDialog1.RestoreDirectory = true ;
            saveFileDialog1.Title = "Tell me where to save the barcode file!";
            saveFileDialog1.FileName = this.id + ".rtf";
            saveFileDialog1.AddExtension = true;
            //saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Properties.Resources.MyFile
                string output = Properties.Resources.barcode.ToString();

                output = output.Replace("PIECE_ID", id);
               

                try
                {
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, output);

                }
                catch (Exception d)
                {
                    MessageBox.Show("Uh oh! :( I wasn't able to save that file... Your OS had this to say: " + d.Message.ToString(), "EPIC FAILURE!", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);
                }
            }
        }
    }
}
