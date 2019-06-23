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
    public partial class MakeOrderForm : Form
    {
        public MakeOrderForm()
        {
            InitializeComponent();
            dtpDate.MinDate = DateTime.Now;
            dtpDate.MaxDate = DateTime.Now.AddDays(6);
            cbService.SelectedIndex = 0;
            cbVehicleType.SelectedIndex = 0;
        }

        private void CbService_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbVehicleType.Items.Clear();
            cbVehicleType.Items.Add("-- Choose Vehicle Type --");
            cbVehicleType.SelectedIndex = 0;

            var selectedService = cbService.SelectedIndex;

            if (selectedService == 1)
            {
                var vehicleTypes = (from BlueBird x in DB.conn
                                    select x.type).ToList();

                foreach (string i in vehicleTypes)
                {
                    cbVehicleType.Items.Add(i);
                }
            }
            else if (selectedService == 2)
            {
                var vehicleTypes = (from SilverBird x in DB.conn
                                    select x.type).ToList();

                foreach (string i in vehicleTypes)
                {
                    cbVehicleType.Items.Add(i);
                }
            }
            else if (selectedService == 3)
            {
                var vehicleTypes = (from BigBird x in DB.conn
                                    select x.type).ToList();

                foreach (string i in vehicleTypes)
                {
                    cbVehicleType.Items.Add(i);
                }
            }
            else
            {
                cbVehicleType.SelectedIndex = 0;
                nudPassengers.Value = 0;
            }
        }

        public String generateID()
        {
            String newID = "";

            var lastID = (from Order x in DB.conn
                          orderby x.ID ascending
                          select x.ID).LastOrDefault();

            if (lastID != null)
            {
                int digit = Int32.Parse(lastID.Substring(2));
                digit++;
                newID = "OR" + digit.ToString("d3");
            }
            else
            {
                newID = "OR001";
            }

            return newID;
        }

        public int getSeats(int serviceType, string vehicleType)
        {
            var seats = 0;

            if (serviceType == 1)
            {
                var getVehicle = (from BlueBird x in DB.conn
                                  where x.type == vehicleType
                                  select x).FirstOrDefault();

                seats = getVehicle.seats;
            }
            else if (serviceType == 2)
            {
                var getVehicle = (from SilverBird x in DB.conn
                                  where x.type == vehicleType
                                  select x).FirstOrDefault();

                seats = getVehicle.seats;
            }
            else if (serviceType == 3)
            {
                var getVehicle = (from BigBird x in DB.conn
                                  where x.type == vehicleType
                                  select x).FirstOrDefault();

                seats = getVehicle.seats;
            }

            return seats;
        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            var pickupLocation = txtPickupAddress.Text;
            var pickupNotes = txtPickupNotes.Text;
            var destinationLocation = txtDestinationAddress.Text;
            var destinationNotes = txtDestinationNotes.Text;
            var serviceType = cbService.SelectedIndex;
            var vehicleType = cbVehicleType.Text;
            var passengers = nudPassengers.Value;
            var pickupDate = dtpDate.Value;
            var orderDate = DateTime.Now; ;

            var seats = getSeats(serviceType, vehicleType);

            if (pickupLocation.Equals(""))
            {
                MessageBox.Show("Pickup location address can't be empty!");
            }
            else if (destinationLocation.Equals(""))
            {
                MessageBox.Show("Destination address can't be empty!");
            }
            else if (serviceType == 0)
            {
                MessageBox.Show("Service type must be selected!");
            }
            else if (vehicleType.Equals("-- Choose Vehicle Type"))
            {
                MessageBox.Show("Vehicle type must be selected!");
            }
            else if (passengers <= 0)
            {
                MessageBox.Show("Passengers must be more than 0!");
            }
            else if (passengers > seats)
            {
                MessageBox.Show("Number of passengers exceed vehicle capacity!");
            }
            else
            {
                var orderID = generateID();

                IndexForm fm1 = (IndexForm)MdiParent;
                var customerID = fm1.getID();

                if (serviceType == 1)
                {
                    var getVehicle = (from BlueBird x in DB.conn
                                      where x.type == vehicleType
                                      select x).FirstOrDefault();

                    Order newOrder = new Order
                    {
                        ID = orderID,
                        customerID = customerID,
                        pickupLocation = pickupLocation,
                        pickupNotes = pickupNotes,
                        destinationLocation = destinationLocation,
                        destinationNotes = destinationNotes,
                        pickupDate = pickupDate,
                        orderDate = orderDate,
                        passengers = Int32.Parse(passengers.ToString()),
                        vehicleID = getVehicle.ID,
                        completed = false
                    };

                    DB.conn.Store(newOrder);
                }
                else if (serviceType == 2)
                {
                    var getVehicle = (from SilverBird x in DB.conn
                                      where x.type == vehicleType
                                      select x).FirstOrDefault();

                    Order newOrder = new Order
                    {
                        ID = orderID,
                        customerID = customerID,
                        pickupLocation = pickupLocation,
                        pickupNotes = pickupNotes,
                        destinationLocation = destinationLocation,
                        destinationNotes = destinationNotes,
                        pickupDate = pickupDate,
                        orderDate = orderDate,
                        passengers = Int32.Parse(passengers.ToString()),
                        vehicleID = getVehicle.ID,
                        completed = false
                    };

                    DB.conn.Store(newOrder);
                }
                else if (serviceType == 3)
                {
                    var getVehicle = (from BigBird x in DB.conn
                                      where x.type == vehicleType
                                      select x).FirstOrDefault();

                    Order newOrder = new Order
                    {
                        ID = orderID,
                        customerID = customerID,
                        pickupLocation = pickupLocation,
                        pickupNotes = pickupNotes,
                        destinationLocation = destinationLocation,
                        destinationNotes = destinationNotes,
                        pickupDate = pickupDate,
                        orderDate = orderDate,
                        passengers = Int32.Parse(passengers.ToString()),
                        vehicleID = getVehicle.ID,
                        completed = false
                    };

                    DB.conn.Store(newOrder);
                }

                MessageBox.Show("Success");
                this.Dispose();
            }
        }
    }
}
