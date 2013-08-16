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

namespace SrinivasToolkit
{
    public partial class eCanarysPayslipParser : Form
    {
        public eCanarysPayslipParser()
        {
            InitializeComponent();
        }

        private void eCanarysPayslipParser_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
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
                    bool oFlag = oPayslipParser.ParsePayslip(txtPayslipPath.Text);
                }
                else if (Path.GetExtension(txtPayslipPath.Text).ToLower().Equals(".zip"))
                { }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

        void ParsePayslip(string oPayslipPath)
        {

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
