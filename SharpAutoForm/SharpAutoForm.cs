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
    /// <summary>
    /// This is the class for the AutoCenterForm.cs
    /// </summary>
    public partial class AutoCenterForm : Form
    {
        // private variables
        private const double _stereoSystemCost = 1500.00;
        private const double _leatherInteriorCost = 2000.00;
        private const double _computerNavigationCost = 1750.00;
        private const double _standardExteriorCost = 1000.00;
        private const double _pearlizedExteriorCost = 1500.00;
        private const double _customDetailiExteriorCost = 2000.00;
        private double _additionalCosts = 1000.00;

        public AutoCenterForm()
        {
            InitializeComponent();
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }


        // ++++++++++++EVENT HANDLERS++++++++++++
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This program calculates the amount due on a new or used vehicle." +
                            "\nAuto Centre\nVersion 1.0\n©2016 Mark Chipp\nAll rights reserved.");
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void StereoSystemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _additionalCosts += StereoSystemCheckBox.Checked ? _stereoSystemCost : -_stereoSystemCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void LeatherInteriorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _additionalCosts += LeatherInteriorCheckBox.Checked ? _leatherInteriorCost : -_leatherInteriorCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void ComputerNavigationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _additionalCosts += ComputerNavigationCheckBox.Checked ? _computerNavigationCost : -_computerNavigationCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void StandardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _additionalCosts += StandardRadioButton.Checked ? _standardExteriorCost : -_standardExteriorCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void PearlizedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _additionalCosts += PearlizedRadioButton.Checked ? _pearlizedExteriorCost : -_pearlizedExteriorCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void CustomizedDetailingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            _additionalCosts += CustomizedDetailingRadioButton.Checked ? _customDetailiExteriorCost : -_customDetailiExteriorCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calculate();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        //++++++++++++++++++FUNCTIONS++++++++++++++++++
        private void Calculate()
        {
            try
            {
                double subTotalCost = Convert.ToDouble(double.Parse(BasePriceTextBox.Text, NumberStyles.Currency));
                double additionalItems = Convert.ToDouble(double.Parse(AdditionalOptionsTextBox.Text, NumberStyles.Currency));
                double salesTaxAmount = 0;
                double totalAmount;
                double tradeInAllowance;
                double amountDue;

                BasePriceTextBox.Text = subTotalCost.ToString("C2");

                subTotalCost += additionalItems;

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
                ClearForm();
            }
        }

        private double calculateSalesTax(double subTotal)
        {
            return subTotal * 0.13;
        }

        private void ClearForm()
        {
            BasePriceTextBox.Text = "$0.00";
            BasePriceTextBox.Focus();
            BasePriceTextBox.SelectAll();
            SubTotalTextBox.Clear();
            SalesTaxTextBox.Clear();
            TotalTextBox.Clear();
            TradeInAllowanceTextBox.Text = "0";
            AmountDueTextBox.Clear();
            StereoSystemCheckBox.Checked = false;
            LeatherInteriorCheckBox.Checked = false;
            ComputerNavigationCheckBox.Checked = false;
            StandardRadioButton.Checked = true;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private static void ExitApplication()
        {
            Application.Exit();
        }
    }
}
