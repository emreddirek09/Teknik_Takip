using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknikTakip
{
    public partial class WebForm5 : System.Web.UI.Page
    {

        private string deger;
        private string degerr;
        bool periyodik_bakimm;
        string durumu ="True";

        protected void Page_Load(object sender, EventArgs e)
        {
            listele();
        }


        public string IkonAl(object boolDeger)
        {
            if (Convert.ToInt32(boolDeger) == 1)
            {
                return "fa fa-check";
            }
            return "fa fa-times";
        }
        protected void listele()
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            //   durumu = Session["gösterim_durumu"].ToString();

               SqlCommand com = new SqlCommand("Select ak.Id, ak.kayitEden_id, ak.bakim_kontrol,ak.arıza_nedeni,ak.aciklamalar,ak.verilis_tarihi,ak.tahmini_teslim_tarihi,ck.firma_adi,ck.markasi,ck.modeli,ck.seriNo " +
                   "from cihazKayit as ck " +
                   " inner join  arizaKayit as ak On ck.Id=ak.cihaz_id  " +
                   " Where durum=@durumu " + " ORDER BY Id DESC ", baglanti);
            com.Parameters.AddWithValue("@durumu",durumu);

        
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

            SqlCommand com = new SqlCommand("DELETE FROM arizaKayit WHERE Id=@id" , baglanti);
            com.Parameters.AddWithValue("@id",deger);
            com.ExecuteNonQuery();
            listele();
            baglanti.Close();
        }


        
        protected void btn_modal_Click1(object sender, EventArgs e)
        {
            LinkButton linkk = (LinkButton)sender;
            degerr = linkk.CommandArgument;
            hiddenfield.Value = degerr;

            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();

            SqlCommand com2 = new SqlCommand("Select * from arizaKayit where Id=@id", baglanti);

            com2.Parameters.AddWithValue("@id", degerr);
            SqlDataReader sqlDataReader = com2.ExecuteReader();
            sqlDataReader.Read();

            periyodik_bakimm = Convert.ToBoolean(sqlDataReader["bakim_kontrol"].ToString()); // bool değer olarak periyodik_bakimm geldi

            string periyodik_bakim_str = periyodik_bakimm.ToString(); // string çevir

            periyodik_bakım_HiddenField1.Value = periyodik_bakim_str;

            
            ariza_nedeni_HiddenField1.Value = sqlDataReader["arıza_nedeni"].ToString();
            Session["cihaz_kayit_tarihi"] = sqlDataReader["verilis_tarihi"].ToString();
            gösterim_durumu_HiddenField1.Value = sqlDataReader["durum"].ToString();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Gonder();", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "Gonder();", true);
            sqlDataReader.Close();
            baglanti.Close();
        }
        protected void PopUpTeslim_Click(object sender, EventArgs e)
        {
            kayit();
            listele();
            ücret_popup.Value = "";
            degisiklikler_popup.Value = "";
            yapilan_is_popup.Value = "";

           
        }
        protected void kayit()
        {
            
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();

                try
                {
                    SqlCommand com = new SqlCommand("insert into islemKayit(arizaKayit_id,teslim_eden_id,yapilan_is,degisiklikler,ücret,kayit_tarihi)VALUES(@arizaKayitId,@teslimEdenId,@yapilanis,@degisikliklerr,@ücrett,@kayittarihi)", baglanti);
                    //SqlCommand sqlCommand = new SqlCommand("insert into teslimEdilenArizaliCihazlar(arizaKayit_id,teslim_eden_id,kayit_tarihi,firma_adi,cihaz_markasi,cihazin_modeli,ariza_nedeni,bakim_kontrol,cihaz_kayit_tarihi)VALUES(@arizaKayitId,@teslimEdenId,@kayittarihi,@firma_adii,@cihaz_markasii,@cihazin_modelii,@ariza_nedenii,@bakim_kontroll,@cihaz_kayit_tarihii)", baglanti);
                    if (periyodik_bakım_HiddenField1.Value == "False" )
                    {
                        com.Parameters.AddWithValue("@ücrett", ücret_popup.Value);
                    }
                    else
                    {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Periyodik Bakıma Dahil Cihazlar Ücrete Tabi Tutulamaz.Ücret Boş Atama Yapılacaktır.');</script>");
                    com.Parameters.AddWithValue("@ücrett", "");
                    }
                      if (yapilan_is_popup.Value == "" || degisiklikler_popup.Value == "")
                      {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
                       }
                      else
                      {
                        com.Parameters.AddWithValue("@degisikliklerr", degisiklikler_popup.Value);
                        com.Parameters.AddWithValue("@yapilanis", yapilan_is_popup.Value);
                        com.Parameters.AddWithValue("@arizaKayitId", hiddenfield.Value);
                        com.Parameters.AddWithValue("@teslimEdenId", Session["giris"].ToString());
                        com.Parameters.AddWithValue("@kayittarihi", System.DateTime.Now);
                        com.ExecuteNonQuery();


                    SqlCommand sqlCommand = new SqlCommand("UPDATE arizaKayit SET durum=@durumm WHERE Id=@id",baglanti);
                    sqlCommand.Parameters.AddWithValue("@durumm","False");
                    sqlCommand.Parameters.AddWithValue("@id",hiddenfield.Value);
                    sqlCommand.ExecuteNonQuery();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Teslim Etme Başarılı Bir Şekilde Gerçekleştirilmiştir.');</script>");
                    baglanti.Close();
                }                   
            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");

            }
            baglanti.Close();
        }


    }
}