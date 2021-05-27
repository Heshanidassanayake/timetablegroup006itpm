using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using timetableforabcinstitute03.timetablemanagementClasses;

namespace timetableforabcinstitute03
{
    public partial class Form13 : Form
    {
        public Form13()
        {
            InitializeComponent();
        }

        NotAvailableRoom nvr = new NotAvailableRoom();

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get the value from input fields
            nvr.RoomID = comboBox1.Text;
            nvr.Day = comboBox2.Text;
            nvr.StartTime = comboBox3.Text;
            nvr.EndTime = comboBox4.Text;


            //Inserting data into the database
            bool success = nvr.Insert(nvr);
            if (success == true)
            {
                //Successfully Inserted
                MessageBox.Show("Successfully Inserted");
                //Call the method here
                //Clear();

                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;

            }
            else
            {
                //Failed to add
                MessageBox.Show("Failed to add.Try again");
            }
            //Load Data
            DataTable dt = nvr.Select();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Call Clear method
            //Clear();

            textBox1.Clear();
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox4.Text = string.Empty;

            MessageBox.Show("Successfully Cleared");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Load Data on Data GridView
            DataTable dt = nvr.Select();
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //get the data from textboxes
            nvr.ID = int.Parse(textBox1.Text);
            nvr.RoomID = comboBox1.Text;
            nvr.Day = comboBox2.Text;
            nvr.StartTime = comboBox3.Text;
            nvr.EndTime = comboBox4.Text;

            //Update data in database
            bool success = nvr.Update(nvr);
            if (success == true)
            {
                //update successfully
                MessageBox.Show("Updated successfully");
                //Load Data on Data GridView
                DataTable dt = nvr.Select();
                dataGridView1.DataSource = dt;

                //call clear button
                //Clear();

                textBox1.Clear();
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;


            }
            else
            {
                //Failed to add
                MessageBox.Show("Failed to add.Try again");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Get Data from the textbox
            nvr.ID = Convert.ToInt32(textBox1.Text);
            bool success = nvr.Delete(nvr);
            if (success == true)
            {
                //successfully Deleted
                MessageBox.Show("Sucessfully Delete");
                //Refresh Data GridView
                //Load Data on Data GridView
                DataTable dt = nvr.Select();
                dataGridView1.DataSource = dt;

                //call the clear method
                //Clear();

                textBox1.Clear();
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;



            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to delete.Try Again");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
        }

        private void Form13_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.WorkingDaysAndHours' table. You can move, or remove it, as needed.
            this.workingDaysAndHoursTableAdapter.Fill(this.timetablemanagement01DataSet1.WorkingDaysAndHours);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Location' table. You can move, or remove it, as needed.
            this.locationTableAdapter.Fill(this.timetablemanagement01DataSet1.Location);

        }
    }
}
