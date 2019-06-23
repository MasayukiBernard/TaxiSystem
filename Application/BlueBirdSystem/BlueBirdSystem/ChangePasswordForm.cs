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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();
        }

        public void resetFields()
        {
            txtOld.Text = "";
            txtNew.Text = "";
            txtConfirm.Text = "";
        }

        private void BtnChangePw_Click(object sender, EventArgs e)
        {
            var oldPw = txtOld.Text;
            var newPw = txtNew.Text;
            var confPw = txtConfirm.Text;

            IndexForm fm1 = (IndexForm)MdiParent;
            var tempID = fm1.getID();

            if (oldPw.Equals(""))
            {
                MessageBox.Show("Old password can't be empty!");
            }
            else if (newPw.Equals(""))
            {
                MessageBox.Show("New password can't be empty!");
            }
            else if (newPw.Equals(oldPw))
            {
                MessageBox.Show("New password can't be the same as old password!");
            }
            else if (newPw.Length < 6 || newPw.Length > 15)
            {
                MessageBox.Show("Password must be between 6 and 15 characters!");
            }
            else if (!confPw.Equals(newPw))
            {
                MessageBox.Show("Confirm password doesn't match!");
            }
            else
            {
                if (tempID.Contains("CU"))
                {
                    var checkPassword = (from Customer x in DB.conn
                                         where x.password == oldPw
                                         select x.password).FirstOrDefault();

                    if (checkPassword == null)
                    {
                        MessageBox.Show("Incorrect old password!");
                        resetFields();
                    }
                    else
                    {
                        MessageBox.Show("Change Password Success!");

                        var userData = (from Customer x in DB.conn
                                        where x.ID == tempID
                                        select x).FirstOrDefault();

                        userData.password = newPw;

                        DB.conn.Store(userData);

                        MessageBox.Show("Please re-login to update your password!");
                        fm1.logOut();
                        this.Dispose();
                    }
                }
                else if (tempID.Contains("DR"))
                {
                    var checkPassword = (from Driver x in DB.conn
                                         where x.password == oldPw
                                         select x.password).FirstOrDefault();

                    if (checkPassword == null)
                    {
                        MessageBox.Show("Incorrect old password!");
                        resetFields();
                    }
                    else
                    {
                        MessageBox.Show("Change Password Success!");

                        var userData = (from Driver x in DB.conn
                                        where x.ID == tempID
                                        select x).FirstOrDefault();

                        userData.password = newPw;

                        DB.conn.Store(userData);

                        MessageBox.Show("Please re-login to update your password!");
                        fm1.logOut();
                        this.Dispose();
                    }
                }
                else if (tempID.Contains("AD"))
                {
                    var checkPassword = (from Admin x in DB.conn
                                         where x.password == oldPw
                                         select x.password).FirstOrDefault();

                    if (checkPassword == null)
                    {
                        MessageBox.Show("Incorrect old password!");
                        resetFields();
                    }
                    else
                    {
                        MessageBox.Show("Change Password Success!");

                        var userData = (from Admin x in DB.conn
                                        where x.ID == tempID
                                        select x).FirstOrDefault();

                        userData.password = newPw;

                        DB.conn.Store(userData);

                        MessageBox.Show("Please re-login to update your password!");
                        fm1.logOut();
                        this.Dispose();
                    }
                }
            }
        }
    }
}
