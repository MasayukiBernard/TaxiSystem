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
    public partial class PaymentForm : Form
    {
        public string customerID;
        public string orderID;
        public TimeSpan travelDuration;

        public PaymentForm(string customerID, string orderID)
        {
            InitializeComponent();
            this.customerID = customerID;
            this.orderID = orderID;
            showData();
            toggleFields(false);
            cbPaymentMethod.SelectedIndex = 0;
        }

        public void showData()
        {
            var orderData = (from Order x in DB.conn
                             where x.ID == orderID
                             select x).FirstOrDefault();

            dtpDate.Value = DateTime.Now;
            txtPickup.Text = orderData.pickupLocation;
            txtDestination.Text = orderData.destinationLocation;

            travelDuration = DateTime.Now.Subtract(orderData.pickupDate);
            txtTravelDays.Text = travelDuration.Days.ToString();
            txtTravelHours.Text = travelDuration.Hours.ToString();
            txtTravelMinutes.Text = travelDuration.Minutes.ToString();

            var getVehicle = (from Vehicle x in DB.conn
                              where x.ID == orderData.vehicleID
                              select x).FirstOrDefault();

            cbVehicleType.Text = getVehicle.type;

            Random ran = new Random();
            if (getVehicle.GetType().IsInstanceOfType(new BlueBird()))
            {
                cbService.Text = "Blue Bird";
                txtDistance.Text = ran.Next(1, 50).ToString();
                txtPrice.Text = (getVehicle.baseFee + (getVehicle.rate * Int32.Parse(txtDistance.Text))).ToString();
            }
            else if (getVehicle.GetType().IsInstanceOfType(new SilverBird()))
            {
                cbService.Text = "Silver Bird";
                txtDistance.Text = ran.Next(1, 50).ToString();
                txtPrice.Text = (getVehicle.baseFee + (getVehicle.rate * Int32.Parse(txtDistance.Text))).ToString();
            }
            else if (getVehicle.GetType().IsInstanceOfType(new BigBird()))
            {
                cbService.Text = "Big Bird";
                txtDistance.Text = ran.Next(50, 500).ToString();
                txtPrice.Text = (getVehicle.baseFee + (getVehicle.rate * Int32.Parse(txtTravelDays.Text))).ToString();

                if (!txtTravelHours.Equals("0") || !txtTravelHours.Equals("0"))
                {
                    txtPrice.Text = (Int32.Parse(txtPrice.Text) + 1).ToString();
                }
            }
        }

        public void toggleFields(bool flag)
        {
            dtpDate.Enabled = flag;
            txtPickup.Enabled = flag;
            txtDestination.Enabled = flag;
            txtDistance.Enabled = flag;
            txtTravelDays.Enabled = flag;
            txtTravelHours.Enabled = flag;
            txtTravelMinutes.Enabled = flag;
            cbService.Enabled = flag;
            cbVehicleType.Enabled = flag;
            txtPrice.Enabled = flag;
        }

        public string generateID()
        {
            String newID = "";

            var lastID = (from Payment x in DB.conn
                          orderby x.ID ascending
                          select x.ID).LastOrDefault();

            if (lastID != null)
            {
                int digit = Int32.Parse(lastID.Substring(2));
                digit++;
                newID = "PY" + digit.ToString("d3");
            }
            else
            {
                newID = "PY001";
            }

            return newID;
        }

        private void BtnPay_Click(object sender, EventArgs e)
        {
            var method = cbPaymentMethod.Text;
            var payment = txtPayment.Text;
            var price = Int32.Parse(txtPrice.Text);

            if (method.Equals("-- Choose Payment Method --"))
            {
                MessageBox.Show("Please select a payment method!");
            }
            else if (payment.Equals(""))
            {
                MessageBox.Show("Payment can't be empty!");
            }
            else if (Int32.Parse(payment) < Int32.Parse(txtPrice.Text))
            {
                MessageBox.Show("Payment can't be less than total price!");
            }
            else
            {
                var result = MessageBox.Show("Are you sure?", "Confirmation Message", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var change = Int32.Parse(payment) - Int32.Parse(txtPrice.Text);
                    MessageBox.Show("Your change is Rp. " + change);

                    var paymentID = generateID();
                    Payment newPayment = new Payment
                    {
                        ID = paymentID,
                        customerID = customerID,
                        paymentMethod = method,
                        price = price,
                        payment = Int32.Parse(payment),
                        change = change,
                        date = DateTime.Now
                    };

                    DB.conn.Store(newPayment);

                    var updateOrder = (from Order x in DB.conn
                                       where x.ID == orderID
                                       select x).FirstOrDefault();

                    updateOrder.paymentID = paymentID;
                    updateOrder.travelDuration = travelDuration;
                    updateOrder.distanceTravelled = Int32.Parse(txtDistance.Text);
                    updateOrder.price = price;
                    updateOrder.completed = true;

                    DB.conn.Store(updateOrder);

                    MessageBox.Show("Thank you for trusting our services! We look forward to your next ride with us!");
                    this.Dispose();
                }
            }
        }
    }
}
