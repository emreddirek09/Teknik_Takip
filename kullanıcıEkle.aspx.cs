using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknikTakip
{
    public partial class WebForm2 : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               listele();
            }
            
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
        protected void sil_Click(object sender, EventArgs e)
        {

            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            try
            {
                LinkButton link = (LinkButton)sender;
                deger = link.CommandArgument;

                SqlCommand com = new SqlCommand("DELETE FROM kullanici WHERE ID=@id", baglanti);
                com.Parameters.AddWithValue("@id", deger);
                com.ExecuteNonQuery();
                listele();
                

            }
            catch (SqlException ex)
            {
                if (ex.Number == 547)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Silme Başarısız. Kullanıcıya Bağlı Kayıt Bulunmaktadır.');</script>");
                }
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");

            }
            baglanti.Close();

        }
        static string kullanici_kontrol = null;
        private string deger;

        protected void ekle()
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select * from kullanici where kullaniciAdi=@kullaniciAdii", baglanti);
                sqlCommand.Parameters.AddWithValue("@kullaniciAdii", kullaniciAdi.Value);
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                sqlDataReader.Read();
                kullanici_kontrol = sqlDataReader["Id"].ToString();
            }
            catch (Exception)
            {

                kullanici_kontrol = null;
            }
            if (kullanici_kontrol == null)
            {
                try
                {

                    SqlCommand com = new SqlCommand("insert into kullanici(adi,soyadi,mail,kullaniciAdi,sifre,kayit_tarihi,KullaniciId)VALUES(@Adi,@Soyadi,@E_posta,@Kullanici_Adi,@sifre,@kayittarihi,@kullaniciId)", baglanti);


                    com.Parameters.AddWithValue("@Adi", adi.Value);
                    com.Parameters.AddWithValue("@Soyadi", soyadi.Value);
                    com.Parameters.AddWithValue("@Kullanici_Adi", kullaniciAdi.Value);
                    com.Parameters.AddWithValue("@E_posta", emailaddress.Value);
                    com.Parameters.AddWithValue("@sifre", sifre.Value);
                    com.Parameters.AddWithValue("@kullaniciId", 1);
                    com.Parameters.AddWithValue("@kayittarihi", System.DateTime.Now);

                    com.ExecuteNonQuery();

                }
                catch (SqlException ex)
                {
                    if (ex.Number == 2627)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
                    }
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Number + "');</script>");
                }
                catch (Exception ex)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");

                }
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Aynı Kullanıcı Adını Kullanamazsınız..');</script>");
            }

            baglanti.Close();
        }


        protected void Button2_Click(object sender, EventArgs e)
        {

            if (adi.Value == "" || soyadi.Value == "" || kullaniciAdi.Value == "" || sifre.Value == "" || emailaddress.Value == "")
            {

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
            }
            else
            {
                ekle();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Kayit İşlemi Başarılı');</script>");
                listele();
                adi.Value = "";
                soyadi.Value = "";
                kullaniciAdi.Value = "";
                sifre.Value = "";
                emailaddress.Value = "";



            }
        }

        
    }
}