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
    public partial class FinishOrderForm : Form
    {
        public string customerID = "";

        public FinishOrderForm(string customerID)
        {
            InitializeComponent();
            this.customerID = customerID;
            resetInitial();
        }

        public void resetInitial()
        {
            showData();
            toggleFields(false);
            clearFields();
        }

        public void showData()
        {
           var orderData = (from Order x in DB.conn
                             where x.customerID == customerID
                             && x.completed == false
                             select new
                             {
                                 OrderID = x.ID,
                                 OrderDate = x.orderDate,
                                 PickupLocation = x.pickupLocation,
                                 PickupNotes = x.pickupNotes,
                                 DestinationLocation = x.destinationLocation,
                                 DestinationNotes = x.destinationNotes,
                                 PickupDate = x.pickupDate,
                                 Passengers = x.passengers,
                                 VehicleID = x.vehicleID,
                                 DriverID = x.driverID
                             }).ToList();

            dgvOrders.DataSource = orderData;
        }

        public void toggleFields(bool flag)
        {
            txtID.Enabled = flag;
            txtPickup.Enabled = flag;
            txtDestination.Enabled = flag;
            dtpPickupDate.Enabled = flag;
            cbService.Enabled = flag;
            cbVehicle.Enabled = flag;
            nudPassengers.Enabled = flag;
            txtDriverName.Enabled = flag;
            txtDriverPhone.Enabled = flag;
        }

        public void clearFields()
        {
            txtID.Text = "";
            txtPickup.Text = "";
            txtDestination.Text = "";
            dtpPickupDate.Value = DateTime.Now; ;
            cbService.Text = "";
            cbVehicle.Text = "";
            nudPassengers.Value = 0;
            txtDriverName.Text = "";
            txtDriverPhone.Text = "";
        }

        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtID.Text = dgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPickup.Text = dgvOrders.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtDestination.Text = dgvOrders.Rows[e.RowIndex].Cells[4].Value.ToString();
                dtpPickupDate.Value = DateTime.Parse(dgvOrders.Rows[e.RowIndex].Cells[6].Value.ToString());
                nudPassengers.Value = Decimal.Parse(dgvOrders.Rows[e.RowIndex].Cells[7].Value.ToString());

                var vehicleID = dgvOrders.Rows[e.RowIndex].Cells[8].Value.ToString();
                var getVehicle = (from Vehicle x in DB.conn
                                  where x.ID == vehicleID
                                  select x).FirstOrDefault();

                if (getVehicle.GetType().IsInstanceOfType(new BlueBird()))
                {
                    cbService.Text = "Blue Bird";
                }
                else if (getVehicle.GetType().IsInstanceOfType(new SilverBird()))
                {
                    cbService.Text = "Silver Bird";
                }
                else if (getVehicle.GetType().IsInstanceOfType(new BigBird()))
                {
                    cbService.Text = "Big Bird";
                }

                cbVehicle.Text = getVehicle.type;

                var orderID = txtID.Text;
                var checkDriver = (from Order x in DB.conn
                                   where x.ID == orderID
                                   select x).FirstOrDefault();

                if (checkDriver.driverID != null)
                {
                    var driverID = dgvOrders.Rows[e.RowIndex].Cells[9].Value.ToString();
                    var getDriver = (from Driver x in DB.conn
                                     where x.ID == driverID
                                     select x).FirstOrDefault();

                    txtDriverName.Text = getDriver.name;
                    txtDriverPhone.Text = getDriver.phoneNumber;
                }
                else
                {
                    txtDriverName.Text = "";
                    txtDriverPhone.Text = "";
                }
            }
        }

        private void BtnFinish_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Please choose an order first!");
            }
            else if (txtDriverName.Text.Equals(""))
            {
                MessageBox.Show("Trip has not started yet!");
            }
            else
            {
                var confirm = MessageBox.Show("To payment?", "Confirmation Message", MessageBoxButtons.OKCancel);

                if (confirm == DialogResult.OK)
                {
                    var orderID = txtID.Text;
                    this.Dispose();

                    PaymentForm pf = new PaymentForm(customerID, orderID);
                    pf.Show();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Please choose an order first!");
            }
            else if (!txtDriverName.Text.Equals(""))
            {
                MessageBox.Show("Unable to cancel! Trip is ongoing!");
            }
            else
            {
                var result = MessageBox.Show("Are you sure?", "Confirmation Message", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var orderID = txtID.Text;
                    var deleteOrder = (from Order x in DB.conn
                                       where x.ID == orderID
                                       select x).FirstOrDefault();

                    DB.conn.Delete(deleteOrder);

                    MessageBox.Show("Order has been cancelled!");

                    resetInitial();
                }
            }
        }
    }
}
