using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Db4objects.Db4o.Linq;
using BlueBirdSystem.data;
using BlueBirdSystem.model;

namespace BlueBirdSystem
{
    public partial class IndexForm : Form
    {
        LoginForm lf;
        RegisterForm rf;
        ChangePasswordForm cpf;
        MakeOrderForm mkf;
        FinishOrderForm fof;
        PickupOrderForm pof;
        ManageCustomersForm mcf;
        ManageDriversForm mdf;
        ManageVehiclesForm mvf;
        ViewOrdersForm vof;
        ManageAdminsForm maf;
        Report_MonthlyUsesPerServiceForm rmupsf;
        Report_FavouriteVehiclesForm rfvf;

        private string userID = "";
        public void setID(string userID) { this.userID = userID; }
        public string getID() { return userID; }

        public IndexForm()
        {
            InitializeComponent();
            //initialData();    -> // ONLY RUN THIS IF INITIAL DATA IS MISSING
            initialMenuState();
        }

        public void initialMenuState()
        {
            customerToolStripMenuItem.Visible = false;
            driverToolStripMenuItem.Visible = false;
            masterToolStripMenuItem.Visible = false;
            reportToolStripMenuItem.Visible = false;
            exitToolStripMenuItem.Visible = true;

            fileToolStripMenuItem.Visible = true;
            loginToolStripMenuItem.Visible = true;
            registerToolStripMenuItem.Visible = true;
            changePasswordToolStripMenuItem.Visible = false;
            logoutToolStripMenuItem.Visible = false;
        }

        public void loggedInMenuState()
        {
            loginToolStripMenuItem.Visible = false;
            registerToolStripMenuItem.Visible = false;
            changePasswordToolStripMenuItem.Visible = true;
            logoutToolStripMenuItem.Visible = true;
            exitToolStripMenuItem.Visible = false;
        }

        public void customerMenuState()
        {
            customerToolStripMenuItem.Visible = true;
            loggedInMenuState();
        }

        public void driverMenuState()
        {
            driverToolStripMenuItem.Visible = true;
            loggedInMenuState();
        }

        public void adminMenuState()
        {
            masterToolStripMenuItem.Visible = true;
            reportToolStripMenuItem.Visible = true;
            loggedInMenuState();
        }


