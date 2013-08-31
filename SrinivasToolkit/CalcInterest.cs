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
    public partial class CalcInterest : Form
    {
        public CalcInterest()
        {
            InitializeComponent();
        }

        private void CalcInterest_Load(object sender, EventArgs e)
        {
            this.Width = 800;
            this.Height = 500;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {

        }
    }
}
