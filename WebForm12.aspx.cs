using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknikTakip
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        private string deger;
        private string degerr;
        private string kontrolvarmi = null;
        int ürün_adett = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            listele();

        }
        protected void sil_Click(object sender, EventArgs e)
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();

            LinkButton link = (LinkButton)sender;
            deger = link.CommandArgument;

            SqlCommand com = new SqlCommand("DELETE FROM Stok_Bilgileri WHERE Id=" + deger, baglanti);
            com.ExecuteNonQuery();
            listele();
            baglanti.Close();
        }
        protected void ekle()
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();


            try
            {
                SqlCommand com1 = new SqlCommand("select * from Stok_Bilgileri where Stok_Kodu=@StokKodu", baglanti);
                com1.Parameters.AddWithValue("@StokKodu", stok_kodu.Value);
                SqlDataReader sqlDataReader = com1.ExecuteReader();
                sqlDataReader.Read();
                kontrolvarmi = sqlDataReader["Id"].ToString();
            }
            catch (Exception)
            {
                kontrolvarmi = null;

            }
            if (kontrolvarmi == null)
            {
                try
                {

                    if (stok_kodu.Value != "" || stok_adi.Value != "" || birim.Value != "" || stok_tip_adi.Value != "")
                    {
                        SqlCommand com = new SqlCommand("insert into Stok_Bilgileri(Stok_Kodu,Stok_Adi,Birim,Stok_Tip_Adi,kayit_tarihi)" +
                            "VALUES(@Stok_Koduu,@Stok_Adii,@Birimm,@Stok_Tip_Adii,@kayit_tarihii)", baglanti);

                        com.Parameters.AddWithValue("@Stok_Koduu", stok_kodu.Value);
                        com.Parameters.AddWithValue("@Stok_Adii", stok_adi.Value);
                        com.Parameters.AddWithValue("@Birimm", birim.Value);
                        com.Parameters.AddWithValue("@Stok_Tip_Adii", stok_tip_adi.Value);
                        com.Parameters.AddWithValue("@kayit_tarihii", System.DateTime.Now);

                        com.ExecuteNonQuery();

                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
                    }
                }
                catch (SqlException ex)
                {

                    throw;
                    //    if (ex.Number == 2627)
                    //    {
                    //        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
                    //    }
                    //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
                    //}
                    //catch (Exception ex)
                    //{
                    //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
                }
                baglanti.Close();

            }
            else
            { 
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Girmiş Olduğunuz Stok Kodu Mevcuttur.');</script>");
            }
        }

        protected void listele()
        {
            DbConnection connection = new DbConnection();

            SqlConnection baglanti = connection.Baglan();

            SqlCommand com = new SqlCommand("SELECT * FROM Stok_Bilgileri ORDER BY ID DESC", baglanti);


            SqlDataReader reader;

            reader = com.ExecuteReader();

            Repeater1.DataSource = reader;
            Repeater1.DataBind();
            reader.Close();
            baglanti.Close();

        }
        protected void sec_Click1(object sender, EventArgs e)
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            LinkButton lnk = (LinkButton)sender;
            deger = lnk.CommandArgument;

            Label6.Text = deger;


            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Stok_Bilgileri where Id=" + deger, baglanti);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                stok_kodu.Value = reader["Stok_Kodu"].ToString();
                stok_adi.Value = reader["Stok_Adi"].ToString();
                birim.Value = reader["Birim"].ToString();
                stok_tip_adi.Value = reader["Stok_Tip_Adi"].ToString();
            }

            reader.Close();
            sqlCommand.ExecuteNonQuery();

            baglanti.Close();
        }

        protected void Güncelle_Click1(object sender, EventArgs e)
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            SqlCommand comm;
            
                try
                {
                    comm = new SqlCommand("UPDATE Stok_Bilgileri SET Stok_Kodu=@Stok_Koduu,Stok_Adi=@Stok_Adii,Birim=@Birimm,Stok_Tip_Adi=@Stok_Tip_Adii,güncelle_tarihi=@güncelle_tarihii WHERE Id=@id", baglanti);

                    comm.Parameters.AddWithValue("@Stok_Koduu", stok_kodu.Value);
                    comm.Parameters.AddWithValue("@Stok_Adii", stok_adi.Value);
                    comm.Parameters.AddWithValue("@Birimm", birim.Value);
                    comm.Parameters.AddWithValue("@Stok_Tip_Adii", stok_tip_adi.Value);
                    comm.Parameters.AddWithValue("@güncelle_tarihii", System.DateTime.Now);

                    comm.Parameters.AddWithValue("@id", Label6.Text);
                 if (stok_kodu.Value == "" || stok_adi.Value == "" || birim.Value == "" || stok_tip_adi.Value == "")
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");

                    }
                    else
                    {
                    stok_kodu.Value = "";
                    stok_adi.Value = "";
                    birim.Value = "";
                    stok_tip_adi.Value = "";
                        Label6.Text = "";
                        comm.ExecuteNonQuery();
                        listele();
                    }
                }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert(' Güncellemeden Önce Seçiminizi Yapınız.');</script>");
            }

            baglanti.Close();
        }

        protected void Ürün_Bilgi_Click(object sender, EventArgs e)
        {
            ekle();
            stok_kodu.Value = "";
            stok_adi.Value = "";
            birim.Value = "";
            stok_tip_adi.Value = "";
            Label6.Text = "";
            listele();
        }
    }
}