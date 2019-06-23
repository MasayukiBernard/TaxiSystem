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
    public partial class ManageVehiclesForm : Form
    {
        private int selectedButton = 0;

        public ManageVehiclesForm()
        {
            InitializeComponent();
            txtID.Enabled = false;
            resetInitial();
        }

        public void resetInitial()
        {
            showData();
            toggleFields(false);
            toggleButtons(true);
            clearFields();
            selectedButton = 0;
            dgvVehicles.Enabled = true;
        }

        public void showData()
        {
            var vehicleData = (from Vehicle x in DB.conn
                               orderby x.ID ascending
                               select new
                               {
                                   VehicleID = x.ID,
                                   VehicleType = x.type,
                                   VehicleSeats = x.seats,
                                   VehicleBaseFee = x.baseFee,
                                   VehicleRate = x.rate
                               }).ToList();

            dgvVehicles.DataSource = vehicleData;
        }

        public void toggleFields(bool flag)
        {
            cbService.Enabled = flag;
            txtType.Enabled = flag;
            nudSeats.Enabled = flag;
            txtBaseFee.Enabled = flag;
            txtRate.Enabled = flag;
        }

        public void clearFields()
        {
            txtID.Text = "";
            cbService.SelectedIndex = 0;
            txtType.Text = "";
            nudSeats.Value = 0;
            txtBaseFee.Text = "";
            txtRate.Text = "";
        }

        public void toggleButtons(bool flag)
        {
            btnInsert.Enabled = flag;
            btnUpdate.Enabled = flag;
            btnDelete.Enabled = flag;
            btnCancel.Enabled = !flag;
            btnSave.Enabled = !flag;
        }

        private void DgvVehicles_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtID.Text = dgvVehicles.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtType.Text = dgvVehicles.Rows[e.RowIndex].Cells[1].Value.ToString();
                nudSeats.Value = Decimal.Parse(dgvVehicles.Rows[e.RowIndex].Cells[2].Value.ToString());
                txtBaseFee.Text = dgvVehicles.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtRate.Text = dgvVehicles.Rows[e.RowIndex].Cells[4].Value.ToString();

                var checkService = (from Vehicle x in DB.conn
                                    where x.ID == txtID.Text
                                    select x).FirstOrDefault();

                if (checkService.GetType().IsInstanceOfType(new BlueBird()))
                {
                    cbService.SelectedIndex = 1;
                }
                else if (checkService.GetType().IsInstanceOfType(new SilverBird()))
                {
                    cbService.SelectedIndex = 2;
                }
                else if (checkService.GetType().IsInstanceOfType(new BigBird()))
                {
                    cbService.SelectedIndex = 3;
                }
            }
        }

        public String generateID()
        {
            String newID = "";

            var lastID = (from Vehicle x in DB.conn
                          orderby x.ID ascending
                          select x.ID).LastOrDefault();

            if (lastID != null)
            {
                int digit = Int32.Parse(lastID.Substring(2));
                digit++;
                newID = "VH" + digit.ToString("d3");
            }
            else
            {
                newID = "VH001";
            }

            return newID;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            toggleFields(true);
            clearFields();
            toggleButtons(false);
            dgvVehicles.Enabled = false;

            txtID.Text = generateID();

            selectedButton = 1;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Please select a user!");
            }
            else
            {
                toggleFields(true);
                toggleButtons(false);
                cbService.Enabled = false;

                selectedButton = 2;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtID.Text.Equals(""))
            {
                MessageBox.Show("Please select a user!");
            }
            else
            {
                var result = MessageBox.Show("Are you sure?", "Confirmation Message", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var vehicleID = txtID.Text;

                    var checkOrders = (from Order x in DB.conn
                                       where x.vehicleID == vehicleID
                                       && x.completed == false
                                       select x).FirstOrDefault();

                    if (checkOrders == null)
                    {
                        var deleteVehicle = (from Vehicle x in DB.conn
                                             where x.ID == vehicleID
                                             select x).FirstOrDefault();

                        DB.conn.Delete(deleteVehicle);

                        var deleteOrder = (from Order x in DB.conn
                                           where x.vehicleID == vehicleID
                                           select x).ToList();

                        foreach (Order o in deleteOrder)
                        {
                            DB.conn.Delete(o);
                        }

                        var resetDriver = (from Driver x in DB.conn
                                           where x.vehicleID == vehicleID
                                           select x).ToList();

                        foreach (Driver d in resetDriver)
                        {
                            d.vehicleID = null;
                            DB.conn.Store(d);
                        }

                        MessageBox.Show("Vehicle has been removed!");
                    }
                    else
                    {
                        MessageBox.Show("Unable to remove vehicle! Vehicle is currenlty being used on an ongoing trip!");
                    }

                    resetInitial();
                }
            }
        }

        public int checkDigit(string input)
        {
            int count = 0;

            foreach (char c in input)
            {
                if (!Char.IsDigit(c))
                {
                    count++;
                }
            }

            return count;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var ID = txtID.Text;
            var serviceType = cbService.SelectedIndex;
            var vehicleType = txtType.Text;
            var seats = Int32.Parse(nudSeats.Value.ToString());
            var baseFee = txtBaseFee.Text;
            var rate = txtRate.Text;

            if (serviceType == 0)
            {
                MessageBox.Show("Service Type must be selected!");
            }
            else if (vehicleType.Equals(""))
            {
                MessageBox.Show("Vehicle Type can't be empty!");
            }
            else if (seats <= 0)
            {
                MessageBox.Show("Seats must be greater than 0!");
            }
            else if (baseFee.Equals(""))
            {
                MessageBox.Show("Base Fee can't be empty!");
            }
            else if (checkDigit(baseFee) != 0)
            {
                MessageBox.Show("Base Fee must be numeric!");
            }
            else if (Int32.Parse(baseFee) <= 0)
            {
                MessageBox.Show("Base Fee must be greater than 0!");
            }
            else if (rate.Equals(""))
            {
                MessageBox.Show("Rate can't be empty!");
            }
            else if (checkDigit(rate) != 0)
            {
                MessageBox.Show("Rate must be numeric!");
            }
            else if (Int32.Parse(rate) <= 0)
            {
                MessageBox.Show("Rate must be greater than 0!");
            }
            else
            {
                if (selectedButton == 1)
                {
                    if (serviceType == 1)
                    {
                        var checkType = (from BlueBird x in DB.conn
                                         where x.type == vehicleType
                                         select x).ToList();

                        if (checkType.Count != 0)
                        {
                            MessageBox.Show("Vehicle type already exists for this service type!");
                        }
                        else
                        {
                            BlueBird newVehicle = new BlueBird
                            {
                                ID = ID,
                                type = vehicleType,
                                seats = seats,
                                baseFee = Int32.Parse(baseFee),
                                rate = Int32.Parse(rate)
                            };

                            DB.conn.Store(newVehicle);

                            MessageBox.Show("Success");
                            resetInitial();
                        }
                    }
                    else if (serviceType == 2)
                    {
                        var checkType = (from SilverBird x in DB.conn
                                         where x.type == vehicleType
                                         select x).ToList();

                        if (checkType.Count != 0)
                        {
                            MessageBox.Show("Vehicle type already exists for this service type!");
                        }
                        else
                        {
                            SilverBird newVehicle = new SilverBird
                            {
                                ID = ID,
                                type = vehicleType,
                                seats = seats,
                                baseFee = Int32.Parse(baseFee),
                                rate = Int32.Parse(rate)
                            };

                            DB.conn.Store(newVehicle);

                            MessageBox.Show("Success");
                            resetInitial();
                        }
                    }
                    else if (serviceType == 3)
                    {
                        var checkType = (from BigBird x in DB.conn
                                         where x.type == vehicleType
                                         select x).ToList();

                        if (checkType.Count != 0)
                        {
                            MessageBox.Show("Vehicle type already exists for this service type!");
                        }
                        else
                        {
                            BigBird newVehicle = new BigBird
                            {
                                ID = ID,
                                type = vehicleType,
                                seats = seats,
                                baseFee = Int32.Parse(baseFee),
                                rate = Int32.Parse(rate)
                            };

                            DB.conn.Store(newVehicle);

                            MessageBox.Show("Success");
                            resetInitial();
                        }
                    }
                }
                else if (selectedButton == 2)
                {
                    var updateVehicle = (from Vehicle x in DB.conn
                                          where x.ID == ID
                                          select x).FirstOrDefault();

                    updateVehicle.type = vehicleType;
                    updateVehicle.seats = seats;
                    updateVehicle.baseFee = Int32.Parse(baseFee);
                    updateVehicle.rate = Int32.Parse(rate);

                    DB.conn.Store(updateVehicle);

                    MessageBox.Show("Success!");

                    resetInitial();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            resetInitial();
        }
    }
}
