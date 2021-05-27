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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        locationClass c = new locationClass();
        private void Form7_Load(object sender, EventArgs e)
        {

            //Load the data in data gridView
            //DataTable dt = c.Select();
            //dataGridView1.DataSource = dt;

            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;

        }
        //method to clear field
        public void Clear()
        {
            textBox2.Text = "";
            txtBname.Text = "";
            txtRname.Text = "";
            txtType.Text = "";
            txtCapacity.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //Get the value from the imput field
            c.BuildingName = txtBname.Text;
            c.RoomName = txtRname.Text;
            c.RoomType = txtType.Text;
            c.Capacity = int.Parse(txtCapacity.Text);

            //Inserting data into database using the method we created in previous episode
            bool success = c.Insert(c);
            if (success == true)
            {
                //Successfully inserted
                MessageBox.Show("New Loction Successfully Inserted");
                //call clear method here
                Clear();
            }
            else
            {
                //Failed to Add contact
                MessageBox.Show("Failed to add new location. Try again!");
            }
            //Load the data in data gridView
            //DataTable dt = c.Select();
            //dataGridView1.DataSource = dt;
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //get the data from textboxes
            c.LocationID = int.Parse(textBox2.Text);
            c.BuildingName = txtBname.Text;
            c.RoomName = txtRname.Text;
            c.RoomType = txtType.Text;
            c.Capacity = int.Parse(txtCapacity.Text);

            //update data in database
            bool success = c.Update(c);
            if (success == true)
            {
                //update successfully
                MessageBox.Show("Location has been successfully updated");
                //load data to data grid view
                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;
                Clear();
            }
            else
            {
                //Update failed
                MessageBox.Show("Failed to Update Location");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Get the LocationID From the Application
            c.LocationID = int.Parse(textBox2.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                //Successfully Deleted
                MessageBox.Show("Location Succsessfully Delete");
                //Refresh DataGridView
                //load data to data grid view
                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;
                Clear();

            }
            else
            {
                //Faild to Delete
                MessageBox.Show("Failed to Delete");


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Call Clear Method here
            Clear();

        }


        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from Datagridview and load it to the textboxes respectivly
            //Identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            txtBname.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            txtRname.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            txtType.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            txtCapacity.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();


        }

        //SEARCH BAR
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //get the value from text box
            string keyword = txtsearch.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Location WHERE LocationID LIKE '%" + keyword + "%' OR BuildingName LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
