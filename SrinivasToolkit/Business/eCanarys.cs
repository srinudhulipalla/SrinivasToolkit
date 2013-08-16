using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Aspose.Pdf;
using Aspose.Pdf.Text;

namespace SrinivasToolkit.Business
{
    public class eCanarys
    {
        public bool ParsePayslip(string oPayslipPath)
        {
            string oDelimiter = "   ";
            int index = 1;
            double oTotalCredit = 0, oTotalDebit = 0, oGrossPayment = 0, oNetPayment = 0;
            DataAccess oDA = new DataAccess();

            Aspose.Pdf.License lic = new Aspose.Pdf.License();
            lic.SetLicense("License.lic");

            Document oPayslipDoc = new Document(oPayslipPath);

            TextAbsorber oPayslipExtracter = new TextAbsorber();
            oPayslipDoc.Pages.Accept(oPayslipExtracter);

            //extract data from pay-slip
            string[] oPayRecords = oPayslipExtracter.Text.Split('\n');

            //get company name
            string oCompanyName = oPayRecords[0].Trim();

            //get company address
            string oCompanyAddress = oPayRecords[1].Trim();

            //get payment month and year
            string[] oPayMonthYear = oPayRecords[2].Trim().Split('/');
            string oPaymentMonth = oPayMonthYear[0].Substring(oPayMonthYear[0].Length - 3);
            int oPaymentYear = int.Parse(oPayMonthYear[1]);

            //get payroll number and employee name
            string[] oTemp = Regex.Split(oPayRecords[3].Trim(), oDelimiter);
            int oPayrollNumber = -1;
            string oEmployeeName = string.Empty;

            foreach (string val in oTemp)
            {
                if (string.IsNullOrWhiteSpace(val)) continue;

                if (index == 1 || index == 3)
                {
                    index++;
                    continue;
                }

                if (index == 2) oPayrollNumber = int.Parse(val.Trim());
                if (index == 4) oEmployeeName = val.Trim();

                index++;
            }

            //get designation and department
            oTemp = Regex.Split(oPayRecords[4].Trim(), oDelimiter);
            string oDesignation = string.Empty, oDepartment = string.Empty;
            index = 1;

            foreach (string val in oTemp)
            {
                if (string.IsNullOrWhiteSpace(val)) continue;

                if (index == 1 || index == 3)
                {
                    index++;
                    continue;
                }

                if (index == 2) oDesignation = val.Trim();
                if (index == 4) oDepartment = val.Trim();

                index++;
            }

            //get bank account number and remarks
            oTemp = Regex.Split(oPayRecords[5].Trim(), oDelimiter);
            long oAccountNumber = -1;
            string oRemarks = string.Empty;
            index = 1;

            foreach (string val in oTemp)
            {
                if (string.IsNullOrWhiteSpace(val)) continue;

                if (index == 1 || index == 3)
                {
                    index++;
                    continue;
                }

                if (index == 2) oAccountNumber = long.Parse(val.Trim());
                if (index == 4) oRemarks = val.Trim();

                index++;
            }

            //remove existing records
            string oSQL = string.Format("DELETE FROM eCanarysPayslip WHERE PaymentMonth='{0}' AND PaymentYear={1}", oPaymentMonth, oPaymentYear);
            bool oFlag = oDA.ExecuteQuery(oSQL);
            if (!oFlag) return false;

            //get credit and debit payments
            string oCreditType = string.Empty;
            double oCreditedAmount = 0;
            string oDebitType = string.Empty;
            double oDebitedAmount = 0;

            for (int i = 8; i < oPayRecords.Length; i++)
            {
                if (string.IsNullOrWhiteSpace(oPayRecords[i])) continue;

                oTemp = Regex.Split(oPayRecords[i].Trim(), oDelimiter);
                if (oTemp[0].Equals("Total")) break;

                index = 1;
                oCreditType = string.Empty;
                oCreditedAmount = 0;
                oDebitType = string.Empty;
                oDebitedAmount = 0;

                foreach (string val in oTemp)
                {
                    if (string.IsNullOrWhiteSpace(val)) continue;

                    if (index == 1) oCreditType = val.Trim();

                    if (index == 2) oCreditedAmount = double.Parse(val.Trim());

                    if (index == 3) oDebitType = val.Trim();

                    if (index == 4) oDebitedAmount = double.Parse(val.Trim());

                    index++;
                }

                oTotalCredit += oCreditedAmount;
                oTotalDebit += oDebitedAmount;

                //insert payment records
                oSQL = "INSERT INTO eCanarysPayslip VALUES('{0}','{1}','{2}','{3}',{4},{5},'{6}','{7}','{8}',{9},'{10}','{11}',{12},'{13}',{14})";
                oSQL = string.Format(oSQL, Guid.NewGuid().ToString(), oCompanyName, oCompanyAddress, oPaymentMonth, oPaymentYear, oPayrollNumber, oEmployeeName, oDesignation, oDepartment, oAccountNumber, oRemarks, oCreditType, oCreditedAmount, oDebitType, oDebitedAmount);
                oFlag = oDA.ExecuteQuery(oSQL);
            }

            //calc gross and net payment
            oGrossPayment = oTotalCredit + oTotalDebit;
            oNetPayment = oTotalCredit - oTotalDebit;

            return oFlag;
        }
    }
}
