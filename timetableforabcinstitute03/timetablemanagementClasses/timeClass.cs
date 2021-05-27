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
    class timeClass
    {
        //Getter Setter Properties
        //Acts as Data Carrier in Our Application
        public int SlotID { get; set; }
        public String TimeBlock { get; set; }
        public String Duration { get; set; }

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
                string sql = "SELECT * FROM Addtimeslot";
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
        public bool Insert(timeClass time)
        {
            //Creating a default return type and setting its value false
            bool isSuccess = false;

            //Step 1 : Connect Database 
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Step 2: Create a SQL Query to insert Data
                string sql = "INSERT INTO Addtimeslot(TimeBlock, Duration) VALUES (@TimeBlock,@Duration)"; //Creating sql command sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@TimeBlock", time.TimeBlock);
                cmd.Parameters.AddWithValue("@Duration", time.Duration);

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
        public bool Update(timeClass time)
        {
            //Create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL to update in our Database
                string sql = "UPDATE Addtimeslot SET TimeBlock=@TimeBlock, Duration=@Duration WHERE SlotID=@SlotID";

                //Creating sql command sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@SlotID", time.SlotID);
                cmd.Parameters.AddWithValue("@TimeBlock", time.TimeBlock);
                cmd.Parameters.AddWithValue("@Duration", time.Duration);

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
        public bool Delete(timeClass time)
        {
            //Create a default return and set its value to false
            bool isSuccess = false;
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL TO delete Data
                string sql = "DELETE FROM Addtimeslot WHERE SlotID= @SlotID";

                //Creating SQL Command 
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@SlotID", time.SlotID);

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


