using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace timetableforabcinstitute03
{
    public partial class Form15 : Form
    {
       

        public Form15()
        {
            InitializeComponent();
        }

        private void Form15_Load(object sender, EventArgs e)
        {

        }

          private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
          {

              string query1 = null;
              if (value == null)
              {
                  query1 = "select Lecture,Tags,Groups,Subject,Duration,day from session order by Duration ";
              }
              else
              {
                  query1 = "select Lecture,Tags,Groups,Subject,Duration,day from session where Lecture LIKE '%" + value + "%' order by Duration";
              }

              SqlConnection conn = new SqlConnection(query1, conn);
              DataTable dt = new DataTable();
              //SqlCommand cmd = new SqlCommand(query1, con);
              conn.Open();
              //DataTable dt = new DataTable();
              SqlDataReader sdr = cmd.ExecuteReader();



       
              dt.Load(sdr);

              conn.Close();

              DataTable newData = new DataTable();

              newData.Columns.Add("Time", typeof(String));
              newData.Columns.Add("Monday", typeof(String));
              newData.Columns.Add("Tuesday", typeof(String));
              newData.Columns.Add("Wednesday", typeof(String));
              newData.Columns.Add("Thursday", typeof(String));
              newData.Columns.Add("Friday", typeof(String));
              newData.Columns.Add("Saturday", typeof(String));
              newData.Columns.Add("Sunday", typeof(String));

              String[] timeSlot = new String[] { "08.30-09.30", "09.30-10.30", "10.30-11.30", "11.30-12.30", "12.30-1.30", "01.30-02.30", "02.30-03.30", "03.30-04.30", "04.30-05.30" };

              for (int i = 0; i < timeSlot.Length; i++)
              {
                  newData.Rows.Add(new object[] { timeSlot[i], "--", "--", "--", "--", "--", "--", "--" });
              }

              foreach (DataRow row in dt.Rows)
              {
                  string ss = row[0] + ":" + row[1] + ":" + row[2] + ":" + row[3] + ":" + row[4] + ":" + row[5];
                  string col = null;

                  if (row[5].Equals("Monday"))
                  {
                      col = "Monday";
                  }
                  else if (row[5].Equals("Tuesday"))
                  {
                      col = "Tuesday";
                  }
                  else if (row[5].Equals("Wednesday"))
                  {
                      col = "Wednesday";
                  }
                  else if (row[5].Equals("Thursday"))
                  {
                      col = "Thursday";
                  }
                  else if (row[5].Equals("Friday"))
                  {
                      col = "Friday";
                  }

                  for (int i = 0; i < timeSlot.Length; i++)
                  {
                      if (row[4].Equals(timeSlot[i]))
                      {
                          newData.Rows[i][col] = ss;
                          break;
                      }
                  }
              }

              dataGridView1.DataSource = newData;
          }
    }
}

