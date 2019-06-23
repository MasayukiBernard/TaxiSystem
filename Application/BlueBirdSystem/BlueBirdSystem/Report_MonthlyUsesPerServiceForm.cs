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
    public partial class Report_MonthlyUsesPerServiceForm : Form
    {
        public Report_MonthlyUsesPerServiceForm()
        {
            InitializeComponent();
            resetInitial();
            showData();
        }

        public void resetInitial()
        {
            txtUses.Enabled = false;
            cbYear.SelectedIndex = 0;
            cbMonth.SelectedIndex = 0;
            cbService.SelectedIndex = 0;
            cbYear.Enabled = false;
            cbMonth.Enabled = false;
        }

        public void showData()
        {
            if (cbService.SelectedIndex == 0)
            {
                var getOrders = (from Order o in DB.conn
                                 join BlueBird b in DB.conn
                                 on o.vehicleID equals b.ID
                                 select new
                                 {
                                     OrderID = o.ID,
                                     OrderDate = o.orderDate,
                                     CustomerID = o.customerID,
                                     VehicleID = o.ID,
                                     ServiceType = "Blue Bird",
                                     VehicleType = b.type,
                                     PickupLocation = o.pickupLocation,
                                     DestinationLocation = o.destinationLocation,
                                     PickupDate = o.pickupDate
                                 }).Union(
                             from Order o in DB.conn
                             join SilverBird b in DB.conn
                             on o.vehicleID equals b.ID
                             select new
                             {
                                 OrderID = o.ID,
                                 OrderDate = o.orderDate,
                                 CustomerID = o.customerID,
                                 VehicleID = o.ID,
                                 ServiceType = "Silver Bird",
                                 VehicleType = b.type,
                                 PickupLocation = o.pickupLocation,
                                 DestinationLocation = o.destinationLocation,
                                 PickupDate = o.pickupDate
                             }).Union(
                             from Order o in DB.conn
                             join BigBird b in DB.conn
                             on o.vehicleID equals b.ID
                             select new
                             {
                                 OrderID = o.ID,
                                 OrderDate = o.orderDate,
                                 CustomerID = o.customerID,
                                 VehicleID = o.ID,
                                 ServiceType = "Big Bird",
                                 VehicleType = b.type,
                                 PickupLocation = o.pickupLocation,
                                 DestinationLocation = o.destinationLocation,
                                 PickupDate = o.pickupDate
                             }).ToList();

                dgvOrders.DataSource = getOrders;
                txtUses.Text = getOrders.Count.ToString();
            }
            else if (cbService.SelectedIndex == 1)
            {
                var getOrders = (from Order o in DB.conn
                                   join BlueBird b in DB.conn
                                   on o.vehicleID equals b.ID
                                   select new
                                   {
                                       OrderID = o.ID,
                                       OrderDate = o.orderDate,
                                       CustomerID = o.customerID,
                                       VehicleID = o.ID,
                                       ServiceType = "Blue Bird",
                                       VehicleType = b.type,
                                       PickupLocation = o.pickupLocation,
                                       DestinationLocation = o.destinationLocation,
                                       PickupDate = o.pickupDate
                                   }).ToList();

                dgvOrders.DataSource = getOrders;
                txtUses.Text = getOrders.Count.ToString();
            }
            else if (cbService.SelectedIndex == 2)
            {
                var getOrders = (from Order o in DB.conn
                                 join SilverBird b in DB.conn
                                 on o.vehicleID equals b.ID
                                 select new
                                 {
                                     OrderID = o.ID,
                                     OrderDate = o.orderDate,
                                     CustomerID = o.customerID,
                                     VehicleID = o.ID,
                                     ServiceType = "Silver Bird",
                                     VehicleType = b.type,
                                     PickupLocation = o.pickupLocation,
                                     DestinationLocation = o.destinationLocation,
                                     PickupDate = o.pickupDate
                                 }).ToList();

                dgvOrders.DataSource = getOrders;
                txtUses.Text = getOrders.Count.ToString();
            }
            else if (cbService.SelectedIndex == 3)
            {
                var getOrders = (from Order o in DB.conn
                                 join BigBird b in DB.conn
                                 on o.vehicleID equals b.ID
                                 select new
                                 {
                                     OrderID = o.ID,
                                     OrderDate = o.orderDate,
                                     CustomerID = o.customerID,
                                     VehicleID = o.ID,
                                     ServiceType = "Big Bird",
                                     VehicleType = b.type,
                                     PickupLocation = o.pickupLocation,
                                     DestinationLocation = o.destinationLocation,
                                     PickupDate = o.pickupDate
                                 }).ToList();

                dgvOrders.DataSource = getOrders;
                txtUses.Text = getOrders.Count.ToString();
            }
        }

        public void showDataYears()
        {
            if (cbYear.SelectedIndex != 0)
            {
                var year = Int32.Parse(cbYear.Text);

                if (cbService.SelectedIndex == 1)
                {
                    var getOrders = (from Order o in DB.conn
                                       join BlueBird b in DB.conn
                                       on o.vehicleID equals b.ID
                                       where o.pickupDate.Year == year
                                       select new
                                       {
                                           OrderID = o.ID,
                                           OrderDate = o.orderDate,
                                           CustomerID = o.customerID,
                                           VehicleID = o.ID,
                                           ServiceType = "Blue Bird",
                                           VehicleType = b.type,
                                           PickupLocation = o.pickupLocation,
                                           DestinationLocation = o.destinationLocation,
                                           PickupDate = o.pickupDate
                                       }).ToList();

                    dgvOrders.DataSource = getOrders;
                    txtUses.Text = getOrders.Count.ToString();
                }
                else if (cbService.SelectedIndex == 2)
                {
                    var getOrders = (from Order o in DB.conn
                                     join SilverBird b in DB.conn
                                     on o.vehicleID equals b.ID
                                     where o.pickupDate.Year == year
                                     select new
                                     {
                                         OrderID = o.ID,
                                         OrderDate = o.orderDate,
                                         CustomerID = o.customerID,
                                         VehicleID = o.ID,
                                         ServiceType = "Silver Bird",
                                         VehicleType = b.type,
                                         PickupLocation = o.pickupLocation,
                                         DestinationLocation = o.destinationLocation,
                                         PickupDate = o.pickupDate
                                     }).ToList();

                    dgvOrders.DataSource = getOrders;
                    txtUses.Text = getOrders.Count.ToString();
                }
                else if (cbService.SelectedIndex == 3)
                {
                    var getOrders = (from Order o in DB.conn
                                     join BigBird b in DB.conn
                                     on o.vehicleID equals b.ID
                                     where o.pickupDate.Year == year
                                     select new
                                     {
                                         OrderID = o.ID,
                                         OrderDate = o.orderDate,
                                         CustomerID = o.customerID,
                                         VehicleID = o.ID,
                                         ServiceType = "Big Bird",
                                         VehicleType = b.type,
                                         PickupLocation = o.pickupLocation,
                                         DestinationLocation = o.destinationLocation,
                                         PickupDate = o.pickupDate
                                     }).ToList();

                    dgvOrders.DataSource = getOrders;
                    txtUses.Text = getOrders.Count.ToString();
                }
            }
        }

        private void CbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbYear.SelectedIndex = 0;
            cbMonth.SelectedIndex = 0;

            if (cbService.SelectedIndex == 0)
            {
                cbYear.Enabled = false;
                cbMonth.Enabled = false;
                showData();
            }
            else
            {
                cbYear.Enabled = true;
                showData();
            }
        }

        private void CbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMonth.SelectedIndex = 0;

            if (cbYear.SelectedIndex == 0)
            {
                cbMonth.Enabled = false;
                showData();
            }
            else
            {
                cbMonth.Enabled = true;
                showDataYears();
            }
        }

        private void CbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonth.SelectedIndex == 0)
            {
                showDataYears();   
            }
            else
            {
                var year = Int32.Parse(cbYear.Text);
                var month = cbMonth.SelectedIndex;

                if (cbService.SelectedIndex == 1)
                {
                    var getOrders = (from Order o in DB.conn
                                       join BlueBird b in DB.conn
                                       on o.vehicleID equals b.ID
                                       where o.pickupDate.Year == year
                                       && o.pickupDate.Month == month
                                       select new
                                       {
                                           OrderID = o.ID,
                                           OrderDate = o.orderDate,
                                           CustomerID = o.customerID,
                                           VehicleID = o.ID,
                                           ServiceType = "Blue Bird",
                                           VehicleType = b.type,
                                           PickupLocation = o.pickupLocation,
                                           DestinationLocation = o.destinationLocation,
                                           PickupDate = o.pickupDate
                                       }).ToList();

                    dgvOrders.DataSource = getOrders;
                    txtUses.Text = getOrders.Count.ToString();
                }
                else if (cbService.SelectedIndex == 2)
                {
                    var getOrders = (from Order o in DB.conn
                                     join SilverBird b in DB.conn
                                     on o.vehicleID equals b.ID
                                     where o.pickupDate.Year == year
                                     && o.pickupDate.Month == month
                                     select new
                                     {
                                         OrderID = o.ID,
                                         OrderDate = o.orderDate,
                                         CustomerID = o.customerID,
                                         VehicleID = o.ID,
                                         ServiceType = "Silver Bird",
                                         VehicleType = b.type,
                                         PickupLocation = o.pickupLocation,
                                         DestinationLocation = o.destinationLocation,
                                         PickupDate = o.pickupDate
                                     }).ToList();

                    dgvOrders.DataSource = getOrders;
                    txtUses.Text = getOrders.Count.ToString();
                }
                else if (cbService.SelectedIndex == 3)
                {
                    var getOrders = (from Order o in DB.conn
                                     join BigBird b in DB.conn
                                     on o.vehicleID equals b.ID
                                     where o.pickupDate.Year == year
                                     && o.pickupDate.Month == month
                                     select new
                                     {
                                         OrderID = o.ID,
                                         OrderDate = o.orderDate,
                                         CustomerID = o.customerID,
                                         VehicleID = o.ID,
                                         ServiceType = "Big Bird",
                                         VehicleType = b.type,
                                         PickupLocation = o.pickupLocation,
                                         DestinationLocation = o.destinationLocation,
                                         PickupDate = o.pickupDate
                                     }).ToList();

                    dgvOrders.DataSource = getOrders;
                    txtUses.Text = getOrders.Count.ToString();
                }
            }
        }
    }
}
