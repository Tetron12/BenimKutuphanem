using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace BenimKutuphanem
{
    public static class Veritabani
    {
        private static string baglanti = @"Data Source=.\SQLEXPRESS;Initial Catalog=BenimKutuphanem;Integrated Security=True;";

        public static DataTable Sorgu(string sql)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(baglanti))
            {
                conn.Open();
                using (SqlDataAdapter da = new SqlDataAdapter(sql, conn))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public static bool Komut(string sql)
        {
            using (SqlConnection conn = new SqlConnection(baglanti))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public static object TekDeger(string sql)
        {
            using (SqlConnection conn = new SqlConnection(baglanti))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    return cmd.ExecuteScalar();
                }
            }
        }
    }
}