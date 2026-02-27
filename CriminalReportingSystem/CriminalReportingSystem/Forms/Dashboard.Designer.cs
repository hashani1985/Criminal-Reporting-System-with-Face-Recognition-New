namespace CriminalReportingSystem.Forms
{
    partial class Dashboard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dashboard));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCrimeRecords = new System.Windows.Forms.Button();
            this.btnOffenderDataMgt = new System.Windows.Forms.Button();
            this.btnOfficialsDataMgt = new System.Windows.Forms.Button();
            this.btnRewadsMgt = new System.Windows.Forms.Button();
            this.btnReportsMgt = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Mongolian Baiti", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(353, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(484, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Criminal Reporting System";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Mongolian Baiti", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(255, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(656, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Assistant Commissioner of Excise Office  - Galle";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCrimeRecords
            // 
            this.btnCrimeRecords.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrimeRecords.Location = new System.Drawing.Point(201, 423);
            this.btnCrimeRecords.Name = "btnCrimeRecords";
            this.btnCrimeRecords.Size = new System.Drawing.Size(154, 89);
            this.btnCrimeRecords.TabIndex = 2;
            this.btnCrimeRecords.Text = "Crime Records Management";
            this.btnCrimeRecords.UseVisualStyleBackColor = true;
            this.btnCrimeRecords.Click += new System.EventHandler(this.btnCrimeRecords_Click);
            // 
            // btnOffenderDataMgt
            // 
            this.btnOffenderDataMgt.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOffenderDataMgt.Location = new System.Drawing.Point(377, 423);
            this.btnOffenderDataMgt.Name = "btnOffenderDataMgt";
            this.btnOffenderDataMgt.Size = new System.Drawing.Size(150, 89);
            this.btnOffenderDataMgt.TabIndex = 3;
            this.btnOffenderDataMgt.Text = "Offender Data Management";
            this.btnOffenderDataMgt.UseVisualStyleBackColor = true;
            this.btnOffenderDataMgt.Click += new System.EventHandler(this.btnOffenderDataMgt_Click);
            // 
            // btnOfficialsDataMgt
            // 
            this.btnOfficialsDataMgt.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOfficialsDataMgt.Location = new System.Drawing.Point(548, 423);
            this.btnOfficialsDataMgt.Name = "btnOfficialsDataMgt";
            this.btnOfficialsDataMgt.Size = new System.Drawing.Size(150, 89);
            this.btnOfficialsDataMgt.TabIndex = 4;
            this.btnOfficialsDataMgt.Text = "Officials Data Management";
            this.btnOfficialsDataMgt.UseVisualStyleBackColor = true;
            this.btnOfficialsDataMgt.Click += new System.EventHandler(this.btnOfficialsDataMgt_Click);
            // 
            // btnRewadsMgt
            // 
            this.btnRewadsMgt.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRewadsMgt.Location = new System.Drawing.Point(726, 423);
            this.btnRewadsMgt.Name = "btnRewadsMgt";
            this.btnRewadsMgt.Size = new System.Drawing.Size(150, 89);
            this.btnRewadsMgt.TabIndex = 5;
            this.btnRewadsMgt.Text = "Rewards Management";
            this.btnRewadsMgt.UseVisualStyleBackColor = true;
            this.btnRewadsMgt.Click += new System.EventHandler(this.btnRewadsMgt_Click);
            // 
            // btnReportsMgt
            // 
            this.btnReportsMgt.Font = new System.Drawing.Font("Mongolian Baiti", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReportsMgt.Location = new System.Drawing.Point(900, 423);
            this.btnReportsMgt.Name = "btnReportsMgt";
            this.btnReportsMgt.Size = new System.Drawing.Size(150, 89);
            this.btnReportsMgt.TabIndex = 6;
            this.btnReportsMgt.Text = "Reports Management";
            this.btnReportsMgt.UseVisualStyleBackColor = true;
            this.btnReportsMgt.Click += new System.EventHandler(this.btnReportsMgt_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(1118, 12);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(52, 46);
            this.btnLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnLogout.TabIndex = 32;
            this.btnLogout.TabStop = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1227, 620);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnReportsMgt);
            this.Controls.Add(this.btnRewadsMgt);
            this.Controls.Add(this.btnOfficialsDataMgt);
            this.Controls.Add(this.btnOffenderDataMgt);
            this.Controls.Add(this.btnCrimeRecords);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Dashboard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnLogout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCrimeRecords;
        private System.Windows.Forms.Button btnOffenderDataMgt;
        private System.Windows.Forms.Button btnOfficialsDataMgt;
        private System.Windows.Forms.Button btnRewadsMgt;
        private System.Windows.Forms.Button btnReportsMgt;
        private System.Windows.Forms.PictureBox btnLogout;
    }
}