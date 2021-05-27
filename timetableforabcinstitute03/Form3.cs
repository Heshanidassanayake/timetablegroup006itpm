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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        SqlConnection conn = new SqlConnection(myconnstrng);
        public int LecturerID;
        public string LecturerRank;
        Boolean empty = false;



        lecturerClass c = new lecturerClass();





        //Generate Rank 

        public void GenerateRank()
        {
            int level_value;
            if (comboBox5.Text == "Professor")
            {
                level_value = 1;
            }
            else if (comboBox5.Text == "Assistant Professor")
            {
                level_value = 2;
            }
            else if (comboBox5.Text == "Senior Lecturer(HG)")
            {
                level_value = 3;
            }
            else if (comboBox5.Text == "Senior Lecturer")
            {
                level_value = 4;
            }
            else if (comboBox5.Text == "Lecturer")
            {
                level_value = 5;
            }
            else
            {
                level_value = 6;
            }


            if (textBox2.Text != "" && comboBox5.Text != "")
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(level_value + "." + textBox2.Text);

                textBox3.Text = sb.ToString();
            }
        }




        private void button1_Click(object sender, EventArgs e)
        {

            //Get the value from the input fields
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text !="" && comboBox2.Text !="" && comboBox3.Text !="" && comboBox4.Text !="" && comboBox5.Text !="" && textBox3.Text !="")
            {
                c.LecturerName = textBox1.Text;
                c.EmployeeID = int.Parse(textBox2.Text);
                c.Faculty = comboBox1.Text;
                c.Department = comboBox2.Text;
                c.Center = comboBox3.Text;
                c.Building = comboBox4.Text;
                c.LecturerLevel = comboBox5.Text;
                c.Rank = textBox3.Text;
                empty = false;
            }
            else
            {
                MessageBox.Show("Please Enter Empty Fields");
                empty = true;
            }


            if (!empty)
            {


                //Inserting Data into Database using the method
                bool success = c.Insert(c);
                if (success == true)
                {
                    //Successfully Inserted
                    MessageBox.Show("New Lecturer Successfully Inserted!");
                    //call the clear method here
                    // Clear();


                    textBox4.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox5.SelectedIndex = -1;
                    textBox3.Clear();


                }
                else
                {
                    //Failed to Add Lecturer
                    MessageBox.Show("Failed to add New Lecturer.Try Again");
                }

                //Load Data on Data GridView
                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            //Load Data on Data GridView
            DataTable dt = c.Select();
            dataGridView1.DataSource = dt;

            //Add is successfully completed 



            //Method to clear Fields
            // public void Clear()
            textBox4.Clear();
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            textBox3.Clear();



        }
        

        private void button3_Click(object sender, EventArgs e)
        {
               GenerateRank();

            //Get the data from the text box
               c.ID = int.Parse(textBox4.Text);
               c.LecturerName = textBox1.Text;
               c.EmployeeID = int.Parse(textBox2.Text);
               c.Faculty = comboBox1.Text;
               c.Department = comboBox2.Text;
               c.Center = comboBox3.Text;
               c.Building = comboBox4.Text;
               c.LecturerLevel = comboBox5.Text;
               c.Rank = textBox3.Text;

            //Update Data in database
            bool success = c.Update(c);
            if(success == true)
            {
                //update successfully
                MessageBox.Show("Lecturer has been Successfully Update.");
                //Load Data on Data GridView
                DataTable dt = c.Select();
                dataGridView1.DataSource = dt;

                //call clear button
                //Clear();

                textBox4.Clear();
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                textBox3.Clear();



            }
            else
            {
                //failed to update
                MessageBox.Show("Failed to update Lecturer.Try Again.");
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from data grid view and Load it to the textboxes respectively
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBox4.Text   = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox1.Text   = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox2.Text   = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            comboBox1.Text  = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBox2.Text  = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            comboBox3.Text  = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            comboBox4.Text  = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            comboBox5.Text  = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            textBox3.Text   = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //call clear method here
            //Clear();
            textBox4.Clear();
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            textBox3.Clear();
            MessageBox.Show("Lecturer Details Are CLEAR!");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //get the lecturer id from the application
            c.ID = Convert.ToInt32(textBox4.Text);
            bool success = c.Delete(c);
            if (success == true)
            {
                //successfully Deleted
                if (MessageBox.Show("Are You Sure You Want to Delete the Lecturer?", "Delete Lecturer", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    MessageBox.Show("Lecturer sucessfully Delete.");
                    //Refresh Data GridView
                    //Load Data on Data GridView
                    DataTable dt = c.Select();
                    dataGridView1.DataSource = dt;

                    //call the clear method
                    //Clear();
                    textBox4.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox5.SelectedIndex = -1;
                    textBox3.Clear();



                }
            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to Delete Lecturer. Try Again.");
            }
        }

        private void button5_Click(object sender, EventArgs e)

        {
            GenerateRank();
        
        }

        



        //SEARCH BAR
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void textBox5_TextChanged_1(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBox5.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Lecturer WHERE LecturerName LIKE '%" + keyword + "%' OR EmployeeID LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }

}

