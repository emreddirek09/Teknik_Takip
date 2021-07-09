using System;
using System.Data.SqlClient;

namespace TeknikTakip
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }
        protected void Giris()
        {
            string kullaniciAdi = TextBox1.Text;
            string kullaniciSifre = TextBox2.Text;

            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            SqlCommand com = new SqlCommand("SELECT * FROM kullanici WHERE kullaniciAdi = @KullaniciAdi and sifre = @sifree ", baglanti);

            com.Parameters.AddWithValue("@KullaniciAdi", kullaniciAdi);
            com.Parameters.AddWithValue("@sifree", kullaniciSifre);

            SqlDataReader sqlDataReader = com.ExecuteReader();


            if (sqlDataReader.Read())
            {
                string kulAdi = sqlDataReader["kullaniciAdi"].ToString();
                string kulSifre = sqlDataReader["sifre"].ToString();
                string kullanici_tipi = sqlDataReader["KullaniciId"].ToString();
                Session["kul_id"] = kullanici_tipi;
                Session["giris"] = kullaniciAdi;

                if (kullaniciAdi == kulAdi && kullaniciSifre == kulSifre)
                {
                    Session["loggedUserID"] = sqlDataReader["Id"].ToString();
                    Response.Redirect("anasayfa.aspx");
                }
            }
            sqlDataReader.Close();
            baglanti.Close();
        }
        protected void giris_Click(object sender, EventArgs e)
        {
            Giris();
        }
    }
}