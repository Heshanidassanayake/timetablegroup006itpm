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
using System.Data.SqlClient;
using System.Configuration;

namespace timetableforabcinstitute03
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();

        }

        NotAvailableClass nav = new NotAvailableClass();
        private string myconnstrng;

        private void Form11_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Session' table. You can move, or remove it, as needed.
            this.sessionTableAdapter.Fill(this.timetablemanagement01DataSet1.Session);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.timetablemanagement01DataSet1.Student);
            // TODO: This line of code loads data into the 'timetablemanagement01DataSet1.Lecturer' table. You can move, or remove it, as needed.
            this.lecturerTableAdapter.Fill(this.timetablemanagement01DataSet1.Lecturer);
            DataGridViewCheckBoxColumn chkbox = new DataGridViewCheckBoxColumn();
            chkbox.HeaderText = "";
            chkbox.Width = 30;
            chkbox.Name = "checkBoxColumn";
            dataGridView2.Columns.Insert(0, chkbox);
            DataGridViewCheckBoxColumn chkbox1 = new DataGridViewCheckBoxColumn();
            chkbox1.HeaderText = "";
            chkbox1.Width = 30;
            chkbox1.Name = "checkBoxColumn1";
            dataGridView3.Columns.Insert(0, chkbox1);
            DataGridViewCheckBoxColumn chkbox2 = new DataGridViewCheckBoxColumn();
            chkbox2.HeaderText = "";
            chkbox2.Width = 30;
            chkbox2.Name = "checkBoxColumn2";
            dataGridView1.Columns.Insert(0, chkbox2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Get the value from input fields
            nav.LecturerName = comboBox1.Text;
            nav.GroupID = comboBox2.Text;
            nav.SubGroupID = comboBox3.Text;
            nav.SessionID = comboBox4.Text;
            nav.Time = comboBox5.Text;

            //Inserting data into the database
            bool success = nav.Insert(nav);
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
                comboBox5.Text = string.Empty;

            }
            else
            {
                //Failed to add
                MessageBox.Show("Failed to add.Try again");
            }
            //Load Data
            DataTable dt = nav.Select();
            dataGridView4.DataSource = dt;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            //get the data from textboxes
            nav.ID = int.Parse(textBox1.Text);
            nav.LecturerName = comboBox1.Text;
            nav.GroupID = comboBox2.Text;
            nav.SubGroupID = comboBox3.Text;
            nav.SessionID = comboBox4.Text;
            nav.Time = comboBox5.Text;

            //Update data in database
            bool success = nav.Update(nav);
            if (success == true)
            {
                //update successfully
                MessageBox.Show("Updated successfully");
                //Load Data on Data GridView
                DataTable dt = nav.Select();
                dataGridView4.DataSource = dt;

                //call clear button
                //Clear();

                textBox1.Clear();
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;
                comboBox5.Text = string.Empty;


            }
            else
            {
                //Failed to add
                MessageBox.Show("Failed to add.Try again");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Load Data on Data GridView
            DataTable dt = nav.Select();
            dataGridView4.DataSource = dt;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //Call Clear method
            //Clear();

            textBox1.Clear();
            comboBox1.Text = string.Empty;
            comboBox2.Text = string.Empty;
            comboBox3.Text = string.Empty;
            comboBox4.Text = string.Empty;
            comboBox5.Text = string.Empty;

            MessageBox.Show("Successfully Cleared");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            // Get Data from the textbox
            nav.ID = Convert.ToInt32(textBox1.Text);
            bool success = nav.Delete(nav);
            if (success == true)
            {
                //successfully Deleted
                MessageBox.Show("Sucessfully Delete");
                //Refresh Data GridView
                //Load Data on Data GridView
                DataTable dt = nav.Select();
                dataGridView4.DataSource = dt;

                //call the clear method
                //Clear();

                textBox1.Clear();
                comboBox1.Text = string.Empty;
                comboBox2.Text = string.Empty;
                comboBox3.Text = string.Empty;
                comboBox4.Text = string.Empty;
                comboBox5.Text = string.Empty;


            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to delete.Try Again");
            }
        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView4_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            int rowIndex = e.RowIndex;
            textBox1.Text = dataGridView4.Rows[rowIndex].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView4.Rows[rowIndex].Cells[1].Value.ToString();
            comboBox2.Text = dataGridView4.Rows[rowIndex].Cells[2].Value.ToString();
            comboBox3.Text = dataGridView4.Rows[rowIndex].Cells[3].Value.ToString();
            comboBox4.Text = dataGridView4.Rows[rowIndex].Cells[4].Value.ToString();
            comboBox5.Text = dataGridView4.Rows[rowIndex].Cells[5].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             string mainconn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
             SqlConnection sqlconn = new SqlConnection(mainconn);

             foreach(DataGridViewRow dr in dataGridView2.Rows)
             {
                 bool chkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn"].Value);
                 if (chkboxselected)
                 {
                     string sqlquery = "Insert into [dbo].[Session] values (@SelectLecturer1, @SelectLecturer2, @SelectSubjectCode, @SelectSubject, @SelectTag, @SelectGroup, @NoOfStudents, @Duration)";
                     SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                     sqlcomm.Parameters.AddWithValue("@SelectLecturer1", dr.Cells[1].Value);
                     sqlcomm.Parameters.AddWithValue("@SelectLecturer2", dr.Cells[2].Value);
                     sqlcomm.Parameters.AddWithValue("@SelectSubjectCode", dr.Cells[3].Value);
                     sqlcomm.Parameters.AddWithValue("@SelectSubject", dr.Cells[4].Value);
                     sqlcomm.Parameters.AddWithValue("@SelectTag", dr.Cells[5].Value);
                     sqlcomm.Parameters.AddWithValue("@SelectGroup", dr.Cells[6].Value);
                     sqlcomm.Parameters.AddWithValue("@NoOfStudents", dr.Cells[7].Value);
                     sqlcomm.Parameters.AddWithValue("@Duration", dr.Cells[8].Value);
                     sqlconn.Open();
                     sqlcomm.ExecuteNonQuery();
                     sqlconn.Close();
                 }
                 label7.Text = "Selected Records Inserted Successfully ! ";
             }

            


        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                string mainconn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
                SqlConnection sqlconn = new SqlConnection(mainconn);

                foreach (DataGridViewRow dr in dataGridView3.Rows)
                {
                    bool chkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn1"].Value);
                    if (chkboxselected)
                    {
                        string sqlquery = "Insert into [dbo].[Session] values (@SelectLecturer1, @SelectLecturer2, @SelectSubjectCode, @SelectSubject, @SelectTag, @SelectGroup, @NoOfStudents, @Duration)";
                        SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                        sqlcomm.Parameters.AddWithValue("@SelectLecturer1", dr.Cells[1].Value);
                        sqlcomm.Parameters.AddWithValue("@SelectLecturer2", dr.Cells[2].Value);
                        sqlcomm.Parameters.AddWithValue("@SelectSubjectCode", dr.Cells[3].Value);
                        sqlcomm.Parameters.AddWithValue("@SelectSubject", dr.Cells[4].Value);
                        sqlcomm.Parameters.AddWithValue("@SelectTag", dr.Cells[5].Value);
                        sqlcomm.Parameters.AddWithValue("@SelectGroup", dr.Cells[6].Value);
                        sqlcomm.Parameters.AddWithValue("@NoOfStudents", dr.Cells[7].Value);
                        sqlcomm.Parameters.AddWithValue("@Duration", dr.Cells[8].Value);
                        sqlconn.Open();
                        sqlcomm.ExecuteNonQuery();
                        sqlconn.Close();
                    }
                    label8.Text = "Selected Records Inserted Successfully ! ";
                }
            }

        private void button9_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button9_Click_2(object sender, EventArgs e)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                bool chkboxselected = Convert.ToBoolean(dr.Cells["checkBoxColumn2"].Value);
                if (chkboxselected)
                {
                    string sqlquery = "Insert into [dbo].[Session] values (@SelectLecturer1, @SelectLecturer2, @SelectSubjectCode, @SelectSubject, @SelectTag, @SelectGroup, @NoOfStudents, @Duration)";
                    SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                    sqlcomm.Parameters.AddWithValue("@SelectLecturer1", dr.Cells[1].Value);
                    sqlcomm.Parameters.AddWithValue("@SelectLecturer2", dr.Cells[2].Value);
                    sqlcomm.Parameters.AddWithValue("@SelectSubjectCode", dr.Cells[3].Value);
                    sqlcomm.Parameters.AddWithValue("@SelectSubject", dr.Cells[4].Value);
                    sqlcomm.Parameters.AddWithValue("@SelectTag", dr.Cells[5].Value);
                    sqlcomm.Parameters.AddWithValue("@SelectGroup", dr.Cells[6].Value);
                    sqlcomm.Parameters.AddWithValue("@NoOfStudents", dr.Cells[7].Value);
                    sqlcomm.Parameters.AddWithValue("@Duration", dr.Cells[8].Value);
                    sqlconn.Open();
                    sqlcomm.ExecuteNonQuery();
                    sqlconn.Close();
                }
                label9.Text = "Selected Records Inserted Successfully ! ";
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }

   


        /* private void button9_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(myconnstrng);
            SqlDataAdapter sda = new SqlDataAdapter("Select SelectLecturer1, SelectLecturer2, SelectSubjectCode, SelectSubject, SelectTag, SelectGroup, NoOfStudents, Duration from Session",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int n = dataGridView2.Rows.Add();
                dataGridView2.Rows[n].Cells[1].Value = item[0].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[1].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[2].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[3].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[4].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[5].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[6].ToString();
                dataGridView2.Rows[n].Cells[1].Value = item[7].ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(myconnstrng);
            SqlDataAdapter sda = new SqlDataAdapter("Select SelectLecturer1, SelectLecturer2, SelectSubjectCode, SelectSubject, SelectTag, SelectGroup, NoOfStudents, Duration from Session",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int w = dataGridView1.Rows.Add();
                dataGridView1.Rows[w].Cells[1].Value = item[0].ToString();
                dataGridView1.Rows[w].Cells[1].Value = item[1].ToString();
                dataGridView1.Rows[w].Cells[1].Value = item[2].ToString();
                dataGridView1.Rows[w].Cells[1].Value = item[3].ToString();
                dataGridView1.Rows[w].Cells[1].Value = item[4].ToString();
                dataGridView1.Rows[w].Cells[1].Value = item[5].ToString();
                dataGridView1.Rows[w].Cells[1].Value = item[6].ToString();
                dataGridView1.Rows[w].Cells[1].Value = item[7].ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(myconnstrng);
            SqlDataAdapter sda = new SqlDataAdapter("Select SelectLecturer1, SelectLecturer2, SelectSubjectCode, SelectSubject, SelectTag, SelectGroup, NoOfStudents, Duration from Session",Con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            foreach (DataRow item in dt.Rows)
            {
                int o = dataGridView3.Rows.Add();
                dataGridView3.Rows[o].Cells[1].Value = item[0].ToString();
                dataGridView3.Rows[o].Cells[1].Value = item[1].ToString();
                dataGridView3.Rows[o].Cells[1].Value = item[2].ToString();
                dataGridView3.Rows[o].Cells[1].Value = item[3].ToString();
                dataGridView3.Rows[o].Cells[1].Value = item[4].ToString();
                dataGridView3.Rows[o].Cells[1].Value = item[5].ToString();
                dataGridView3.Rows[o].Cells[1].Value = item[6].ToString();
                dataGridView3.Rows[o].Cells[1].Value = item[7].ToString();
            }
        }*/





    }
  

