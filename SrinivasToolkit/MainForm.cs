using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SrinivasToolkit
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 1000;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCanarysPayslip_Click(object sender, EventArgs e)
        {            
            eCanarysPayslipParser parser = new eCanarysPayslipParser();            
            parser.ShowDialog();            
        }
    }
}
