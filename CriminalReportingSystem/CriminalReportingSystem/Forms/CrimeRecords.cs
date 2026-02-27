using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace CriminalReportingSystem.Forms
{
    public partial class CrimeRecords : Form
    {
        public string connectionString = "Data Source=DESKTOP-BU7QFI6\\SQLEXPRESS;Initial Catalog=CriminalReportingDB; Integrated Security=True";
        private SqlConnection sqlConnection;
        private SqlDataAdapter specialtyDataAdapter;
        private SqlDataAdapter doctorDataAdapter;
        private SqlDataAdapter scheduleDataAdapter;
        private DataSet dataSet;
        public string passedUserRole;

        public CrimeRecords(string UserRole)
        {
            InitializeComponent();
            ChangeLabelBgColor();

            this.WindowState = FormWindowState.Maximized;
        }

        private void CrimeRecords_Load(object sender, EventArgs e)
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
                    string selectQuery = "SELECT * FROM CrimeRecords";

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
                dtgViewCrimeRecord.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listOffenderSuggessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOffender.Text = listOffenderSuggessions.SelectedItem?.ToString();
            listOffenderSuggessions.Visible = false; // Hide the ListBox
        }

        private void txtOffender_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtOffender.Text.Trim();

            // Clear the existing suggestions
            listOffenderSuggessions.Items.Clear();

            if (!string.IsNullOrEmpty(searchText))
            {
                try
                {
                    // Establish a database connection 
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Create a SQL query to retrieve patient names based on input
                        string query = "SELECT Name FROM Offenders WHERE Name LIKE @SearchText";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            // Add a parameter for the search text
                            cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Add patient names to the ListBox as suggestions
                                    listOffenderSuggessions.Items.Add(reader["Name"].ToString());
                                }
                            }
                        }
                    }

                    // Show the ListBox with suggestions
                    listOffenderSuggessions.Visible = true;
                }
                catch (SqlException ex)
                {
                    // Handle SQL-related exceptions
                    MessageBox.Show("A database error occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle other types of exceptions
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                // Hide the ListBox when there is no text entered
                listOffenderSuggessions.Visible = false;
            }
        }

        private void listOfficer1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOfficer1.Text = listOfficer1.SelectedItem?.ToString();
            listOfficer1.Visible = false; // Hide the ListBox
        }

        private void txtOfficer1_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtOfficer1.Text.Trim();

            // Clear the existing suggestions
            listOfficer1.Items.Clear();

            if (!string.IsNullOrEmpty(searchText))
            {
                try
                {
                    // Establish a database connection 
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Create a SQL query to retrieve patient names based on input
                        string query = "SELECT Name FROM Officers WHERE Name LIKE @SearchText";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            // Add a parameter for the search text
                            cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Add patient names to the ListBox as suggestions
                                    listOfficer1.Items.Add(reader["Name"].ToString());
                                }
                            }
                        }
                    }

                    // Show the ListBox with suggestions
                    listOfficer1.Visible = true;
                }
                catch (SqlException ex)
                {
                    // Handle SQL-related exceptions
                    MessageBox.Show("A database error occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle other types of exceptions
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                // Hide the ListBox when there is no text entered
                listOfficer1.Visible = false;
            }
        }

        private void txtOfficer2_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtOfficer2.Text.Trim();

            // Clear the existing suggestions
            listOfficer2.Items.Clear();

            if (!string.IsNullOrEmpty(searchText))
            {
                try
                {
                    // Establish a database connection 
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Create a SQL query to retrieve patient names based on input
                        string query = "SELECT Name FROM Officers WHERE Name LIKE @SearchText";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            // Add a parameter for the search text
                            cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Add patient names to the ListBox as suggestions
                                    listOfficer2.Items.Add(reader["Name"].ToString());
                                }
                            }
                        }
                    }

                    // Show the ListBox with suggestions
                    listOfficer2.Visible = true;
                }
                catch (SqlException ex)
                {
                    // Handle SQL-related exceptions
                    MessageBox.Show("A database error occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle other types of exceptions
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                // Hide the ListBox when there is no text entered
                listOfficer2.Visible = false;
            }
        }

        private void listOfficer2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOfficer2.Text = listOfficer2.SelectedItem?.ToString();
            listOfficer2.Visible = false; // Hide the ListBox
        }

        private void txtAssCommissioner_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtAssCommissioner.Text.Trim();

            // Clear the existing suggestions
            listACSuggessions.Items.Clear();

            if (!string.IsNullOrEmpty(searchText))
            {
                try
                {
                    // Establish a database connection 
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Create a SQL query to retrieve patient names based on input
                        string query = "SELECT Name FROM Officers WHERE Name LIKE @SearchText AND Designation ='Assistant Commissioner'";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            // Add a parameter for the search text
                            cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Add patient names to the ListBox as suggestions
                                    listACSuggessions.Items.Add(reader["Name"].ToString());
                                }
                            }
                        }
                    }

                    // Show the ListBox with suggestions
                    listACSuggessions.Visible = true;
                }
                catch (SqlException ex)
                {
                    // Handle SQL-related exceptions
                    MessageBox.Show("A database error occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle other types of exceptions
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                // Hide the ListBox when there is no text entered
                listACSuggessions.Visible = false;
            }
        }

        private void txtSuperintendant_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtSuperintendant.Text.Trim();

            // Clear the existing suggestions
            listSESuggessions.Items.Clear();

            if (!string.IsNullOrEmpty(searchText))
            {
                try
                {
                    // Establish a database connection 
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Create a SQL query to retrieve patient names based on input
                        string query = "SELECT Name FROM Officers WHERE Name LIKE @SearchText AND Designation ='Superintendant'";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            // Add a parameter for the search text
                            cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Add patient names to the ListBox as suggestions
                                    listSESuggessions.Items.Add(reader["Name"].ToString());
                                }
                            }
                        }
                    }

                    // Show the ListBox with suggestions
                    listSESuggessions.Visible = true;
                }
                catch (SqlException ex)
                {
                    // Handle SQL-related exceptions
                    MessageBox.Show("A database error occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle other types of exceptions
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                // Hide the ListBox when there is no text entered
                listSESuggessions.Visible = false;
            }
        }

        private void txtOIC_TextChanged(object sender, EventArgs e)
        {
            string searchText = txtOIC.Text.Trim();

            // Clear the existing suggestions
            listOICSuggessions.Items.Clear();

            if (!string.IsNullOrEmpty(searchText))
            {
                try
                {
                    // Establish a database connection 
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Create a SQL query to retrieve patient names based on input
                        string query = "SELECT Name FROM Officers WHERE Name LIKE @SearchText AND Designation ='Officer in Charge'";

                        using (SqlCommand cmd = new SqlCommand(query, connection))
                        {
                            // Add a parameter for the search text
                            cmd.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");

                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    // Add patient names to the ListBox as suggestions
                                    listOICSuggessions.Items.Add(reader["Name"].ToString());
                                }
                            }
                        }
                    }

                    // Show the ListBox with suggestions
                    listOICSuggessions.Visible = true;
                }
                catch (SqlException ex)
                {
                    // Handle SQL-related exceptions
                    MessageBox.Show("A database error occurred: " + ex.Message);
                }
                catch (Exception ex)
                {
                    // Handle other types of exceptions
                    MessageBox.Show("An error occurred: " + ex.Message);
                }
            }
            else
            {
                // Hide the ListBox when there is no text entered
                listOICSuggessions.Visible = false;
            }
        }

        private void listACSuggessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtAssCommissioner.Text = listACSuggessions.SelectedItem?.ToString();
            listACSuggessions.Visible = false; // Hide the ListBox
        }

        private void listSESuggessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSuperintendant.Text = listSESuggessions.SelectedItem?.ToString();
            listSESuggessions.Visible = false; // Hide the ListBox
        }

        private void listOICSuggessions_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOIC.Text = listOICSuggessions.SelectedItem?.ToString();
            listOICSuggessions.Visible = false; // Hide the ListBox
        }

        private void txtFine_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtFine.Text, out _))
            {
                // Valid number input
                txtFine.BackColor = System.Drawing.Color.White;
                lblFineError.Text = "";
                btnSave.Enabled = true;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                // Invalid input (not a number)
                txtFine.BackColor = System.Drawing.Color.White;
                lblFineError.Text = "Enter a valid number";
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

        private void cmbCrimeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Handle the event when a crime type is selected
            string selectedCrimeType = cmbCrimeType.SelectedItem.ToString();
            string crimeDescription = GetCrimeDescriptionFromDatabase(selectedCrimeType);
            string crimeUnit= GetCrimeUnitFromDatabase(selectedCrimeType);

            // Update the description TextBox
            txtDescription.Text = crimeDescription;
            txtUnit.Text = crimeUnit;
        }

        //------------------------ GET CRIME TYPE ------------
        private string GetCrimeDescriptionFromDatabase(string crimeType)
        {
            string query = "SELECT Description FROM CrimeTypes WHERE Type = @CrimeType";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CrimeType", crimeType);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving crime description: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }

        ///----------------------- get unit from crimetype ---------------
        ///

        private string GetCrimeUnitFromDatabase(string crimeType)
        {
            string query = "SELECT Unit FROM CrimeTypes WHERE Type = @CrimeType";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@CrimeType", crimeType);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving crime description: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string Status = "Yes";

                string CrimeType = cmbCrimeType.SelectedItem.ToString();
                double Amount = Convert.ToDouble(txtAmount.Text.Trim());
                string Unit = txtUnit.Text.Trim();
                string Description=txtDescription.Text.Trim();
                DateTime DateOfOffence = OffenceDate.Value;
                string Place = txtPlace.Text.Trim();
                string Offender=txtOffender.Text.Trim();
                string Officer1 = txtOfficer1.Text.Trim();
                string Officer2 = txtOfficer2.Text.Trim();
                string AssistantCommissioner= txtAssCommissioner.Text.Trim();
                string Superintendent = txtSuperintendant.Text.Trim();
                string OIC = txtOIC.Text.Trim();
                double Fine = Convert.ToDouble((txtFine.Text.Trim()));





                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Generate the custom AppointmentID
                    string customCrimeID = GenerateCustomCrimeID();
                    string OffenderId=GetOffenderID(Offender);
                    string Officer1Id=GetOfficer1ID(Officer1);
                    string Officer2Id=GetOfficer2ID(Officer2);
                    string AssistantCommissionerId=GetAssistantCommissionerID(AssistantCommissioner);
                    string SuperintendantId=GetSuperintendantID(Superintendent);
                    string OICId=GetOICID(OIC);


                    string insertQuery = "INSERT INTO CrimeRecords (CrimeId,CrimeType,Amount, Unit, Description, DateOfOffence, PlaceOfOffence, OffenderId,Officer1Id,Officer2Id,AssistantCommissionerId,SuperintendantId,OICId,Fine) VALUES (@CrimeId,@CrimeType,@Amount, @Unit, @Description, @DateOfOffence, @PlaceOfOffence, @OffenderId,@Officer1Id,@Officer2Id,@AssistantCommissionerId,@SuperintendantId,@OICId,@Fine)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@CrimeId", customCrimeID);
                        command.Parameters.AddWithValue("@CrimeType", CrimeType);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Unit", Unit);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@DateOfOffence", DateOfOffence);
                        command.Parameters.AddWithValue("@PlaceOfOffence", Place);
                        command.Parameters.AddWithValue("@OffenderId", OffenderId);
                        command.Parameters.AddWithValue("@Officer1Id", Officer1Id);
                        command.Parameters.AddWithValue("@Officer2Id", Officer2Id);
                        command.Parameters.AddWithValue("@AssistantCommissionerId", AssistantCommissionerId);
                        command.Parameters.AddWithValue("@SuperintendantId", SuperintendantId);
                        command.Parameters.AddWithValue("@OICId", OICId);
                        command.Parameters.AddWithValue("@Fine", Fine);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Crime Record inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Insertion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                //RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            ClearForm();
            RefreshDataGridView();
        }

        //-------------------------------------- Generate custom Crime id ---------------------

        private string GenerateCustomCrimeID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT MAX(CONVERT(INT, SUBSTRING(CrimeId, 2, LEN(CrimeId) - 1))) FROM CrimeRecords";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    int nextNumericValue = 1; // Default if no existing records

                    if (result != DBNull.Value)
                    {
                        // If there are existing records, parse the numeric part and increment it
                        nextNumericValue = Convert.ToInt32(result) + 1;
                    }

                    string customOffenderID = "C" + nextNumericValue.ToString("D3");
                    return customOffenderID;
                }
            }
        }

        private string GetOffenderID(string Offender)
        {
            string query = "SELECT OffenderId FROM Offenders WHERE Name = @Name";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", Offender);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving crime description: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }
        private string GetOfficer1ID(string Officer1)
        {

            string query = "SELECT OfficerId FROM Officers WHERE Name = @Name";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", Officer1);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving crime description: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }
        private string GetOfficer2ID(string Officer2)
        {
            string query = "SELECT OfficerId FROM Officers WHERE Name = @Name";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", Officer2);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving crime description: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }
        private string GetAssistantCommissionerID(string AssistantCommissioner)
        {
            string query = "SELECT OfficerId FROM Officers WHERE Name = @Name";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", AssistantCommissioner);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving crime description: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }
        private string GetSuperintendantID(string Superintendant)
        {
            string query = "SELECT OfficerId FROM Officers WHERE Name = @Name";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", Superintendant);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving crime description: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }
        private string GetOICID(string OIC)
        {
            string query = "SELECT OfficerId FROM Officers WHERE Name = @Name";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@Name", OIC);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving crime description: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
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

        //--------------------------- clear form
        public void ClearForm()
        {
            cmbCrimeType.Text = string.Empty;
            txtAmount.Text= string.Empty;
            txtUnit.Text= string.Empty;
            txtDescription.Text = string.Empty;
            txtPlace.Text = string.Empty;
            txtOffender.Text = string.Empty;
            txtOfficer1.Text = string.Empty;
            txtOfficer2.Text = string.Empty;
            txtAssCommissioner.Text = string.Empty;
            txtSuperintendant.Text = string.Empty;
            txtOIC.Text = string.Empty;
            txtFine.Text= string.Empty;


        }

        //----------------  refresh datagrid

        private void RefreshDataGridView()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    // SQL query to select data from the database table
                    string selectQuery = "SELECT * FROM CrimeRecords";

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
                dtgViewCrimeRecord.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dtgViewCrimeRecord_SelectionChanged(object sender, EventArgs e)
        {
            if (dtgViewCrimeRecord.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dtgViewCrimeRecord.SelectedRows[0];

                // Extract data from the selected row and populate TextBox controls

               
                cmbCrimeType.SelectedItem= selectedRow.Cells["CrimeType"].Value.ToString();
                txtAmount.Text= selectedRow.Cells["Amount"].Value.ToString();
                txtUnit.Text= selectedRow.Cells["Unit"].Value.ToString();
                txtDescription.Text= selectedRow.Cells["Description"].Value.ToString();
                //DateTime DateOfOffence = OffenceDate.Value;
                txtPlace.Text = selectedRow.Cells["PlaceOfOffence"].Value.ToString();
                txtFine.Text = selectedRow.Cells["Fine"].Value.ToString();


                string Offender= selectedRow.Cells["OffenderId"].Value.ToString();
                string Officer1 = selectedRow.Cells["Officer1Id"].Value.ToString();
                string Officer2 = selectedRow.Cells["Officer2Id"].Value.ToString();
                string AssistantCommissioner = selectedRow.Cells["AssistantCommissionerId"].Value.ToString();
                string Superintendent = selectedRow.Cells["SuperintendantId"].Value.ToString();
                string OIC = selectedRow.Cells["OICId"].Value.ToString();

                txtOffender.Text = GetOffenderName(Offender);
                txtOfficer1.Text = GetOfficer1Name(Officer1);
                txtOfficer2.Text = GetOfficer2Name(Officer2);
                txtAssCommissioner.Text=GetAssCommissionerName(AssistantCommissioner);
                txtSuperintendant.Text=GetSuperintendantName(Superintendent);
                txtOIC.Text = GetOICName(OIC);



                //txtContact.BackColor = System.Drawing.Color.White;
                //lblContactError.Text = "";
                btnSave.Enabled = false;
                btnUpdate.Enabled = true;
                btnDelete.Enabled = false;
            }
        }

        //-------------------------------get officer name and offender name according to ids

        private string GetOffenderName(string OffenderId)
        {
            string query = "SELECT Name FROM Offenders WHERE OffenderId = @OffenderId";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@OffenderId", OffenderId);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving offender name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }

        private string GetOfficer1Name(string Officer1Name)
        {
            string query = "SELECT Name FROM Officers WHERE OfficerId = @OfficerId";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@OfficerId", Officer1Name);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving offender name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }
        private string GetOfficer2Name(string Officer2Name)
        {
            string query = "SELECT Name FROM Officers WHERE OfficerId = @OfficerId";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@OfficerId", Officer2Name);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving offender name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }
        private string GetAssCommissionerName(string AssCommissionerName)
        {
            string query = "SELECT Name FROM Officers WHERE OfficerId = @OfficerId";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@OfficerId", AssCommissionerName);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving offender name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }

        private string GetSuperintendantName(string SuperintendantName)
        {
            string query = "SELECT Name FROM Officers WHERE OfficerId = @OfficerId";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@OfficerId", SuperintendantName);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving offender name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }

        private string GetOICName(string OICName)
        {
            string query = "SELECT Name FROM Officers WHERE OfficerId = @OfficerId";
            sqlConnection = new SqlConnection(connectionString);

            using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
            {
                sqlConnection.Open();
                sqlCommand.Parameters.AddWithValue("@OfficerId", OICName);

                try
                {
                    object result = sqlCommand.ExecuteScalar();
                    return result != null ? result.ToString() : "Description not found";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error retrieving offender name: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "Description retrieval error";
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string CrimeType = cmbCrimeType.SelectedItem.ToString();
            double Amount = Convert.ToDouble(txtAmount.Text.Trim());
            string Unit = txtUnit.Text.Trim();
            string Description = txtDescription.Text.Trim();
            DateTime DateOfOffence = OffenceDate.Value;
            string Place = txtPlace.Text.Trim();
            double Fine = Convert.ToDouble((txtFine.Text.Trim()));

            string OffenderName = txtOffender.Text.Trim();
            string Officer1Name = txtOfficer1.Text.Trim();
            string Officer2Name = txtOfficer2.Text.Trim();
            string AssistantCommissionerName = txtAssCommissioner.Text.Trim();
            string SuperintendantName = txtSuperintendant.Text.Trim();
            string OICName = txtOIC.Text.Trim();

            // Generate the custom AppointmentID
            
            string OffenderId = GetOffenderID(OffenderName);
            string Officer1Id = GetOfficer1ID(Officer1Name);
            string Officer2Id = GetOfficer2ID(Officer2Name);
            string AssistantCommissionerId = GetAssistantCommissionerID(AssistantCommissionerName);
            string SuperintendantId = GetSuperintendantID(SuperintendantName);
            string OICId = GetOICID(OICName);

            
            


            if (dtgViewCrimeRecord.SelectedRows.Count > 0)
            {
                // Get the selected row
                DataGridViewRow selectedRow = dtgViewCrimeRecord.SelectedRows[0];

                String CrimeId = selectedRow.Cells["CrimeId"].Value.ToString();

                // SQL query to insert data
                string insertQuery = "UPDATE CrimeRecords SET CrimeType=@CrimeType,Amount=@Amount, Unit=@Unit, Description=@Description, DateOfOffence=@DateOfOffence, PlaceOfOffence=@PlaceOfOffence, OffenderId=@OffenderId,Officer1Id=@Officer1Id,Officer2Id=@Officer2Id,AssistantCommissionerId=@AssistantCommissionerId,SuperintendantId=@SuperintendantId,OICId=@OICId,Fine=@Fine  WHERE CrimeId = @CrimeId";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add parameters to the query
                        command.Parameters.AddWithValue("@CrimeId", CrimeId);
                        command.Parameters.AddWithValue("@CrimeType", CrimeType);
                        command.Parameters.AddWithValue("@Amount", Amount);
                        command.Parameters.AddWithValue("@Unit", Unit);
                        command.Parameters.AddWithValue("@Description", Description);
                        command.Parameters.AddWithValue("@DateOfOffence", DateOfOffence);
                        command.Parameters.AddWithValue("@PlaceOfOffence", Place);
                        command.Parameters.AddWithValue("@OffenderId", OffenderId);
                        command.Parameters.AddWithValue("@Officer1Id", Officer1Id);
                        command.Parameters.AddWithValue("@Officer2Id", Officer2Id);
                        command.Parameters.AddWithValue("@AssistantCommissionerId", AssistantCommissionerId);
                        command.Parameters.AddWithValue("@SuperintendantId", SuperintendantId);
                        command.Parameters.AddWithValue("@OICId", OICId);
                        command.Parameters.AddWithValue("@Fine", Fine);


                        try
                        {
                            connection.Open();
                            int rowsAffected = command.ExecuteNonQuery();
                            MessageBox.Show($"Updated Offender Data.Rows affected: {rowsAffected}");
                            ClearForm();

                            //txtContact.BackColor = System.Drawing.Color.White;
                            //lblContactError.Text = "";
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

        // --function to change label colors
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
    }
}
