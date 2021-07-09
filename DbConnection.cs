using System.Data.SqlClient;

namespace TeknikTakip
{
    public class DbConnection
    {
        public SqlConnection Baglan()
        {
            //SqlConnection sqlConnection = new SqlConnection(@"Server=WIN-SQCB61TDPG8\MSSQLSERVER2012; Initial Catalog=Teknik_Takip; Integrated Security=SSPI; MultipleActiveResultSets=True; User ID=sa;Password=dgfceu;");
            // SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-QS5JIJI\SQLEXPRESS; Initial Catalog=Teknik_Takip; Integrated Security=SSPI; MultipleActiveResultSets=True;");

            // SqlConnection sqlConnection = new SqlConnection(@"Data Source=185.82.220.84; Initial Catalog=Teknik_Takip; User ID=sa;Password=dgfceU.*");
            // SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-K4S8US0\SQLEXPRESS; Initial Catalog=TeknikTakip; Integrated Security=SSPI; MultipleActiveResultSets=True;");
            // SqlConnection sqlConnection = new SqlConnection(@"Server=DESKTOP-J9OEKO6\SQLEXPRESS; Initial Catalog=TeknikTakip; Integrated Security=SSPI; MultipleActiveResultSets=True;");
            SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-J9OEKO6; Database=TeknikTakip; Integrated Security = True");
            sqlConnection.Open();
            return sqlConnection;
        }


    }
}