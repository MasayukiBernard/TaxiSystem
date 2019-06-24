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
    public partial class Report_OngoingTripsForm : Form
    {
        public Report_OngoingTripsForm()
        {
            InitializeComponent();
            showData();
        }

        public void showData()
        {
            var getTrips = (from Order x in DB.conn
                            where x.completed == false
                            select new
                            {
                                x.ID,
                                x.orderDate,
                                x.customerID,
                                x.driverID,
                                x.vehicleID,
                                x.pickupLocation,
                                x.pickupNotes,
                                x.destinationLocation,
                                x.destinationNotes,
                                x.pickupDate,
                                x.passengers
                            }).ToList();

            dgvOngoing.DataSource = getTrips;
            txtOngoing.Text = getTrips.Count.ToString();
        }
    }
}
