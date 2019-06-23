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
    public partial class PickupOrderForm : Form
    {
        public string driverID;
        public string vehicleID;
        public string orderID;
        public bool available;

        public PickupOrderForm(string driverID)
        {
            InitializeComponent();
            setValues(driverID);
            lblWarning.Visible = false;
            toggleFields(false);
            available = checkAvailable();

            if (available == true)
            {
                showData();
            }
            else
            {
                toggleUnavailable();
                showTrip();
            }
        }

        public bool checkAvailable()
        {
            var checkAvailablity = (from Order x in DB.conn
                                    where x.driverID == driverID
                                    && x.completed == false
                                    select x).FirstOrDefault();

            if (checkAvailablity == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setValues(string driverID)
        {
            this.driverID = driverID;

            var getDriver = (from Driver x in DB.conn
                             where x.ID == driverID
                             select x).FirstOrDefault();

            this.vehicleID = getDriver.vehicleID;
        }

        public void showData()
        {
            var orderData = (from Order x in DB.conn
                             where x.vehicleID == vehicleID
                             && x.driverID == null
                             && x.completed == false
                             orderby x.pickupDate ascending
                             select new
                             {
                                 OrderID = x.ID,
                                 CustomerID = x.customerID,
                                 PickupLocation = x.pickupLocation,
                                 PickupNotes = x.pickupNotes,
                                 DestinationLocation = x.destinationLocation,
                                 DestinationNotes = x.destinationNotes,
                                 PickupDate = x.pickupDate
                             }).ToList();

            dgvOrders.DataSource = orderData;
        }

        public void toggleFields(bool flag)
        {
            txtPickupAddress.Enabled = flag;
            txtPickupNotes.Enabled = flag;
            txtDestinationAddress.Enabled = flag;
            txtDestinationNotes.Enabled = flag;
            dtpDate.Enabled = flag;
            txtName.Enabled = flag;
            txtPhoneNumber.Enabled = flag;
        }

        public void toggleUnavailable()
        {
            lblWarning.Visible = true;
            dgvOrders.Enabled = false;
            btnPickup.Enabled = false;
        }

        public void showTrip()
        {
            var getTrip = (from Order x in DB.conn
                           where x.driverID == driverID
                           && x.completed == false
                           select x).FirstOrDefault();

            txtPickupAddress.Text = getTrip.pickupLocation;
            txtPickupNotes.Text = getTrip.pickupNotes;
            txtDestinationAddress.Text = getTrip.destinationLocation;
            txtDestinationNotes.Text = getTrip.destinationNotes;
            dtpDate.Value = getTrip.pickupDate;

            var getCustomer = (from Customer x in DB.conn
                               where x.ID == getTrip.customerID
                               select x).FirstOrDefault();

            txtName.Text = getCustomer.name;
            txtPhoneNumber.Text = getCustomer.phoneNumber;
        }

        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                orderID = dgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPickupAddress.Text = dgvOrders.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPickupNotes.Text = dgvOrders.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDestinationAddress.Text = dgvOrders.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtDestinationNotes.Text = dgvOrders.Rows[e.RowIndex].Cells[5].Value.ToString();
                dtpDate.Value = DateTime.Parse(dgvOrders.Rows[e.RowIndex].Cells[6].Value.ToString());

                var customerID = dgvOrders.Rows[e.RowIndex].Cells[1].Value.ToString();
                var getCustomer = (from Customer x in DB.conn
                                   where x.ID == customerID
                                   select x).FirstOrDefault();

                txtName.Text = getCustomer.name;
                txtPhoneNumber.Text = getCustomer.phoneNumber;
            }
        }

        private void BtnPickup_Click(object sender, EventArgs e)
        {
            if (txtPickupAddress.Text.Equals(""))
            {
                MessageBox.Show("Please select an order!");
            }
            else
            {
                var updateOrder = (from Order x in DB.conn
                                   where x.ID == orderID
                                   select x).FirstOrDefault();

                updateOrder.driverID = driverID;

                DB.conn.Store(updateOrder);

                MessageBox.Show("Success");
                MessageBox.Show("Please contact your customer as soon as possible!");
                this.Dispose();
            }
        }
    }
}
