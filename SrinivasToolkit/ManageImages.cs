using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SrinivasToolkit
{
    public partial class ManageImages : Form
    {
        delegate void DoWork(int oHeight, int oWidth);

        public ManageImages()
        {
            InitializeComponent();
        }

        private void ManageImages_Load(object sender, EventArgs e)
        {
            pictureBox1.Visible = progressBar1.Visible = false;            
            lblMessage.Text = string.Empty;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            int oHeight = 0, oWidth = 0;

            int.TryParse(txtHeight.Text.Trim(), out oHeight);
            int.TryParse(txtWidth.Text.Trim(), out oWidth);

            if (string.IsNullOrWhiteSpace(txtImagesFolderPath.Text))
            {
                errorProvider1.SetError(btnBrowse, "Images Path can't be blank");
                return;
            }

            if (oHeight == 0)
            {
                errorProvider1.SetError(txtHeight, "Invalid Height");
                return;
            }

            if (oWidth == 0)
            {
                errorProvider1.SetError(txtWidth, "Invalid Width");
                return;
            }

            DoWork oWork = new DoWork(ChangeImageDimensions);
            progressBar1.BeginInvoke(oWork, oHeight, oWidth);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {            
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtImagesFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        void ChangeImageDimensions(int oHeight, int oWidth)
        {
            try
            {
                pictureBox1.Visible = progressBar1.Visible = true;
                lblMessage.ForeColor = Color.Red;

                string[] oSourceImages = Directory.GetFiles(txtImagesFolderPath.Text);
                int oCounter = 0;
                progressBar1.Minimum = 0;
                progressBar1.Maximum = oSourceImages.Length;
                
                string sDestFolderName = txtImagesFolderPath.Text + "\\" + DateTime.Now.ToString("dd-MMM-yyyy hh-mm tt") + "\\";
                Directory.CreateDirectory(sDestFolderName);
                
                for (int i = 0; i < oSourceImages.Length; i++)
                {
                    string oFile = oSourceImages[i];
                    string extn = Path.GetExtension(oFile).ToLower();

                    if (extn == ".jpg" || extn == ".jpeg" || extn == ".png")
                    {
                        int height = -1, width = -1;
                        oCounter++;

                        string oImageDestination = sDestFolderName + Path.GetFileName(oFile);

                        Image oImage = Image.FromFile(oFile);

                        pictureBox1.Image = oImage;
                        progressBar1.Value = oCounter;
                        lblMessage.Text = string.Format("Image {0}: {1}", oCounter, Path.GetFileName(oFile));                        
                        Application.DoEvents();

                        if (oImage.Width > oImage.Height)
                        {
                            width = oWidth;
                            height = oHeight;
                        }
                        else
                        {
                            width = oHeight;
                            height = oWidth;
                        }

                        Size oSize = new Size(width, height);

                        Bitmap oBitmap = new Bitmap(oImage, oSize);
                        oBitmap.Save(oImageDestination);
                    }
                }

                pictureBox1.Visible = progressBar1.Visible = false;
                lblMessage.Text = "Total number of modified images: " + oCounter;
                lblMessage.ForeColor = Color.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
    }
}
