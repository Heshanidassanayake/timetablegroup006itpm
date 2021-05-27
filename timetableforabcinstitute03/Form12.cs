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
    public partial class Form12 : Form
    {
        public Form12()
        {
            InitializeComponent();
        }


        Boolean empty = false;
        SessionRoomClass j = new SessionRoomClass();

        private void Form12_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Location' table. You can move, or remove it, as needed.
            this.locationTableAdapter.Fill(this.timetablemanagement01DataSet1.Location);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.timetablemanagement01DataSet1.Student);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Tag' table. You can move, or remove it, as needed.
            this.tagTableAdapter.Fill(this.timetablemanagement01DataSet1.Tag);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Lecturer' table. You can move, or remove it, as needed.
            this.lecturerTableAdapter.Fill(this.timetablemanagement01DataSet1.Lecturer);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Subject' table. You can move, or remove it, as needed.
            this.subjectTableAdapter.Fill(this.timetablemanagement01DataSet1.Subject);

            {
                //Load Data on Data GridView
                DataTable dt = j.Select();
                dataGridView1.DataSource = dt;

                //Add is successfully completed 



                //Method to clear Fields
                // public void Clear()
                textBox1.Clear();
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                comboBox5.SelectedIndex = -1;
                comboBox6.SelectedIndex = -1;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Get the value from the input fields
            if (comboBox1.Text != "" && comboBox2.Text != "" && comboBox3.Text != "" && comboBox4.Text != "" && comboBox5.Text != "" && comboBox6.Text != "")
            {
                //Get the value from the input fields

                j.SubjectCode = comboBox1.Text;
                j.SubjectName = comboBox2.Text;
                j.LecturerName = comboBox3.Text;
                j.TagName = comboBox4.Text;
                j.SubGroupID = comboBox5.Text;
                j.RoomType = comboBox6.Text;
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
                bool success = j.Insert(j);
                if (success == true)
                {
                    //Successfully Inserted
                    MessageBox.Show("New SessionRoom Successfully Inserted!");
                    //call the clear method here
                    // Clear();
                    textBox1.Clear();
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
                    MessageBox.Show("Failed to add New SessionRoom.Try Again");
                }

                //Load Data on Data GridView
                DataTable dt = j.Select();
                dataGridView1.DataSource = dt;

            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            comboBox5.SelectedIndex = -1;
            comboBox6.SelectedIndex = -1;
        
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Get the data from data grid view and Load it to the textboxes respectively
            //identify the row on which mouse is clicked
            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView1.Rows[rowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[rowIndex].Cells[2].Value.ToString();
            comboBox3.Text = dataGridView1.Rows[rowIndex].Cells[3].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[rowIndex].Cells[4].Value.ToString();
            comboBox5.Text = dataGridView1.Rows[rowIndex].Cells[5].Value.ToString();
            comboBox6.Text = dataGridView1.Rows[rowIndex].Cells[6].Value.ToString();
        }
    }

}