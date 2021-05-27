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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        Boolean empty = false;
        SubjectClass d = new SubjectClass();

        private void button1_Click(object sender, EventArgs e)
        {


            //Get the value from the input fields
            if (textBox1.Text != "" && textBox2.Text != "" && comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "")
            {
                //Get the value from the input fields
                d.SubjectName = textBox1.Text;
                d.SubjectCode = textBox2.Text;
                d.OfferedYear = comboBox1.Text;
                d.OfferedSemester = comboBox2.Text;
                d.NumberOfLectureHours = int.Parse(comboBox3.Text);
                d.NumberOfTutorialHours = int.Parse(comboBox4.Text);
                d.NumberOfLabHours = int.Parse(comboBox5.Text);
                d.NumberOfEvaluationHours = int.Parse(comboBox6.Text);
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
                bool success = d.Insert(d);
                if (success == true)
                {
                    //Successfully Inserted
                    MessageBox.Show("New Subject Successfully Inserted!");
                    //call the clear method here
                    // Clear();
                    textBox3.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox5.SelectedIndex = -1;
                    comboBox6.SelectedIndex = -1;

                }
                else
                {
                    //Failed to Add Lecturer
                    MessageBox.Show("Failed to add New Subject.Try Again");
                }

                //Load Data on Data GridView
                DataTable dt = d.Select();
                dataGridView1.DataSource = dt;

            }
        }

         private void Form4_Load(object sender, EventArgs e)
        {
            //Load Data on Data GridView
            DataTable dt = d.Select();
            dataGridView1.DataSource = dt;

            //Add is successfully completed 



            //Method to clear Fields
            // public void Clear()
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;

        }


        private void button2_Click(object sender, EventArgs e)
        {
            
                //call clear method here
                //Clear();
                textBox3.Clear();
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;

                MessageBox.Show("Subject Details Are CLEAR!");
            
         }

        private void button3_Click(object sender, EventArgs e)
        {
            //Get the data from the text box
            d.ID = int.Parse(textBox3.Text);
            d.SubjectName = textBox1.Text;
            d.SubjectCode = textBox2.Text;
            d.OfferedYear = comboBox1.Text;
            d.OfferedSemester = comboBox2.Text;
            d.NumberOfLectureHours = int.Parse(comboBox3.Text);
            d.NumberOfTutorialHours = int.Parse(comboBox4.Text);
            d.NumberOfLabHours = int.Parse(comboBox5.Text);
            d.NumberOfEvaluationHours = int.Parse(comboBox6.Text);

            //Update Data in database
            bool success = d.Update(d);
            if (success == true)
            {
                //update successfully
                MessageBox.Show("Subject has been Successfully Update.");
                //Load Data on Data GridView
                DataTable dt = d.Select();
                dataGridView1.DataSource = dt;

                //call clear button
                //Clear();

                //call clear method here
                //Clear();
                textBox3.Clear();
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;

            }
            else
            {
                //failed to update
                MessageBox.Show("Failed to update Subject.Try Again.");
            }

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from data grid view and Load it to the textboxes respectively
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBox3.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            comboBox6.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //get the lecturer id from the application
            d.ID = Convert.ToInt32(textBox3.Text);
            bool success = d.Delete(d);
            if (success == true)
            {
                //successfully Deleted
                MessageBox.Show("Lecturer sucessfully Delete.");
                //Refresh Data GridView
                //Load Data on Data GridView
                DataTable dt = d.Select();
                dataGridView1.DataSource = dt;

                //call the clear method
                //Clear();
                //call clear method here
                //Clear();
                textBox3.Clear();
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;


            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to Delete Lecturer. Try Again.");
            }
        }
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            //Get the value from text box
            string keyword = textBox5.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Subject WHERE SubjectName LIKE '%" + keyword + "%' OR SubjectCode LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
 }

