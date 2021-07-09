using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknikTakip
{
    public partial class WebForm13 : System.Web.UI.Page
    {
       
        private string stokAdi;
        private string birimi;
        private string stokTipAdi;
        private string stok_kodu;
        private string stok_id;
        private string deger;
        private string degerr;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Ürün_Bilgisi_EKle();
                listele();
            }
        }
        protected void Ürün_Bilgisi_EKle()
        {

            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            SqlCommand com = new SqlCommand("SELECT Id, Stok_Kodu FROM Stok_Bilgileri", baglanti);

            SqlDataReader oku;
            oku = com.ExecuteReader();
            int i = 0;
            while (oku.Read())
            {
                DropDownList1.Items.Add(new ListItem(oku["Stok_Kodu"].ToString(), oku["Id"].ToString()));
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
                SqlCommand com = new SqlCommand("insert into Alt_Stok_Bilgileri(ürün_id,cinsi,tür,renk,fiyat,alim_yeri,adet,kayit_tarihi)" +
                        "VALUES(@ürün_idd,@cinsii,@türr,@renkk,@fiyatt,@alim_yerii,@adett,@kayit_tarihii)", baglanti);

                com.Parameters.AddWithValue("@ürün_idd", Session["Stok_id"].ToString());
                com.Parameters.AddWithValue("@cinsii",cinsi.Text);
                com.Parameters.AddWithValue("@türr", tür.Text);
                com.Parameters.AddWithValue("@renkk", renk.Text);
                com.Parameters.AddWithValue("@fiyatt", fiyat.Value);
                com.Parameters.AddWithValue("@alim_yerii", alim_yeri.Text);
                com.Parameters.AddWithValue("@adett", adet.Text);
                com.Parameters.AddWithValue("@kayit_tarihii", System.DateTime.Now);
                com.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw;
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
            baglanti.Close();
        }

        protected void kayit_Click(object sender, EventArgs e)
        {
            kayitekle();
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Kayıt Başarılı ');</script>");
            cinsi.Text = "";
            tür.Text = "";
            renk.Text = "";
            fiyat.Value = "";
            alim_yeri.Text = "";
            adet.Text = "";
            stok_adi.Text = "";
            birim.Text = "";
            stok_tip_adi.Text = "";
            DropDownList1.SelectedValue = "";
            listele();
        }

        protected void DropDownList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            SqlCommand com3 = new SqlCommand("Select * from Stok_Bilgileri where Stok_Kodu = @Stok_Koduu", baglanti);
            com3.Parameters.AddWithValue("@Stok_Koduu", DropDownList1.SelectedItem.Text);
            SqlDataReader sqlDataReader2 = com3.ExecuteReader();
            sqlDataReader2.Read();

            Session["Stok_id"] = sqlDataReader2["Id"].ToString();
            stokAdi = sqlDataReader2["Stok_Adi"].ToString();
            stok_adi.Text = stokAdi;
            birimi = sqlDataReader2["Birim"].ToString();
            birim.Text = birimi;
            stokTipAdi = sqlDataReader2["Stok_Tip_Adi"].ToString();
            stok_tip_adi.Text = stokTipAdi;

        }
        protected void listele()
        {
            DbConnection connection = new DbConnection();

            SqlConnection baglanti = connection.Baglan();

            SqlCommand com = new SqlCommand("select ASB.Id, sb.Stok_Kodu,sb.Stok_Adi,sb.Birim,sb.Stok_Tip_Adi,ASB.cinsi,ASB.tür,ASB.renk,ASB.adet,ASB.fiyat,ASB.alim_yeri, ASB.kayit_tarihi,ASB.güncelleme_tarihi from Stok_Bilgileri as SB inner join Alt_Stok_Bilgileri as ASB On SB.Id = ASB.ürün_id ORDER BY ID DESC", baglanti);


            SqlDataReader reader;

            reader = com.ExecuteReader();

            Repeater1.DataSource = reader;
            Repeater1.DataBind();
            reader.Close();
            baglanti.Close();

        }

        protected void sec_Click(object sender, EventArgs e)
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            LinkButton lnk = (LinkButton)sender;
            deger = lnk.CommandArgument;

            sec_id_HiddenField1.Value = deger;


            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM Alt_Stok_Bilgileri where Id=" + deger, baglanti);

            SqlDataReader reader = sqlCommand.ExecuteReader();

            if (reader.Read())
            {
                cinsi.Text = reader["cinsi"].ToString();
                tür.Text = reader["tür"].ToString();
                renk.Text = reader["renk"].ToString();
                fiyat.Value = reader["fiyat"].ToString();
                alim_yeri.Text = reader["alim_yeri"].ToString();
                adet.Text = reader["adet"].ToString();
            }

            reader.Close();
            sqlCommand.ExecuteNonQuery();

            baglanti.Close();
        }


        protected void stok_cikar_PopUp_Click(object sender, EventArgs e)
        {
            int ilk_stok = Convert.ToInt32(önceki_ürün_adet_HiddenField1.Value);
            int cikan_stok = Convert.ToInt32(kac_adet_popup.Value);
            if (ilk_stok < cikan_stok)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert(' Elinizde Yeteri Kadar Stok Yok.');</script>");
            }
            else
            {
                int güncel_stok = ilk_stok - cikan_stok;

                DbConnection connection = new DbConnection();
                SqlConnection baglanti = connection.Baglan();
                SqlCommand comm = new SqlCommand("UPDATE Alt_Stok_Bilgileri SET adet=@ürün_adett WHERE Id=@id", baglanti);


                comm.Parameters.AddWithValue("@ürün_adett", güncel_stok);

                comm.Parameters.AddWithValue("@id", stok_id_hiddenfield.Value);

                comm.ExecuteNonQuery();
                popup_kayit();
                listele();
            }
        }
        protected void popup_kayit()
        {

            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            try
            {
                SqlCommand com = new SqlCommand("insert into stokDüs(stok_düsen_kul,ürün_adi,cinsi,tür,renk,kime_verildi,kullanildigi_yer,kac_adet,kayit_tarihi)VALUES(@stok_düsen_kull,@ürün_adii,@cinsii,@türr,@renkk,@kime_verildii,@kullanildigi_yerr,@kac_adett,@kayit_tarihii)", baglanti);

                com.Parameters.AddWithValue("@stok_düsen_kull", Session["giris"].ToString());
                com.Parameters.AddWithValue("@ürün_adii", ürün_adi_hiddenfield1.Value);

                com.Parameters.AddWithValue("@cinsii", cinsi_HiddenField1.Value);
                com.Parameters.AddWithValue("@türr", tür_adet_HiddenField1.Value);
                com.Parameters.AddWithValue("@renkk", renk_HiddenField1.Value);


                com.Parameters.AddWithValue("@kime_verildii", kime_verildi_popup.Value);
                com.Parameters.AddWithValue("@kullanildigi_yerr", kullanildigi_yer_popup.Value);
                com.Parameters.AddWithValue("@kac_adett", kac_adet_popup.Value);
                com.Parameters.AddWithValue("@kayit_tarihii", System.DateTime.Now);

                com.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                // throw;
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

            baglanti.Close();
        }


        protected void sil_Click(object sender, EventArgs e)
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();

            LinkButton link = (LinkButton)sender;
            deger = link.CommandArgument;

            SqlCommand com = new SqlCommand("DELETE FROM Alt_Stok_Bilgileri WHERE Id=" + deger, baglanti);
            com.ExecuteNonQuery();
            listele();
            baglanti.Close();

        }

        protected void stok_cikar_Click1(object sender, EventArgs e)
        {
            LinkButton linkk = (LinkButton)sender;
            degerr = linkk.CommandArgument;
            stok_id_hiddenfield.Value = degerr;

            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();

            SqlCommand com2 = new SqlCommand("select ASB.Id, sb.Stok_Kodu,sb.Stok_Adi,sb.Birim,sb.Stok_Tip_Adi,ASB.cinsi,ASB.tür,ASB.renk,ASB.adet,ASB.fiyat,ASB.alim_yeri from Stok_Bilgileri as SB inner join Alt_Stok_Bilgileri as ASB On SB.Id = ASB.ürün_id where ASB.Id=@id", baglanti);

            com2.Parameters.AddWithValue("@id", degerr);
            SqlDataReader sqlDataReader = com2.ExecuteReader();
            sqlDataReader.Read();


            ürün_adi_hiddenfield1.Value = sqlDataReader["Stok_Adi"].ToString();
            önceki_ürün_adet_HiddenField1.Value = sqlDataReader["adet"].ToString();
            cinsi_HiddenField1.Value = sqlDataReader["cinsi"].ToString();
            tür_adet_HiddenField1.Value = sqlDataReader["tür"].ToString();
            renk_HiddenField1.Value = sqlDataReader["renk"].ToString();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Gonder();", true);


        }

        protected void Güncelle_Click1(object sender, EventArgs e)
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            SqlCommand comm;
            try
            {
                int ürün_adett = Convert.ToInt32(adet.Text);

                if (ürün_adett < 0 || ürün_adett > 9999)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Stok Miktarı 0-9999 arasında olmalıdır. ');</script>");
                }
                else
                {
                    comm = new SqlCommand("UPDATE Alt_Stok_Bilgileri SET cinsi=@cinsii,tür=@türr,renk=@renkk,fiyat=@fiyatt,alim_yeri=@alim_yerii,adet=@adett,güncelleme_tarihi=@güncelle_tarihii WHERE Id=@id", baglanti);

                    comm.Parameters.AddWithValue("@cinsii", cinsi.Text);
                    comm.Parameters.AddWithValue("@türr", tür.Text);
                    comm.Parameters.AddWithValue("@renkk", renk.Text);
                    comm.Parameters.AddWithValue("@fiyatt", fiyat.Value);
                    comm.Parameters.AddWithValue("@alim_yerii", alim_yeri.Text);
                    comm.Parameters.AddWithValue("@adett", adet.Text);
                    comm.Parameters.AddWithValue("@güncelle_tarihii", System.DateTime.Now);

                    comm.Parameters.AddWithValue("@id", sec_id_HiddenField1.Value);
                    if (cinsi.Text == "" || tür.Text == "" || renk.Text == "" || fiyat.Value == "" || alim_yeri.Text == "")
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");

                    }
                    else
                    {
                       
                        cinsi.Text = "";
                        tür.Text = "";
                        renk.Text = "";
                        fiyat.Value = "";
                        alim_yeri.Text = "";
                        adet.Text = "";
                         comm.ExecuteNonQuery();
                        listele();
                    }
                }
            }
            catch
            {
                throw;
            }
            //catch (Exception)
            //{
            //    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert(' Güncellemeden Önce Seçiminizi Yapınız.');</script>");
            //}

            baglanti.Close();

        }
    }
}