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
    public partial class ManageAdminsForm : Form
    {
        private int selectedButton = 0;

        public ManageAdminsForm()
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
            dgvAdmins.Enabled = true;
        }

        public void showData()
        {
            var adminData = (from Admin x in DB.conn
                             orderby x.ID ascending
                             select new
                             {
                                 AdminID = x.ID,
                                 AdminName = x.name,
                                 AdminEmail = x.email,
                             }).ToList();

            dgvAdmins.DataSource = adminData;
        }

        public void toggleFields(bool flag)
        {
            txtName.Enabled = flag;
            txtEmail.Enabled = flag;
        }

        public void clearFields()
        {
            txtID.Text = "";
            txtName.Text = "";
            txtEmail.Text = "";
        }

        public void toggleButtons(bool flag)
        {
            btnInsert.Enabled = flag;
            btnUpdate.Enabled = flag;
            btnDelete.Enabled = flag;
            btnCancel.Enabled = !flag;
            btnSave.Enabled = !flag;
        }

        private void DgvAdmins_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                txtID.Text = dgvAdmins.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dgvAdmins.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEmail.Text = dgvAdmins.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        public String generateID()
        {
            String newID = "";

            var lastID = (from Admin x in DB.conn
                          orderby x.ID ascending
                          select x.ID).LastOrDefault();

            if (lastID != null)
            {
                int digit = Int32.Parse(lastID.Substring(2));
                digit++;
                newID = "AD" + digit.ToString("d3");
            }
            else
            {
                newID = "AD001";
            }

            return newID;
        }

        private void BtnInsert_Click(object sender, EventArgs e)
        {
            toggleFields(true);
            clearFields();
            toggleButtons(false);
            dgvAdmins.Enabled = false;

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
                    IndexForm fm1 = (IndexForm)MdiParent;
                    var currID = fm1.getID();

                    var userID = txtID.Text;

                    var checkAdmin = (from Admin x in DB.conn
                                      select x).ToList();

                    if (checkAdmin.Count == 1)
                    {
                        MessageBox.Show("User delete failed! You are the only admin left!");
                    }
                    else
                    {
                        var deleteAdmin = (from Admin x in DB.conn
                                           where x.ID == userID
                                           select x).FirstOrDefault();

                        DB.conn.Delete(deleteAdmin);

                        MessageBox.Show("Admin has been removed!");

                        resetInitial();

                        if (currID.Equals(userID))
                        {
                            MessageBox.Show("Your account has been removed!");
                            fm1.logOut();
                        }
                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            var ID = txtID.Text;
            var name = txtName.Text;
            var email = txtEmail.Text;

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
            else
            {
                if (selectedButton == 1)
                {
                    var checkEmail = (from Admin x in DB.conn
                                      where x.email == email
                                      select x).ToList();

                    if (checkEmail.Count != 0)
                    {
                        MessageBox.Show("Email is already linked to an existing account!");
                    }
                    else
                    {
                        Admin newAdmin = new Admin
                        {
                            ID = ID,
                            name = name,
                            email = email,
                            password = "admin"
                        };

                        DB.conn.Store(newAdmin);

                        MessageBox.Show("Success");
                        resetInitial();
                    }
                }
                else if (selectedButton == 2)
                {
                    var updateAdmin = (from Admin x in DB.conn
                                          where x.ID == ID
                                          select x).FirstOrDefault();

                    updateAdmin.name = name;
                    updateAdmin.email = email;
                    updateAdmin.password = "admin";

                    DB.conn.Store(updateAdmin);

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
