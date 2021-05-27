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
    class TagClass
    {
        //Getter Setter Properties
        //Acts as data carrier in our Application

        public int ID { get; set; }
        public string TagName { get; set; }
        public int TagCode { get; set; }
        public string RelatedTag { get; set; }
       

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
                string sql = "SELECT * FROM Tag";
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
        public bool Insert(TagClass w)
        {
            //Creating a defualt return type and setting its value to false
            bool isSuccess = false;


            //Step 1: Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Create a SQL Query to insert data
                string sql = "INSERT INTO Tag(TagName,TagCode,RelatedTag)VALUES(@TagName,@TagCode,@RelatedTag)";
                //Creating SQL command using Sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Creating parameters to add data
                cmd.Parameters.AddWithValue("@TagName", w.TagName);
                cmd.Parameters.AddWithValue("@TagCode", w.TagCode);
                cmd.Parameters.AddWithValue("@RelatedTag", w.RelatedTag);
                

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
        public bool Update(TagClass w)
        {
            //create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL to update data in our database
                string sql = "UPDATE Tag SET TagName=@TagName, TagCode=@TagCode, RelatedTag=@RelatedTag WHERE ID=@ID";

                //Creating SQL command
                SqlCommand cmd = new SqlCommand(sql, conn);
                //create parameters to add values

             
                cmd.Parameters.AddWithValue("@TagName", w.TagName);
                cmd.Parameters.AddWithValue("@TagCode", w.TagCode);
                cmd.Parameters.AddWithValue("@RelatedTag", w.RelatedTag);
                cmd.Parameters.AddWithValue("@ID", w.ID);

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
        public bool Delete(TagClass w)
        {
            //Create a default Return Value and set its value to false
            bool isSuccess = false;
            //Create SQL connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL to Delete data
                string sql = "DELETE FROM Tag WHERE ID=@ID";

                //Create SQL command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", w.ID);
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
