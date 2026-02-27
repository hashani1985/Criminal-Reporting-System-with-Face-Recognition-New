using CriminalReportingSystem.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriminalReportingSystem
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //Application.Run(new OffenderDataManagement());
            //Application.Run(new Dashboard("administrator"));
            //Application.Run(new OffenderDataView());
            //Application.Run(new DisplayCapturedImage());
            //Application.Run(new CrimeReports());
            //Application.Run(new CalculateRewards());
            //Application.Run(new ReportGenerationPage());
        }
    }
}
