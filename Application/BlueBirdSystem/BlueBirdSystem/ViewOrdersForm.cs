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
    public partial class ViewOrdersForm : Form
    {
        public ViewOrdersForm()
        {
            InitializeComponent();
            showData();
            toggleFields(false);
        }

        public void showData()
        {
            var orderData = (from Order x in DB.conn
                             orderby x.completed ascending, x.pickupDate ascending
                             select new
                             {
                                 OrderID = x.ID,
                                 PickupLocation = x.pickupLocation,
                                 Destination = x.destinationLocation,
                                 OrderDate = x.orderDate,
                                 PickupDate = x.pickupDate,
                                 Completed = x.completed
                             }).ToList();

            dgvOrders.DataSource = orderData;
        }

        public void toggleFields(bool flag)
        {
            txtOrderID.Enabled = flag;
            txtPickupLocation.Enabled = flag;
            txtDestination.Enabled = flag;
            dtpOrder.Enabled = flag;
            dtpPickup.Enabled = flag;
            txtStatus.Enabled = flag;

            txtCustomerID.Enabled = flag;
            txtCustomerName.Enabled = flag;
            txtCustomerEmail.Enabled = flag;
            txtCustomerPhone.Enabled = flag;

            txtDriverID.Enabled = flag;
            txtDriverName.Enabled = flag;
            txtDriverPhone.Enabled = flag;
            cbDriverService.Enabled = flag;
            cbVehicleService.Enabled = flag;
        }

        private void DgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtOrderID.Text = dgvOrders.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtPickupLocation.Text = dgvOrders.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtDestination.Text = dgvOrders.Rows[e.RowIndex].Cells[2].Value.ToString();
                dtpOrder.Value = DateTime.Parse(dgvOrders.Rows[e.RowIndex].Cells[3].Value.ToString());
                dtpPickup.Value = DateTime.Parse(dgvOrders.Rows[e.RowIndex].Cells[4].Value.ToString());

                var completed = (bool)dgvOrders.Rows[e.RowIndex].Cells[5].Value;
                if (completed == true)
                {
                    txtStatus.Text = "Completed";
                }
                else
                {
                    txtStatus.Text = "Not Completed";
                }

                var orderID = txtOrderID.Text;
                var orderData = (from Order x in DB.conn
                                 where x.ID == orderID
                                 select x).FirstOrDefault();

                var customerID = orderData.customerID;
                var customerData = (from Customer x in DB.conn
                                    where x.ID == customerID
                                    select x).FirstOrDefault();
                txtCustomerID.Text = customerData.ID;
                txtCustomerName.Text = customerData.name;
                txtCustomerEmail.Text = customerData.email;
                txtCustomerPhone.Text = customerData.phoneNumber;

                var driverID = orderData.driverID;

                if (driverID != null)
                {
                    var driverData = (from Driver x in DB.conn
                                      where x.ID == driverID
                                      select x).FirstOrDefault();
                    txtDriverID.Text = driverData.ID;
                    txtDriverName.Text = driverData.name;
                    txtDriverPhone.Text = driverData.phoneNumber;

                    var vehicleID = driverData.vehicleID;
                    var vehicleData = (from Vehicle x in DB.conn
                                       where x.ID == vehicleID
                                       select x).FirstOrDefault();

                    if (vehicleData.GetType().IsInstanceOfType(new BlueBird()))
                    {
                        cbDriverService.Text = "Blue Bird";
                    }
                    else if (vehicleData.GetType().IsInstanceOfType(new SilverBird()))
                    {
                        cbDriverService.Text = "Silver Bird";
                    }
                    else if (vehicleData.GetType().IsInstanceOfType(new BigBird()))
                    {
                        cbDriverService.Text = "Big Bird";
                    }
                    
                    cbVehicleService.Text = vehicleData.type;
                }
                else
                {
                    txtDriverID.Text = "";
                    txtDriverName.Text = "";
                    txtDriverPhone.Text = "";
                    cbDriverService.Text = "";
                    cbVehicleService.Text = "";
                }
            }
        }
    }
}
