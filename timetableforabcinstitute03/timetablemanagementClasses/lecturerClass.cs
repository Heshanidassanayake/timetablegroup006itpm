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
    class lecturerClass
    {
        //Getter Setter Properties
        //Acts as Data Carrier in Our Application
        public int ID { get; set; }
        public string LecturerName { get; set; }
        public int EmployeeID { get; set; }
        public string Faculty { get; set; }
        public string Department { get; set; }
        public string Center { get; set; }
        public string Building { get; set; }
        public string LecturerLevel { get; set; }
        public string Rank { get; set; }
         


        static string myconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;


        //Selecting Data from Database
        public DataTable Select()
        {
            ///Step 1: Database Connection 
            SqlConnection conn = new SqlConnection(myconnstrng);
            DataTable dt = new DataTable();
            try
            {
                //Step 2: Writing SQL Query
                string sql = "SELECT * FROM Lecturer";
                //Creating cmd using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Creating SQL DataAdapter using cmd
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

            //Inserting Data into Database
            public bool Insert (lecturerClass c)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;

            //Step 1: Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Step 2: Create a SQL Query to insert Data
                string sql = "INSERT INTO Lecturer(LecturerName, EmployeeID, Faculty, Department, Center, Building, LecturerLevel, Rank) VALUES(@LecturerName, @EmployeeID, @Faculty, @Department, @Center, @Building, @LecturerLevel, @Rank)";
                //Creating SQL Command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@LecturerName", c.LecturerName);
                cmd.Parameters.AddWithValue("@EmployeeID", c.EmployeeID);
                cmd.Parameters.AddWithValue("@Faculty", c.Faculty);
                cmd.Parameters.AddWithValue("@Department", c.Department);
                cmd.Parameters.AddWithValue("@Center", c.Center);
                cmd.Parameters.AddWithValue("@Building", c.Building);
                cmd.Parameters.AddWithValue("@LecturerLevel", c.LecturerLevel);
                cmd.Parameters.AddWithValue("@Rank", c.Rank);
                

                //connection Open Here
                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                //if the query runs successfully then the value of rows will be grater than zero else its will be 0
                if(rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch(Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }




        //Method to update data in database from our application
        public bool Update(lecturerClass c)
        {
            //Create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL to update in our Database
                string sql = "UPDATE Lecturer SET LecturerName=@LecturerName, EmployeeID=@EmployeeID, Faculty=@Faculty, Department=@Department, Center=@Center, Building=@Building, LecturerLevel=@LecturerLevel, Rank=@Rank   WHERE ID=@ID";

                //Creat SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create Parameters to add value
                cmd.Parameters.AddWithValue("@ID", c.ID);
                cmd.Parameters.AddWithValue("@LecturerName", c.LecturerName);
                cmd.Parameters.AddWithValue("@EmployeeID", c.EmployeeID);
                cmd.Parameters.AddWithValue("@Faculty", c.Faculty);
                cmd.Parameters.AddWithValue("@Department", c.Department);
                cmd.Parameters.AddWithValue("@Center", c.Center);
                cmd.Parameters.AddWithValue("@Building", c.Building);
                cmd.Parameters.AddWithValue("@LecturerLevel", c.LecturerLevel);
                cmd.Parameters.AddWithValue("@Rank", c.Rank);


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




            //Method to Delete Data From Database
            public bool Delete(lecturerClass c)
        {
            //Create a default return and set its value to false
            bool isSuccess = false;
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL TO delete Data
                string sql = "DELETE FROM Lecturer WHERE ID=@ID";

                //Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", c.ID);
               
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
            catch(Exception ex)
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
