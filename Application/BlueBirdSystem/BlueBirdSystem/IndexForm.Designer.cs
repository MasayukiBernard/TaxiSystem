namespace BlueBirdSystem
{
    partial class IndexForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driverToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pickupOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.masterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageDriversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageVehiclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageOrdersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageAdminsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usesPerServiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.favouriteVehiclesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalIncomeEarnedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyOfCompleteTripsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listOfCurrenltyOngoingTripsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.driverTripHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.customerToolStripMenuItem,
            this.driverToolStripMenuItem,
            this.masterToolStripMenuItem,
            this.reportToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1251, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.registerToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.loginToolStripMenuItem.Text = "Login";
            this.loginToolStripMenuItem.Click += new System.EventHandler(this.LoginToolStripMenuItem_Click);
            // 
            // registerToolStripMenuItem
            // 
            this.registerToolStripMenuItem.Name = "registerToolStripMenuItem";
            this.registerToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.registerToolStripMenuItem.Text = "Register";
            this.registerToolStripMenuItem.Click += new System.EventHandler(this.RegisterToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.ChangePasswordToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.LogoutToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.makeOrderToolStripMenuItem,
            this.finishOrderToolStripMenuItem});
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(86, 24);
            this.customerToolStripMenuItem.Text = "Customer";
            // 
            // makeOrderToolStripMenuItem
            // 
            this.makeOrderToolStripMenuItem.Name = "makeOrderToolStripMenuItem";
            this.makeOrderToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.makeOrderToolStripMenuItem.Text = "Make Order";
            this.makeOrderToolStripMenuItem.Click += new System.EventHandler(this.MakeOrderToolStripMenuItem_Click);
            // 
            // finishOrderToolStripMenuItem
            // 
            this.finishOrderToolStripMenuItem.Name = "finishOrderToolStripMenuItem";
            this.finishOrderToolStripMenuItem.Size = new System.Drawing.Size(171, 26);
            this.finishOrderToolStripMenuItem.Text = "Finish Order";
            this.finishOrderToolStripMenuItem.Click += new System.EventHandler(this.FinishOrderToolStripMenuItem_Click);
            // 
            // driverToolStripMenuItem
            // 
            this.driverToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pickupOrderToolStripMenuItem});
            this.driverToolStripMenuItem.Name = "driverToolStripMenuItem";
            this.driverToolStripMenuItem.Size = new System.Drawing.Size(63, 24);
            this.driverToolStripMenuItem.Text = "Driver";
            // 
            // pickupOrderToolStripMenuItem
            // 
            this.pickupOrderToolStripMenuItem.Name = "pickupOrderToolStripMenuItem";
            this.pickupOrderToolStripMenuItem.Size = new System.Drawing.Size(177, 26);
            this.pickupOrderToolStripMenuItem.Text = "Pickup Order";
            this.pickupOrderToolStripMenuItem.Click += new System.EventHandler(this.PickupOrderToolStripMenuItem_Click);
            // 
            // masterToolStripMenuItem
            // 
            this.masterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageCustomerToolStripMenuItem,
            this.manageDriversToolStripMenuItem,
            this.manageVehiclesToolStripMenuItem,
            this.manageOrdersToolStripMenuItem,
            this.manageAdminsToolStripMenuItem});
            this.masterToolStripMenuItem.Name = "masterToolStripMenuItem";
            this.masterToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.masterToolStripMenuItem.Text = "Master";
            // 
            // manageCustomerToolStripMenuItem
            // 
            this.manageCustomerToolStripMenuItem.Name = "manageCustomerToolStripMenuItem";
            this.manageCustomerToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.manageCustomerToolStripMenuItem.Text = "Manage Customers";
            this.manageCustomerToolStripMenuItem.Click += new System.EventHandler(this.ManageCustomerToolStripMenuItem_Click);
            // 
            // manageDriversToolStripMenuItem
            // 
            this.manageDriversToolStripMenuItem.Name = "manageDriversToolStripMenuItem";
            this.manageDriversToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.manageDriversToolStripMenuItem.Text = "Manage Drivers";
            this.manageDriversToolStripMenuItem.Click += new System.EventHandler(this.ManageDriversToolStripMenuItem_Click);
            // 
            // manageVehiclesToolStripMenuItem
            // 
            this.manageVehiclesToolStripMenuItem.Name = "manageVehiclesToolStripMenuItem";
            this.manageVehiclesToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.manageVehiclesToolStripMenuItem.Text = "Manage Vehicles";
            this.manageVehiclesToolStripMenuItem.Click += new System.EventHandler(this.ManageVehiclesToolStripMenuItem_Click);
            // 
            // manageOrdersToolStripMenuItem
            // 
            this.manageOrdersToolStripMenuItem.Name = "manageOrdersToolStripMenuItem";
            this.manageOrdersToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.manageOrdersToolStripMenuItem.Text = "View Orders";
            this.manageOrdersToolStripMenuItem.Click += new System.EventHandler(this.ViewOrdersToolStripMenuItem_Click);
            // 
            // manageAdminsToolStripMenuItem
            // 
            this.manageAdminsToolStripMenuItem.Name = "manageAdminsToolStripMenuItem";
            this.manageAdminsToolStripMenuItem.Size = new System.Drawing.Size(219, 26);
            this.manageAdminsToolStripMenuItem.Text = "Manage Admins";
            this.manageAdminsToolStripMenuItem.Click += new System.EventHandler(this.ManageAdminsToolStripMenuItem_Click);
            // 
            // reportToolStripMenuItem
            // 
            this.reportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usesPerServiceToolStripMenuItem,
            this.favouriteVehiclesToolStripMenuItem,
            this.totalIncomeEarnedToolStripMenuItem,
            this.historyOfCompleteTripsToolStripMenuItem,
            this.listOfCurrenltyOngoingTripsToolStripMenuItem,
            this.driverTripHistoryToolStripMenuItem});
            this.reportToolStripMenuItem.Name = "reportToolStripMenuItem";
            this.reportToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.reportToolStripMenuItem.Text = "Report";
            // 
            // usesPerServiceToolStripMenuItem
            // 
            this.usesPerServiceToolStripMenuItem.Name = "usesPerServiceToolStripMenuItem";
            this.usesPerServiceToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.usesPerServiceToolStripMenuItem.Text = "Monthly uses per service";
            this.usesPerServiceToolStripMenuItem.Click += new System.EventHandler(this.UsesPerServiceToolStripMenuItem_Click);
            // 
            // favouriteVehiclesToolStripMenuItem
            // 
            this.favouriteVehiclesToolStripMenuItem.Name = "favouriteVehiclesToolStripMenuItem";
            this.favouriteVehiclesToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.favouriteVehiclesToolStripMenuItem.Text = "Top 5 favourite vehicles";
            this.favouriteVehiclesToolStripMenuItem.Click += new System.EventHandler(this.FavouriteVehiclesToolStripMenuItem_Click);
            // 
            // totalIncomeEarnedToolStripMenuItem
            // 
            this.totalIncomeEarnedToolStripMenuItem.Name = "totalIncomeEarnedToolStripMenuItem";
            this.totalIncomeEarnedToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.totalIncomeEarnedToolStripMenuItem.Text = "Total income earned";
            this.totalIncomeEarnedToolStripMenuItem.Click += new System.EventHandler(this.TotalIncomeEarnedToolStripMenuItem_Click);
            // 
            // historyOfCompleteTripsToolStripMenuItem
            // 
            this.historyOfCompleteTripsToolStripMenuItem.Name = "historyOfCompleteTripsToolStripMenuItem";
            this.historyOfCompleteTripsToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.historyOfCompleteTripsToolStripMenuItem.Text = "History of complete trips";
            this.historyOfCompleteTripsToolStripMenuItem.Click += new System.EventHandler(this.HistoryOfCompleteTripsToolStripMenuItem_Click);
            // 
            // listOfCurrenltyOngoingTripsToolStripMenuItem
            // 
            this.listOfCurrenltyOngoingTripsToolStripMenuItem.Name = "listOfCurrenltyOngoingTripsToolStripMenuItem";
            this.listOfCurrenltyOngoingTripsToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.listOfCurrenltyOngoingTripsToolStripMenuItem.Text = "List of currenlty ongoing trips";
            this.listOfCurrenltyOngoingTripsToolStripMenuItem.Click += new System.EventHandler(this.ListOfCurrenltyOngoingTripsToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // driverTripHistoryToolStripMenuItem
            // 
            this.driverTripHistoryToolStripMenuItem.Name = "driverTripHistoryToolStripMenuItem";
            this.driverTripHistoryToolStripMenuItem.Size = new System.Drawing.Size(286, 26);
            this.driverTripHistoryToolStripMenuItem.Text = "Driver trip history";
            this.driverTripHistoryToolStripMenuItem.Click += new System.EventHandler(this.DriverTripHistoryToolStripMenuItem_Click);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1251, 760);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "IndexForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Blue Bird Order Management System";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driverToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pickupOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem masterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageDriversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageVehiclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageOrdersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageAdminsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usesPerServiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem favouriteVehiclesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalIncomeEarnedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyOfCompleteTripsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listOfCurrenltyOngoingTripsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem driverTripHistoryToolStripMenuItem;
    }
}

