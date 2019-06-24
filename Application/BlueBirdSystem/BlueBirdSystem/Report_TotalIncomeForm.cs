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
    public partial class Report_TotalIncomeForm : Form
    {
        public Report_TotalIncomeForm()
        {
            InitializeComponent();
            initState();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            filteByCb.SelectedIndex = 0;
            dateTimePicker1.Text = "";
            dateTimePicker2.Text = "";
        }

        private void initState()
        {
            dateTimePicker1.Enabled = false;
            dateTimePicker2.Enabled = false;
            result1Tb.Enabled = false;
            result2Tb.Enabled = false;
            dateTimePicker1.Visible = false;
            dateTimePicker2.Visible = false;
            textBox1.Visible = true;
            textBox2.Visible = true;
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker2.ShowUpDown = true;
        }

        private void FilteByCb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (filteByCb.SelectedIndex == 0)
            {
                textBox1.Text = "";
                textBox2.Text = "";

                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                textBox1.Visible = true;
                textBox2.Visible = true;
                dateTimePicker1.Enabled = false;
                dateTimePicker2.Enabled = false;
            }
            else if (filteByCb.SelectedIndex == 1)
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "MMMM";
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "MMMM";

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
            else if (filteByCb.SelectedIndex == 2)
            {
                dateTimePicker1.Format = DateTimePickerFormat.Custom;
                dateTimePicker1.CustomFormat = "yyyy";
                dateTimePicker2.Format = DateTimePickerFormat.Custom;
                dateTimePicker2.CustomFormat = "yyyy";

                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                textBox1.Visible = false;
                textBox2.Visible = false;
                dateTimePicker1.Enabled = true;
                dateTimePicker2.Enabled = true;
            }
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            int option = filteByCb.SelectedIndex;
            int date1 = 0;
            int date2 = 0;
            if (option == 0)
                MessageBox.Show("Please pick a filter !!");
            else
            {
                var resultByMonth1 = (from Order x in DB.conn select x.price);
                var resultByMonth2 = (from Order x in DB.conn select x.price);

                if (option == 1)
                {
                    date1 = dateTimePicker1.Value.Month;
                    date2 = dateTimePicker2.Value.Month;
                    resultByMonth1 = (from Order x
                                      in DB.conn
                                      where x.completed == true && x.orderDate.Month == date1
                                      select x.price);


                    resultByMonth2 = (from Order x
                                      in DB.conn
                                      where x.completed == true && x.orderDate.Month == date2
                                      select x.price);

                }
                else if (option == 2)
                {
                    date1 = dateTimePicker1.Value.Year;
                    date2 = dateTimePicker2.Value.Year;
                    resultByMonth1 = (from Order x
                                     in DB.conn
                                      where x.completed == true && x.orderDate.Year == date1
                                      select x.price);


                    resultByMonth2 = (from Order x
                                      in DB.conn
                                      where x.completed == true && x.orderDate.Year == date2
                                      select x.price);
                }
                result1Tb.Text = resultByMonth1.Sum().ToString();
                result2Tb.Text = resultByMonth2.Sum().ToString();
            }
        }
    }
}
