///Application: Auto Centre Form for COMP1004 Assignment 2
///Author: Mark Chipp
///Student ID: 200180985
///Created on: 06-Oct-2016
///Last edited: 14-Oct-2016
///This program calculates the amount due on a new or used vehicle based on varoius accessories
///and options, and trade-in value (if applicable).
///This file is the main driver which starts the application.

using SplashScreen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharpAutoForm
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SplashScreenForm());
        }
    }
}
