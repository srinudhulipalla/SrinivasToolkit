using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Aspose.Pdf;
using System.Text.RegularExpressions;
using Aspose.Pdf.Text;
using System.IO;
using SrinivasToolkit.Business;
using ICSharpCode.SharpZipLib.Zip;

namespace SrinivasToolkit
{
    public partial class eCanarysPayslipParser : Form
    {
        delegate void DoWork();

        public eCanarysPayslipParser()
        {
            InitializeComponent();
        }

        private void eCanarysPayslipParser_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;

            lblMessage.Text = string.Empty;
            progressBar1.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoWork work = new DoWork(dothis);
            progressBar1.BeginInvoke(work);
        }

        void dothis()
        {
            try
            {
                bool oFlag = false;
                string oFailureFiles = string.Empty;

                if (string.IsNullOrWhiteSpace(txtPayslipPath.Text))
                {
                    MessageBox.Show("Please provide the payslip location to above input field.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!File.Exists(txtPayslipPath.Text))
                {
                    MessageBox.Show("Invalid file path.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (Path.GetExtension(txtPayslipPath.Text).ToLower().Equals(".pdf"))
                {
                    eCanarys oPayslipParser = new eCanarys();
                    oFlag = oPayslipParser.ParsePayslip(txtPayslipPath.Text);

                    if (!oFlag) oFailureFiles += Path.GetFileName(txtPayslipPath.Text) + Environment.NewLine;
                }
                else if (Path.GetExtension(txtPayslipPath.Text).ToLower().Equals(".zip"))
                {
                    progressBar1.Visible = true;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    string oTargetPath = Path.GetTempPath() + Guid.NewGuid().ToString();
                    FastZip oZip = new FastZip();
                    oZip.ExtractZip(txtPayslipPath.Text, oTargetPath, "");

                    if (Directory.Exists(oTargetPath))
                    {
                        eCanarys oPayslipParser = new eCanarys();
                        string[] oPdfFiles = Directory.GetFiles(oTargetPath);
                        progressBar1.Minimum = 0;
                        progressBar1.Maximum = oPdfFiles.Length;

                        for (int i = 0; i < oPdfFiles.Length; i++)
                        {
                            string oPdfFile = oPdfFiles[i];
                            
                            progressBar1.Value = i + 1;
                            lblMessage.Text = string.Format("Payslip {0}: {1}", i + 1, Path.GetFileName(oPdfFile));
                            Application.DoEvents();

                            oFlag = oPayslipParser.ParsePayslip(oPdfFile);

                            if (!oFlag) oFailureFiles += Path.GetFileName(oPdfFile) + Environment.NewLine;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Not a valid file path extension.", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrEmpty(oFailureFiles))
                {
                    lblMessage.Text = "All file(s) are successfully imported into the system.";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    lblMessage.Text = "The following file(s) are failed to process:" + Environment.NewLine + oFailureFiles;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }

                progressBar1.Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openPayslipFile.ShowDialog();
            txtPayslipPath.Text = openPayslipFile.FileName;            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }
    }
}
