using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CriminalReportingSystem.Forms;

namespace CriminalReportingSystem.Forms
{
    public partial class Dashboard : Form
    {
        public string passedUserRole;

        public Dashboard(string userRole)
        {
            InitializeComponent();
            passedUserRole = userRole;
            //this.userRole = userRole;
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            if (passedUserRole =="Officer")
            {
                btnOfficialsDataMgt.Enabled = false;
                btnReportsMgt.Enabled = false;
                btnRewadsMgt.Enabled = false;
            }
            else
            {
                btnOfficialsDataMgt.Enabled = true;
                btnReportsMgt.Enabled = true;
                btnReportsMgt.Enabled = true;

            }

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOffenderDataMgt_Click(object sender, EventArgs e)
        {
            OffenderDataManagement OffenderDataManagementForm = new OffenderDataManagement(passedUserRole);
            OffenderDataManagementForm.Show();
            this.Hide();
        }

        private void btnCrimeRecords_Click(object sender, EventArgs e)
        {
            CrimeRecords CrimeRecordsForm = new CrimeRecords(passedUserRole);
            CrimeRecordsForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {

            this.Close();

            // Show the login form (LoginForm)
            Form1 loginForm = new Form1();
            loginForm.Show();
        }

        private void btnOfficialsDataMgt_Click(object sender, EventArgs e)
        {
            OfficerDataManagement OffenderDataManagementForm = new OfficerDataManagement(passedUserRole);
            OffenderDataManagementForm.Show();
            this.Hide();
        }

        private void btnRewadsMgt_Click(object sender, EventArgs e)
        {
            CalculateRewards calculateRewardsForm = new CalculateRewards();
            calculateRewardsForm.Show();
            this.Hide();
        }

        private void btnReportsMgt_Click(object sender, EventArgs e)
        {
            CrimeReports crimeReportsForm = new CrimeReports();
            crimeReportsForm.Show();
            this.Hide();
        }
    }
}
