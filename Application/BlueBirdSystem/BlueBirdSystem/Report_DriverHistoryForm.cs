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
    public partial class Report_DriverHistoryForm : Form
    {
        public Report_DriverHistoryForm()
        {
            InitializeComponent();
            showData();
        }

        public void showData()
        {
            var getDriver = (from Order o in DB.conn
                             join Driver d in DB.conn
                             on o.driverID equals d.ID
                             group o by new { o.driverID, d.name } into g
                             let count = g.Count()
                             orderby count descending
                             select new
                             {
                                 g.Key.driverID,
                                 Name = g.Key.name,
                                 Trips = count
                             }).Take(10).ToList();

            dgvDriver.DataSource = getDriver;
        }
    }
}
