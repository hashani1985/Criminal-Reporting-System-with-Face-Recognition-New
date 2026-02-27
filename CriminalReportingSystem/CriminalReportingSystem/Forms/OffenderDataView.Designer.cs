namespace CriminalReportingSystem.Forms
{
    partial class OffenderDataView
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
            this.dtgViewOffenderData = new System.Windows.Forms.DataGridView();
            this.lblOffenderId = new System.Windows.Forms.Label();
            this.btnFaceRecognition = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewOffenderData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgViewOffenderData
            // 
            this.dtgViewOffenderData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgViewOffenderData.Location = new System.Drawing.Point(88, 52);
            this.dtgViewOffenderData.Name = "dtgViewOffenderData";
            this.dtgViewOffenderData.RowHeadersWidth = 51;
            this.dtgViewOffenderData.RowTemplate.Height = 24;
            this.dtgViewOffenderData.Size = new System.Drawing.Size(623, 365);
            this.dtgViewOffenderData.TabIndex = 0;
            this.dtgViewOffenderData.SelectionChanged += new System.EventHandler(this.dtgViewOffenderData_SelectionChanged);
            // 
            // lblOffenderId
            // 
            this.lblOffenderId.AutoSize = true;
            this.lblOffenderId.Location = new System.Drawing.Point(85, 492);
            this.lblOffenderId.Name = "lblOffenderId";
            this.lblOffenderId.Size = new System.Drawing.Size(83, 16);
            this.lblOffenderId.TabIndex = 1;
            this.lblOffenderId.Text = "lblOffenderId";
            // 
            // btnFaceRecognition
            // 
            this.btnFaceRecognition.Location = new System.Drawing.Point(365, 498);
            this.btnFaceRecognition.Name = "btnFaceRecognition";
            this.btnFaceRecognition.Size = new System.Drawing.Size(179, 23);
            this.btnFaceRecognition.TabIndex = 2;
            this.btnFaceRecognition.Text = "Face Recognition";
            this.btnFaceRecognition.UseVisualStyleBackColor = true;
            this.btnFaceRecognition.Click += new System.EventHandler(this.btnFaceRecognition_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(805, 62);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(398, 484);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // OffenderDataView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 764);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnFaceRecognition);
            this.Controls.Add(this.lblOffenderId);
            this.Controls.Add(this.dtgViewOffenderData);
            this.Name = "OffenderDataView";
            this.Text = "OffenderDataView";
            this.Load += new System.EventHandler(this.OffenderDataView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgViewOffenderData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgViewOffenderData;
        private System.Windows.Forms.Label lblOffenderId;
        private System.Windows.Forms.Button btnFaceRecognition;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}