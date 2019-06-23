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
    public partial class ManageDriversForm : Form
    {
        private int selectedButton = 0;

        public ManageDriversForm()
        {
            InitializeComponent();
            txtDriverID.Enabled = false;
            cbVehicleID.Enabled = false;
            nudSeats.Enabled = false;
            resetInitial();
        }

        public void resetInitial()
        {
            showData();
            toggleFields(false);
            toggleButtons(true);
            clearFields();
            selectedButton = 0;
            dgvDrivers.Enabled = true;
        }

        public void showData()
        {
            var driverData = (from Driver x in DB.conn
                              orderby x.ID ascending
                              select new
                              {
                                  DriverID = x.ID,
                                  DriverName = x.name,
                                  DriverKTPNumber = x.KTP,
                                  DriverEmail = x.email,
                                  DriverPhoneNumber = x.phoneNumber,
                                  DriverAddress = x.address,
                                  VehicleID = x.vehicleID
                              }).ToList();

            dgvDrivers.DataSource = driverData;
        }

        public void toggleFields(bool flag)
        {
            txtName.Enabled = flag;
            txtKTP.Enabled = flag;
            txtEmail.Enabled = flag;
            txtPhoneNumber.Enabled = flag;
            txtAddress.Enabled = flag;
            cbService.Enabled = flag;
            cbVehicleType.Enabled = flag;
        }

        public void clearFields()
        {
            txtDriverID.Text = "";
            txtName.Text = "";
            txtKTP.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            txtAddress.Text = "";
            cbVehicleID.SelectedIndex = 0;
            cbService.SelectedIndex = 0;
            cbVehicleType.SelectedIndex = 0;
            nudSeats.Value = 0;
        }

        public void toggleButtons(bool flag)
        {
            btnInsert.Enabled = flag;
            btnUpdate.Enabled = flag;
            btnDelete.Enabled = flag;
            btnCancel.Enabled = !flag;
            btnSave.Enabled = !flag;
        }

        private void DgvDrivers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtDriverID.Text = dgvDrivers.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvDrivers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtKTP.Text = dgvDrivers.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtEmail.Text = dgvDrivers.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtPhoneNumber.Text = dgvDrivers.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtAddress.Text = dgvDrivers.Rows[e.RowIndex].Cells[5].Value.ToString();
                cbVehicleID.Text = dgvDrivers.Rows[e.RowIndex].Cells[6].Value.ToString();

                var vehicleID = cbVehicleID.Text;

                var checkVehicle = (from Vehicle x in DB.conn
                                    where x.ID == vehicleID
                                    select x).FirstOrDefault();

                if (checkVehicle.GetType().IsInstanceOfType(new BlueBird()))
                {
                    cbService.SelectedIndex = 1;

                }
                else if (checkVehicle.GetType().IsInstanceOfType(new SilverBird()))
                {
                    cbService.SelectedIndex = 2;
                }
                else if (checkVehicle.GetType().IsInstanceOfType(new BigBird()))
                {
                    cbService.SelectedIndex = 3;
                }

                cbVehicleType.Text = checkVehicle.type;
                nudSeats.Value = checkVehicle.seats;
            }
        }

        public String generateID()
        {
            String newID = "";

            var lastID = (from Driver x in DB.conn
                          orderby x.ID ascending
                          select x.ID).LastOrDefault();

            if (lastID != null)
            {
                int digit = Int32.Parse(lastID.Substring(2));
                digit++;
                newID = "DR" + digit.ToString("d3");
            }
            else
            {
                newID = "DR001";
            }

            return newID;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            toggleFields(true);
            clearFields();
            toggleButtons(false);
            dgvDrivers.Enabled = false;

            txtDriverID.Text = generateID();

            selectedButton = 1;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if (txtDriverID.Text.Equals(""))
            {
                MessageBox.Show("Please select a user!");
            }
            else
            {
                toggleFields(true);
                toggleButtons(false);

                selectedButton = 2;
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (txtDriverID.Text.Equals(""))
            {
                MessageBox.Show("Please select a user!");
            }
            else
            {
                var result = MessageBox.Show("Are you sure?", "Confirmation Message", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    var userID = txtDriverID.Text;

                    var checkOrders = (from Order x in DB.conn
                                       where x.driverID == userID
                                       && x.completed == false
                                       select x).FirstOrDefault();

                    if (checkOrders == null)
                    {
                        var deleteDriver = (from Driver x in DB.conn
                                            where x.ID == userID
                                            select x).FirstOrDefault();

                        DB.conn.Delete(deleteDriver);

                        MessageBox.Show("Driver has been removed!");
                    }
                    else
                    {
                        MessageBox.Show("Unable to remove driver! Driver is currenlty on an ongoing trip!");
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
            var driverID = txtDriverID.Text;
            var name = txtName.Text;
            var ktp = txtKTP.Text;
            var email = txtEmail.Text;
            var phoneNum = txtPhoneNumber.Text;
            var address = txtAddress.Text;
            var vehicleID = cbVehicleID.Text;

            if (name.Equals(""))
            {
                MessageBox.Show("Name can't be empty!");
            }
            else if (ktp.Length < 15)
            {
                MessageBox.Show("KTP Number must be at least 15 characters!");
            }
            else if (checkDigit(ktp) != 0)
            {
                MessageBox.Show("KTP number must be numeric!");
            }
            else if (email.Equals(""))
            {
                MessageBox.Show("Email can't be empty!");
            }
            else if (!email.Contains("@") || !email.Contains("."))
            {
                MessageBox.Show("Email format is incorrect!");
            }
            else if (email.IndexOf("@") == 0 || email.EndsWith("@"))
            {
                MessageBox.Show("Email format is incorrect!");
            }
            else if (email.IndexOf(".") == 0 || email.EndsWith("."))
            {
                MessageBox.Show("Email format is incorrect!");
            }
            else if (email.IndexOf("@") > email.IndexOf("."))
            {
                MessageBox.Show("Email format is incorrect!");
            }
            else if (email.IndexOf("@") + 1 == email.IndexOf("."))
            {
                MessageBox.Show("Email format is incorrect!");
            }
            else if (!email.EndsWith(".com") && !email.EndsWith(".co.id"))
            {
                MessageBox.Show("Email must end with '.com' or '.co.id'!");
            }
            else if (phoneNum.Equals(""))
            {
                MessageBox.Show("Phone number can't be empty!");
            }
            else if (phoneNum.Length < 9)
            {
                MessageBox.Show("Phone number must be more than 9 characters!");
            }
            else if (checkDigit(phoneNum) != 0)
            {
                MessageBox.Show("Phone number must be numeric!");
            }
            else if (address.Equals(""))
            {
                MessageBox.Show("Address can't be empty!");
            }
            else if (!address.EndsWith("Street"))
            {
                MessageBox.Show("Address must ends with 'Street'!");
            }
            else if (vehicleID.Equals("-- Choose Vehicle --"))
            {
                MessageBox.Show("Vehicle must be chosen!");
            }
            else
            {
                if (selectedButton == 1)
                {
                    var checkEmail = (from Driver x in DB.conn
                                      where x.email == email
                                      select x).ToList();

                    if (checkEmail.Count != 0)
                    {
                        MessageBox.Show("Email is already linked to an existing account!");
                    }
                    else
                    {
                        Driver newDriver = new Driver
                        {
                            ID = driverID,
                            name = name,
                            KTP = ktp,
                            email = email,
                            phoneNumber = phoneNum,
                            address = address,
                            vehicleID = vehicleID,
                            password = "default"
                        };

                        DB.conn.Store(newDriver);

                        MessageBox.Show("Success");
                        resetInitial();
                    }
                }
                else if (selectedButton == 2)
                {
                    var updateDriver = (from Driver x in DB.conn
                                        where x.ID == driverID
                                        select x).FirstOrDefault();

                    updateDriver.name = name;
                    updateDriver.KTP = ktp;
                    updateDriver.email = email;
                    updateDriver.phoneNumber = phoneNum;
                    updateDriver.address = address;
                    updateDriver.vehicleID = vehicleID;
                    updateDriver.password = "default";

                    DB.conn.Store(updateDriver);

                    MessageBox.Show("Success!");

                    resetInitial();
                }
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            resetInitial();
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
                cbVehicleID.Text = "-- Choose Vehicle --";
                cbVehicleType.SelectedIndex = 0;
                nudSeats.Value = 0;
            }
        }

        private void CbVehicleType_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedVehicle = cbVehicleType.Text;
            var selectedService = cbService.SelectedIndex;

            if (selectedService == 1)
            {
                var vehicleData = (from BlueBird x in DB.conn
                                   where x.type == selectedVehicle
                                   select x).FirstOrDefault();

                if (cbVehicleType.SelectedIndex != 0)
                {
                    cbVehicleID.Text = vehicleData.ID;
                    nudSeats.Value = Decimal.Parse(vehicleData.seats.ToString());
                }
                else
                {
                    cbVehicleID.Text = "-- Choose Vehicle --";
                    nudSeats.Value = 0;
                }
            }
            else if (selectedService == 2)
            {
                var vehicleData = (from SilverBird x in DB.conn
                                   where x.type == selectedVehicle
                                   select x).FirstOrDefault();

                if (cbVehicleType.SelectedIndex != 0)
                {
                    cbVehicleID.Text = vehicleData.ID;
                    nudSeats.Value = Decimal.Parse(vehicleData.seats.ToString());
                }
                else
                {
                    cbVehicleID.Text = "-- Choose Vehicle --";
                    nudSeats.Value = 0;
                }
            }
            else if (selectedService == 3)
            {
                var vehicleData = (from BigBird x in DB.conn
                                   where x.type == selectedVehicle
                                   select x).FirstOrDefault();

                if (cbVehicleType.SelectedIndex != 0)
                {
                    cbVehicleID.Text = vehicleData.ID;
                    nudSeats.Value = Decimal.Parse(vehicleData.seats.ToString());
                }
                else
                {
                    cbVehicleID.Text = "-- Choose Vehicle --";
                    nudSeats.Value = 0;
                }
            }
            else
            {
                cbVehicleID.Text = "-- Choose Vehicle --";
                nudSeats.Value = 0;
            }
        }
    }
}
