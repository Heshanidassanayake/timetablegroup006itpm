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
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        TagClass w = new TagClass();
        private void button4_Click(object sender, EventArgs e)
        {
            //Get the value from the input fields
            w.TagName = textBox1.Text;
            w.TagCode = int.Parse(textBox2.Text);
            w.RelatedTag = comboBox1.Text;

            bool success = w.Insert(w);
            if (success == true)
            {
                //Successfully Inserted
                MessageBox.Show("Successfully Inserted");

                textBox3.Clear();
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = string.Empty;
            }
            else
            {
                //Failed to Add Lecturer
                MessageBox.Show("Failed to add New Tag.Try Again");
            }

            //Load Data on Data GridView
            DataTable dt = w.Select();
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Get the data from the text box
            w.ID = int.Parse(textBox3.Text);
            w.TagName = textBox1.Text;
            w.TagCode = int.Parse(textBox2.Text);
            w.RelatedTag = comboBox1.Text;
           

            //Update Data in database
            bool success = w.Update(w);
            if (success == true)
            {
                //update successfully
                MessageBox.Show("Successfully Update.");
                //Load Data on Data GridView
                DataTable dt = w.Select();
                dataGridView1.DataSource = dt;

                //call clear button
                //Clear();

                textBox3.Clear();
                textBox1.Clear();
                textBox2.Clear();
                comboBox1.Text = string.Empty;

            }
            else
            {
                //failed to update
                MessageBox.Show("Failed to update Tag.Try Again.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //get the lecturer id from the application
            w.ID = Convert.ToInt32(textBox3.Text);
            bool success = w.Delete(w);
            if (success == true)
            {
                
                {
                    MessageBox.Show("sucessfully Delete.");
                    //Refresh Data GridView
                    //Load Data on Data GridView
                    DataTable dt = w.Select();
                    dataGridView1.DataSource = dt;

                    //call the clear method
                    //Clear();
                    textBox3.Clear();
                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.Text = string.Empty;
                   
                }
            }
            else
            {
                //Failed to delete
                MessageBox.Show("Failed to Delete Tag. Try Again.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //method to clear field
            textBox3.Clear();
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = string.Empty;
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            //Load the data in data gridView
            //DataTable dt = c.Select();
            //dataGridView1.DataSource = dt;

            DataTable dt = w.Select();
            dataGridView1.DataSource = dt;

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
        }



        //SEARCH BAR
        static string myconnstr = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

            //Get the value from text box
            string keyword = textBox4.Text;

            SqlConnection conn = new SqlConnection(myconnstr);
            SqlDataAdapter sda = new SqlDataAdapter("SELECT * FROM Tag WHERE ID LIKE '%" + keyword + "%'", conn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
