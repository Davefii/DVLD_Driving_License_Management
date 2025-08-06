namespace dvld
{
    partial class AddOrUpdateLocalDrivingLicenseApplication
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button3 = new System.Windows.Forms.Button();
            this.ctrlPersonCartWithFilterControl1 = new dvld.CtrlPersonCartWithFilterControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.labelforuser = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labelforfees = new System.Windows.Forms.Label();
            this.labelforApplicationID = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.labelforDate = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbltitle = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(1, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(824, 501);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.ctrlPersonCartWithFilterControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(816, 475);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Person Info";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.button3.Location = new System.Drawing.Point(726, 443);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "Next ->";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ctrlPersonCartWithFilterControl1
            // 
            this.ctrlPersonCartWithFilterControl1.FilterEnabled = true;
            this.ctrlPersonCartWithFilterControl1.Location = new System.Drawing.Point(5, 3);
            this.ctrlPersonCartWithFilterControl1.Name = "ctrlPersonCartWithFilterControl1";
            this.ctrlPersonCartWithFilterControl1.ShowAddPerson = true;
            this.ctrlPersonCartWithFilterControl1.Size = new System.Drawing.Size(808, 441);
            this.ctrlPersonCartWithFilterControl1.TabIndex = 0;
            this.ctrlPersonCartWithFilterControl1.OnPersonSelected += new System.Action<int>(this.ctrlPersonCartWithFilterControl1_OnPersonSelected);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.labelforuser);
            this.tabPage2.Controls.Add(this.label16);
            this.tabPage2.Controls.Add(this.labelforfees);
            this.tabPage2.Controls.Add(this.labelforApplicationID);
            this.tabPage2.Controls.Add(this.comboBox2);
            this.tabPage2.Controls.Add(this.label18);
            this.tabPage2.Controls.Add(this.labelforDate);
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.label21);
            this.tabPage2.Controls.Add(this.label20);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(816, 475);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Application Info";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // labelforuser
            // 
            this.labelforuser.AutoSize = true;
            this.labelforuser.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelforuser.Location = new System.Drawing.Point(384, 234);
            this.labelforuser.Name = "labelforuser";
            this.labelforuser.Size = new System.Drawing.Size(43, 21);
            this.labelforuser.TabIndex = 19;
            this.labelforuser.Text = "[???]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(202, 102);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(159, 21);
            this.label16.TabIndex = 10;
            this.label16.Text = "D, L Application ID :";
            // 
            // labelforfees
            // 
            this.labelforfees.AutoSize = true;
            this.labelforfees.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelforfees.Location = new System.Drawing.Point(384, 200);
            this.labelforfees.Name = "labelforfees";
            this.labelforfees.Size = new System.Drawing.Size(43, 21);
            this.labelforfees.TabIndex = 18;
            this.labelforfees.Text = "[???]";
            // 
            // labelforApplicationID
            // 
            this.labelforApplicationID.AutoSize = true;
            this.labelforApplicationID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelforApplicationID.Location = new System.Drawing.Point(384, 102);
            this.labelforApplicationID.Name = "labelforApplicationID";
            this.labelforApplicationID.Size = new System.Drawing.Size(43, 21);
            this.labelforApplicationID.TabIndex = 11;
            this.labelforApplicationID.Text = "[???]";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(388, 169);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(213, 21);
            this.comboBox2.TabIndex = 17;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(214, 136);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(147, 21);
            this.label18.TabIndex = 12;
            this.label18.Text = "Application Date :";
            // 
            // labelforDate
            // 
            this.labelforDate.AutoSize = true;
            this.labelforDate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelforDate.Location = new System.Drawing.Point(384, 136);
            this.labelforDate.Name = "labelforDate";
            this.labelforDate.Size = new System.Drawing.Size(110, 21);
            this.labelforDate.TabIndex = 16;
            this.labelforDate.Text = "dd/mm/yyyy";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(244, 166);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(117, 21);
            this.label19.TabIndex = 13;
            this.label19.Text = "Licence Class :";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(261, 234);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(100, 21);
            this.label21.TabIndex = 15;
            this.label21.Text = "Created By :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(224, 200);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(137, 21);
            this.label20.TabIndex = 14;
            this.label20.Text = "Application Fee :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = global::dvld.Properties.Resources.Save_32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(708, 581);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 38);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.button2.Image = global::dvld.Properties.Resources.Close_32;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(571, 581);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 38);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbltitle
            // 
            this.lbltitle.AutoSize = true;
            this.lbltitle.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltitle.Location = new System.Drawing.Point(172, 9);
            this.lbltitle.Name = "lbltitle";
            this.lbltitle.Size = new System.Drawing.Size(440, 40);
            this.lbltitle.TabIndex = 3;
            this.lbltitle.Text = "Add New Local Driving Licence";
            // 
            // AddOrUpdateLocalDrivingLicenseApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(825, 622);
            this.Controls.Add(this.lbltitle);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(841, 661);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(841, 661);
            this.Name = "AddOrUpdateLocalDrivingLicenseApplication";
            this.Text = "Add/Update Local Driving License Application";
            this.Activated += new System.EventHandler(this.AddOrUpdateLocalDrivingLicenseApplication_Activated);
            this.Load += new System.EventHandler(this.AddOrUpdateLocalDrivingLicenseApplication_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button2;
        private CtrlPersonCartWithFilterControl ctrlPersonCartWithFilterControl1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lbltitle;
        private System.Windows.Forms.Label labelforuser;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label labelforfees;
        private System.Windows.Forms.Label labelforApplicationID;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label labelforDate;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label20;
    }
}