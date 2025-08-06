namespace dvld
{
    partial class frmLocalDrivingLicenceInformation
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
            this.ctrlDrivingLicenceInformation1 = new dvld.ctrlDrivingLicenceInformation();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenceInformation1
            // 
            this.ctrlDrivingLicenceInformation1.Location = new System.Drawing.Point(0, 2);
            this.ctrlDrivingLicenceInformation1.Name = "ctrlDrivingLicenceInformation1";
            this.ctrlDrivingLicenceInformation1.Size = new System.Drawing.Size(900, 361);
            this.ctrlDrivingLicenceInformation1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::dvld.Properties.Resources.Close_32;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(763, 369);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmLocalDrivingLicenceInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 413);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ctrlDrivingLicenceInformation1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(917, 452);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(917, 452);
            this.Name = "frmLocalDrivingLicenceInformation";
            this.Text = "Local Driving Licence Information";
            this.Load += new System.EventHandler(this.frmLocalDrivingLicenceInformation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private ctrlDrivingLicenceInformation ctrlDrivingLicenceInformation1;
        private System.Windows.Forms.Button button1;
    }
}