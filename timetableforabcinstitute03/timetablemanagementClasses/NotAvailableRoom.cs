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
    class NotAvailableRoom
    {
        public int ID { get; set; }
        public string RoomID { get; set; }
        public string Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }


        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        public DataTable Select()
        {
            //Step 1 : Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //Step 2://Writing SQL Query
                string sql = "SELECT * FROM NotAvailableRooms";
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
        public bool Insert(NotAvailableRoom nvr)
        {
            //Creating a default return type and setting its value false
            bool isSuccess = false;

            //Step 1 : Connect Database 
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Step 2: Create a SQL Query to insert Data
                string sql = "INSERT INTO NotAvailableRooms(RoomID,Day,StartTime,EndTime) VALUES (@RoomID,@Day,@StartTime,@EndTime )";
                //Creating sql command sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@RoomID", nvr.RoomID);
                cmd.Parameters.AddWithValue("@Day", nvr.Day);
                cmd.Parameters.AddWithValue("@StartTime", nvr.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", nvr.EndTime);


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

        public bool Update(NotAvailableRoom nvr)
        {
            //Create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {

                //SQL to update in our Database
                string sql = "UPDATE  NotAvailableRooms SET RoomID = @RoomID, Day = @Day, StartTime = @StartTime, EndTime = @EndTime WHERE ID = @ID";
                //Create SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", nvr.ID);
                cmd.Parameters.AddWithValue("@RoomID", nvr.RoomID);
                cmd.Parameters.AddWithValue("@Day", nvr.Day);
                cmd.Parameters.AddWithValue("@StartTime", nvr.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", nvr.EndTime);
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

        public bool Delete(NotAvailableRoom nvr)
        {
            //Create a default return and set its value to false
            bool isSuccess = false;
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL TO delete Data
                string sql = "DELETE FROM NotAvailableRooms WHERE ID = @ID";

                //Creating SQL Command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", nvr.ID);

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


