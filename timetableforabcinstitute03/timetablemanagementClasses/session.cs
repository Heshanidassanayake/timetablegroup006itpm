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
    class session
    {
        //Getter Setter Properties
        //Acts as Data Carrier in Our Application
        public int ID { get; set; }
        public string SelectLecturer1 { get; set; }
        public string SelectLecturer2 { get; set; }
        public string SelectSubjectCode { get; set; }
        public string SelectSubject { get; set; }
        public string SelectTag { get; set; }
        public string SelectGroup { get; set; }
        public string NoOfStudents { get; set; }
        public string Duration { get; set; }

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
                string sql = "SELECT * FROM Session";
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
        public bool Insert(session m)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;

            //Step 1: Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Step 2: Create a SQL Query to insert Data
                string sql = "INSERT INTO Session(SelectLecturer1, SelectLecturer2, SelectSubjectCode, SelectSubject, SelectTag, SelectGroup, NoOfStudents, Duration ) VALUES(@SelectLecturer1, @SelectLecturer2, @SelectSubjectCode, @SelectSubject, @SelectTag, @SelectGroup, @NoOfStudents, @Duration)";
                //Creating SQL Command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@SelectLecturer1", m.SelectLecturer1);
                cmd.Parameters.AddWithValue("@SelectLecturer2", m.SelectLecturer2);
                cmd.Parameters.AddWithValue("@SelectSubjectCode", m.SelectSubjectCode);
                cmd.Parameters.AddWithValue("@SelectSubject", m.SelectSubject);
                cmd.Parameters.AddWithValue("@SelectTag", m.SelectTag);
                cmd.Parameters.AddWithValue("@SelectGroup", m.SelectGroup);
                cmd.Parameters.AddWithValue("@NoOfStudents", m.NoOfStudents);
                cmd.Parameters.AddWithValue("@Duration", m.Duration);


                //connection Open Here
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




        //Method to update data in database from our application
        public bool Update(session m)
        {
            //Create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL to update in our Database
                string sql = "UPDATE Session SET SelectLecturer1=@SelectLecturer1, SelectLecturer2=@SelectLecturer2, SelectSubjectCode=@SelectSubjectCode, SelectSubject=@SelectSubject, SelectTag=@SelectTag, SelectGroup=@SelectGroup, NoOfStudents=@NoOfStudents, Duration=@Duration   WHERE ID=@ID";

                //Creat SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create Parameters to add value
                cmd.Parameters.AddWithValue("@ID", m.ID);
                cmd.Parameters.AddWithValue("@SelectLecturer1", m.SelectLecturer1);
                cmd.Parameters.AddWithValue("@SelectLecturer2", m.SelectLecturer2);
                cmd.Parameters.AddWithValue("@SelectSubjectCode", m.SelectSubjectCode);
                cmd.Parameters.AddWithValue("@SelectSubject", m.SelectSubject);
                cmd.Parameters.AddWithValue("@SelectTag", m.SelectTag);
                cmd.Parameters.AddWithValue("@SelectGroup", m.SelectGroup);
                cmd.Parameters.AddWithValue("@NoOfStudents", m.NoOfStudents);
                cmd.Parameters.AddWithValue("@Duration", m.Duration);


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
        public bool Delete(session m)
        {
            //Create a default return and set its value to false
            bool isSuccess = false;
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL TO delete Data
                string sql = "DELETE FROM Session WHERE ID=@ID";

                //Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", m.ID);

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

