namespace dvld
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.drivingLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalDrivingLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivngLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewLocalDrivngLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewInternationalDrivingLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.replacmentDamegedOrLostLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.relaeseDetainedDrivingLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.retakeTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDetainedLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicecnceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.releaseDetainedLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageTestTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.internationalLicenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewInternationalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageInternationalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip2
            // 
            this.menuStrip2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1292, 40);
            this.menuStrip2.TabIndex = 1;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.drivingLicenceToolStripMenuItem,
            this.manageToolStripMenuItem,
            this.detainLicenceToolStripMenuItem,
            this.manageApplicationLicenceToolStripMenuItem,
            this.manageTestTypesToolStripMenuItem,
            this.internationalLicenceToolStripMenuItem});
            this.toolStripMenuItem1.Image = global::dvld.Properties.Resources.Applications;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(181, 36);
            this.toolStripMenuItem1.Text = "Application";
            // 
            // drivingLicenceToolStripMenuItem
            // 
            this.drivingLicenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicenceToolStripMenuItem,
            this.renewDrivngLicenceToolStripMenuItem,
            this.toolStripMenuItem7,
            this.replacmentDamegedOrLostLicenceToolStripMenuItem,
            this.toolStripMenuItem8,
            this.relaeseDetainedDrivingLicenceToolStripMenuItem,
            this.retakeTestToolStripMenuItem});
            this.drivingLicenceToolStripMenuItem.Image = global::dvld.Properties.Resources.Driver_License_48;
            this.drivingLicenceToolStripMenuItem.Name = "drivingLicenceToolStripMenuItem";
            this.drivingLicenceToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.drivingLicenceToolStripMenuItem.Text = "Driving Licence Service";
            this.drivingLicenceToolStripMenuItem.Click += new System.EventHandler(this.drivingLicenceToolStripMenuItem_Click);
            // 
            // newDrivingLicenceToolStripMenuItem
            // 
            this.newDrivingLicenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenceToolStripMenuItem,
            this.internationalDrivingLicenceToolStripMenuItem});
            this.newDrivingLicenceToolStripMenuItem.Name = "newDrivingLicenceToolStripMenuItem";
            this.newDrivingLicenceToolStripMenuItem.Size = new System.Drawing.Size(504, 36);
            this.newDrivingLicenceToolStripMenuItem.Text = "New Driving Licence";
            // 
            // localDrivingLicenceToolStripMenuItem
            // 
            this.localDrivingLicenceToolStripMenuItem.Name = "localDrivingLicenceToolStripMenuItem";
            this.localDrivingLicenceToolStripMenuItem.Size = new System.Drawing.Size(401, 36);
            this.localDrivingLicenceToolStripMenuItem.Text = "Local Driving Licence";
            this.localDrivingLicenceToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenceToolStripMenuItem_Click);
            // 
            // internationalDrivingLicenceToolStripMenuItem
            // 
            this.internationalDrivingLicenceToolStripMenuItem.Name = "internationalDrivingLicenceToolStripMenuItem";
            this.internationalDrivingLicenceToolStripMenuItem.Size = new System.Drawing.Size(401, 36);
            this.internationalDrivingLicenceToolStripMenuItem.Text = "International Driving Licence";
            this.internationalDrivingLicenceToolStripMenuItem.Click += new System.EventHandler(this.internationalDrivingLicenceToolStripMenuItem_Click);
            // 
            // renewDrivngLicenceToolStripMenuItem
            // 
            this.renewDrivngLicenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renewLocalDrivngLicenceToolStripMenuItem,
            this.renewInternationalDrivingLicenceToolStripMenuItem});
            this.renewDrivngLicenceToolStripMenuItem.Name = "renewDrivngLicenceToolStripMenuItem";
            this.renewDrivngLicenceToolStripMenuItem.Size = new System.Drawing.Size(504, 36);
            this.renewDrivngLicenceToolStripMenuItem.Text = "Renew Drivng Licence";
            // 
            // renewLocalDrivngLicenceToolStripMenuItem
            // 
            this.renewLocalDrivngLicenceToolStripMenuItem.Name = "renewLocalDrivngLicenceToolStripMenuItem";
            this.renewLocalDrivngLicenceToolStripMenuItem.Size = new System.Drawing.Size(480, 36);
            this.renewLocalDrivngLicenceToolStripMenuItem.Text = "Renew Local Drivng Licence";
            this.renewLocalDrivngLicenceToolStripMenuItem.Click += new System.EventHandler(this.renewLocalDrivngLicenceToolStripMenuItem_Click);
            // 
            // renewInternationalDrivingLicenceToolStripMenuItem
            // 
            this.renewInternationalDrivingLicenceToolStripMenuItem.Name = "renewInternationalDrivingLicenceToolStripMenuItem";
            this.renewInternationalDrivingLicenceToolStripMenuItem.Size = new System.Drawing.Size(480, 36);
            this.renewInternationalDrivingLicenceToolStripMenuItem.Text = "Renew International Driving Licence";
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(501, 6);
            // 
            // replacmentDamegedOrLostLicenceToolStripMenuItem
            // 
            this.replacmentDamegedOrLostLicenceToolStripMenuItem.Name = "replacmentDamegedOrLostLicenceToolStripMenuItem";
            this.replacmentDamegedOrLostLicenceToolStripMenuItem.Size = new System.Drawing.Size(504, 36);
            this.replacmentDamegedOrLostLicenceToolStripMenuItem.Text = "Replacment Lost or Dameged  Licence";
            this.replacmentDamegedOrLostLicenceToolStripMenuItem.Click += new System.EventHandler(this.replacmentDamegedOrLostLicenceToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(501, 6);
            // 
            // relaeseDetainedDrivingLicenceToolStripMenuItem
            // 
            this.relaeseDetainedDrivingLicenceToolStripMenuItem.Name = "relaeseDetainedDrivingLicenceToolStripMenuItem";
            this.relaeseDetainedDrivingLicenceToolStripMenuItem.Size = new System.Drawing.Size(504, 36);
            this.relaeseDetainedDrivingLicenceToolStripMenuItem.Text = "Relaese Detained Driving Licence";
            this.relaeseDetainedDrivingLicenceToolStripMenuItem.Click += new System.EventHandler(this.relaeseDetainedDrivingLicenceToolStripMenuItem_Click);
            // 
            // retakeTestToolStripMenuItem
            // 
            this.retakeTestToolStripMenuItem.Name = "retakeTestToolStripMenuItem";
            this.retakeTestToolStripMenuItem.Size = new System.Drawing.Size(504, 36);
            this.retakeTestToolStripMenuItem.Text = "Retake Test";
            this.retakeTestToolStripMenuItem.Click += new System.EventHandler(this.retakeTestToolStripMenuItem_Click);
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Image = global::dvld.Properties.Resources.Applications;
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.manageToolStripMenuItem.Text = "Manage Application";
            this.manageToolStripMenuItem.Click += new System.EventHandler(this.manageToolStripMenuItem_Click);
            // 
            // detainLicenceToolStripMenuItem
            // 
            this.detainLicenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageDetainedLicenceToolStripMenuItem,
            this.detainLicecnceToolStripMenuItem,
            this.releaseDetainedLicenceToolStripMenuItem});
            this.detainLicenceToolStripMenuItem.Image = global::dvld.Properties.Resources.Detain_32;
            this.detainLicenceToolStripMenuItem.Name = "detainLicenceToolStripMenuItem";
            this.detainLicenceToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.detainLicenceToolStripMenuItem.Text = "Detain Licence";
            // 
            // manageDetainedLicenceToolStripMenuItem
            // 
            this.manageDetainedLicenceToolStripMenuItem.Name = "manageDetainedLicenceToolStripMenuItem";
            this.manageDetainedLicenceToolStripMenuItem.Size = new System.Drawing.Size(370, 36);
            this.manageDetainedLicenceToolStripMenuItem.Text = "Manage Detained Licence";
            this.manageDetainedLicenceToolStripMenuItem.Click += new System.EventHandler(this.manageDetainedLicenceToolStripMenuItem_Click);
            // 
            // detainLicecnceToolStripMenuItem
            // 
            this.detainLicecnceToolStripMenuItem.Name = "detainLicecnceToolStripMenuItem";
            this.detainLicecnceToolStripMenuItem.Size = new System.Drawing.Size(370, 36);
            this.detainLicecnceToolStripMenuItem.Text = "Detain Licecnce";
            this.detainLicecnceToolStripMenuItem.Click += new System.EventHandler(this.detainLicecnceToolStripMenuItem_Click);
            // 
            // releaseDetainedLicenceToolStripMenuItem
            // 
            this.releaseDetainedLicenceToolStripMenuItem.Name = "releaseDetainedLicenceToolStripMenuItem";
            this.releaseDetainedLicenceToolStripMenuItem.Size = new System.Drawing.Size(370, 36);
            this.releaseDetainedLicenceToolStripMenuItem.Text = "Release Detained Licence";
            this.releaseDetainedLicenceToolStripMenuItem.Click += new System.EventHandler(this.releaseDetainedLicenceToolStripMenuItem_Click);
            // 
            // manageApplicationLicenceToolStripMenuItem
            // 
            this.manageApplicationLicenceToolStripMenuItem.Image = global::dvld.Properties.Resources.Manage_Applications_64;
            this.manageApplicationLicenceToolStripMenuItem.Name = "manageApplicationLicenceToolStripMenuItem";
            this.manageApplicationLicenceToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.manageApplicationLicenceToolStripMenuItem.Text = "Manage Application Types";
            this.manageApplicationLicenceToolStripMenuItem.Click += new System.EventHandler(this.manageApplicationLicenceToolStripMenuItem_Click);
            // 
            // manageTestTypesToolStripMenuItem
            // 
            this.manageTestTypesToolStripMenuItem.Image = global::dvld.Properties.Resources.Test_Type_64;
            this.manageTestTypesToolStripMenuItem.Name = "manageTestTypesToolStripMenuItem";
            this.manageTestTypesToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.manageTestTypesToolStripMenuItem.Text = "Manage Test Types";
            this.manageTestTypesToolStripMenuItem.Click += new System.EventHandler(this.manageTestTypesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Image = global::dvld.Properties.Resources.users_alt;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(131, 36);
            this.toolStripMenuItem2.Text = "People";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::dvld.Properties.Resources.Drivers_64;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(134, 36);
            this.toolStripMenuItem3.Text = "Drivers";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::dvld.Properties.Resources.users_alt;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(117, 36);
            this.toolStripMenuItem4.Text = "Users";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.toolStripMenuItem6,
            this.signOutToolStripMenuItem});
            this.toolStripMenuItem5.Image = global::dvld.Properties.Resources.user_skill_gear;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(242, 36);
            this.toolStripMenuItem5.Text = "Account Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(279, 36);
            this.currentUserInfoToolStripMenuItem.Text = "Current User Info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(279, 36);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(276, 6);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(279, 36);
            this.signOutToolStripMenuItem.Text = "Sign out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "user-add.png");
            this.imageList1.Images.SetKeyName(1, "user-gear.png");
            this.imageList1.Images.SetKeyName(2, "users.png");
            this.imageList1.Images.SetKeyName(3, "users-alt.png");
            this.imageList1.Images.SetKeyName(4, "users-alt-white.png");
            this.imageList1.Images.SetKeyName(5, "user-skill-gear.png");
            // 
            // internationalLicenceToolStripMenuItem
            // 
            this.internationalLicenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewInternationalToolStripMenuItem,
            this.manageInternationalToolStripMenuItem});
            this.internationalLicenceToolStripMenuItem.Image = global::dvld.Properties.Resources.International_32;
            this.internationalLicenceToolStripMenuItem.Name = "internationalLicenceToolStripMenuItem";
            this.internationalLicenceToolStripMenuItem.Size = new System.Drawing.Size(391, 38);
            this.internationalLicenceToolStripMenuItem.Text = "International Licence";
            // 
            // addNewInternationalToolStripMenuItem
            // 
            this.addNewInternationalToolStripMenuItem.Name = "addNewInternationalToolStripMenuItem";
            this.addNewInternationalToolStripMenuItem.Size = new System.Drawing.Size(336, 36);
            this.addNewInternationalToolStripMenuItem.Text = "Add New International";
            this.addNewInternationalToolStripMenuItem.Click += new System.EventHandler(this.addNewInternationalToolStripMenuItem_Click);
            // 
            // manageInternationalToolStripMenuItem
            // 
            this.manageInternationalToolStripMenuItem.Name = "manageInternationalToolStripMenuItem";
            this.manageInternationalToolStripMenuItem.Size = new System.Drawing.Size(336, 36);
            this.manageInternationalToolStripMenuItem.Text = "Manage International";
            this.manageInternationalToolStripMenuItem.Click += new System.EventHandler(this.manageInternationalToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1292, 666);
            this.Controls.Add(this.menuStrip2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DVLD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem drivingLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageTestTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalDrivingLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivngLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewLocalDrivngLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewInternationalDrivingLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem replacmentDamegedOrLostLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem relaeseDetainedDrivingLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem retakeTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDetainedLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicecnceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem releaseDetainedLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalLicenceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewInternationalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageInternationalToolStripMenuItem;
    }
}

