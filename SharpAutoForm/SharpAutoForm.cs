///Application: Auto Centre Form for COMP1004 Assignment 2
///Author: Mark Chipp
///Student ID: 200180985
///Created on: 06-Oct-2016
///Last edited: 14-Oct-2016
///This program calculates the amount due on a new or used vehicle based on varoius accessories
///and options, and trade-in value (if applicable).
///This file is the bulk of the program, holding variables to calculate, and performing
///calculation functions.

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

            // set initial additional costs text to match initial value
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
            // call Calculate() function
            Calculate();
        }

        private void StereoSystemCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the Stere option button is checked or unchecked, add or subtract stereo value from additional costs value
            _additionalCosts += StereoSystemCheckBox.Checked ? _stereoSystemCost : -_stereoSystemCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void LeatherInteriorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the leather interior option button is checked or unchecked, add or subtract leather interior value from additional costs value
            _additionalCosts += LeatherInteriorCheckBox.Checked ? _leatherInteriorCost : -_leatherInteriorCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void ComputerNavigationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the computer navigation option button is checked or unchecked, add or subtract computer navigation value from additional costs value
            _additionalCosts += ComputerNavigationCheckBox.Checked ? _computerNavigationCost : -_computerNavigationCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void StandardRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // If the standard exterior button is checked or unchecked, add or subtract value from additional costs value
            _additionalCosts += StandardRadioButton.Checked ? _standardExteriorCost : -_standardExteriorCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void PearlizedRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // If the pearlized exterior button is checked or unchecked, add or subtract value from additional costs value
            _additionalCosts += PearlizedRadioButton.Checked ? _pearlizedExteriorCost : -_pearlizedExteriorCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void CustomizedDetailingRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            // If the custom exterior button is checked or unchecked, add or subtract value from additional costs value
            _additionalCosts += CustomizedDetailingRadioButton.Checked ? _customDetailiExteriorCost : -_customDetailiExteriorCost;
            AdditionalOptionsTextBox.Text = _additionalCosts.ToString("C2");
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            // call ClearForm() function
            ClearForm();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call ClearForm() function
            ClearForm();
        }

        private void calculateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call ClearForm() function
            Calculate();
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            // call ExitApplication() function
            ExitApplication();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // call ExitApplication() function
            ExitApplication();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this should allow user to change the font of the base cost and amount due text boxes
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = BasePriceTextBox.Font;

            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                BasePriceTextBox.Font = fontDialog.Font;
                AmountDueTextBox.Font = fontDialog.Font;
            }
        }

        private void colourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this should allow user to change the colour of the base cost and amount due text boxes
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = BasePriceTextBox.BackColor;

            if (colorDialog.ShowDialog() != DialogResult.Cancel)
            {
                BasePriceTextBox.BackColor = colorDialog.Color;
                AmountDueTextBox.BackColor = colorDialog.Color;
            }
        }

        //++++++++++++++++++FUNCTIONS++++++++++++++++++
        /// <summary>
        /// This function will add the values of the various text fields to find the total amount owing
        /// </summary>
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

                // set the base cost text box to a currency formatted string
                BasePriceTextBox.Text = subTotalCost.ToString("C2");

                // add additional options to the sub total
                subTotalCost += additionalItems;

                // set the sub total text box to a currency formatted string
                SubTotalTextBox.Text = subTotalCost.ToString("C2");

                // calculate sales tax and set the sales tax text box to a currency formatted string
                salesTaxAmount = calculateSalesTax(subTotalCost);
                SalesTaxTextBox.Text = salesTaxAmount.ToString("C2");

                // calculate total amount and set total amount text box to a currency formatted string
                totalAmount = (subTotalCost + salesTaxAmount);
                TotalTextBox.Text = totalAmount.ToString("C2");

                // set trade in allowance to double format of trade in allowance text box
                tradeInAllowance = Convert.ToDouble(double.Parse(TradeInAllowanceTextBox.Text, NumberStyles.Currency));

                // set the trade in allowance text box to a currency formatted string
                TradeInAllowanceTextBox.Text = tradeInAllowance.ToString("C2");

                // calculate the amount due and set the amount due text box to a currency formatted string
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

        /// <summary>
        /// This function calculates the sales tax
        /// </summary>
        /// <param name="subTotal"></param>
        /// <returns></returns>
        private double calculateSalesTax(double subTotal)
        {
            return subTotal * 0.13;
        }

        /// <summary>
        /// This function will clear the entire form and allow the user to start over
        /// </summary>
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

            // Ensure base cost and amount due boxes font and colour match the rest
            BasePriceTextBox.Font = SubTotalTextBox.Font;
            AmountDueTextBox.Font = SubTotalTextBox.Font;
            BasePriceTextBox.BackColor = SubTotalTextBox.BackColor;
            AmountDueTextBox.BackColor = SubTotalTextBox.BackColor;
        }

        /// <summary>
        /// This function exits the application
        /// </summary>
        private static void ExitApplication()
        {
            Application.Exit();
        }
    }
}
