namespace CriminalReportingSystem.Forms
{
    partial class CalculateRewards
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculateRewards));
            this.txtOfficer1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dtgViewRewardsRecord = new System.Windows.Forms.DataGridView();
            this.btnLogout = new System.Windows.Forms.PictureBox();
            this.btnHome = new System.Windows.Forms.PictureBox();
            this.btnSaveDB = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFineError = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cmbCrimeNumber = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtOfficer2 = new System.Windows.Forms.TextBox();
            this.txtAssistantCommissioner = new System.Windows.Forms.TextBox();
            this.txtFine = new System.Windows.Forms.TextBox();
            this.txtOIC = new System.Windows.Forms.TextBox();
            this.txtSuperintendant = new System.Windows.Forms.TextBox();
            this.txtOfficer1Reward = new System.Windows.Forms.TextBox();
            this.txtOfficer2Reward = new System.Windows.Forms.TextBox();
            this.txtAssistantCommissionerReward = new System.Windows.Forms.TextBox();
            this.txtSuperintendantReward = new System.Windows.Forms.TextBox();
            this.txtOICReward = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewRewardsRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOfficer1
            // 
            this.txtOfficer1.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOfficer1.Location = new System.Drawing.Point(278, 124);
            this.txtOfficer1.Name = "txtOfficer1";
            this.txtOfficer1.ReadOnly = true;
            this.txtOfficer1.Size = new System.Drawing.Size(212, 27);
            this.txtOfficer1.TabIndex = 117;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(55, 180);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 18);
            this.label7.TabIndex = 112;
            this.label7.Text = "Officer 2";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtgViewRewardsRecord
            // 
            this.dtgViewRewardsRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgViewRewardsRecord.Location = new System.Drawing.Point(944, 85);
            this.dtgViewRewardsRecord.Name = "dtgViewRewardsRecord";
            this.dtgViewRewardsRecord.RowHeadersWidth = 51;
            this.dtgViewRewardsRecord.RowTemplate.Height = 24;
            this.dtgViewRewardsRecord.Size = new System.Drawing.Size(937, 691);
            this.dtgViewRewardsRecord.TabIndex = 111;
            // 
            // btnLogout
            // 
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(1816, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(65, 64);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLogout.TabIndex = 110;
            this.btnLogout.TabStop = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnHome
            // 
            this.btnHome.Image = ((System.Drawing.Image)(resources.GetObject("btnHome.Image")));
            this.btnHome.Location = new System.Drawing.Point(1735, 12);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(75, 64);
            this.btnHome.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnHome.TabIndex = 109;
            this.btnHome.TabStop = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnSaveDB
            // 
            this.btnSaveDB.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveDB.Location = new System.Drawing.Point(502, 490);
            this.btnSaveDB.Name = "btnSaveDB";
            this.btnSaveDB.Size = new System.Drawing.Size(177, 31);
            this.btnSaveDB.TabIndex = 106;
            this.btnSaveDB.Text = "Save to Database";
            this.btnSaveDB.UseVisualStyleBackColor = true;
            this.btnSaveDB.Click += new System.EventHandler(this.btnSaveDB_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(268, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(185, 31);
            this.btnSave.TabIndex = 105;
            this.btnSave.Text = "Calculate Reward";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFineError
            // 
            this.lblFineError.AutoSize = true;
            this.lblFineError.ForeColor = System.Drawing.Color.Red;
            this.lblFineError.Location = new System.Drawing.Point(533, 572);
            this.lblFineError.Name = "lblFineError";
            this.lblFineError.Size = new System.Drawing.Size(0, 16);
            this.lblFineError.TabIndex = 104;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(55, 296);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(215, 18);
            this.label12.TabIndex = 95;
            this.label12.Text = "Superintendent of Excise ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbCrimeNumber
            // 
            this.cmbCrimeNumber.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCrimeNumber.FormattingEnabled = true;
            this.cmbCrimeNumber.Items.AddRange(new object[] {
            "PUDS",
            "USFL",
            "USA",
            "UPG",
            "UMA",
            "UPA,UTA",
            "UST"});
            this.cmbCrimeNumber.Location = new System.Drawing.Point(278, 79);
            this.cmbCrimeNumber.Name = "cmbCrimeNumber";
            this.cmbCrimeNumber.Size = new System.Drawing.Size(174, 26);
            this.cmbCrimeNumber.TabIndex = 86;
            this.cmbCrimeNumber.SelectedIndexChanged += new System.EventHandler(this.cmbCrimeNumber_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(55, 406);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(43, 18);
            this.label9.TabIndex = 83;
            this.label9.Text = "Fine";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(55, 349);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 18);
            this.label8.TabIndex = 82;
            this.label8.Text = "Officer In Charge";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(55, 240);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(201, 18);
            this.label6.TabIndex = 81;
            this.label6.Text = "Assistant Commissioner";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(55, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 18);
            this.label4.TabIndex = 79;
            this.label4.Text = "Officer 1";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(55, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 18);
            this.label3.TabIndex = 78;
            this.label3.Text = "Select Crime Number";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(409, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(265, 30);
            this.label1.TabIndex = 77;
            this.label1.Text = "Rewards Calculation";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtOfficer2
            // 
            this.txtOfficer2.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOfficer2.Location = new System.Drawing.Point(278, 171);
            this.txtOfficer2.Name = "txtOfficer2";
            this.txtOfficer2.ReadOnly = true;
            this.txtOfficer2.Size = new System.Drawing.Size(212, 27);
            this.txtOfficer2.TabIndex = 118;
            // 
            // txtAssistantCommissioner
            // 
            this.txtAssistantCommissioner.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssistantCommissioner.Location = new System.Drawing.Point(278, 231);
            this.txtAssistantCommissioner.Name = "txtAssistantCommissioner";
            this.txtAssistantCommissioner.ReadOnly = true;
            this.txtAssistantCommissioner.Size = new System.Drawing.Size(212, 27);
            this.txtAssistantCommissioner.TabIndex = 119;
            // 
            // txtFine
            // 
            this.txtFine.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFine.Location = new System.Drawing.Point(278, 397);
            this.txtFine.Name = "txtFine";
            this.txtFine.ReadOnly = true;
            this.txtFine.Size = new System.Drawing.Size(174, 27);
            this.txtFine.TabIndex = 122;
            // 
            // txtOIC
            // 
            this.txtOIC.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOIC.Location = new System.Drawing.Point(278, 340);
            this.txtOIC.Name = "txtOIC";
            this.txtOIC.ReadOnly = true;
            this.txtOIC.Size = new System.Drawing.Size(212, 27);
            this.txtOIC.TabIndex = 121;
            // 
            // txtSuperintendant
            // 
            this.txtSuperintendant.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuperintendant.Location = new System.Drawing.Point(278, 287);
            this.txtSuperintendant.Name = "txtSuperintendant";
            this.txtSuperintendant.ReadOnly = true;
            this.txtSuperintendant.Size = new System.Drawing.Size(212, 27);
            this.txtSuperintendant.TabIndex = 120;
            // 
            // txtOfficer1Reward
            // 
            this.txtOfficer1Reward.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOfficer1Reward.Location = new System.Drawing.Point(526, 124);
            this.txtOfficer1Reward.Name = "txtOfficer1Reward";
            this.txtOfficer1Reward.ReadOnly = true;
            this.txtOfficer1Reward.Size = new System.Drawing.Size(174, 27);
            this.txtOfficer1Reward.TabIndex = 123;
            // 
            // txtOfficer2Reward
            // 
            this.txtOfficer2Reward.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOfficer2Reward.Location = new System.Drawing.Point(526, 171);
            this.txtOfficer2Reward.Name = "txtOfficer2Reward";
            this.txtOfficer2Reward.ReadOnly = true;
            this.txtOfficer2Reward.Size = new System.Drawing.Size(174, 27);
            this.txtOfficer2Reward.TabIndex = 124;
            // 
            // txtAssistantCommissionerReward
            // 
            this.txtAssistantCommissionerReward.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAssistantCommissionerReward.Location = new System.Drawing.Point(526, 231);
            this.txtAssistantCommissionerReward.Name = "txtAssistantCommissionerReward";
            this.txtAssistantCommissionerReward.ReadOnly = true;
            this.txtAssistantCommissionerReward.Size = new System.Drawing.Size(174, 27);
            this.txtAssistantCommissionerReward.TabIndex = 125;
            // 
            // txtSuperintendantReward
            // 
            this.txtSuperintendantReward.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSuperintendantReward.Location = new System.Drawing.Point(526, 287);
            this.txtSuperintendantReward.Name = "txtSuperintendantReward";
            this.txtSuperintendantReward.ReadOnly = true;
            this.txtSuperintendantReward.Size = new System.Drawing.Size(174, 27);
            this.txtSuperintendantReward.TabIndex = 126;
            // 
            // txtOICReward
            // 
            this.txtOICReward.Font = new System.Drawing.Font("Mongolian Baiti", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOICReward.Location = new System.Drawing.Point(526, 340);
            this.txtOICReward.Name = "txtOICReward";
            this.txtOICReward.ReadOnly = true;
            this.txtOICReward.Size = new System.Drawing.Size(174, 27);
            this.txtOICReward.TabIndex = 127;
            // 
            // CalculateRewards
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1903, 886);
            this.Controls.Add(this.txtOICReward);
            this.Controls.Add(this.txtSuperintendantReward);
            this.Controls.Add(this.txtAssistantCommissionerReward);
            this.Controls.Add(this.txtOfficer2Reward);
            this.Controls.Add(this.txtOfficer1Reward);
            this.Controls.Add(this.txtFine);
            this.Controls.Add(this.txtOIC);
            this.Controls.Add(this.txtSuperintendant);
            this.Controls.Add(this.txtAssistantCommissioner);
            this.Controls.Add(this.txtOfficer2);
            this.Controls.Add(this.txtOfficer1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtgViewRewardsRecord);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnHome);
            this.Controls.Add(this.btnSaveDB);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblFineError);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmbCrimeNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "CalculateRewards";
            this.Text = "CalculateRewards";
            this.Load += new System.EventHandler(this.CalculateRewards_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewRewardsRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOfficer1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dtgViewRewardsRecord;
        private System.Windows.Forms.PictureBox btnLogout;
        private System.Windows.Forms.PictureBox btnHome;
        private System.Windows.Forms.Button btnSaveDB;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFineError;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmbCrimeNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOfficer2;
        private System.Windows.Forms.TextBox txtAssistantCommissioner;
        private System.Windows.Forms.TextBox txtFine;
        private System.Windows.Forms.TextBox txtOIC;
        private System.Windows.Forms.TextBox txtSuperintendant;
        private System.Windows.Forms.TextBox txtOfficer1Reward;
        private System.Windows.Forms.TextBox txtOfficer2Reward;
        private System.Windows.Forms.TextBox txtAssistantCommissionerReward;
        private System.Windows.Forms.TextBox txtSuperintendantReward;
        private System.Windows.Forms.TextBox txtOICReward;
    }
}