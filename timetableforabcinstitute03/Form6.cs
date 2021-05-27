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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        DayHour day = new DayHour();
        private void button1_Click(object sender, EventArgs e)
        {
            //Get the value from input fields

            day.ActiveNoOfDays = int.Parse(comboBox1.Text);
            day.ActiveDaysPerWeekDay01 = comboBox2.Text;
            day.ActiveDaysPerWeekDay02 = comboBox3.Text;
            day.ActiveDaysPerWeekDay03 = comboBox4.Text;
            day.ActiveDaysPerWeekDay04 = comboBox5.Text;
            day.ActiveDaysPerWeekDay05 = comboBox6.Text;
            day.ActiveDaysPerWeekDay06 = comboBox7.Text;
            day.ActiveDaysPerWeekDay07 = comboBox8.Text;
            day.ActiveHours = int.Parse(comboBox9.Text);
            day.ActiveMinutes = int.Parse(comboBox10.Text);

            //Inserting data into the database
            bool success = day.Insert(day);
            if (success == true)
            {
                //Successfully Inserted
                MessageBox.Show("Successfully Inserted");
                //Call the method here
                //Clear();



                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;
                comboBox7.SelectedIndex = -1;
                comboBox8.SelectedIndex = -1;
                comboBox9.SelectedIndex = -1;
                comboBox10.SelectedIndex = -1;

            }
            else
            {
                //Failed to add
                MessageBox.Show("Failed to add.Try again");
            }
            //Load Data on Data GridView
            DataTable dt = day.Select();
            dataGridView1.DataSource = dt;


        }



        private void button2_Click(object sender, EventArgs e)
        {
            //get the data from textboxes
            day.entryID = int.Parse(textBox1.Text);
            day.ActiveNoOfDays = int.Parse(comboBox1.Text);
            day.ActiveDaysPerWeekDay01 = comboBox2.Text;
            day.ActiveDaysPerWeekDay02 = comboBox3.Text;
            day.ActiveDaysPerWeekDay03 = comboBox4.Text;
            day.ActiveDaysPerWeekDay04 = comboBox5.Text;
            day.ActiveDaysPerWeekDay05 = comboBox6.Text;
            day.ActiveDaysPerWeekDay06 = comboBox7.Text;
            day.ActiveDaysPerWeekDay07 = comboBox8.Text;
            day.ActiveHours = int.Parse(comboBox9.Text);
            day.ActiveMinutes = int.Parse(comboBox10.Text);

            //Update data in database
            bool success = day.Update(day);
            if (success == true)
            {
                //update successfully
                MessageBox.Show("Updated successfully");
                //Load Data on Data GridView
                DataTable dt = day.Select();
                dataGridView1.DataSource = dt;

                //call clear button
                //Clear();

                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;
                comboBox7.SelectedIndex = -1;
                comboBox8.SelectedIndex = -1;
                comboBox9.SelectedIndex = -1;
                comboBox10.SelectedIndex = -1;


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
           // day.entryID = Convert.ToInt32(textBox4.Text);
            bool success = day.Delete(day);
            if (success == true)
            {
                //successfully Deleted
                MessageBox.Show("Sucessfully Delete");
                //Refresh Data GridView
                //Load Data on Data GridView
                DataTable dt = day.Select();
                dataGridView1.DataSource = dt;

                //call the clear method
                //Clear();


                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;
                comboBox7.SelectedIndex = -1;
                comboBox8.SelectedIndex = -1;
                comboBox9.SelectedIndex = -1;
                comboBox10.SelectedIndex = -1;


            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to delete.Try Again");
            }
        }


        private void button5_Click(object sender, EventArgs e)
        {
            //Call Clear method
            //Clear();


            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            comboBox7.SelectedIndex = -1;
            comboBox8.SelectedIndex = -1;
            comboBox9.SelectedIndex = -1;
            comboBox10.SelectedIndex = -1;

            MessageBox.Show("Successfully Cleared");

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            comboBox6.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            comboBox7.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            comboBox8.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
            comboBox9.Text = dataGridView1.Rows[rowIndex].Cells[9].Value.ToString();
            comboBox10.Text = dataGridView1.Rows[rowIndex].Cells[10].Value.ToString();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            //Load Data on Data GridView
            DataTable dt = day.Select();
            dataGridView1.DataSource = dt;
        }

        //SEARCH BAR
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBox2.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM WorkingDaysAndHours  WHERE ActiveNoOfDays LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            // sda.Fill(dt);
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
