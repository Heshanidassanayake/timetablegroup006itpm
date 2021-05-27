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
using System.Windows.Forms.DataVisualization.Charting;

namespace timetableforabcinstitute03
{
    public partial class Form9 : Form
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        //SqlConnection con = new SqlConnection("Data Source = ; Initial Catalog = timetableDB; Integrated Security = True");
        SqlConnection con = new SqlConnection(myconnstrng);

        SqlCommand cmd;
        DataTable dt;
        SqlDataAdapter da;
        DataSet ds;

        public Form9()
        {
            InitializeComponent();
        }
        // locationClass c = new locationClass();

        private void button4_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select RoomType,COUNT(LocationID) as c from Location GROUP BY RoomType", con);
            adapt.Fill(ds, "RoomType");
            Roomchart.DataSource = ds.Tables["RoomType"];

            Roomchart.Series["RoomType"].XValueMember = "RoomType";
            Roomchart.Series["RoomType"].YValueMembers = "c";
            Roomchart.Series["RoomType"].ChartType = SeriesChartType.Bar;


            //Roomchart.DataSource = dataBase1DataSet.mydb;
            Roomchart.DataBind();
            con.Close();
        }

            private void button5_Click(object sender, EventArgs e)
        {
            listView1.Columns.Add("LocationID", 70);
            listView1.Columns.Add("BuildingName", 170, HorizontalAlignment.Left);
            listView1.Columns.Add("RoomName", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("RoomType", 70, HorizontalAlignment.Left);
            listView1.Columns.Add("Capacity", 70, HorizontalAlignment.Left);
            listView1.View = View.Details;


            con.Open();
            cmd = new SqlCommand("SELECT * FROM Location", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            con.Close();

            dt = ds.Tables["testTable"];
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {

                listView1.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView1.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView4.Columns.Add("ID", 70);
            listView4.Columns.Add("LecturerName", 70, HorizontalAlignment.Left);
            listView4.Columns.Add("EmployeeID", 70, HorizontalAlignment.Left);
            listView4.Columns.Add("Faculty", 70, HorizontalAlignment.Left);
            listView4.Columns.Add("Department", 70, HorizontalAlignment.Left);
            listView4.Columns.Add("Center", 70, HorizontalAlignment.Left);
            listView4.Columns.Add("Building", 70, HorizontalAlignment.Left);
            listView4.Columns.Add("LecturerLevel", 70, HorizontalAlignment.Left);
            listView4.Columns.Add("Rank", 70, HorizontalAlignment.Left);
            listView4.View = View.Details;


            con.Open();
            cmd = new SqlCommand("SELECT * FROM Lecturer", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            con.Close();

            dt = ds.Tables["testTable"];
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {

                listView4.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView4.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView4.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView4.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView4.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView4.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView4.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                listView4.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                listView4.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select Faculty,COUNT(ID) as c from Lecturer GROUP BY Faculty", con);
            adapt.Fill(ds, "Faculty");
            LecChart.DataSource = ds.Tables["Faculty"];

            LecChart.Series["Faculty"].XValueMember = "Faculty";
            LecChart.Series["Faculty"].YValueMembers = "c";
            LecChart.Series["Faculty"].ChartType = SeriesChartType.Bar;


            //Roomchart.DataSource = dataBase1DataSet.mydb;
            LecChart.DataBind();
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("Select OfferedYear,COUNT(ID) as c from Subject GROUP BY OfferedYear", con);
            adapt.Fill(ds, "OfferedYear");
            SubChart.DataSource = ds.Tables["OfferedYear"];

            SubChart.Series["Academic Year"].XValueMember = "OfferedYear";
            SubChart.Series["Academic Year"].YValueMembers = "c";
            SubChart.Series["Academic Year"].ChartType = SeriesChartType.Bar;


            //Roomchart.DataSource = dataBase1DataSet.mydb;
            SubChart.DataBind();
            con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listView2.Columns.Add("ID", 70);
            listView2.Columns.Add("SubjectName", 170, HorizontalAlignment.Left);
            listView2.Columns.Add("SubjectCode", 70, HorizontalAlignment.Left);
            listView2.Columns.Add("OfferedYear", 70, HorizontalAlignment.Left);
            listView2.Columns.Add("OfferedSemester", 70, HorizontalAlignment.Left);
            listView2.Columns.Add("NumberOfLectureHours", 170, HorizontalAlignment.Left);
            listView2.Columns.Add("NumberOfTutorialHours", 70, HorizontalAlignment.Left);
            listView2.Columns.Add("NumberOfLabHours", 70, HorizontalAlignment.Left);
            listView2.Columns.Add("NumberOfEvaluationHours", 70, HorizontalAlignment.Left);
            listView2.View = View.Details;


            con.Open();
            cmd = new SqlCommand("SELECT * FROM Subject", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            con.Close();

            dt = ds.Tables["testTable"];
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {

                listView2.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());
                listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[7].ToString());
                listView2.Items[i].SubItems.Add(dt.Rows[i].ItemArray[8].ToString());

            }

        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = con;

            DataSet ds = new DataSet();
            con.Open();
            SqlDataAdapter adapt = new SqlDataAdapter("select Programme, COUNT(ID) as c  from Student GROUP BY Programme", con);
            adapt.Fill(ds, "Programme");
            StudentChart.DataSource = ds.Tables["Programme"];


            StudentChart.Series["Programme"].XValueMember = "Programme";
            StudentChart.Series["Programme"].YValueMembers = "c";
            StudentChart.Series["Programme"].ChartType = SeriesChartType.Bar;


            StudentChart.DataBind();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listView3.Columns.Add("ID", 70);
            listView3.Columns.Add("AcademicYearSemester", 170, HorizontalAlignment.Left);
            listView3.Columns.Add("Programme", 70, HorizontalAlignment.Left);
            listView3.Columns.Add("GroupNumber", 70, HorizontalAlignment.Left);
            listView3.Columns.Add("SubGroupNumber", 70, HorizontalAlignment.Left);
            listView3.Columns.Add("GroupID", 70, HorizontalAlignment.Left);
            listView3.Columns.Add("SubGroupID", 70, HorizontalAlignment.Left);

            listView3.View = View.Details;


            con.Open();
            cmd = new SqlCommand("SELECT * FROM Student", con);
            da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds, "testTable");
            con.Close();

            dt = ds.Tables["testTable"];
            int i;
            for (i = 0; i <= dt.Rows.Count - 1; i++)
            {

                listView3.Items.Add(dt.Rows[i].ItemArray[0].ToString());
                listView3.Items[i].SubItems.Add(dt.Rows[i].ItemArray[1].ToString());
                listView3.Items[i].SubItems.Add(dt.Rows[i].ItemArray[2].ToString());
                listView3.Items[i].SubItems.Add(dt.Rows[i].ItemArray[3].ToString());
                listView3.Items[i].SubItems.Add(dt.Rows[i].ItemArray[4].ToString());
                listView3.Items[i].SubItems.Add(dt.Rows[i].ItemArray[5].ToString());
                listView3.Items[i].SubItems.Add(dt.Rows[i].ItemArray[6].ToString());

            }
        }
    }
    } 

