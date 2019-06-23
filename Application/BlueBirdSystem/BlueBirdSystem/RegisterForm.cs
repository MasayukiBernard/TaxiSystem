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
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
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

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            var name = txtName.Text;
            var email = txtEmail.Text;
            var phoneNum = txtPhoneNum.Text;
            var password = txtPassword.Text;
            var confPass = txtConfirm.Text;

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
                MessageBox.Show("Phone number can't be empty");
            }
            else if (phoneNum.Length < 9)
            {
                MessageBox.Show("Phone number must be at least 9 characters!");
            }
            else if (checkDigit(phoneNum) != 0)
            {
                MessageBox.Show("Phone number must be numeric!");
            }
            else if (password.Equals(""))
            {
                MessageBox.Show("Password can't be empty!");
            }
            else if (password.Length < 6 || password.Length > 15)
            {
                MessageBox.Show("Password must be between 6 and 15 characters!");
            }
            else if (confPass.Equals(""))
            {
                MessageBox.Show("Confirm password can't be empty!");
            }
            else if (!confPass.Equals(password))
            {
                MessageBox.Show("Confirm password doesn't match!");
            }
            else
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
                    var newID = generateID();

                    Customer newCustomer = new Customer
                    {
                        ID = newID,
                        name = name,
                        email = email,
                        phoneNumber = phoneNum,
                        password = password
                    };

                    DB.conn.Store(newCustomer);

                    MessageBox.Show("Success");
                    this.Dispose();
                }
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
    }
}
