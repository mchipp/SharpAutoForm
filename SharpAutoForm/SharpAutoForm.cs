using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAutoForm
{
    public partial class AutoCenterForm : Form
    {

        private const double _stereoSystemCost = 1500.00;
        private const double _leatherInteriorCost = 2000.00;
        private const double _computerNavigationCost = 1750.00;
        private const double _standardExteriorCost = 1000.00;
        private const double _pearlizedExteriorCost = 1500.00;
        private const double _customDetailiExteriorCost = 2000.00;

        public AutoCenterForm()
        {
            InitializeComponent();
        }

        private void TotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program calculates the amount due on a new or used vehicle." +
                            "\nAuto Centre\nVersion 1.0\n©2016 Mark Chipp\nAll rights reserved.");
        }

        private void StereoSystemCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void LeatherInteriorCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ComputerNavigationCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This button will add up all costs and features, plus tax, less trade-in value.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            double subTotalCost = 0;
            double additionalOptionsCost = 0;
            double salesTaxAmount = 0;
            double totalAmount;
            double tradeInAllowance;
            double amountDue;

            additionalOptionsCost += StereoSystemCheckBox.Checked ? _stereoSystemCost : 0.00 ;
            additionalOptionsCost += LeatherInteriorCheckBox.Checked ? _leatherInteriorCost : 0.00;
            additionalOptionsCost += ComputerNavigationCheckBox.Checked ? _computerNavigationCost : 0.00;

            AdditionalOptionsTextBox.Text = additionalOptionsCost.ToString("C2");

            try
            {
                subTotalCost += Convert.ToDouble(double.Parse(BasePriceTextBox.Text, NumberStyles.Currency)) + additionalOptionsCost;

                subTotalCost += StandardRadioButton.Checked ? _standardExteriorCost : 0.00;
                subTotalCost += PearlizedRadioButton.Checked ? _pearlizedExteriorCost : 0.00;
                subTotalCost += CustomizedDetailingRadioButton.Checked ? _customDetailiExteriorCost : 0.00;

                SubTotalTextBox.Text = subTotalCost.ToString("C2");
                salesTaxAmount = calculateSalesTax(subTotalCost);
                SalesTaxTextBox.Text = salesTaxAmount.ToString("C2");
                totalAmount = (subTotalCost + salesTaxAmount);
                TotalTextBox.Text = totalAmount.ToString("C2");

                tradeInAllowance = Convert.ToDouble(double.Parse(TradeInAllowanceTextBox.Text, NumberStyles.Currency));
                TradeInAllowanceTextBox.Text = tradeInAllowance.ToString("C2");

                amountDue = totalAmount - tradeInAllowance;

                AmountDueTextBox.Text = amountDue.ToString("C2");
            }
            catch (Exception exception)
            {
                MessageBox.Show("Invalid Data Entered", "Input Error");
                Debug.WriteLine(exception.Message);
                //ResetForm();
            }
        }

        private double calculateSalesTax(double subTotal)
        {
            return subTotal * 0.13;
        }
    }
}
