using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace MVCWithADO.Models
{
	public class TrackingViewModel
	{
		public int InsertTrackingStates(string ipaddress, long duration, string controller, string action, long createdAt)
		{
			using (MySqlConnection conn = MyConnection.GetConnection())
			{
				conn.Open();
				string query = "INSERT INTO TrackingList (IpAddress, Duration, Controller, Action, CreatedAt) VALUES(@item1, @item2, @item3, @item4, @item5)";
				MySqlCommand cmd = new MySqlCommand(query, conn);
				cmd.Parameters.AddWithValue("@item1", ipaddress);
				cmd.Parameters.AddWithValue("@item2", duration);
				cmd.Parameters.AddWithValue("@item3", controller);
				cmd.Parameters.AddWithValue("@item4", action);
				cmd.Parameters.AddWithValue("@item5", createdAt);

				return cmd.ExecuteNonQuery();
			}
		}

		public DataTable GetAllTrackingStates()
		{
			DataTable dt = new DataTable();
			using (MySqlConnection conn = MyConnection.GetConnection())
			{
				conn.Open();
				MySqlCommand cmd = new MySqlCommand("SELECT * FROM TrackingList", conn);
				MySqlDataAdapter da = new MySqlDataAdapter(cmd);
				da.Fill(dt);
				conn.Close();
			}
			return dt;
		}
	}
}