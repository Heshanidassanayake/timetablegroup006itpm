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
    class SessionRoomClass
    {

        //Getter Setter Properties
        //Acts as Data Carrier in Our Application
        public int ID { get; set; }
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public string LecturerName { get; set; }
        public string TagName { get; set; }
        public string SubGroupID { get; set; }
        public string RoomType { get; set; }
       

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
                string sql = "SELECT * FROM SessionRoom";
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
        public bool Insert(SessionRoomClass j)
        {
            //Creating a default return type and setting its value to false
            bool isSuccess = false;

            //Step 1: Connect Database
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                //Step 2: Create a SQL Query to insert Data
                string sql = "INSERT INTO SessionRoom(SubjectCode, SubjectName, LecturerName, TagName, SubGroupID, RoomType ) VALUES(@SubjectCode, @SubjectName, @LecturerName, @TagName, @SubGroupID, @RoomType)";
                //Creating SQL Command using sql and conn
                SqlCommand cmd = new SqlCommand(sql, conn);
                //Create Parameters to add data
                cmd.Parameters.AddWithValue("@SubjectCode", j.SubjectCode);
                cmd.Parameters.AddWithValue("@SubjectName", j.SubjectName);
                cmd.Parameters.AddWithValue("@LecturerName", j.LecturerName);
                cmd.Parameters.AddWithValue("@TagName", j.TagName);
                cmd.Parameters.AddWithValue("@SubGroupID", j.SubGroupID);
                cmd.Parameters.AddWithValue("@RoomType", j.RoomType);
                


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

    }
}
