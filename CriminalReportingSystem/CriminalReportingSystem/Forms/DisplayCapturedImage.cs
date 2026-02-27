using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriminalReportingSystem.Forms
{
    public partial class DisplayCapturedImage : Form
    {
        public string connectionString = "Data Source=DESKTOP-BU7QFI6\\SQLEXPRESS;Initial Catalog=CriminalReportingDB; Integrated Security=True";
        private SqlConnection sqlConnection;
        private SqlDataAdapter specialtyDataAdapter;
        private SqlDataAdapter doctorDataAdapter;
        private SqlDataAdapter scheduleDataAdapter;
        private DataSet dataSet;
        public DisplayCapturedImage()
        {
            InitializeComponent();
        }

        private void DisplayCapturedImage_Load(object sender, EventArgs e)
        {
            DisplayImageFromDatabase();

        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DisplayCapturedImage());
        }
        private void DisplayImageFromDatabase()
        {
            try
            {
                // Replace this with your database connection and query
                byte[] imageData = GetImageDataFromDatabase();

                if (imageData != null && imageData.Length > 0)
                {
                    // Convert the binary data to an Image
                    using (MemoryStream ms = new MemoryStream(imageData))
                    {
                        Image image = Image.FromStream(ms);

                        // Display the image in the PictureBox control
                        pictureBox1.Image = image;
                    }
                }
                else
                {
                    MessageBox.Show("No image data found in the database.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private byte[] GetImageDataFromDatabase()
        {
            // Replace this with your database connection and query
            //string connectionString = "YourConnectionString";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Example query to fetch binary image data from a table
                string query = "SELECT ImageData FROM Offenders WHERE OffenderId='O005'";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (reader["ImageData"] != DBNull.Value)
                            {
                                return (byte[])reader["ImageData"];
                            }
                        }
                    }
                }
            }

            return null;
        }

    }
}
