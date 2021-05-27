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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        StudentClass p = new StudentClass();
        private void button1_Click(object sender, EventArgs e)
        {

            //insert
            p.AcademicYearSemester = textBox1.Text;
            p.Programme = comboBox1.Text;
            p.GroupNumber = int.Parse(comboBox2.Text);
            p.SubGroupNumber = int.Parse(comboBox3.Text);
            p.GroupID = textBox2.Text;
            p.SubGroupID = textBox3.Text;

            //Inserting data into the database
            bool success = p.Insert(p);
            if (success == true)
            {
                //Successfully Inserted
                MessageBox.Show("Successfully Inserted");
                //Call the method here
                //Clear();



                textBox4.Clear();
                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.Text = string.Empty;
                comboBox3.SelectedIndex = -1;
                textBox2.Clear();
                textBox3.Clear();


            }
            else
            {
                //Failed to add
                MessageBox.Show("Failed to add.Try again");
            }
            //Load Data on Data GridView
            DataTable dt = p.Select();
            dataGridView1.DataSource = dt;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //clear


            textBox4.Clear();
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.Text = string.Empty;
            comboBox3.SelectedIndex = -1;
            textBox2.Clear();
            textBox3.Clear();

            MessageBox.Show("Student Details Are CLEAR!");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //get the data from textboxes
            p.ID = int.Parse(textBox4.Text);
            p.AcademicYearSemester = textBox1.Text;
            p.Programme = comboBox1.Text;
            p.GroupNumber = int.Parse(comboBox2.Text);
            p.SubGroupNumber = int.Parse(comboBox3.Text);
            p.GroupID = textBox2.Text;
            p.SubGroupID = textBox3.Text;

            //update data in database
            bool success = p.Update(p);
            if (success == true)
            {
                //update successfully
                MessageBox.Show("Student has been successfully updated");
                //load data to data grid view
                DataTable dt = p.Select();
                dataGridView1.DataSource = dt;
                //Clear();

                textBox4.Clear();
                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.Text = string.Empty;
                comboBox3.SelectedIndex = -1;
                textBox2.Clear();
                textBox3.Clear();

            }
            else
            {
                //Update failed
                MessageBox.Show("Failed to Update Student");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Get the LocationID From the Application
            p.ID = int.Parse(textBox4.Text);
            bool success = p.Delete(p);
            if (success == true)
            {
                //Successfully Deleted
                MessageBox.Show("Student Succsessfully Delete");
                //Refresh DataGridView
                //load data to data grid view
                DataTable dt = p.Select();
                dataGridView1.DataSource = dt;
                //Clear();


                textBox4.Clear();
                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.Text = string.Empty;
                comboBox3.SelectedIndex = -1;
                textBox2.Clear();
                textBox3.Clear();


            }
            else
            {
                //Faild to Delete
                MessageBox.Show("Failed to Delete");


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string AcademicYearSemester = textBox1.Text;
            string Programme = comboBox1.Text;
            int GroupNumber = int.Parse(comboBox2.Text);
            int SubGroupNumber = int.Parse(comboBox3.Text);


            textBox2.Text = AcademicYearSemester + "." + Programme + "." + GroupNumber;
            textBox3.Text = AcademicYearSemester + "." +  Programme + "." + GroupNumber + "." + SubGroupNumber;


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //Load Data on Data GridView
            DataTable dt = p.Select();
            dataGridView1.DataSource = dt;

            //Add is successfully completed 



            //Method to clear Fields
            // public void Clear()

            textBox4.Clear();
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.Text = string.Empty;
            comboBox3.SelectedIndex = -1;
            textBox2.Clear();
            textBox3.Clear();



        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Get the data from data grid view and Load it to the textboxes respectively
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
        }


        //SEARCH BAR
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBox5.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Student WHERE ID LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
