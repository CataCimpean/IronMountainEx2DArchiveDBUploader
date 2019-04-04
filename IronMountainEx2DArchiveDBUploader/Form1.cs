using IronMountainEx2DArchiveDBUploader.Controller;
using IronMountainEx2DArchiveDBUploader.Utils.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IronMountainEx2DArchiveDBUploader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string archivePath { get; set; }
        public string metaDataExtractedPath { get; set; }
        public string delimterMeta { get; set; } = "|";

        public RichTextBox GetRichTextBoxInfo()
        {
            return richTextBox1;
        }

        public Button GetLoadButton()
        {
            return LoadToDatabaseButton;
        }

        private void UploadArchiveButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK)
            {
                archivePath = openFileDialog1.FileName;
                AppController appCtrl = new AppController((Form1)FindForm());
                appCtrl.StartExtractDataFromArchive();

            }
        }

        private void LoadToDatabaseButton_Click(object sender, EventArgs e)
        {
            int x = (Screen.PrimaryScreen.WorkingArea.Width - this.Width +450)/ 2;
            int y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height+200) / 2;
            string response = Microsoft.VisualBasic.Interaction.InputBox("Please select delimter.By default is set to ' |  '", "DelimterOption", delimterMeta, x, y);
            if (response != string.Empty) delimterMeta = response;


            AppController appCtrl = new AppController((Form1)FindForm());
            appCtrl.StartParseMetaDataInfo();

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
