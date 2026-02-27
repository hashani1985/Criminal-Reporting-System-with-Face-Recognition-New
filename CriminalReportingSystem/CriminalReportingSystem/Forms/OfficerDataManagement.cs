using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriminalReportingSystem.Forms
{
    public partial class OfficerDataManagement : Form
    {
        public string connectionString = "Data Source=DESKTOP-BU7QFI6\\SQLEXPRESS;Initial Catalog=CriminalReportingDB; Integrated Security=True";
        private SqlConnection sqlConnection;
        private SqlDataAdapter specialtyDataAdapter;
        private SqlDataAdapter doctorDataAdapter;
        private SqlDataAdapter scheduleDataAdapter;
        private DataSet dataSet;
        public string passedUserRole;
        public OfficerDataManagement(string UserRole)
        {
            InitializeComponent();
            //InitializeComponent();

            ChangeLabelBgColor();

            this.WindowState = FormWindowState.Maximized;
        }

        private void OfficerDataManagement_Load(object sender, EventArgs e)
        {

            //---- load data to the datagrid view from the database
            try
            {
                // Create a DataTable to store the data
                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to select data from the database table
                    string selectQuery = "SELECT * FROM Officers";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Fill the DataTable with data from the database
                            adapter.Fill(dataTable);
                        }
                    }
                }

                // Bind the DataTable to the DataGridView
                dtgViewOfficer.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //-------------  email validation ----------
        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            Regex regex = new Regex(emailPattern);

            if (regex.IsMatch(txtEmail.Text) || txtEmail.Text == "No")
            {
                // Valid email address
                txtEmail.BackColor = System.Drawing.Color.White;
                //lblEmailError.Text = "";
                label13.Text = "";
                btnSave.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                // Invalid email address
                txtEmail.BackColor = System.Drawing.Color.LightPink;
                //lblEmailError.Text = "Type a valid email address";
                label13.Text = "Type a valid email address";
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Status = "Yes";

                string Title = cmbTitle.Text.Trim();
                string Name = txtName.Text.Trim();
                string NIC = txtNIC.Text.Trim();
                string Gender = cmbGender.SelectedItem.ToString();
                DateTime DOB = DatePickDOB.Value;
                string Address = txtAddress.Text.Trim();
                string Contact = txtContact.Text.Trim();
                string Email = txtEmail.Text.Trim();
                string Designation=cmbDesignation.SelectedItem.ToString();
                string EmployeeId=txtEmpID.Text.Trim();

                // Check if NIC or name already exists in the database
                if (IsNICAlreadyExists(NIC, Name))
                {
                    MessageBox.Show("An Officer with this NIC number or name already exists in the database.", "Duplicate NIC or name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Generate the custom AppointmentID
                    string customOfficerID = GenerateCustomOfficerID();

                    string insertQuery = "INSERT INTO Officers (OfficerId,Title,Name,Designation,EmployeeId, NIC, Gender, DOB, Address, Contact,Email) VALUES (@OfficerId,@Title,@Name,@Designation,@EmployeeId, @NIC, @Gender, @DOB, @Address, @Contact,@Email)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OfficerId", customOfficerID);
                        command.Parameters.AddWithValue("@Title", Title);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Designation", Designation);
                        command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                        command.Parameters.AddWithValue("@NIC", NIC);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@DOB", DOB);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Contact", Contact);
                        command.Parameters.AddWithValue("@Email", Email);



                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Officer data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Insertion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                RefreshDataGridView();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearForm();
        }

        public void ChangeLabelBgColor()
        {
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            label10.BackColor = Color.Transparent;
            label11.BackColor = Color.Transparent;
            label12.BackColor = Color.Transparent;
            label13.BackColor = Color.Transparent;

        }

        //----------- validate only numbers for contact number -----------------------
        private void txtContact_TextChanged(object sender, EventArgs e)
        {
            if (txtContact.Text.Length >= 10)
            {
                txtContact.Text = txtContact.Text.Substring(0, 10);
            }
            if (int.TryParse(txtContact.Text, out _))
            {
                // Valid number input
                txtContact.BackColor = System.Drawing.Color.White;
                lblContactError.Text = "";
                btnSave.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                // Invalid input (not a number)
                txtContact.BackColor = System.Drawing.Color.White;
                lblContactError.Text = "Enter a valid number";
                btnSave.Enabled = false;
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;

            }
        }

        //------------------------ functions for home and logout buttons ---------------------
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        //-------------  clear form --------------------
        public void ClearForm()
        {
            cmbTitle.Text = string.Empty;
            txtName.Text = string.Empty;
            txtNIC.Text = string.Empty;
            cmbGender.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtContact.Text = string.Empty;


            //txtEmail.BackColor = System.Drawing.Color.White;
            //lblEmailError.Text = "";
            //txtContact.BackColor = System.Drawing.Color.White;
            //lblContactError.Text = "";
            btnSave.Enabled = true;
            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;

        }

        //--------  refresh datagrid----
        private void RefreshDataGridView()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    // SQL query to select data from the database table
                    string selectQuery = "SELECT * FROM Officers";

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
                dtgViewOfficer.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }

        }

        //-------------------------------------- Generate custom Offender id ---------------------

        private string GenerateCustomOfficerID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT MAX(CONVERT(INT, SUBSTRING(OfficerId, 2, LEN(OfficerId) - 1))) FROM Officers";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    int nextNumericValue = 1; // Default if no existing records

                    if (result != DBNull.Value)
                    {
                        // If there are existing records, parse the numeric part and increment it
                        nextNumericValue = Convert.ToInt32(result) + 1;
                    }

                    string customOffenderID = "E" + nextNumericValue.ToString("D3");
                    return customOffenderID;
                }
            }
        }


        //----- function to check database with exixsting NIC

        private bool IsNICAlreadyExists(string nic, string Name)
        {
            if (nic == "")
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT COUNT(*) FROM Officers WHERE Name = @Name";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", Name);

                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }

                }
            }
            else
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectQuery = "SELECT COUNT(*) FROM Officers WHERE NIC = @NIC";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NIC", nic);

                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
        }

        private void dtgViewOfficer_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgViewOfficer.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dtgViewOfficer.SelectedRows[0];

                // Extract data from the selected row and populate TextBox controls

                txtNIC.Text = selectedRow.Cells["NIC"].Value.ToString();
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtContact.Text = selectedRow.Cells["Contact"].Value.ToString();
                cmbGender.SelectedItem = selectedRow.Cells["Gender"].Value.ToString();
                cmbTitle.SelectedItem = selectedRow.Cells["Title"].Value.ToString();
                cmbDesignation.SelectedItem= selectedRow.Cells["Title"].Value.ToString();
                txtEmpID.Text= selectedRow.Cells["EmployeeId"].Value.ToString();


                txtContact.BackColor = System.Drawing.Color.White;
                lblContactError.Text = "";
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string Title = cmbTitle.Text.Trim();
            string Name = txtName.Text.Trim();
            string NIC = txtNIC.Text.Trim();
            string Gender = cmbGender.SelectedItem.ToString();
            DateTime DOB = DatePickDOB.Value;
            string Address = txtAddress.Text.Trim();
            string Contact = txtContact.Text.Trim();
            string Email = txtEmail.Text.Trim();
            string Designation = cmbDesignation.SelectedItem.ToString();
            string EmployeeId = txtEmpID.Text.Trim();


            if (dtgViewOfficer.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dtgViewOfficer.SelectedRows[0];

                String OffenderId = selectedRow.Cells["OfficerId"].Value.ToString();

                // SQL query to insert data
                string insertQuery = "UPDATE Officers SET Title = @Title, Name=@Name,Designation=@Designation, EmployeeId=@EmployeeId, NIC=@NIC,  Gender=@Gender,DOB=@DOB, Address=@Address, Contact=@Contact,Email=@Email WHERE OfficerId = @OfficerId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@OfficerId", OffenderId);
                        command.Parameters.AddWithValue("@Title", Title);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Designation", Designation);
                        command.Parameters.AddWithValue("@EmployeeId", EmployeeId);
                        command.Parameters.AddWithValue("@NIC", NIC);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@DOB", DOB);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Contact", Contact);
                        command.Parameters.AddWithValue("@Email", Email);

                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show($"Updated Officer Data.Rows affected: {rowsAffected}");
                            ClearForm();

                            txtContact.BackColor = System.Drawing.Color.White;
                            lblContactError.Text = "";
                            btnSave.Enabled = true;
                            btnUpdate.Enabled = true;
                            btnDelete.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}");
                        }
                    }
                }
            }
            RefreshDataGridView();
            ClearForm();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgViewOfficer.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dtgViewOfficer.SelectedRows[0];

                    // Extract the unique identifier (e.g., primary key) from the selected row
                    string primaryKeyValue = selectedRow.Cells["OfficerId"].Value.ToString();

                    // Delete the row from the databaseSecon using a SQL DELETE statement
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM Officers WHERE OfficerId = @OfficerId";
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@OfficerId", primaryKeyValue);

                            int rowsAffected = command.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                // Deletion successful, you can provide feedback to the user
                                MessageBox.Show("Deletion successful.");
                            }
                            else
                            {
                                // No rows were deleted, handle accordingly
                                MessageBox.Show("Deletion failed or no rows were affected.");
                            }
                        }
                    }

                    // Refresh the DataGridView to reflect the updated data
                    RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Please select a row to delete.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            ClearForm();
        }
    }



}
