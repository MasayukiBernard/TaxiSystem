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
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            resetFields();
        }

        public void resetFields()
        {
            txtEmail.Text = "";
            txtPassword.Text = "";
            cbRole.SelectedIndex = 0;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            var role = cbRole.SelectedIndex;
            var email = txtEmail.Text;
            var password = txtPassword.Text;

            if (email.Equals("") || password.Equals(""))
            {
                MessageBox.Show("Email or Password can't be empty!");
            }
            else if (role == 0)
            {
                MessageBox.Show("Role must be selected!");
            }
            else
            {
                if (role == 1)
                {
                    var userLogin = (from Customer x in DB.conn
                                         where x.email == email && x.password == password
                                         select x).FirstOrDefault();

                    if (userLogin == null)
                    {
                        MessageBox.Show("Incorrect Email or Password!");
                        resetFields();
                    }
                    else
                    {
                        MessageBox.Show("Login Success");

                        IndexForm fm1 = (IndexForm)MdiParent;
                        fm1.customerMenuState();
                        fm1.setID(userLogin.ID);

                        this.Dispose();
                    }
                }
                else if (role == 2)
                {
                    var userLogin = (from Driver x in DB.conn
                                       where x.email == email && x.password == password
                                       select x).FirstOrDefault();

                    if (userLogin == null)
                    {
                        MessageBox.Show("Incorrect Email or Password!");
                        resetFields();
                    }
                    else
                    {
                        MessageBox.Show("Login Success");

                        IndexForm fm1 = (IndexForm)MdiParent;
                        fm1.driverMenuState();
                        fm1.setID(userLogin.ID);

                        this.Dispose();
                    }
                }
                else if (role == 3)
                {
                    var userLogin = (from Admin x in DB.conn
                                      where x.email == email && x.password == password
                                      select x).FirstOrDefault();

                    if (userLogin == null)
                    {
                        MessageBox.Show("Incorrect Email or Password!");
                        resetFields();
                    }
                    else
                    {
                        MessageBox.Show("Login Success");

                        IndexForm fm1 = (IndexForm)MdiParent;
                        fm1.adminMenuState();
                        fm1.setID(userLogin.ID);

                        this.Dispose();
                    }
                }
            }
        }
    }
}
