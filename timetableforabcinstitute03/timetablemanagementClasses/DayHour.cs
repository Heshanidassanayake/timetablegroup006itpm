using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace timetableforabcinstitute03.timetablemanagementClasses
{
    class DayHour
    {
        //Getter Setter Properties
        //Acts as Data Carrier in our application
        public int entryID { get; set; }
        public int ActiveNoOfDays { get; set; }
        public String ActiveDaysPerWeekDay01 { get; set; }
        public String ActiveDaysPerWeekDay02 { get; set; }
        public String ActiveDaysPerWeekDay03 { get; set; }
        public String ActiveDaysPerWeekDay04 { get; set; }
        public String ActiveDaysPerWeekDay05 { get; set; }
        public String ActiveDaysPerWeekDay06 { get; set; }
        public String ActiveDaysPerWeekDay07 { get; set; }
        public int ActiveHours { get; set; }
        public int ActiveMinutes { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        //selecting data form database
        public DataTable Select()
        {
            //Step 1 : Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //Step 2://Writing SQL Query
                string sql = "SELECT * FROM WorkingDaysAndHours";
                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Creating SQL DataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();

            }
            return dt;
        }

        //Inserting Data into Database
        public bool Insert(DayHour day)
        {
            //Creating a default return type and setting its value false
            bool isSuccess = false;

            //Step 1 : Connect Database 
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Step 2: Create a SQL Query to insert Data
                string sql = "INSERT INTO WorkingDaysAndHours(ActiveNoOfDays, ActiveDaysPerWeekDay01, ActiveDaysPerWeekDay02, ActiveDaysPerWeekDay03, ActiveDaysPerWeekDay04, ActiveDaysPerWeekDay05, ActiveDaysPerWeekDay06, ActiveDaysPerWeekDay07, ActiveHours, ActiveMinutes) VALUES (@ActiveNoOfDays, @ActiveDaysPerWeekDay01, @ActiveDaysPerWeekDay02, @ActiveDaysPerWeekDay03, @ActiveDaysPerWeekDay04, @ActiveDaysPerWeekDay05, @ActiveDaysPerWeekDay06, @ActiveDaysPerWeekDay07, @ActiveHours, @ActiveMinutes)";
                //Creating sql command sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@ActiveNoOfDays", day.ActiveNoOfDays);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay01", day.ActiveDaysPerWeekDay01);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay02", day.ActiveDaysPerWeekDay02);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay03", day.ActiveDaysPerWeekDay03);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay04", day.ActiveDaysPerWeekDay04);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay05", day.ActiveDaysPerWeekDay05);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay06", day.ActiveDaysPerWeekDay06);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay07", day.ActiveDaysPerWeekDay07);
                cmd.Parameters.AddWithValue("@ActiveHours", day.ActiveHours);
                cmd.Parameters.AddWithValue("@ActiveMinutes", day.ActiveMinutes);

                //Open Connection here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                //if the query runs successfully then the value of rows will be grater than zero else its will be 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;

        }

        //Method to Update data in Database from our application
        public bool Update(DayHour day)
        {
            //Create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL to update in our Database
                string sql = "UPDATE WorkingDaysAndHours SET ActiveNoOfDays = @ActiveNoOfDays, ActiveDaysPerWeekDay01 = @ActiveDaysPerWeekDay01, ActiveDaysPerWeekDay02 = @ActiveDaysPerWeekDay02, ActiveDaysPerWeekDay03 = @ActiveDaysPerWeekDay03 ,ActiveDaysPerWeekDay04 = @ActiveDaysPerWeekDay04, ActiveDaysPerWeekDay05 = @ActiveDaysPerWeekDay05, ActiveDaysPerWeekDay06 = @ActiveDaysPerWeekDay06, ActiveDaysPerWeekDay07 = @ActiveDaysPerWeekDay07, ActiveHours =@ActiveHours, ActiveMinutes= @ActiveMinutes WHERE entryID = @entryID";
                //Create SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@entryID", day.entryID);
                cmd.Parameters.AddWithValue("@ActiveNoOfDays", day.ActiveNoOfDays);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay01", day.ActiveDaysPerWeekDay01);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay02", day.ActiveDaysPerWeekDay02);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay03", day.ActiveDaysPerWeekDay03);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay04", day.ActiveDaysPerWeekDay04);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay05", day.ActiveDaysPerWeekDay05);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay06", day.ActiveDaysPerWeekDay06);
                cmd.Parameters.AddWithValue("@ActiveDaysPerWeekDay07", day.ActiveDaysPerWeekDay07);
                cmd.Parameters.AddWithValue("@ActiveHours", day.ActiveHours);
                cmd.Parameters.AddWithValue("@ActiveMinutes", day.ActiveMinutes);

                //Open Database Connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //if the query runs sucessfully then the value of row will be greater than zero else its value will be zero
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        //Method to Delete Data from Database
        public bool Delete(DayHour day)
        {
            //Create a default return and set its value to false
            bool isSuccess = false;
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL TO delete Data
                string sql = "DELETE FROM WorkingDaysAndHours WHERE entryID = @entryID";

                //Creating SQL Command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@entryID", day.entryID);

                //Open Connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //If the query run sucessfully then the vvalue of rows is greater than zero else its value is 0
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                //Close Connection
                conn.Close();
            }
            return isSuccess;
        }
    }
}
