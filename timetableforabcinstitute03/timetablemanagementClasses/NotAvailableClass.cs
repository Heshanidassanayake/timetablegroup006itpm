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
    class NotAvailableClass
    {

        public int ID { get; set; }
        public string LecturerName { get; set; }
        public string GroupID { get; set; }
        public string SubGroupID { get; set; }
        public string SessionID { get; set; }
        public string Time { get; set; }


        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;
       //static string myconfig1 = "Server=tcp:timetablegroup06.database.windows.net,1433;Initial Catalog=Timetablegroup06;Persist Security Info=False;User ID=HeshaniDassanayake;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";

        //Selecting Data from Database
        public DataTable Select()
        {
            //Step 1 : Database Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //Step 2://Writing SQL Query
                string sql = "SELECT * FROM NotAvailableTime";
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
        public bool Insert(NotAvailableClass nav)
        {
            //Creating a default return type and setting its value false
            bool isSuccess = false;

            //Step 1 : Connect Database 
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Step 2: Create a SQL Query to insert Data
                string sql = "INSERT INTO NotAvailableTime(LecturerName,GroupID,SubGroupID,SessionID,Time) VALUES (@LecturerName,@GroupID,@SubGroupID,@SessionID,@Time)";
                //Creating sql command sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@LecturerName", nav.LecturerName);
                cmd.Parameters.AddWithValue("@GroupID", nav.GroupID);
                cmd.Parameters.AddWithValue("@SubGroupID", nav.SubGroupID);
                cmd.Parameters.AddWithValue("@SessionID", nav.SessionID);
                cmd.Parameters.AddWithValue("@Time", nav.Time);

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
        public bool Update(NotAvailableClass nav)
        {
            //Create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {

                //SQL to update in our Database
                string sql = "UPDATE  NotAvailableTime SET LecturerName=@LecturerName, GroupID=@GroupID, SubGroupID=@SubGroupID, SessionID=@SessionID ,Time = @Time  WHERE ID = @ID";
                //Create SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("ID", nav.ID);
                cmd.Parameters.AddWithValue("@LecturerName", nav.LecturerName);
                cmd.Parameters.AddWithValue("@GroupID", nav.GroupID);
                cmd.Parameters.AddWithValue("@SubGroupID", nav.SubGroupID);
                cmd.Parameters.AddWithValue("@SessionID", nav.SessionID);
                cmd.Parameters.AddWithValue("@Time", nav.Time);

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
        public bool Delete(NotAvailableClass nav)
        {
            //Create a default return and set its value to false
            bool isSuccess = false;
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL TO delete Data
                string sql = "DELETE FROM NotAvailableTime WHERE ID = @ID";

                //Creating SQL Command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", nav.ID);

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

