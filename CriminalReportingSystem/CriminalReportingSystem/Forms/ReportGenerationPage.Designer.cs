namespace CriminalReportingSystem.Forms
{
    partial class ReportGenerationPage
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
            this.cmbOfficerName = new System.Windows.Forms.ComboBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbOfficerName
            // 
            this.cmbOfficerName.FormattingEnabled = true;
            this.cmbOfficerName.Location = new System.Drawing.Point(328, 58);
            this.cmbOfficerName.Name = "cmbOfficerName";
            this.cmbOfficerName.Size = new System.Drawing.Size(287, 24);
            this.cmbOfficerName.TabIndex = 0;
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(405, 136);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(194, 23);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate Report";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // ReportGenerationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 479);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.cmbOfficerName);
            this.Name = "ReportGenerationPage";
            this.Text = "ReportGenerationPage";
            this.Load += new System.EventHandler(this.ReportGenerationPage_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOfficerName;
        private System.Windows.Forms.Button btnGenerate;
    }
}