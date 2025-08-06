namespace dvld
{
    partial class frmLicenseHistory
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.ctrlPersonCartWithFilterControl1 = new dvld.CtrlPersonCartWithFilterControl();
            this.ctrlDriverLicensesControl1 = new dvld.ctrlDriverLicensesControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(12, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(808, 74);
            this.lblTitle.TabIndex = 130;
            this.lblTitle.Text = "License History";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlPersonCartWithFilterControl1
            // 
            this.ctrlPersonCartWithFilterControl1.FilterEnabled = true;
            this.ctrlPersonCartWithFilterControl1.Location = new System.Drawing.Point(12, 86);
            this.ctrlPersonCartWithFilterControl1.Name = "ctrlPersonCartWithFilterControl1";
            this.ctrlPersonCartWithFilterControl1.ShowAddPerson = true;
            this.ctrlPersonCartWithFilterControl1.Size = new System.Drawing.Size(808, 441);
            this.ctrlPersonCartWithFilterControl1.TabIndex = 131;
            this.ctrlPersonCartWithFilterControl1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCartWithFilterControl1_OnPersonSelected);
            // 
            // ctrlDriverLicensesControl1
            // 
            this.ctrlDriverLicensesControl1.Location = new System.Drawing.Point(12, 527);
            this.ctrlDriverLicensesControl1.Name = "ctrlDriverLicensesControl1";
            this.ctrlDriverLicensesControl1.Size = new System.Drawing.Size(1066, 342);
            this.ctrlDriverLicensesControl1.TabIndex = 132;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::dvld.Properties.Resources.Local_Driving_License_5121;
            this.pictureBox1.Location = new System.Drawing.Point(826, 255);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(280, 266);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 133;
            this.pictureBox1.TabStop = false;
            // 
            // frmLicenseHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 881);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.ctrlDriverLicensesControl1);
            this.Controls.Add(this.ctrlPersonCartWithFilterControl1);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1124, 920);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1124, 858);
            this.Name = "frmLicenseHistory";
            this.Text = "License History";
            this.Load += new System.EventHandler(this.frmLicenseHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private CtrlPersonCartWithFilterControl ctrlPersonCartWithFilterControl1;
        private ctrlDriverLicensesControl ctrlDriverLicensesControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}