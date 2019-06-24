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
    public partial class Report_TripHistoryForm : Form
    {
        public Report_TripHistoryForm()
        {
            InitializeComponent();
            resetInitial();
            showData();
        }
        public void resetInitial()
        {

            Year.SelectedIndex = 0;
            Month.SelectedIndex = 0;
            Year.Enabled = true;
            Month.Enabled = false;
        }


        public void showData()
        {

            var data = (from Order o in DB.conn
                        join Driver d in DB.conn on o.driverID equals d.ID
                        join Customer c in DB.conn on o.customerID equals c.ID
                        join Payment p in DB.conn on o.paymentID equals p.ID
                        where o.completed == true
                        select new
                        {
                            OrderID = o.ID,
                            CustomerID = c.ID,
                            DriverID = d.ID,
                            PaymentID = p.ID,
                            OrderDate = o.orderDate,
                            PickupLocation = o.pickupLocation,
                            DestinationLocation = o.destinationLocation,
                            TravelDuration = o.travelDuration


                        }).ToList();

            dataGridView1.DataSource = data;
        }
        public void showDataYear()
        {
            if (Year.SelectedIndex != 0)
            {
                var year = Int32.Parse(Year.Text);
                var data = (from Order o in DB.conn
                            join Driver d in DB.conn on o.driverID equals d.ID
                            join Customer c in DB.conn on o.customerID equals c.ID
                            join Payment p in DB.conn on o.paymentID equals p.ID
                            where o.completed == true && o.orderDate.Year == year
                            select new
                            {
                                OrderID = o.ID,
                                CustomerID = c.ID,
                                DriverID = d.ID,
                                PaymentID = p.ID,
                                OrderDate = o.orderDate,
                                PickupLocation = o.pickupLocation,
                                DestinationLocation = o.destinationLocation,
                                TravelDuration = o.travelDuration


                            }).ToList();

                dataGridView1.DataSource = data;
            }

        }

      
        

        

        private void Year_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            {
                Month.SelectedIndex = 0;
                if (Year.SelectedIndex == 0)
                {
                    showData();
                    Month.Enabled = false;
                }
                else if (Year.SelectedIndex != 0)
                {
                    showDataYear();
                    Month.Enabled = true;
                }
            }
        }

        private void Month_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (Month.SelectedIndex == 0)
            {
                showDataYear();
            }
            else
            {
                var year = Int32.Parse(Year.Text);
                var month = Month.SelectedIndex;
                var data = (from Order o in DB.conn
                            join Driver d in DB.conn on o.driverID equals d.ID
                            join Customer c in DB.conn on o.customerID equals c.ID
                            join Payment p in DB.conn on o.paymentID equals p.ID
                            where o.completed == true && o.orderDate.Year == year && o.orderDate.Month == month
                            select new
                            {
                                OrderID = o.ID,
                                CustomerID = c.ID,
                                DriverID = d.ID,
                                PaymentID = p.ID,
                                OrderDate = o.orderDate,
                                PickupLocation = o.pickupLocation,
                                DestinationLocation = o.destinationLocation,
                                TravelDuration = o.travelDuration


                            }).ToList();

                dataGridView1.DataSource = data;
            }
        }
    }

}


