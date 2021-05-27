using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using timetableforabcinstitute03.timetablemanagementClasses;

namespace timetableforabcinstitute03
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        timeClass time = new timeClass();
        private void button1_Click(object sender, EventArgs e)
        {

            // Get the value from input fields
            time.TimeBlock = comboBox1.Text;
            time.Duration = comboBox2.Text;

            //Inserting data into the database
            bool success = time.Insert(time);
            if (success == true)
            {
                //Successfully Inserted
                MessageBox.Show("Successfully Inserted");
                //Call the method here
                //Clear();
                textBox2.Clear();
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
            }
            else
            {
                //Failed to add
                MessageBox.Show("Failed to add.Try again");
            }
            //Load Data on Data GridView
            DataTable dt = time.Select();
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Call Clear method
            //Clear();
            textBox2.Clear();
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            MessageBox.Show("Successfully Cleared");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Get the data from data grid view and Load it to the textboxes respectively
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
        }


        //SEARCH BAR
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBox1.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Addtimeslot WHERE SlotID LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            //sda.Fill(dt);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //get the data from textboxes
            time.SlotID = int.Parse(textBox2.Text);
            time.TimeBlock = comboBox1.Text;
            time.Duration = comboBox2.Text;

            //Update data in database
            bool success = time.Update(time);
            if (success == true)
            {
                //update successfully
                MessageBox.Show("Updated successfully");
                //Load Data on Data GridView
                DataTable dt = time.Select();
                dataGridView1.DataSource = dt;

                //call clear button
                //Clear();
                textBox2.Clear();
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
            }
            else
            {
                //Failed to add
                MessageBox.Show("Failed to add.Try again");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Get Data from the textbox
            time.SlotID = Convert.ToInt32(textBox2.Text);
            bool success = time.Delete(time);
            if (success == true)
            {
                //successfully Deleted
                MessageBox.Show("Sucessfully Delete");
                //Refresh Data GridView
                //Load Data on Data GridView
                DataTable dt = time.Select();
                dataGridView1.DataSource = dt;

                //call the clear method
                //Clear();
                //textBox1.Clear();
                //comboBox1.Text = string.Empty;
                //comboBox2.Text = string.Empty;
                textBox2.Clear();
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to delete.Try Again");
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from data grid view and Load it to the textboxes respectively
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            {
                //Load Data on Data GridView
                DataTable dt = time.Select();
                dataGridView1.DataSource = dt;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}


