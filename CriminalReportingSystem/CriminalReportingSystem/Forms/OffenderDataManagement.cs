using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace CriminalReportingSystem.Forms
{
    public partial class OffenderDataManagement : Form
    {
        public string connectionString = "Data Source=DESKTOP-BU7QFI6\\SQLEXPRESS;Initial Catalog=CriminalReportingDB; Integrated Security=True";
        private SqlConnection sqlConnection;
        private SqlDataAdapter specialtyDataAdapter;
        private SqlDataAdapter doctorDataAdapter;
        private SqlDataAdapter scheduleDataAdapter;
        private DataSet dataSet;
        public string passedUserRole;
        public OffenderDataManagement(string UserRole)
        {
            InitializeComponent();

            ChangeLabelBgColor();

            this.WindowState = FormWindowState.Maximized;
        }

        //public OffenderDataManagement(string passedUserRole)
        //{
        //    this.passedUserRole = passedUserRole;
        //}

        private void label5_Click(object sender, EventArgs e)
        {

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
            //label10.BackColor = Color.Transparent;
            //label11.BackColor = Color.Transparent;
            //label12.BackColor = Color.Transparent;

        }

        //------ open face recogntion python script---------------------------------
        private void btnFaceRecognition_Click(object sender, EventArgs e)
        {
            string pythonScriptPath = "D:\\Project\\Application\\FaceRecognitionPart\\FaceRecogNew6.py"; //  script's actual path

            // Create a new process to run the Python script
            Process process = new Process();
            process.StartInfo.FileName = "python"; // Use "python" or "python3" depending on your Python installation
            process.StartInfo.Arguments = pythonScriptPath;
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.CreateNoWindow = true;

            // Redirect the output to a StreamReader
            process.Start();

            // Read the output of the Python script (if needed)
            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();

            // Optionally, display the Python script output in a MessageBox
            MessageBox.Show("Python Script Output:\n" + output, "Python Script Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Status = "Yes";

                string Title = cmbTitle.Text.Trim();
                string Name= txtName.Text.Trim();
                string NIC=txtNIC.Text.Trim();
                string Gender= cmbGender.SelectedItem.ToString(); 
                DateTime DOB = DatePickDOB.Value;
                string Address=txtAddress.Text.Trim(); 
                string Contact=txtContact.Text.Trim();

                // Check if NIC or name already exists in the database
                if (IsNICAlreadyExists(NIC, Name))
                {
                    MessageBox.Show("An Offender with this NIC number or name already exists in the database.", "Duplicate NIC or name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Generate the custom AppointmentID
                    string customOffenderID = GenerateCustomOffenderID();

                    string insertQuery = "INSERT INTO Offenders (OffenderId,Title,Name, NIC, Gender, DOB, Address, Contact) VALUES (@OffenderId,@Title,@Name, @NIC, @Gender, @DOB, @Address, @Contact)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@OffenderId", customOffenderID);
                        command.Parameters.AddWithValue("@Title", Title);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@NIC", NIC);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@DOB", DOB);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Contact", Contact);
                       



                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Offender data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Insertion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                RefreshDataGridView();
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //-------------------------------------- Generate custom Offender id ---------------------

        private string GenerateCustomOffenderID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT MAX(CONVERT(INT, SUBSTRING(OffenderId, 2, LEN(OffenderId) - 1))) FROM Offenders";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    int nextNumericValue = 1; // Default if no existing records

                    if (result != DBNull.Value)
                    {
                        // If there are existing records, parse the numeric part and increment it
                        nextNumericValue = Convert.ToInt32(result) + 1;
                    }

                    string customOffenderID = "O" + nextNumericValue.ToString("D3");
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

                    string selectQuery = "SELECT COUNT(*) FROM Offenders WHERE Name = @Name";

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

                    string selectQuery = "SELECT COUNT(*) FROM Offenders WHERE NIC = @NIC";

                    using (SqlCommand command = new SqlCommand(selectQuery, connection))
                    {
                        command.Parameters.AddWithValue("@NIC", nic);

                        int count = (int)command.ExecuteScalar();

                        return count > 0;
                    }
                }
            }
        }

        private void OffenderDataManagement_Load(object sender, EventArgs e)
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
                    string selectQuery = "SELECT * FROM Offenders";

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
                dtgViewOffender.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        //-------------  clear form --------------------
        public void ClearForm()
        {
            cmbTitle.Text =string.Empty;
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

        private void dtgViewOffender_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgViewOffender.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dtgViewOffender.SelectedRows[0];

                // Extract data from the selected row and populate TextBox controls

                txtNIC.Text = selectedRow.Cells["NIC"].Value.ToString();
                txtName.Text = selectedRow.Cells["Name"].Value.ToString();
                txtAddress.Text = selectedRow.Cells["Address"].Value.ToString();
                //txtEmail.Text = selectedRow.Cells["Email"].Value.ToString();
                txtContact.Text = selectedRow.Cells["Contact"].Value.ToString();
                cmbGender.SelectedItem = selectedRow.Cells["Gender"].Value.ToString();
               


                txtContact.BackColor = System.Drawing.Color.White;
                lblContactError.Text = "";
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
            }
        }

        // ----  ---- display sugessions from database on textbox----

        
private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //string searchTerm = txtSearch.Text;

            
            //List<string> suggestions = GetSuggestionsFromDatabase(searchTerm);

            //// Display the suggestions in a ListBox or ComboBox.
            //suggestionListBox.DataSource = suggestions;
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


            if (dtgViewOffender.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dtgViewOffender.SelectedRows[0];

                String OffenderId = selectedRow.Cells["OffenderId"].Value.ToString();

                // SQL query to insert data
                string insertQuery = "UPDATE Offenders SET Title = @Title, Name=@Name, NIC=@NIC,  Gender=@Gender,DOB=@DOB, Address=@Address, Contact=@Contact WHERE OffenderId = @OffenderId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@OffenderId", OffenderId);
                        command.Parameters.AddWithValue("@Title", Title);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@NIC", NIC);
                        command.Parameters.AddWithValue("@Gender", Gender);
                        command.Parameters.AddWithValue("@DOB", DOB);
                        command.Parameters.AddWithValue("@Address", Address);
                        command.Parameters.AddWithValue("@Contact", Contact);


                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show($"Updated Offender Data.Rows affected: {rowsAffected}");
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
                dtgViewOffender.DataSource = dataTable;
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtgViewOffender.SelectedRows.Count > 0)
                {
                    // Get the selected row
                    DataGridViewRow selectedRow = dtgViewOffender.SelectedRows[0];

                    // Extract the unique identifier (e.g., primary key) from the selected row
                    string primaryKeyValue = selectedRow.Cells["OffenderId"].Value.ToString();

                    // Delete the row from the databaseSecon using a SQL DELETE statement
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        string deleteQuery = "DELETE FROM Offenders WHERE OffenderId = @OffenderId";
                        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
                        {
                            command.Parameters.AddWithValue("@OffenderId", primaryKeyValue);

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

        private void DatePickDOB_ValueChanged(object sender, EventArgs e)
        {

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









