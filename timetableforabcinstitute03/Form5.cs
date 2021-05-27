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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
           
        }

        Boolean empty = false;
        session m = new session();

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.timetablemanagement01DataSet1.Student);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Tag' table. You can move, or remove it, as needed.
            this.tagTableAdapter.Fill(this.timetablemanagement01DataSet1.Tag);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Subject' table. You can move, or remove it, as needed.
            this.subjectTableAdapter.Fill(this.timetablemanagement01DataSet1.Subject);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Lecturer' table. You can move, or remove it, as needed.
            this.lecturerTableAdapter1.Fill(this.timetablemanagement01DataSet1.Lecturer);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet.Lecturer' table. You can move, or remove it, as needed.
            this.lecturerTableAdapter.Fill(this.timetablemanagement01DataSet.Lecturer);

            {
                //Load Data on Data GridView
                DataTable dt = m.Select();
                dataGridView1.DataSource = dt;

                //Add is successfully completed 



                //Method to clear Fields
                // public void Clear()
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;
                textBox1.Clear();
                textBox2.Clear();

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();
        }
       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get the value from the input fields
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "" && textBox1.Text != "" && textBox2.Text != "")
            {
                //Get the value from the input fields
                
                m.SelectLecturer1 = comboBox1.Text;
                m.SelectLecturer2 = comboBox2.Text;
                m.SelectSubjectCode = comboBox3.Text;
                m.SelectSubject = comboBox4.Text;
                m.SelectTag = comboBox5.Text;
                m.SelectGroup = comboBox6.Text;
                m.NoOfStudents = textBox1.Text;
                m.Duration = textBox2.Text;
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
                bool success = m.Insert(m);
                if (success == true)
                {
                    //Successfully Inserted
                    MessageBox.Show("New Session Successfully Inserted!");
                    //call the clear method here
                    // Clear();
                    textBox4.Clear();
                    comboBox1.SelectedIndex = -1;
                    comboBox2.SelectedIndex = -1;
                    comboBox3.SelectedIndex = -1;
                    comboBox4.SelectedIndex = -1;
                    comboBox5.SelectedIndex = -1;
                    comboBox6.SelectedIndex = -1;
                    textBox1.Clear();
                    textBox2.Clear();

                }
                else
                {
                    //Failed to Add Lecturer
                    MessageBox.Show("Failed to add New Session.Try Again");
                }

                //Load Data on Data GridView
                DataTable dt = m.Select();
                dataGridView1.DataSource = dt;

            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //Load Data on Data GridView
            DataTable dt = m.Select();
            dataGridView1.DataSource = dt;

            //Add is successfully completed 



            //Method to clear Fields
            // public void Clear()
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
            textBox1.Clear();
            textBox2.Clear();

        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from data grid view and Load it to the textboxes respectively
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBox4.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            comboBox6.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[7].Value.ToString();
            textBox2.Text = dataGridView1.Rows[rowIndex].Cells[8].Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //get the lecturer id from the application
            m.ID = Convert.ToInt32(textBox4.Text);
            bool success = m.Delete(m);
            if (success == true)
            {
                //successfully Deleted
                MessageBox.Show("Session sucessfully Delete.");
                //Refresh Data GridView
                //Load Data on Data GridView
                DataTable dt = m.Select();
                dataGridView1.DataSource = dt;

                //call the clear method
                //Clear();
                //call clear method here
                //Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;
                textBox1.Clear();
                textBox2.Clear();


            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to Delete Lecturer. Try Again.");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Get the data from the text box
            m.ID = int.Parse(textBox4.Text);
            m.SelectLecturer1 = comboBox1.Text;
            m.SelectLecturer2 = comboBox2.Text;
            m.SelectSubjectCode = comboBox3.Text;
            m.SelectSubject = comboBox4.Text;
            m.SelectTag = comboBox5.Text;
            m.SelectGroup = comboBox6.Text;
            m.NoOfStudents = textBox1.Text;
            m.Duration = textBox2.Text;

            //Update Data in database
            bool success = m.Update(m);
            if (success == true)
            {
                //update successfully
                MessageBox.Show("Session has been Successfully Update.");
                //Load Data on Data GridView
                DataTable dt = m.Select();
                dataGridView1.DataSource = dt;

                //call clear button
                //Clear();

                //call clear method here
                //Clear();
                textBox4.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;
                textBox1.Clear();
                textBox2.Clear();

            }
            else
            {
                //failed to update
                MessageBox.Show("Failed to update Session.Try Again.");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
 }
 

