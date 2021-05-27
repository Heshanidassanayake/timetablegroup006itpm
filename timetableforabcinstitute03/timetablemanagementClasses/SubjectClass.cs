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
    class SubjectClass
    {
        //Getter Setter Properties
        //Acts as Data Carrier in Our Application
        public int ID { get; set; }
        public string SubjectName { get; set; }
        public string SubjectCode { get; set; }
        public string OfferedYear { get; set; }
        public string OfferedSemester { get; set; }
        public int NumberOfLectureHours { get; set; }
        public int NumberOfTutorialHours { get; set; }
        public int NumberOfLabHours { get; set; }
        public int NumberOfEvaluationHours { get; set; }

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
                string sql = "SELECT * FROM Subject";
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
        public bool Insert(SubjectClass d)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;

            //Step 1: Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Step 2: Create a SQL Query to insert Data
                string sql = "INSERT INTO Subject(SubjectName, SubjectCode, OfferedYear, OfferedSemester, NumberOfLectureHours, NumberOfTutorialHours, NumberOfLabHours, NumberOfEvaluationHours) VALUES(@SubjectName, @SubjectCode, @OfferedYear, @OfferedSemester, @NumberOfLectureHours, @NumberOfTutorialHours, @NumberOfLabHours, @NumberOfEvaluationHours)";
                //Creating SQL Command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@SubjectName", d.SubjectName);
                cmd.Parameters.AddWithValue("@SubjectCode", d.SubjectCode);
                cmd.Parameters.AddWithValue("@OfferedYear", d.OfferedYear);
                cmd.Parameters.AddWithValue("@OfferedSemester", d.OfferedSemester);
                cmd.Parameters.AddWithValue("@NumberOfLectureHours", d.NumberOfLectureHours);
                cmd.Parameters.AddWithValue("@NumberOfTutorialHours", d.NumberOfTutorialHours);
                cmd.Parameters.AddWithValue("@NumberOfLabHours", d.NumberOfLabHours);
                cmd.Parameters.AddWithValue("@NumberOfEvaluationHours", d.NumberOfEvaluationHours);


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
        public bool Update(SubjectClass d)
        {
            //Create a default return type and set its default value to false
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                //SQL to update in our Database
                string sql = "UPDATE Subject SET SubjectName=@SubjectName, SubjectCode=@SubjectCode, OfferedYear=@OfferedYear, OfferedSemester=@OfferedSemester, NumberOfLectureHours=@NumberOfLectureHours, NumberOfTutorialHours=@NumberOfTutorialHours, NumberOfLabHours=@NumberOfLabHours, NumberOfEvaluationHours=@NumberOfEvaluationHours   WHERE ID=@ID";

                //Creat SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create Parameters to add value
                cmd.Parameters.AddWithValue("@ID", d.ID);
                cmd.Parameters.AddWithValue("@SubjectName", d.SubjectName);
                cmd.Parameters.AddWithValue("@SubjectCode", d.SubjectCode);
                cmd.Parameters.AddWithValue("@OfferedYear", d.OfferedYear);
                cmd.Parameters.AddWithValue("@OfferedSemester", d.OfferedSemester);
                cmd.Parameters.AddWithValue("@NumberOfLectureHours", d.NumberOfLectureHours);
                cmd.Parameters.AddWithValue("@NumberOfTutorialHours", d.NumberOfTutorialHours);
                cmd.Parameters.AddWithValue("@NumberOfLabHours", d.NumberOfLabHours);
                cmd.Parameters.AddWithValue("@NumberOfEvaluationHours", d.NumberOfEvaluationHours);


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
        public bool Delete(SubjectClass d)
        {
            //Create a default return and set its value to false
            bool isSuccess = false;
            //Create SQL Connection
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //SQL TO delete Data
                string sql = "DELETE FROM Subject WHERE ID=@ID";

                //Creating SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", d.ID);

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
