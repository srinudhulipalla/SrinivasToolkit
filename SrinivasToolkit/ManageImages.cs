using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            string sDestFolderName = txtImagesFolderPath.Text + "\\" + DateTime.Now.ToString("dd-MMM-yyyy hh-mm tt") + "\\";

            Directory.CreateDirectory(sDestFolderName);

            try
            {
                foreach (string file in Directory.GetFiles(txtImagesFolderPath.Text))
                {
                    string extn = System.IO.Path.GetExtension(file).ToLower();

                    if (extn == ".jpg" || extn == "jpeg" || extn == "png")
                    {
                        string width = string.Empty;
                        string height = string.Empty;

                        string sImgDestPath = sDestFolderName + System.IO.Path.GetFileName(file);

                        System.Drawing.Image image = System.Drawing.Image.FromFile(file);

                        if (image.Width > image.Height)
                        {
                            width = txtWidth.Text;
                            height = txtHeight.Text;
                        }
                        else
                        {
                            width = txtHeight.Text;
                            height = txtWidth.Text;
                        }

                        System.Drawing.Size size = new System.Drawing.Size(int.Parse(width), int.Parse(height));

                        Bitmap bitmap = new Bitmap(image, size);
                        bitmap.Save(sImgDestPath, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                }

                //MessageBox.Show("All resized images are copies to " + sDestFolderName, "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        

        
    }
}
