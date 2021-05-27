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
    class locationClass
    {

        //Getter Setter Properties
        //Acts as data carrier in our Application

        public int LocationID { get; set; }
        public string BuildingName { get; set; }
        public string RoomName { get; set; }
        public string RoomType { get; set; }
        public int Capacity { get; set; }

        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        //Selecting Data from database
        public DataTable Select()
        {
            //step 1. Database Conncetion
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //step 2. writing SQL Query
                string sql = "SELECT * FROM Location";
                //creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Creating SQL Data Adapter using cmd
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
        //Inserting data into database 
        public bool Insert(locationClass c)
        {
            //Creating a defualt return type and setting its value to false
            bool isSuccess = false;


            //Step 1: Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Create a SQL Query to insert data
                string sql = "INSERT INTO Location(BuildingName,RoomName,RoomType,Capacity)VALUES(@BuildingName,@RoomName,@RoomType,@Capacity)";
                //Creating SQL command using Sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Creating parameters to add data
                cmd.Parameters.AddWithValue("@BuildingName", c.BuildingName);
                cmd.Parameters.AddWithValue("@RoomName", c.RoomName);
                cmd.Parameters.AddWithValue("@RoomType", c.RoomType);
                cmd.Parameters.AddWithValue("@Capacity", c.Capacity);

                //Connection open here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if the query runs sucessfully then the value of rows will be greter than zero else its value will be zero
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
        //Method to update data in database in our application
        public bool Update(locationClass c)
        {
            //create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL to update data in our database
                string sql = "UPDATE Location SET BuildingName=@BuildingName, RoomName=@RoomName, RoomType=@RoomType, Capacity=@Capacity WHERE LocationID=@LocationID";

                //Creating SQL command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //create parameters to add values

                cmd.Parameters.AddWithValue("@BuildingName", c.BuildingName);
                cmd.Parameters.AddWithValue("@RoomName", c.RoomName);
                cmd.Parameters.AddWithValue("@RoomType", c.RoomType);
                cmd.Parameters.AddWithValue("@Capacity", c.Capacity);
                cmd.Parameters.AddWithValue("@LocationID", c.LocationID);

                //open DB connection
                conn.Open();

                int rows = cmd.ExecuteNonQuery();
                //if the query tuns successfully then the value of rows will be greater than zero else its value will be zero
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
        public bool Delete(locationClass c)
        {
            //Create a default Return Value and set its value to false
            bool isSuccess = false;
            //Create SQL connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL to Delete data
                string sql = "DELETE FROM Location WHERE LocationID=@LocationID";

                //Create SQL command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@LocationID", c.LocationID);
                //Open connection
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if the query run successfully then the value of rows is greater than zero else its value is 0
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
                //Close connection
                conn.Close();
            }
            return isSuccess;

        }


    }
}
