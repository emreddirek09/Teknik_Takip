using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknikTakip
{
    public partial class WebForm11 : System.Web.UI.Page
    {
        private string müs_adi;
        private string deger;
        int müs_id;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MüsteriEkle();
                listele();
            }
        }
        string searhEdilen = null;
        protected void MüsteriEkle()
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            SqlCommand com = new SqlCommand("SELECT Sponsorid, SponsorAdi FROM Sponsorlar", baglanti);


            SqlDataReader oku;
            oku = com.ExecuteReader();
            int i = 0;
            while (oku.Read())
            {
                DropDownList1.Items.Add(new ListItem(oku["SponsorAdi"].ToString(), oku["Sponsorid"].ToString()));
                i++;
            }
            baglanti.Close();
        }
        protected void kayitekle()
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();

                try
                {
                    SqlCommand com2 = new SqlCommand("Select * from müsteriler where Firma_Adi=@FirmaAdi", baglanti);
                    com2.Parameters.AddWithValue("@FirmaAdi", DropDownList1.SelectedItem.Text);
                    SqlDataReader sqlDataReader = com2.ExecuteReader();
                    sqlDataReader.Read();
                    müs_adi = sqlDataReader["Firma_Adi"].ToString();
                    Session["müs_adi"] = sqlDataReader["Firma_Adi"].ToString();
                    müs_id = Convert.ToInt32(sqlDataReader["Id"].ToString());

                    SqlCommand com = new SqlCommand("insert into cihazKayit(kayitEden_id,firma_adi,firma_id,markasi,modeli,aksesuarDurumu,seriNo,adaptörNo,bataryaSeriNo,kayit_tarihi)" +
                        "VALUES(@kayitEdenid,@firmaadi,@firma_idd,@marka,@model,@aksesuarDurumuu,@seriNoo,@adaptörSeriNoo,@bataryaSeriNoo,@kayit_tarihii)", baglanti);

                    com.Parameters.AddWithValue("@kayitEdenid", Session["giris"].ToString());
                    com.Parameters.AddWithValue("@firmaadi", müs_adi);
                    com.Parameters.AddWithValue("@firma_idd", müs_id);
                    com.Parameters.AddWithValue("@marka", marka.Value);
                    com.Parameters.AddWithValue("@model", modeli.Value);
                    com.Parameters.AddWithValue("@aksesuarDurumuu", aksesuarDurumu.Value);
                    com.Parameters.AddWithValue("@seriNoo", seriNo.Value);
                    com.Parameters.AddWithValue("@adaptörSeriNoo", adaptörSeriNo.Value);
                    com.Parameters.AddWithValue("@bataryaSeriNoo", bataryaSeriNo.Value);
                    com.Parameters.AddWithValue("@kayit_tarihii", System.DateTime.Now);
                    com.ExecuteNonQuery();

                    //SqlCommand sqlCommand = new SqlCommand("Select * from cihazKayit Where kayitEden_id=@kayitEdenİd AND firma_adi=@FirmaAdi AND seriNo=@seriNoo", baglanti);
                    //sqlCommand.Parameters.AddWithValue("@kayitEdenİd", Session["loggedUserID"].ToString());
                    //sqlCommand.Parameters.AddWithValue("@FirmaAdi", müs_adi);
                    //sqlCommand.Parameters.AddWithValue("@seriNoo",seriNo.Value);
                    //SqlDataReader sqlDataReader1 = sqlCommand.ExecuteReader();
                    //sqlDataReader1.Read();
                    //int kayit_id = Convert.ToInt32(sqlDataReader1["Id"].ToString());
                    //Session["yeniKayit_id"] = kayit_id;
                }
                catch (SqlException ex)
                {

                    // throw;
                    if (ex.Number == 2627)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Aynı Seri Numarasına Ait Kayıt Bulunmaktadır.');</script>");
                    }
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
                }

           
            baglanti.Close();
        }
        protected void Ekle_Click(object sender, EventArgs e)
        {
            try
            {
                if (seriNo.Value != "")
                {
                    kayitekle();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Kayit İşlemi Başarılı');</script>");
                    listele();
                }
                else
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
                }
                marka.Value = "";
                modeli.Value = "";
                aksesuarDurumu.Value = "";
                seriNo.Value = "";
                adaptörSeriNo.Value = "";
                bataryaSeriNo.Value = "";
                DropDownList1.SelectedValue = "";
            }
            catch (Exception ex)
            {

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
            }


        }
        protected void listele()
        {
            DbConnection connection = new DbConnection();

            SqlConnection baglanti = connection.Baglan();

            if (searhEdilen == null)
            {
                SqlCommand com = new SqlCommand("SELECT * FROM cihazKayit ORDER BY ID DESC", baglanti);
             

                SqlDataReader reader;

                reader = com.ExecuteReader();

                Repeater1.DataSource = reader;
                Repeater1.DataBind();
                reader.Close();
                
            }
            baglanti.Close();

        }
       
        protected void sil_Click1(object sender, EventArgs e)
        {

            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();

            LinkButton link = (LinkButton)sender;
            deger = link.CommandArgument;

            SqlCommand com = new SqlCommand("DELETE FROM cihazKayit WHERE Id=@id" , baglanti);
            com.Parameters.AddWithValue("@id",deger);
            com.ExecuteNonQuery();
            listele();
            baglanti.Close();
        }

     

        protected void PopUpGüncelle_Click(object sender, EventArgs e)
        {
            
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            SqlCommand comm;
            try
            {

                comm = new SqlCommand("UPDATE cihazKayit SET markasi=@markasii,modeli=@modelii,seriNo=@seriNoo,adaptörNo=@adaptörNoo , bataryaSeriNo=@bataryaSeriNoo,aksesuarDurumu=@aksesuarDurumuu, güncelleme_tarihi=@güncelleme_tarihii  WHERE ID=@id", baglanti);

               

                comm.Parameters.AddWithValue("@markasii", marka_popup.Value);
                comm.Parameters.AddWithValue("@modelii", modeli_popup.Value);
                comm.Parameters.AddWithValue("@seriNoo", seriNo_popup.Value);
                comm.Parameters.AddWithValue("@adaptörNoo", adaptörNo_popup.Value);
                comm.Parameters.AddWithValue("@bataryaSeriNoo", bataryaNo_popup.Value);
                comm.Parameters.AddWithValue("@aksesuarDurumuu", aksesuar_popup.Value);

                comm.Parameters.AddWithValue("@güncelleme_tarihii", System.DateTime.Now);
                comm.Parameters.AddWithValue("@id", sec_id_HiddenField1.Value);

                //if (firma_Adi_popup.Value == "" || yetkili_kisi_popup.Value == "" || telefon_popup.Value == "" || email1_popup.Value == "")
                //{
                //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");


                //}
                //else
                //{
                marka_popup.Value = "";
                modeli_popup.Value = "";
                seriNo_popup.Value = "";
                adaptörNo_popup.Value = "";
                bataryaNo_popup.Value = "";
                aksesuar_popup.Value = "";
                comm.ExecuteNonQuery();
                listele();
                //}
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Aynı Seri Numarasına Ait Kayıt Bulunmaktadır.');</script>");
                }
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
            }
            baglanti.Close();

        }

        protected void Güncelle_Click1(object sender, EventArgs e)
        {

                DbConnection connection = new DbConnection();
                SqlConnection baglanti = connection.Baglan();
            try
            {
                LinkButton lnk = (LinkButton)sender;
                deger = lnk.CommandArgument;
                sec_id_HiddenField1.Value = deger;

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM cihazKayit where Id=@id" , baglanti);
                sqlCommand.Parameters.AddWithValue("@id",deger);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    marka_popup.Value = reader["markasi"].ToString();
                    modeli_popup.Value = reader["modeli"].ToString();
                    seriNo_popup.Value = reader["seriNo"].ToString();
                    adaptörNo_popup.Value = reader["adaptörNo"].ToString();


                    bataryaNo_popup.Value = reader["bataryaSeriNo"].ToString();
                    aksesuar_popup.Value = reader["AksesuarDurumu"].ToString();

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Gonder();", true);

                }
                reader.Close();
                sqlCommand.ExecuteNonQuery();

                baglanti.Close();
            }
            catch (Exception ex)
            {
                // throw;
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
            }
            baglanti.Close();
            
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
                string searhEdilen = searchInput.Text;

                DbConnection connection = new DbConnection();
                SqlConnection baglanti = connection.Baglan();

                try
                {
                //SqlCommand com = new SqlCommand("select * From cihazKayit where Firma_Adi LIKE '%" + searhEdilen.Trim() + "%' ORDER BY Id DESC", baglanti);
                SqlCommand com = new SqlCommand("select * From cihazKayit where Firma_Adi LIKE @ara ORDER BY Id DESC", baglanti);
                com.Parameters.AddWithValue("@ara", "%" +searhEdilen+ "%");


                SqlDataReader reader;

                    reader = com.ExecuteReader();

                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    reader.Close();
                    
                }
                catch (Exception ex)
                {
                    // throw;
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
                }
            baglanti.Close();
        }
        
    }
}