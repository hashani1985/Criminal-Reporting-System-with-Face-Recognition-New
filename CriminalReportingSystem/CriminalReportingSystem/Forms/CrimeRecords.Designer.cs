namespace CriminalReportingSystem.Forms
{
    partial class CrimeRecords
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrimeRecords));
            this.label1 = new System.Windows.Forms.Label();
            this.txtOffender = new System.Windows.Forms.TextBox();
            this.txtFine = new System.Windows.Forms.TextBox();
            this.txtOIC = new System.Windows.Forms.TextBox();
            this.txtPlace = new System.Windows.Forms.TextBox();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.cmbCrimeType = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOfficer1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOfficer2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.listOffenderSuggessions = new System.Windows.Forms.ListBox();
            this.txtAssCommissioner = new System.Windows.Forms.TextBox();
            this.txtSuperintendant = new System.Windows.Forms.TextBox();
            this.listOfficer1 = new System.Windows.Forms.ListBox();
            this.listOfficer2 = new System.Windows.Forms.ListBox();
            this.listACSuggessions = new System.Windows.Forms.ListBox();
            this.listSESuggessions = new System.Windows.Forms.ListBox();
            this.listOICSuggessions = new System.Windows.Forms.ListBox();
            this.lblFineError = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.dtgViewCrimeRecord = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.OffenceDate = new System.Windows.Forms.DateTimePicker();
            this.label14 = new System.Windows.Forms.Label();
            this.txtUnit = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewCrimeRecord)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(446, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(194, 30);
            this.label1.TabIndex = 23;
            this.label1.Text = "Crime Records";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOffender
            // 
            this.txtOffender.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOffender.Location = new System.Drawing.Point(305, 399);
            this.txtOffender.Name = "txtOffender";
            this.txtOffender.Size = new System.Drawing.Size(321, 27);
            this.txtOffender.TabIndex = 50;
            this.txtOffender.TextChanged += new System.EventHandler(this.txtOffender_TextChanged);
            // 
            // txtFine
            // 
            this.txtFine.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFine.Location = new System.Drawing.Point(292, 733);
            this.txtFine.Name = "txtFine";
            this.txtFine.Size = new System.Drawing.Size(252, 27);
            this.txtFine.TabIndex = 48;
            this.txtFine.TextChanged += new System.EventHandler(this.txtFine_TextChanged);
            // 
            // txtOIC
            // 
            this.txtOIC.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOIC.Location = new System.Drawing.Point(292, 682);
            this.txtOIC.Name = "txtOIC";
            this.txtOIC.Size = new System.Drawing.Size(321, 27);
            this.txtOIC.TabIndex = 47;
            this.txtOIC.TextChanged += new System.EventHandler(this.txtOIC_TextChanged);
            // 
            // txtPlace
            // 
            this.txtPlace.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlace.Location = new System.Drawing.Point(305, 346);
            this.txtPlace.Name = "txtPlace";
            this.txtPlace.Size = new System.Drawing.Size(321, 27);
            this.txtPlace.TabIndex = 45;
            // 
            // txtAmount
            // 
            this.txtAmount.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmount.Location = new System.Drawing.Point(305, 121);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(186, 27);
            this.txtAmount.TabIndex = 44;
            // 
            // cmbCrimeType
            // 
            this.cmbCrimeType.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCrimeType.FormattingEnabled = true;
            this.cmbCrimeType.Items.AddRange(new object[] {
            "PUDS",
            "USFL",
            "USA",
            "UPG",
            "UMA",
            "UPA,UTA",
            "UST"});
            this.cmbCrimeType.Location = new System.Drawing.Point(305, 76);
            this.cmbCrimeType.Name = "cmbCrimeType";
            this.cmbCrimeType.Size = new System.Drawing.Size(442, 26);
            this.cmbCrimeType.TabIndex = 43;
            this.cmbCrimeType.SelectedIndexChanged += new System.EventHandler(this.cmbCrimeType_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.White;
            this.label11.Location = new System.Drawing.Point(92, 402);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(80, 18);
            this.label11.TabIndex = 41;
            this.label11.Text = "Offender";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(92, 352);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 18);
            this.label10.TabIndex = 40;
            this.label10.Text = "Place of Offence";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(92, 742);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 18);
            this.label9.TabIndex = 39;
            this.label9.Text = "Fine";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(92, 682);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 18);
            this.label8.TabIndex = 38;
            this.label8.Text = "Officer In Charge";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(92, 573);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 18);
            this.label6.TabIndex = 36;
            this.label6.Text = "Assistant Commissioner";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(92, 460);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 18);
            this.label5.TabIndex = 35;
            this.label5.Text = "Officer1";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(92, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 18);
            this.label4.TabIndex = 34;
            this.label4.Text = "Amount";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(92, 76);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 18);
            this.label3.TabIndex = 33;
            this.label3.Text = "Type";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOfficer1
            // 
            this.txtOfficer1.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOfficer1.Location = new System.Drawing.Point(305, 451);
            this.txtOfficer1.Name = "txtOfficer1";
            this.txtOfficer1.Size = new System.Drawing.Size(186, 27);
            this.txtOfficer1.TabIndex = 51;
            this.txtOfficer1.TextChanged += new System.EventHandler(this.txtOfficer1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(92, 513);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 18);
            this.label2.TabIndex = 52;
            this.label2.Text = "Officer2";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOfficer2
            // 
            this.txtOfficer2.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOfficer2.Location = new System.Drawing.Point(305, 513);
            this.txtOfficer2.Name = "txtOfficer2";
            this.txtOfficer2.Size = new System.Drawing.Size(186, 27);
            this.txtOfficer2.TabIndex = 53;
            this.txtOfficer2.TextChanged += new System.EventHandler(this.txtOfficer2_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(92, 629);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 18);
            this.label12.TabIndex = 54;
            this.label12.Text = "Superintendent of Excise ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listOffenderSuggessions
            // 
            this.listOffenderSuggessions.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOffenderSuggessions.ForeColor = System.Drawing.Color.Black;
            this.listOffenderSuggessions.FormattingEnabled = true;
            this.listOffenderSuggessions.ItemHeight = 18;
            this.listOffenderSuggessions.Location = new System.Drawing.Point(696, 390);
            this.listOffenderSuggessions.Name = "listOffenderSuggessions";
            this.listOffenderSuggessions.Size = new System.Drawing.Size(269, 40);
            this.listOffenderSuggessions.TabIndex = 55;
            this.listOffenderSuggessions.SelectedIndexChanged += new System.EventHandler(this.listOffenderSuggessions_SelectedIndexChanged);
            // 
            // txtAssCommissioner
            // 
            this.txtAssCommissioner.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssCommissioner.Location = new System.Drawing.Point(305, 564);
            this.txtAssCommissioner.Name = "txtAssCommissioner";
            this.txtAssCommissioner.Size = new System.Drawing.Size(186, 27);
            this.txtAssCommissioner.TabIndex = 56;
            this.txtAssCommissioner.TextChanged += new System.EventHandler(this.txtAssCommissioner_TextChanged);
            // 
            // txtSuperintendant
            // 
            this.txtSuperintendant.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuperintendant.Location = new System.Drawing.Point(305, 620);
            this.txtSuperintendant.Name = "txtSuperintendant";
            this.txtSuperintendant.Size = new System.Drawing.Size(186, 27);
            this.txtSuperintendant.TabIndex = 57;
            this.txtSuperintendant.TextChanged += new System.EventHandler(this.txtSuperintendant_TextChanged);
            // 
            // listOfficer1
            // 
            this.listOfficer1.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOfficer1.ForeColor = System.Drawing.Color.Black;
            this.listOfficer1.FormattingEnabled = true;
            this.listOfficer1.ItemHeight = 18;
            this.listOfficer1.Location = new System.Drawing.Point(696, 451);
            this.listOfficer1.Name = "listOfficer1";
            this.listOfficer1.Size = new System.Drawing.Size(269, 40);
            this.listOfficer1.TabIndex = 58;
            this.listOfficer1.SelectedIndexChanged += new System.EventHandler(this.listOfficer1_SelectedIndexChanged);
            // 
            // listOfficer2
            // 
            this.listOfficer2.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOfficer2.ForeColor = System.Drawing.Color.Black;
            this.listOfficer2.FormattingEnabled = true;
            this.listOfficer2.ItemHeight = 18;
            this.listOfficer2.Location = new System.Drawing.Point(696, 513);
            this.listOfficer2.Name = "listOfficer2";
            this.listOfficer2.Size = new System.Drawing.Size(269, 40);
            this.listOfficer2.TabIndex = 59;
            this.listOfficer2.SelectedIndexChanged += new System.EventHandler(this.listOfficer2_SelectedIndexChanged);
            // 
            // listACSuggessions
            // 
            this.listACSuggessions.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listACSuggessions.ForeColor = System.Drawing.Color.Black;
            this.listACSuggessions.FormattingEnabled = true;
            this.listACSuggessions.ItemHeight = 18;
            this.listACSuggessions.Location = new System.Drawing.Point(696, 573);
            this.listACSuggessions.Name = "listACSuggessions";
            this.listACSuggessions.Size = new System.Drawing.Size(269, 40);
            this.listACSuggessions.TabIndex = 60;
            this.listACSuggessions.SelectedIndexChanged += new System.EventHandler(this.listACSuggessions_SelectedIndexChanged);
            // 
            // listSESuggessions
            // 
            this.listSESuggessions.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listSESuggessions.ForeColor = System.Drawing.Color.Black;
            this.listSESuggessions.FormattingEnabled = true;
            this.listSESuggessions.ItemHeight = 18;
            this.listSESuggessions.Location = new System.Drawing.Point(696, 629);
            this.listSESuggessions.Name = "listSESuggessions";
            this.listSESuggessions.Size = new System.Drawing.Size(269, 40);
            this.listSESuggessions.TabIndex = 61;
            this.listSESuggessions.SelectedIndexChanged += new System.EventHandler(this.listSESuggessions_SelectedIndexChanged);
            // 
            // listOICSuggessions
            // 
            this.listOICSuggessions.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOICSuggessions.ForeColor = System.Drawing.Color.Black;
            this.listOICSuggessions.FormattingEnabled = true;
            this.listOICSuggessions.ItemHeight = 18;
            this.listOICSuggessions.Location = new System.Drawing.Point(696, 682);
            this.listOICSuggessions.Name = "listOICSuggessions";
            this.listOICSuggessions.Size = new System.Drawing.Size(269, 40);
            this.listOICSuggessions.TabIndex = 62;
            this.listOICSuggessions.SelectedIndexChanged += new System.EventHandler(this.listOICSuggessions_SelectedIndexChanged);
            // 
            // lblFineError
            // 
            this.lblFineError.AutoSize = true;
            this.lblFineError.ForeColor = System.Drawing.Color.Red;
            this.lblFineError.Location = new System.Drawing.Point(570, 569);
            this.lblFineError.Name = "lblFineError";
            this.lblFineError.Size = new System.Drawing.Size(0, 16);
            this.lblFineError.TabIndex = 63;
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(650, 816);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(101, 31);
            this.btnClear.TabIndex = 67;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(533, 816);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(101, 31);
            this.btnDelete.TabIndex = 66;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(410, 816);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(101, 31);
            this.btnUpdate.TabIndex = 65;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(292, 816);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(101, 31);
            this.btnSave.TabIndex = 64;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(1830, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(65, 64);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLogout.TabIndex = 69;
            this.btnLogout.TabStop = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(1749, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 64);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 68;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // dtgViewCrimeRecord
            // 
            this.dtgViewCrimeRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgViewCrimeRecord.Location = new System.Drawing.Point(981, 82);
            this.dtgViewCrimeRecord.Name = "dtgViewCrimeRecord";
            this.dtgViewCrimeRecord.RowHeadersWidth = 51;
            this.dtgViewCrimeRecord.RowTemplate.Height = 24;
            this.dtgViewCrimeRecord.Size = new System.Drawing.Size(918, 691);
            this.dtgViewCrimeRecord.TabIndex = 70;
            this.dtgViewCrimeRecord.SelectionChanged += new System.EventHandler(this.dtgViewCrimeRecord_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(92, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(102, 18);
            this.label7.TabIndex = 71;
            this.label7.Text = "Description";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(305, 173);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(442, 95);
            this.txtDescription.TabIndex = 72;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(92, 301);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 18);
            this.label13.TabIndex = 73;
            this.label13.Text = "Date of Offence";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OffenceDate
            // 
            this.OffenceDate.Location = new System.Drawing.Point(305, 301);
            this.OffenceDate.Name = "OffenceDate";
            this.OffenceDate.Size = new System.Drawing.Size(200, 22);
            this.OffenceDate.TabIndex = 74;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.White;
            this.label14.Location = new System.Drawing.Point(519, 130);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(43, 18);
            this.label14.TabIndex = 75;
            this.label14.Text = "Unit";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUnit
            // 
            this.txtUnit.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUnit.Location = new System.Drawing.Point(573, 118);
            this.txtUnit.Name = "txtUnit";
            this.txtUnit.ReadOnly = true;
            this.txtUnit.Size = new System.Drawing.Size(174, 27);
            this.txtUnit.TabIndex = 76;
            // 
            // CrimeRecords
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1924, 833);
            this.Controls.Add(this.txtUnit);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.OffenceDate);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtgViewCrimeRecord);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblFineError);
            this.Controls.Add(this.listOICSuggessions);
            this.Controls.Add(this.listSESuggessions);
            this.Controls.Add(this.listACSuggessions);
            this.Controls.Add(this.listOfficer2);
            this.Controls.Add(this.listOfficer1);
            this.Controls.Add(this.txtSuperintendant);
            this.Controls.Add(this.txtAssCommissioner);
            this.Controls.Add(this.listOffenderSuggessions);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtOfficer2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOfficer1);
            this.Controls.Add(this.txtOffender);
            this.Controls.Add(this.txtFine);
            this.Controls.Add(this.txtOIC);
            this.Controls.Add(this.txtPlace);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.cmbCrimeType);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "CrimeRecords";
            this.Text = "CrimeRecords";
            this.Load += new System.EventHandler(this.CrimeRecords_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewCrimeRecord)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOffender;
        private System.Windows.Forms.TextBox txtFine;
        private System.Windows.Forms.TextBox txtOIC;
        private System.Windows.Forms.TextBox txtPlace;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.ComboBox cmbCrimeType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOfficer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOfficer2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listOffenderSuggessions;
        private System.Windows.Forms.TextBox txtAssCommissioner;
        private System.Windows.Forms.TextBox txtSuperintendant;
        private System.Windows.Forms.ListBox listOfficer1;
        private System.Windows.Forms.ListBox listOfficer2;
        private System.Windows.Forms.ListBox listACSuggessions;
        private System.Windows.Forms.ListBox listSESuggessions;
        private System.Windows.Forms.ListBox listOICSuggessions;
        private System.Windows.Forms.Label lblFineError;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox btnLogout;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.DataGridView dtgViewCrimeRecord;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DateTimePicker OffenceDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtUnit;
    }
}