using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CriminalReportingSystem.Forms
{
    public partial class OffenderDataView : Form
    {
        public string connectionString = "Data Source=DESKTOP-BU7QFI6\\SQLEXPRESS;Initial Catalog=CriminalReportingDB; Integrated Security=True";
        private SqlConnection sqlConnection;
       
        private DataSet dataSet;
        public OffenderDataView()
        {
            InitializeComponent();
        }

        private void OffenderDataView_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    // SQL query to select data from the database table
                    string selectQuery = "SELECT * FROM Offenders";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Clear the DataTable to remove existing data
                            dataTable.Clear();

                            // Fill the DataTable with fresh data from the database
                            adapter.Fill(dataTable);
                        }
                    }
                }

                // Update the DataGridView's data source
                dtgViewOffenderData.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }

            //........................ load image......................


            // Replace the connection string with your own connection string
          //  string connectionString = "YourConnectionStringHere";

            // Replace "YourTableName" and "YourImageColumn" with your actual table and column names
            string query = "SELECT ImageData FROM Offenders WHERE OffenderId='O003'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Execute the query and read the binary data
                    byte[] imageData = (byte[])command.ExecuteScalar();

                    // Check if the binary data is not null
                    if (imageData != null)
                    {
                        // Convert the binary data to an image
                        Image originalImage = ByteArrayToImage(imageData);

                        // Resize the image to 300x400
                        Image resizedImage = ResizeImage(originalImage, 300, 400);

                        // Display the resized image in the PictureBox
                        pictureBox1.Image = resizedImage;
                    }
                    else
                    {
                        MessageBox.Show("Image data not found in the database.");
                    }
                }
            }
        }

        // Convert byte array to image
        private Image ByteArrayToImage(byte[] byteArray)
        {
            MemoryStream memoryStream = new MemoryStream(byteArray);
            Image image = Image.FromStream(memoryStream);
            return image;
        }

        private Image ResizeImage(Image originalImage, int width, int height)
        {
            Bitmap resizedImage = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(resizedImage))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(originalImage, 0, 0, width, height);
            }
            return resizedImage;
        }



        private void dtgViewOffenderData_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgViewOffenderData.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dtgViewOffenderData.SelectedRows[0];

                // Extract data from the selected row and populate TextBox controls

                
                
                lblOffenderId.Text = selectedRow.Cells["OffenderId"].Value.ToString();
                



            }
        }

        private void btnFaceRecognition_Click(object sender, EventArgs e)
        {
            PassOffenderId();

        }

        public void PassOffenderId()
        {
            string pythonScriptPath = @"D:\Project\Application\FaceRecognitionPart\FaceRecogNew4.py";  // ath to the Python script
            string offenderId = lblOffenderId.Text.ToString(); //  Offender ID
            System.Diagnostics.Process process1 = new System.Diagnostics.Process();
            process1.StartInfo.FileName = "D:\\Project\\Application\\FaceRecognitionPart\\myenv\\Scripts\\python.exe";
            


            // Start the Python script as a separate process
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "python",
                Arguments = $"{pythonScriptPath} {offenderId}",
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            using (Process process = new Process { StartInfo = startInfo })
            {
                process.Start();

                // Pass the Offender ID to the Python script via standard input
                using (StreamWriter sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        sw.WriteLine(offenderId);
                        sw.Close();
                    }
                }

                // Read and display the Python script's output from standard output
                using (StreamReader sr = process.StandardOutput)
                {
                    if (sr.BaseStream.CanRead)
                    {
                        string output = sr.ReadToEnd();
                        Console.WriteLine(output);
                    }
                }

                process.WaitForExit();
            }
        }
    }
}