        private void LoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lf == null || lf.IsDisposed)
            {
                lf = new LoginForm();
                lf.MdiParent = this;
                lf.Show();
            }
        }

        private void RegisterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rf == null || rf.IsDisposed)
            {
                rf = new RegisterForm();
                rf.MdiParent = this;
                rf.Show();
            }
        }

        private void ChangePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cpf == null || cpf.IsDisposed)
            {
                cpf = new ChangePasswordForm();
                cpf.MdiParent = this;
                cpf.Show();
            }
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logOut();
        }

        public void logOut()
        {
            foreach (Form page in this.MdiChildren)
            {
                page.Dispose();
            }

            initialMenuState();
        }

        private void MakeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mkf == null || mkf.IsDisposed)
            {
                mkf = new MakeOrderForm();
                mkf.MdiParent = this;
                mkf.Show();
            }
        }

        private void FinishOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fof == null || fof.IsDisposed)
            {
                fof = new FinishOrderForm(userID);
                fof.MdiParent = this;
                fof.Show();
            }
        }

        private void PickupOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (pof == null || pof.IsDisposed)
            {
                pof = new PickupOrderForm(userID);
                pof.MdiParent = this;
                pof.Show();
            }
        }

        private void ManageCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mcf == null || mcf.IsDisposed)
            {
                mcf = new ManageCustomersForm();
                mcf.MdiParent = this;
                mcf.Show();
            }
        }

        private void ManageDriversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mdf == null || mdf.IsDisposed)
            {
                mdf = new ManageDriversForm();
                mdf.MdiParent = this;
                mdf.Show();
            }
        }

        private void ManageVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (mvf == null || mvf.IsDisposed)
            {
                mvf = new ManageVehiclesForm();
                mvf.MdiParent = this;
                mvf.Show();
            }
        }

        private void ViewOrdersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (vof == null || vof.IsDisposed)
            {
                vof = new ViewOrdersForm();
                vof.MdiParent = this;
                vof.Show();
            }
        }

        private void ManageAdminsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (maf == null || maf.IsDisposed)
            {
                maf = new ManageAdminsForm();
                maf.MdiParent = this;
                maf.Show();
            }
        }

        public void initialData()
        {
            Admin newAdmin = new Admin
            {
                ID = "AD001",
                name = "admin",
                email = "admin@bluebird.com",
                password = "admin"
            };

            DB.conn.Store(newAdmin);

            //Blue Bird
            BlueBird car1 = new BlueBird
            {
                ID = "VH001",
                type = "Limo",
                seats = 4,
                baseFee = 6500,
                rate = 4000
            };

            BlueBird car2 = new BlueBird
            {
                ID = "VH002",
                type = "Mobilio",
                seats = 7,
                baseFee = 7500,
                rate = 5000
            };

            BlueBird car3 = new BlueBird
            {
                ID = "VH003",
                type = "Transmover",
                seats = 7,
                baseFee = 7500,
                rate = 5000
            };

            BlueBird car4 = new BlueBird
            {
                ID = "VH004",
                type = "Serena",
                seats = 6,
                baseFee = 7000,
                rate = 4500
            };

            DB.conn.Store(car1);
            DB.conn.Store(car2);
            DB.conn.Store(car3);
            DB.conn.Store(car4);

            //Silver Bird
            SilverBird car5 = new SilverBird
            {
                ID = "VH005",
                type = "Mercedes C200",
                seats = 4,
                baseFee = 13000,
                rate = 7000
            };

            SilverBird car6 = new SilverBird
            {
                ID = "VH006",
                type = "Alphard",
                seats = 7,
                baseFee = 17000,
                rate = 9000
            };

            DB.conn.Store(car5);
            DB.conn.Store(car6);

            // Big Bird
            BigBird car7 = new BigBird
            {
                ID = "VH007",
                type = "Delta Long Chasis",
                seats = 11,
                baseFee = 1170000,
                rate = 1500000
            };

            BigBird car8 = new BigBird
            {
                ID = "VH008",
                type = "Delta Bus",
                seats = 10,
                baseFee = 1170000,
                rate = 1500000
            };

            BigBird car9 = new BigBird
            {
                ID = "VH009",
                type = "Commuter Bus",
                seats = 14,
                baseFee = 1530000,
                rate = 2000000
            };

            BigBird car10 = new BigBird
            {
                ID = "VH010",
                type = "Charlie Premium",
                seats = 10,
                baseFee = 1530000,
                rate = 2000000
            };

            BigBird car11 = new BigBird
            {
                ID = "VH011",
                type = "Bravo Bus",
                seats = 25,
                baseFee = 1920000,
                rate = 2500000
            };

            BigBird car12 = new BigBird
            {
                ID = "VH012",
                type = "Bravo Premium",
                seats = 12,
                baseFee = 2720000,
                rate = 3700000
            };

            BigBird car13 = new BigBird
            {
                ID = "VH013",
                type = "Alpha Bus 37",
                seats = 37,
                baseFee = 2670000,
                rate = 3500000
            };

            BigBird car14 = new BigBird
            {
                ID = "VH014",
                type = "Alpha Bus 44",
                seats = 44,
                baseFee = 2670000,
                rate = 3500000
            };

            BigBird car15 = new BigBird
            {
                ID = "VH015",
                type = "Alpha Bus 54",
                seats = 54,
                baseFee = 2670000,
                rate = 3500000
            };

            BigBird car16 = new BigBird
            {
                ID = "VH016",
                type = "Alpha Premium",
                seats = 12,
                baseFee = 6100000,
                rate = 8500000
            };

            DB.conn.Store(car7);
            DB.conn.Store(car8);
            DB.conn.Store(car9);
            DB.conn.Store(car10);
            DB.conn.Store(car11);
            DB.conn.Store(car12);
            DB.conn.Store(car13);
            DB.conn.Store(car14);
            DB.conn.Store(car15);
            DB.conn.Store(car16);
        }

        public void eraseData()
        {
            var eraseCustomer = (from Customer x in DB.conn
                                 select x).ToList();
            foreach (Customer c in eraseCustomer)
            {
                DB.conn.Delete(c);
            }

            var eraseOrder = (from Order x in DB.conn
                              select x).ToList();
            foreach (Order o in eraseOrder)
            {
                DB.conn.Delete(o);
            }

            var eraseDriver = (from Driver x in DB.conn
                               select x).ToList();
            foreach (Driver d in eraseDriver)
            {
                DB.conn.Delete(d);
            }

            var erasePayment = (from Payment x in DB.conn
                                select x).ToList();
            foreach (Payment x in erasePayment)
            {
                DB.conn.Delete(x);
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void UsesPerServiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rmupsf == null || rmupsf.IsDisposed)
            {
                rmupsf = new Report_MonthlyUsesPerServiceForm();
                rmupsf.MdiParent = this;
                rmupsf.Show();
            }
        }

        private void FavouriteVehiclesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rfvf == null || rfvf.IsDisposed)
            {
                rfvf = new Report_FavouriteVehiclesForm();
                rfvf.MdiParent = this;
                rfvf.Show();
            }
        }
    }
}
