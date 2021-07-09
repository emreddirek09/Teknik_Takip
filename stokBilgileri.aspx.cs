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

            SqlCommand com = new SqlCommand("DELETE FROM Stok_Bilgileri WHERE Id=@id", baglanti);
            com.Parameters.AddWithValue("@id",deger);
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

                    if (stok_kodu.Value != "")
                    {
                        SqlCommand com = new SqlCommand("insert into Stok_Bilgileri(Stok_Kodu,Stok_Adi,Birim,Stok_Tip_Adi,saklamaRafi,kayit_tarihi)" +
                              "VALUES(@Stok_Koduu,@Stok_Adii,@Birimm,@Stok_Tip_Adii,@saklamaRafii,@kayit_tarihii)", baglanti);
                    com.Parameters.AddWithValue("@Stok_Koduu", stok_kodu.Value);
                    com.Parameters.AddWithValue("@Stok_Adii", stok_adi.Value);
                    com.Parameters.AddWithValue("@Birimm", birim.Value);
                    com.Parameters.AddWithValue("@Stok_Tip_Adii", stok_tip_adi.Value);
                    com.Parameters.AddWithValue("@saklamaRafii", saklamaRafi.Value);
                    com.Parameters.AddWithValue("@kayit_tarihii", System.DateTime.Now);
                    com.ExecuteNonQuery();

                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Kayit İşlemi Başarılı');</script>");
                    listele();

                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
                    }
                }
                catch (SqlException ex)
                {
                    //throw;
                    if (ex.Number == 2627)
                    {
                    
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Girmiş Olduğunuz Stok Kodu Mevcut Kayıtlarda Vardır.');</script>");
                    
                    }
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
    
                 }
                
                baglanti.Close();

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
        protected void Ürün_Bilgi_Click(object sender, EventArgs e)
        {
            ekle();
            stok_kodu.Value = "";
            stok_adi.Value = "";
            birim.Value = "";
            stok_tip_adi.Value = "";
            saklamaRafi.Value = "";
            Label6.Text = "";
            listele();
        }

        protected void Güncelle_Click(object sender, EventArgs e)
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();

            try
            {
                LinkButton lnk = (LinkButton)sender;
                deger = lnk.CommandArgument;
                sec_id_HiddenField1.Value = deger;

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Stok_Bilgileri where Id=@id", baglanti);
                sqlCommand.Parameters.AddWithValue("@id",deger);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    stok_kodu_popup.Value = reader["Stok_Kodu"].ToString();
                    stok_adi_popup.Value = reader["Stok_Adi"].ToString();
                    birim_popup.Value = reader["Birim"].ToString();
                    stok_tip_adi_popup.Value = reader["Stok_Tip_Adi"].ToString();
                    saklamaRafi_popup.Value = reader["saklamaRafi"].ToString();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Gonder();", true);

                }
                reader.Close();
                sqlCommand.ExecuteNonQuery();

               
            }
            catch (SqlException ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");

            }

            baglanti.Close();

        }
        protected void PopUpGüncelle_Click(object sender, EventArgs e)
        {

            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            SqlCommand comm;
                try
                {

                    comm = new SqlCommand("UPDATE Stok_Bilgileri SET Stok_Kodu=@Stok_Koduu,Stok_Adi=@Stok_Adii, Birim=@Birimm,Stok_Tip_Adi=@Stok_Tip_Adii,saklamaRafi=@saklamaRafii,güncelle_tarihi=@güncelleme_tarihii  WHERE ID=@id", baglanti);


                    comm.Parameters.AddWithValue("@Stok_Koduu", stok_kodu_popup.Value);
                    comm.Parameters.AddWithValue("@Stok_Adii", stok_adi_popup.Value);
                    comm.Parameters.AddWithValue("@Birimm", birim_popup.Value);
                    comm.Parameters.AddWithValue("@Stok_Tip_Adii", stok_tip_adi_popup.Value);
                    comm.Parameters.AddWithValue("@saklamaRafii", saklamaRafi_popup.Value);
                    comm.Parameters.AddWithValue("@güncelleme_tarihii", System.DateTime.Now);
                    comm.Parameters.AddWithValue("@id", sec_id_HiddenField1.Value);

                    if (stok_kodu_popup.Value == "" || stok_adi_popup.Value == "" || birim_popup.Value == "" || stok_tip_adi_popup.Value == "")
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");

                    }
                    else
                    {

                        comm.ExecuteNonQuery();
                        listele();
                        stok_kodu_popup.Value = "";
                        stok_adi_popup.Value = "";
                        birim_popup.Value = "";
                        stok_tip_adi_popup.Value = "";


                    }
                }
                catch (SqlException ex)
                {
                    //throw;
                    if (ex.Number == 2627)
                    {

                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Girmiş Olduğunuz Stok Kodu Mevcut Kayıtlarda Vardır.');</script>");

                    }
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");

                }
                baglanti.Close();    
        }
    }
}