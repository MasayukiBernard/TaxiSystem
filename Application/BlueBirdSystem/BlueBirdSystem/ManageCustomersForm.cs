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
    public partial class ManageCustomersForm : Form
    {
        private int selectedButton = 0;

        public ManageCustomersForm()
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
            dgvCustomers.Enabled = true;
        }

        public void showData()
        {
            var customerData = (from Customer x in DB.conn
                                orderby x.ID ascending
                                select new
                                {
                                    CustomerID = x.ID,
                                    CustomerName = x.name,
                                    CustomerEmail = x.email,
                                    CustomerPhone = x.phoneNumber,
                                }).ToList();

            dgvCustomers.DataSource = customerData;
        }

        public void toggleFields(bool flag)
        {
            txtName.Enabled = flag;
            txtEmail.Enabled = flag;
            txtPhoneNum.Enabled = flag;
        }

        public void clearFields()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhoneNum.Text = "";
        }

        public void toggleButtons(bool flag)
        {
            btnInsert.Enabled = flag;
            btnUpdate.Enabled = flag;
            btnDelete.Enabled = flag;
            btnCancel.Enabled = !flag;
            btnSave.Enabled = !flag;
        }

        private void DgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtID.Text = dgvCustomers.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvCustomers.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEmail.Text = dgvCustomers.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtPhoneNum.Text = dgvCustomers.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        public String generateID()
        {
            String newID = "";

            var lastID = (from Customer x in DB.conn
                          orderby x.ID ascending
                          select x.ID).LastOrDefault();

            if (lastID != null)
            {
                int digit = Int32.Parse(lastID.Substring(2));
                digit++;
                newID = "CU" + digit.ToString("d3");
            }
            else
            {
                newID = "CU001";
            }

            return newID;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            toggleFields(true);
            clearFields();
            toggleButtons(false);
            dgvCustomers.Enabled = false;

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
                    var userID = txtID.Text;

                    var checkOrders = (from Order x in DB.conn
                                       where x.customerID == userID
                                       && x.driverID != null
                                       && x.completed == false
                                       select x).FirstOrDefault();

                    if (checkOrders == null)
                    {
                        var deleteCustomer = (from Customer x in DB.conn
                                              where x.ID == userID
                                              select x).FirstOrDefault();

                        DB.conn.Delete(deleteCustomer);

                        var deleteOrder = (from Order x in DB.conn
                                           where x.customerID == userID
                                           select x).ToList();

                        foreach (Order o in deleteOrder)
                        {
                            DB.conn.Delete(o);
                        }

                        var deletePayment = (from Payment x in DB.conn
                                             where x.customerID == userID
                                             select x).ToList();

                        foreach (Payment p in deletePayment)
                        {
                            DB.conn.Delete(p);
                        }

                        MessageBox.Show("Customer has been removed!");
                    }
                    else
                    {
                        MessageBox.Show("Unable to remove customer! Customer is currenlty on an ongoing trip!");
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
            var name = txtName.Text;
            var email = txtEmail.Text;
            var phoneNum = txtPhoneNum.Text;

            if (name.Equals(""))
            {
                MessageBox.Show("Name can't be empty!");
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
                MessageBox.Show("Phone number must be at least 9 characters!");
            }
            else if (checkDigit(phoneNum) != 0)
            {
                MessageBox.Show("Phone number must be numeric!");
            }
            else
            {
                if (selectedButton == 1)
                {
                    var checkEmail = (from Customer x in DB.conn
                                      where x.email == email
                                      select x).ToList();

                    if (checkEmail.Count != 0)
                    {
                        MessageBox.Show("Email is already linked to an existing account!");
                    }
                    else
                    {
                        Customer newCustomer = new Customer
                        {
                            ID = ID,
                            name = name,
                            email = email,
                            phoneNumber = phoneNum,
                            password = "default"
                        };

                        DB.conn.Store(newCustomer);

                        MessageBox.Show("Success");
                        resetInitial();
                    }
                }
                else if (selectedButton == 2)
                {
                    var updateCustomer = (from Customer x in DB.conn
                                      where x.ID == ID
                                      select x).FirstOrDefault();

                    updateCustomer.name = name;
                    updateCustomer.email = email;
                    updateCustomer.password = "default";
                    updateCustomer.phoneNumber = phoneNum;

                    DB.conn.Store(updateCustomer);

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
