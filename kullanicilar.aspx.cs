using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TeknikTakip
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        private string deger;

        protected void Page_Load(object sender, EventArgs e)
        {
            listele();
        }
        protected void listele()
        {
            DbConnection connection = new DbConnection();

            SqlConnection baglanti = connection.Baglan();

            SqlCommand com = new SqlCommand("SELECT * FROM kullanici ORDER BY ID DESC", baglanti);


            SqlDataReader reader;

            reader = com.ExecuteReader();

            Repeater1.DataSource = reader;
            Repeater1.DataBind();
            reader.Close();
            baglanti.Close();

        }
        protected void sil_Click1(object sender, EventArgs e)
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();

            LinkButton link = (LinkButton)sender;
            deger = link.CommandArgument;

            SqlCommand com = new SqlCommand("DELETE FROM kullanici WHERE ID=" + deger, baglanti);
            com.ExecuteNonQuery();
            listele();
            baglanti.Close();

        }
    }
}