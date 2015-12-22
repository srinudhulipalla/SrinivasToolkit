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

            dtStart.Value = dtEnd.Value.AddMonths(-1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (!IsFormValid()) return; 
        }

        bool IsFormValid()
        {
            if (dtStart.Value >= dtEnd.Value)
            {
                errorProvider1.SetError(dtEnd, "Either Start and End dates can't be equal or Start date can't be greater than End date.");
                return false;
            }

            double tempAmt = 0;
            double.TryParse(txtInvestAmt.Text.Trim(), out tempAmt);
            if (tempAmt == 0)
            {
                errorProvider1.SetError(txtInvestAmt, "Invested amount has invalid data");
                return false;
            }

            tempAmt = 0;
            double.TryParse(txtInterestRate.Text.Trim(), out tempAmt);
            if (tempAmt == 0)
            {
                errorProvider1.SetError(rbPercent, "Interest rate has invalid data");
                return false;
            }
            if (tempAmt > 100 && rbPercent.Checked)
            {
                errorProvider1.SetError(rbPercent, "percentage value can't exceed 100");
                return false;
            }

            tempAmt = 0;
            double.TryParse(txtTax.Text.Trim(), out tempAmt);
            if (tempAmt == 0)
            {
                errorProvider1.SetError(txtTax, "Tax value has invalid data");
                return false;
            }
            if (tempAmt > 100)
            {
                errorProvider1.SetError(txtTax, "Tax percentage can't exceed 100");
                return false;
            }
            
            return true;
        }
    }
}
