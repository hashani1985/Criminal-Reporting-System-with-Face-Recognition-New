using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CriminalReportingSystem.Forms;
using System.Xml.Linq;


namespace CriminalReportingSystem
{
    public partial class Form1 : Form
    {
        public string connectionString = "Data Source=DESKTOP-BU7QFI6\\SQLEXPRESS;Initial Catalog=CriminalReportingDB; Integrated Security=True";
        private SqlConnection sqlConnection;
        private SqlDataAdapter specialtyDataAdapter;
        private SqlDataAdapter doctorDataAdapter;
        private SqlDataAdapter scheduleDataAdapter;
        private DataSet dataSet;

        public string passedUserRole;

        public Form1()
        {
            InitializeComponent();
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            label1.BackColor = Color.Transparent;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        //-------- Clear Form ---------------

        public void ClearForm()
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            cmbUserRole.SelectedIndex = 0;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string enteredUsername = txtUsername.Text;
                string enteredPassword = txtPassword.Text;
                string enteredUserRole=cmbUserRole.SelectedItem.ToString();


                //string connectionString = connectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to retrieve username and password for authentication
                    string query = "SELECT Username, Password, UserRole FROM Users WHERE Username = @Username";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", enteredUsername);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string storedUsername = reader["Username"].ToString();
                                string storedPassword = reader["Password"].ToString();
                                string storedUserRole = reader["UserRole"].ToString();

                                // Compare the stored username and password with the entered credentials
                                if (enteredUsername == storedUsername && enteredPassword == storedPassword)
                                {
                                    // Authentication successful

                                    //--- indert login details to login data table

                                    MessageBox.Show("Login successful.");
                                    // Redirect to the admin dashboard form
                                    Dashboard adminDashboardForm = new Dashboard(enteredUserRole);
                                    adminDashboardForm.Show();
                                    this.Hide();
                                }
                                else
                                {
                                    // Authentication failed
                                    MessageBox.Show("Invalid username or password. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                // Username not found in the database
                                MessageBox.Show("Username not found. Please try again.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any unexpected exceptions
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            InsertLoginData();
        }

        //-------------------- insert login details to login table-----

        public void InsertLoginData()
        {
            string Username = txtUsername.Text.Trim();
            string Password = txtPassword.Text.Trim();
            string UserRole = cmbUserRole.Text.Trim();
            string AccountStatus = "Active";
            DateTime LastLoginTimeStamp=DateTime.Now;
           


            
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Generate the custom PatientID
                    string customPatientID = GenerateCustomUserID();

                    string insertQuery = "INSERT INTO LoginData (UserId, Username, Password,UserRole, LastLoginTimeStamp,AccountStatus) VALUES (@UserId, @Username, @Password,@UserRole,@LastLoginTimeStamp,@AccountStatus)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@UserId", customPatientID);
                        command.Parameters.AddWithValue("@Username", Username);
                        command.Parameters.AddWithValue("@Password", Password);
                        command.Parameters.AddWithValue("@UserRole", UserRole);
                        command.Parameters.AddWithValue("@LastLoginTimeStamp", LastLoginTimeStamp);
                        command.Parameters.AddWithValue("@AccountStatus", AccountStatus);
                       


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                           // MessageBox.Show("Login data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            //MessageBox.Show("Insertion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        // --------- generate auto number for patient id ------------- 

        private string GenerateCustomUserID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT MAX(CONVERT(INT, SUBSTRING(UserId, 2, LEN(UserId) - 1))) FROM LoginData";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    int nextNumericValue = 1; // Default if no existing records

                    if (result != DBNull.Value)
                    {
                        // If there are existing records, parse the numeric part and increment it
                        nextNumericValue = Convert.ToInt32(result) + 1;
                    }

                    string customPatientID = "U" + nextNumericValue.ToString("D3");
                    return customPatientID;
                }
            }
        }

    }
}
