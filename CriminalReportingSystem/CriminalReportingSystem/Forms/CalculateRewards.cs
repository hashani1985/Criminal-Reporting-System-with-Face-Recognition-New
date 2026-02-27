using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace CriminalReportingSystem.Forms
{
    public partial class CalculateRewards : Form
    {
        public string connectionString = "Data Source=DESKTOP-BU7QFI6\\SQLEXPRESS;Initial Catalog=CriminalReportingDB; Integrated Security=True";
        private SqlConnection sqlConnection;

        private DataSet dataSet;
        public string passedUserRole;

        public CalculateRewards()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ChangeLabelBgColor();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void CalculateRewards_Load(object sender, EventArgs e)
        {
            LoadCrimeIds();

            //---- load data to the datagrid view from the database
            try
            {
                // Create a DataTable to store the data
                DataTable dataTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to select data from the database table
                    string selectQuery = "SELECT * FROM Rewards";

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
                dtgViewRewardsRecord.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
//---- function to load crimeid to the combo box
        public void LoadCrimeIds()
        {
            // Clear existing items in the ComboBox
            cmbCrimeNumber.Items.Clear();

            // Create a new SqlConnection using the connection string
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT CrimeId FROM CrimeRecords";
                    SqlCommand command = new SqlCommand(query, connection);

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();

                    dataAdapter.Fill(dataTable);

                    // Assuming your ComboBox is named comboBox1
                    cmbCrimeNumber.DisplayMember = "CrimeId";
                    cmbCrimeNumber.ValueMember = "CrimeId"; // You can set this to a different column if needed
                    cmbCrimeNumber.DataSource = dataTable;
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

        //-------------- function to load other records to text boxes when a crimeid is selected from combo box
        private void LoadDataIntoTextBoxes(string selectedCrimeId)
        {
            

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Officer1Id, Officer2Id, AssistantCommissionerId, SuperintendantId, OICId, Fine FROM CrimeRecords WHERE CrimeId = @CrimeId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", selectedCrimeId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Assuming your TextBoxes are named textBox1, textBox2, etc.
                        string Officer1id = reader["Officer1Id"].ToString();
                        string Officer2id = reader["Officer2Id"].ToString();
                        string AssistantCommissionerId = reader["AssistantCommissionerId"].ToString();
                        string SuperintendantId = reader["SuperintendantId"].ToString();
                        string OICId = reader["OICId"].ToString();

                        //------------getting names with relevant ids to text boxes

                        txtOfficer1.Text=GetOfficer1Name(Officer1id);
                        txtOfficer2.Text=GetOfficer2Name(Officer2id);
                        txtAssistantCommissioner.Text=GetAssCommissionerName(AssistantCommissionerId);
                        txtSuperintendant.Text=GetSuperintendantName(SuperintendantId);
                        txtOIC.Text = GetOICName(OICId);
                        txtFine.Text= reader["Fine"].ToString();

                        // Add more lines for additional text boxes as needed
                    }
                    else
                    {
                        // Handle the case where no record is found for the selected CrimeID
                        MessageBox.Show("No data found for the selected CrimeID.");
                    }
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

       

        private void cmbCrimeNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Check if an item is selected in the ComboBox
            if (cmbCrimeNumber.SelectedItem != null)
            {
                // Assuming your ComboBox is bound to a DataTable with a CrimeID column
                string selectedCrimeId = ((DataRowView)cmbCrimeNumber.SelectedItem)["CrimeId"].ToString();

                // Call the method to load data into text boxes
                LoadDataIntoTextBoxes(selectedCrimeId);
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtFine.Text=="")
            {
                MessageBox.Show("Select a crime record", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                double fineAmount = Convert.ToDouble(txtFine.Text);
                double fineAmountforRewards = fineAmount * 0.25;
                CalculateRewardsFunction(fineAmountforRewards);
                
            }


        }

        //----------------function to calculate rewards--------
        public void CalculateRewardsFunction(double fine)
        {
            double fOfficer1 = 0.5 * fine;
            double fOfficer2= 0.25 * fine;
            double fAssCommissioner = 0.05 * fine;
            double fSuperintendant = 0.05 * fine;
            double fOIC = 0.15 * fine;

            txtOfficer1Reward.Text = Convert.ToString(fOfficer1);
            txtOfficer2Reward.Text = Convert.ToString(fOfficer2);
            txtAssistantCommissionerReward.Text=Convert.ToString(fAssCommissioner);
            txtSuperintendantReward.Text = Convert.ToString(fSuperintendant);
            txtOICReward.Text = Convert.ToString(fOIC);
        }

        private void btnSaveDB_Click(object sender, EventArgs e)
        {
            
                string selectedCrimeId = cmbCrimeNumber.Text;

                string Officer1Id = "";
                string Officer2Id = "";
                string AssistantCommissionerId = "";
                string SuperintendantId = "";
                string OICId = "";
                double Fine = Convert.ToDouble(txtFine.Text);
                double RewardOfficer1 = Convert.ToDouble(txtOfficer1Reward.Text);
                double RewardOfficer2 = Convert.ToDouble(txtOfficer2Reward.Text);
                double RewardAssistantCommmissioner = Convert.ToDouble(txtAssistantCommissionerReward.Text);
                double RewardSuperintendant = Convert.ToDouble(txtSuperintendantReward.Text);
                double RewardOIC = Convert.ToDouble(txtOICReward.Text);



            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT Officer1Id, Officer2Id, AssistantCommissionerId, SuperintendantId, OICId, Fine FROM CrimeRecords WHERE CrimeId = @CrimeId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", selectedCrimeId);

                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Assuming your TextBoxes are named textBox1, textBox2, etc.
                        Officer1Id = reader["Officer1Id"].ToString();
                        Officer2Id = reader["Officer2Id"].ToString();
                        AssistantCommissionerId = reader["AssistantCommissionerId"].ToString();
                        SuperintendantId = reader["SuperintendantId"].ToString();
                        OICId = reader["OICId"].ToString();

                    }
                    else
                    {
                        // Handle the case where no record is found for the selected CrimeID
                        MessageBox.Show("No data found for the selected CrimeID.");

                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
                //finally
                //{
                //    reader.Close();
                //}

                //----------------------------insertung data into rewards table
                // Check if NIC or name already exists in the database
                string selectedCrimeId1 = cmbCrimeNumber.Text;
                string customRewardId = GenerateCustomRewardID();

                // Check if the record already exists
                if (IsRewardRecordExists(selectedCrimeId1, customRewardId))
                {
                    MessageBox.Show("A record with the specified CrimeId and RewardId already exists.");
                    return; // Don't proceed with the insertion
                }

                else
                {
                    //string customRewardId = GenerateCustomRewardID();
                    string insertQuery = "INSERT INTO Rewards (RewardId,CrimeId,Officer1Id,Officer2Id,AssistantCommissionerId,SuperintendantId,OICId,Fine,RewardOfficer1, RewardOfficer2,RewardAssistantCommissioner, RewardSuperintendant, RewardOIC) VALUES (@RewardId,@CrimeId,@Officer1Id,@Officer2Id,@AssistantCommissionerId,@SuperintendantId,@OICId,@Fine,@RewardOfficer1, @RewardOfficer2,@RewardAssistantCommissioner, @RewardSuperintendant, @RewardOIC)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@RewardId", customRewardId);
                        command.Parameters.AddWithValue("@CrimeId", selectedCrimeId);
                        command.Parameters.AddWithValue("@Officer1Id", Officer1Id);
                        command.Parameters.AddWithValue("@Officer2Id", Officer2Id);
                        command.Parameters.AddWithValue("@AssistantCommissionerId", AssistantCommissionerId);
                        command.Parameters.AddWithValue("@SuperintendantId", SuperintendantId);
                        command.Parameters.AddWithValue("@OICId", OICId);
                        command.Parameters.AddWithValue("@Fine", Fine);
                        command.Parameters.AddWithValue("@RewardOfficer1", RewardOfficer1);
                        command.Parameters.AddWithValue("@RewardOfficer2", RewardOfficer2);
                        command.Parameters.AddWithValue("@RewardAssistantCommissioner", RewardAssistantCommmissioner);
                        command.Parameters.AddWithValue("@RewardSuperintendant", RewardSuperintendant);
                        command.Parameters.AddWithValue("@RewardOIC", RewardOIC);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Rewards data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Insertion failed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
                RefreshDataGridView();
                ClearForm();
           
        }

        //-------------------------------------- Generate custom Offender id ---------------------

        private string GenerateCustomRewardID()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectQuery = "SELECT MAX(CONVERT(INT, SUBSTRING(RewardId, 2, LEN(RewardId) - 1))) FROM Rewards";

                using (SqlCommand command = new SqlCommand(selectQuery, connection))
                {
                    object result = command.ExecuteScalar();
                    int nextNumericValue = 1; // Default if no existing records

                    if (result != DBNull.Value)
                    {
                        // If there are existing records, parse the numeric part and increment it
                        nextNumericValue = Convert.ToInt32(result) + 1;
                    }

                    string customOffenderID = "R" + nextNumericValue.ToString("D3");
                    return customOffenderID;
                }
            }
        }

        //-------------------------- refresh datagrid

        private void RefreshDataGridView()
        {
            DataTable dataTable = new DataTable();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();



                    // SQL query to select data from the database table
                    string selectQuery = "SELECT * FROM Rewards";

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
                dtgViewRewardsRecord.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");

            }

        }

        //--------------------------- clear form
        public void ClearForm()
        {
            cmbCrimeNumber.Text = string.Empty;
            txtOfficer1.Text = string.Empty;
            txtOfficer2.Text = string.Empty;
            txtAssistantCommissioner.Text = string.Empty;
            txtSuperintendant.Text = string.Empty;
            txtOIC.Text = string.Empty;
            txtOfficer1Reward.Text = string.Empty;
            txtOfficer2Reward.Text = string.Empty;
            txtAssistantCommissionerReward.Text = string.Empty;
            txtSuperintendantReward.Text = string.Empty;
            txtOICReward.Text = string.Empty;
            


        }

        //----------------------------  check same crime record's reward is inserted

        private bool IsRewardRecordExists(string crimeId, string rewardId)
        {
            bool recordExists = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Rewards WHERE CrimeId = @CrimeId ";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CrimeId", crimeId);
                    //command.Parameters.AddWithValue("@RewardId", rewardId);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    // If count is greater than 0, a record with the specified CrimeId and RewardId exists
                    recordExists = count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error checking for existing record: " + ex.Message);
                }
            }

            return recordExists;
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

        // --function to change label colors
        public void ChangeLabelBgColor()
        {
            label1.BackColor = Color.Transparent;
            //label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
            //label5.BackColor = Color.Transparent;
            label6.BackColor = Color.Transparent;
            label7.BackColor = Color.Transparent;
            label8.BackColor = Color.Transparent;
            label9.BackColor = Color.Transparent;
            //label10.BackColor = Color.Transparent;
            //label11.BackColor = Color.Transparent;
            label12.BackColor = Color.Transparent;
            //label13.BackColor = Color.Transparent;
            

        }
    }
}
