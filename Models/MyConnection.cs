using System.Web;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace MVCWithADO.Models
{
	public static class MyConnection
	{
		//public static SqlConnection GetConnection()
		//{
		//	string ip = HttpContext.Current.Request.UserHostAddress;
		//	string localConnectionString = ConfigurationManager.ConnectionStrings["TestStudentConnection"].ConnectionString;
		//	string defaultConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

		//	SqlConnection conn = new SqlConnection(defaultConnectionString);

		//	if (ip == "127.0.0.1" || ip == "::1")
		//	{
		//		conn = new SqlConnection(localConnectionString);
		//		return conn;
		//	}

		//	return conn;
		//}

		public static MySqlConnection GetConnection()
		{
			string ip = HttpContext.Current.Request.UserHostAddress;
			string localConnectionString = ConfigurationManager.ConnectionStrings["TestStudentConnection"].ConnectionString;
			string defaultConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

			MySqlConnection conn = new MySqlConnection(defaultConnectionString);
			if (ip == "127.0.0.1" || ip == "::1")
			{
				conn = new MySqlConnection(localConnectionString);
				return conn;
			}

			return conn;
		}
	}
}