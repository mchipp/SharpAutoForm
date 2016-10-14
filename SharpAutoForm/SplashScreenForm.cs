///Application: Auto Centre Form for COMP1004 Assignment 2
///Author: Mark Chipp
///Student ID: 200180985
///Created on: 06-Oct-2016
///Last edited: 14-Oct-2016
///This program calculates the amount due on a new or used vehicle based on varoius accessories
///and options, and trade-in value (if applicable).
///This file loads the splash screenn.


using SharpAutoForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SplashScreen
{
    public partial class SplashScreenForm : Form
    {
        /// <summary>
        /// This is the intialization point for the splash screen.
        /// </summary>
        public SplashScreenForm()
        {
            InitializeComponent();
        }

        private void SplashScreenTimer_Tick(object sender, EventArgs e)
        {
            SplashScreenTimer.Enabled = false;

            // lines 26-27 can be uncommented when SplashScreenForm.cs is
            // added to a project with a form to proceed to
            AutoCenterForm startForm = new AutoCenterForm();
            startForm.Show();
            this.Hide();
        }
    }
}
