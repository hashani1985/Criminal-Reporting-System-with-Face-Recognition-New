using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using iText.Commons;
using System.IO;
using iText.Commons.Utils;
using iTextSharp.text;
using iTextSharp;
using iTextSharp.text.pdf;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using LicenseContext = System.ComponentModel.LicenseContext;


//using iText.Kernel.Pdf;
//using iText.Layout;
//using iText.Layout.Element;


namespace CriminalReportingSystem.Forms
{

    public partial class ReportGenerationPage : Form
    {

        public string connectionString = "Data Source=DESKTOP-BU7QFI6\\SQLEXPRESS;Initial Catalog=CriminalReportingDB; Integrated Security=True";
        private SqlConnection sqlConnection;

        private DataSet dataSet;
        private DataSet myDataSet; // Assuming you have a DataSet
        private DataTable myDataTable;

        public ReportGenerationPage()
        {
            InitializeComponent();
        }

        private void ReportGenerationPage_Load(object sender, EventArgs e)
        {
            LoadOfficerNames();
            
        }

        //------------ load officer names---------------------
        public void LoadOfficerNames()
        {
            // Clear existing items in the ComboBox
            cmbOfficerName.Items.Clear();

            // Create a new SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Name FROM Officers";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    // Assuming your ComboBox is named comboBox1
                    cmbOfficerName.DisplayMember = "Name";
                    cmbOfficerName.ValueMember = "Name"; // You can set this to a different column if needed
                    cmbOfficerName.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        //---------------- recieve rewads for officer-------

        private DataTable GetCrimeRecordsForOfficer(string officer1Id)
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM CrimeRecords WHERE Officer1Id = @Officer1Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Officer1Id", officer1Id);

                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(dataTable);
                }
            }

            return dataTable;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            ReportGen();

        }

        public void ReportGen()
        {
            // Connection string for your SQL Server database
            //string connectionString = "your_connection_string_here";

            // SQL query to fetch data
            //ExcelPackage.LicenseContext = LicenseContext.NonCommercial; 
            

            // Create and run your main form or application
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            string sqlQuery = "SELECT OfficerId, Name,DOB FROM Officers";



            // Create a new Excel package
            using (var package = new ExcelPackage())
            {
                // Add a new worksheet
                var worksheet = package.Workbook.Worksheets.Add("Report");

                // Set cell values for headers
                worksheet.Cells["A1"].Value = "OfficerId";
                worksheet.Cells["B1"].Value = "Name";
                worksheet.Cells["C1"].Value = "DOB";

                // Connect to the database and fetch data
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            int row = 2; // Start writing data from row 2
                            while (reader.Read())
                            {
                                worksheet.Cells[$"A{row}"].Value = reader["OfficerId"];
                                worksheet.Cells[$"B{row}"].Value = reader["Name"];
                                worksheet.Cells[$"C{row}"].Value = reader["DOB"];
                                row++;
                            }
                        }
                    }
                }

                // Apply some formatting
                worksheet.Cells["A1:C1"].Style.Font.Bold = true;

                // Save the Excel package to a file
                var fileInfo = new FileInfo("ExcelReportWithData.xlsx");
                package.SaveAs(fileInfo);

                Console.WriteLine($"Excel report with data created: {fileInfo.FullName}");
            }
        }

            //private string GeneratePDF(DataTable dtCrimeRecords, DataTable dtRewards)
            //{
            //    string pdfFilePath = $"Report_{DateTime.Now:yyyyMMddHHmmss}.pdf";

            //    using (PdfWriter writer = new PdfWriter(pdfFilePath)) ;
            //    {
            //        using (PdfDocument pdf = new PdfDocument(writer))
            //        {
            //            Document document = new Document(pdf);

            //            // Add crime records to the PDF
            //            document.Add(new Paragraph("Crime Records"));
            //            document.Add(new Paragraph("-----------------------------------------------"));

            //            foreach (DataRow row in dtCrimeRecords.Rows)
            //            {
            //                document.Add(new Paragraph($"Crime ID: {row["CrimeId"]}, Crime Type: {row["CrimeType"]}, Amount: {row["Amount"]}"));
            //            }

            //            // Add rewards to the PDF
            //            document.Add(new Paragraph("\nRewards"));
            //            document.Add(new Paragraph("-----------------------------------------------"));

            //            foreach (DataRow row in dtRewards.Rows)
            //            {
            //                document.Add(new Paragraph($"Reward ID: {row["RewardId"]}, Fine: {row["Fine"]}, Reward Officer1: {row["RewardOfficer1"]}, Reward Officer2: {row["RewardOfficer2"]}"));
            //            }
            //        }
            //    }

            //    return pdfFilePath;
            //}
        }
}
