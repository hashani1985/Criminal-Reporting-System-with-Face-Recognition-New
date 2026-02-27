using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CriminalReportingSystem.Forms
{
    public partial class CrimeReports : Form
    {
        public string connectionString = "Data Source=DESKTOP-BU7QFI6\\SQLEXPRESS;Initial Catalog=CriminalReportingDB; Integrated Security=True";
        private SqlConnection sqlConnection;
        private SqlDataAdapter specialtyDataAdapter;
        private SqlDataAdapter doctorDataAdapter;
        private SqlDataAdapter scheduleDataAdapter;
        private DataSet dataSet;
        public string passedUserRole;
        public CrimeReports()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ChangeLabelBgColor();
        }

        private void CrimeReports_Load(object sender, EventArgs e)
        {
            LoadData();
            LoadGenderData();
            LoadOfficersData();
        }

        private void LoadData()
        {
            
            string query = "SELECT CrimeType, SUM(Amount) AS TotalAmount FROM CrimeRecords GROUP BY CrimeType";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing data in the chart
                        chart1.Series.Clear();

                        // Create a new series for the chart
                        Series series = new Series("TotalAmountSeries");
                        series.ChartType = SeriesChartType.Column;

                        // Populate the series with data from the database
                        while (reader.Read())
                        {
                            string crimeType = reader["CrimeType"].ToString();
                            int totalAmount = Convert.ToInt32(reader["TotalAmount"]);

                            series.Points.AddXY(crimeType, totalAmount);
                        }

                        // Add the series to the chart
                        chart1.Series.Add(series);
                    }
                }
            }
        }

        //  ---------------chart for officers 

        private void LoadGenderData()
        {
           
            string query = "SELECT Gender, COUNT(*) AS TotalCrimes FROM Offenders GROUP BY Gender";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing data in the chart
                        chartOfficers.Series.Clear();

                        // Create a new series for the chart
                        Series series = new Series("TotalCrimesSeries");
                        series.ChartType = SeriesChartType.Pie; // You can change the chart type as needed

                        // Populate the series with data from the database
                        while (reader.Read())
                        {
                            string gender = reader["Gender"].ToString();
                            int totalCrimes = Convert.ToInt32(reader["TotalCrimes"]);

                            // Add a point for each gender with its corresponding total crimes
                            DataPoint point = new DataPoint();
                            point.SetValueXY(gender, totalCrimes);

                            // Display the amount on the chart
                            point.Label = totalCrimes.ToString();
                            point.IsValueShownAsLabel = true;

                            // Set the legend text as the gender type name
                            point.LegendText = gender;

                            series.Points.Add(point);
                        }

                        // Add the series to the chart
                        chartOfficers.Series.Add(series);
                    }
                }
            }
        }


        // --function to change label colors
        public void ChangeLabelBgColor()
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;


        }
        private void LoadOfficersData()
        {
            
            string query = "SELECT Designation, COUNT(*) AS NumberOfOfficers FROM Officers GROUP BY Designation";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Clear existing data in the chart
                        chartOfficersType.Series.Clear();

                        // Create a new series for the chart
                        Series series = new Series("NumberOfOfficersSeries");
                        series.ChartType = SeriesChartType.Column; // You can change the chart type as needed

                        // Populate the series with data from the database
                        while (reader.Read())
                        {
                            string designation = reader["Designation"].ToString();
                            int numberOfOfficers = Convert.ToInt32(reader["NumberOfOfficers"]);

                            // Add a point for each designation with its corresponding number of officers
                            series.Points.AddXY(designation, numberOfOfficers);
                        }

                        // Add the series to the chart
                        chartOfficersType.Series.Add(series);
                    }
                }
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Dashboard dashboardForm = new Dashboard(passedUserRole);
            dashboardForm.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();

            // Show the login form (LoginForm)
            Form1 loginForm = new Form1();
            loginForm.Show();
        }
    }
}
