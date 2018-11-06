using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace MVCWithADO.Models
{
	public class StudentModel
	{
		/// <summary>
		/// Get all records from the DB
		/// </summary>
		/// <returns>Datatable</returns>
		public DataTable GetAllStudents()
		{
			DataTable dt = new DataTable();
			using(MySqlConnection con = MyConnection.GetConnection())
			{
				con.Open();
				MySqlCommand cmd = new MySqlCommand("SELECT * FROM Students", con);
				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				da.Fill(dt);
				con.Close();
			}
			return dt;
		}

		/// <summary>
		/// Get student detail by StudentId
		/// </summary>
		/// <param name="intStudentId"></param>
		/// <returns>Datatable</returns>
		public DataTable GetStudentById(int intStudentId)
		{
			DataTable dt = new DataTable();
			using (MySqlConnection con = MyConnection.GetConnection())
			{
				con.Open();
				MySqlCommand cmd = new MySqlCommand("SELECT * FROM Students where StudentId = " + intStudentId, con);
				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				da.Fill(dt);
				con.Close();
			}
			return dt;
		}

		/// <summary>
		/// Update the student details
		/// </summary>
		/// <param name="intStudentId"></param>
		/// <param name="strStudentName"></param>
		/// <param name="strGender"></param>
		/// <param name="intAge"></param>
		/// <returns></returns>
		public int UpdateStudent(int intStudentId, string strStudentName, string strGender, int intAge)
		{
			using (MySqlConnection con = MyConnection.GetConnection())
			{
				con.Open();
				string query = "UPDATE Students SET StudentName = @studname, StudentAge = @studage, " +
					"StudentGender = @gender WHERE StudentId = @studid";
				MySqlCommand cmd = new MySqlCommand(query, con);
				cmd.Parameters.AddWithValue("@studname", strStudentName);
				cmd.Parameters.AddWithValue("@studage", intAge);
				cmd.Parameters.AddWithValue("@gender", strGender);
				cmd.Parameters.AddWithValue("@studid", intStudentId);

				return cmd.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// Insert Student record to DB
		/// </summary>
		/// <param name="strStudentName"></param>
		/// <param name="strGender"></param>
		/// <param name="intAge"></param>
		/// <returns></returns>
		public int InsertStudent(string strStudentName, string strGender, int intAge)
		{
			using (MySqlConnection con = MyConnection.GetConnection())
			{
				con.Open();
				string query = "INSERT INTO Students (StudentName, StudentAge, StudentGender) VALUES(@studname, @studage, @gender)";
				MySqlCommand cmd = new MySqlCommand(query, con);
				cmd.Parameters.AddWithValue("@studname", strStudentName);
				cmd.Parameters.AddWithValue("@studage", intAge);
				cmd.Parameters.AddWithValue("@gender", strGender);

				return cmd.ExecuteNonQuery();
			}
		}

		/// <summary>
		/// Delete Student based on ID
		/// </summary>
		/// <param name="intStudentId"></param>
		/// <returns></returns>
		public int DeleteStudent(int intStudentId)
		{
			using (MySqlConnection con = MyConnection.GetConnection())
			{
				con.Open();
				string query = "DELETE FROM Students where StudentId=@studid";
				MySqlCommand cmd = new MySqlCommand(query, con);
				cmd.Parameters.AddWithValue("@studid", intStudentId);
				return cmd.ExecuteNonQuery();
			}
		}
	}
}