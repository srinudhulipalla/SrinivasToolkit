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
        delegate void DoWork(double oScale);

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
            double oScale = 0;

            double.TryParse(txtScale.Text.Trim(), out oScale);
            //int.TryParse(txtWidth.Text.Trim(), out oWidth);

            if (string.IsNullOrWhiteSpace(txtImagesFolderPath.Text))
            {
                errorProvider1.SetError(btnBrowse, "Images Path can't be blank");
                return;
            }

            if (oScale == 0)
            {
                errorProvider1.SetError(txtScale, "Invalid value");
                return;
            }

            //if (oWidth == 0)
            //{
            //    errorProvider1.SetError(txtWidth, "Invalid Width");
            //    return;
            //}

            DoWork oWork = new DoWork(ChangeImageDimensions);
            progressBar1.BeginInvoke(oWork, oScale);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {            
            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtImagesFolderPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        void ChangeImageDimensions(double oScale)
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
                        //int height = -1, width = -1;
                        oCounter++;

                        string oImageDestination = sDestFolderName + Path.GetFileName(oFile);

                        Image oImage = Image.FromFile(oFile);

                        pictureBox1.Image = oImage;
                        progressBar1.Value = oCounter;
                        lblMessage.Text = string.Format("Image {0}: {1}", oCounter, Path.GetFileName(oFile));
                        Application.DoEvents();

                        //if (oImage.Width > oImage.Height)
                        //{
                        //    width = oWidth;
                        //    height = oHeight;
                        //}
                        //else
                        //{
                        //    width = oHeight;
                        //    height = oWidth;
                        //}

                        //Size oSize = new Size(width, height);

                        //Bitmap oBitmap = new Bitmap(oImage, oSize);
                        //oBitmap.Save(oImageDestination);

                        //using (var image = Image.FromStream(sourcePath))

                        // can given width of image as we want
                        var newWidth = (int)(oImage.Width * ((100 - oScale) / 100));
                        // can given height of image as we want
                        var newHeight = (int)(oImage.Height * ((100 - oScale) / 100));
                        var thumbnailImg = new Bitmap(newWidth, newHeight);
                        var thumbGraph = Graphics.FromImage(thumbnailImg);
                        thumbGraph.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        thumbGraph.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        thumbGraph.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);
                        thumbGraph.DrawImage(oImage, imageRectangle);
                        thumbnailImg.Save(oImageDestination, oImage.RawFormat);

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
