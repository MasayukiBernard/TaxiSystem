﻿using System;
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
    public partial class Report_FavouriteVehiclesForm : Form
    {
        public Report_FavouriteVehiclesForm()
        {
            InitializeComponent();
            cbYear.SelectedIndex = 0;
            cbMonth.SelectedIndex = 0;
            cbMonth.Enabled = false;
            showData();
        }

        public void showData()
        {
            var getData = (from Order o in DB.conn
                           join Vehicle v in DB.conn
                           on o.vehicleID equals v.ID
                           group v.type by v.type into g
                           orderby g.Count() descending
                           select new
                           {
                               VehicleType = g.Key,
                               Trips = g.Count()
                           }).Take(5).ToList();

            dgvFavourites.DataSource = getData;
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

                var year = Int32.Parse(cbYear.Text);

                var getData = (from Order o in DB.conn
                               join Vehicle v in DB.conn
                               on o.vehicleID equals v.ID
                               where o.pickupDate.Year == year
                               group v.type by v.type into g
                               orderby g.Count() descending
                               select new
                               {
                                   VehicleType = g.Key,
                                   Trips = g.Count()
                               }).Take(5).ToList();

                dgvFavourites.DataSource = getData;
            }
        }

        private void CbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMonth.SelectedIndex == 0)
            {
                if (cbYear.SelectedIndex != 0)
                {
                    var year = Int32.Parse(cbYear.Text);

                    var getData = (from Order o in DB.conn
                                   join Vehicle v in DB.conn
                                   on o.vehicleID equals v.ID
                                   where o.pickupDate.Year == year
                                   group v.type by v.type into g
                                   orderby g.Count() descending
                                   select new
                                   {
                                       VehicleType = g.Key,
                                       Trips = g.Count()
                                   }).Take(5).ToList();

                    dgvFavourites.DataSource = getData;
                }
            }
            else
            {
                var year = Int32.Parse(cbYear.Text);
                var month = cbMonth.SelectedIndex;

                var getData = (from Order o in DB.conn
                               join Vehicle v in DB.conn
                               on o.vehicleID equals v.ID
                               where o.pickupDate.Year == year
                               && o.pickupDate.Month == month
                               group v.type by v.type into g
                               orderby g.Count() descending
                               select new
                               {
                                   VehicleType = g.Key,
                                   Trips = g.Count()
                               }).Take(5).ToList();

                dgvFavourites.DataSource = getData;
            }
        }
    }
}
