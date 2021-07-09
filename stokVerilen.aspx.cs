using System;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace TeknikTakip
{
    public partial class WebForm9 : System.Web.UI.Page
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

            SqlCommand com = new SqlCommand("SELECT * FROM stokDüs ORDER BY ID DESC", baglanti);

         
            SqlDataReader reader;

            reader = com.ExecuteReader();

            Repeater1.DataSource = reader;
            Repeater1.DataBind();
            reader.Close();
            baglanti.Close();

        }
        protected void sil_Click(object sender, EventArgs e)
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();

            LinkButton link = (LinkButton)sender;
            deger = link.CommandArgument;

            SqlCommand com = new SqlCommand("DELETE FROM stokDüs WHERE Id=@id", baglanti);
            com.Parameters.AddWithValue("@id",deger);
            com.ExecuteNonQuery();
            listele();
            baglanti.Close();
        }
    }
}