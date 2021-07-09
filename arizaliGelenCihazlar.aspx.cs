using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknikTakip
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        
        bool bakim_kontroll;
        string müs_adi = "";
        public int firma_id;
        private string cihazMarka;
        private string cihazModeli;
        private string cihazSeriNo;
        private string cihazAdaptörNo;
        private string cihazBataryaNo;
        private string cihazAksesuarDurumu;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {                
            MüsteriEkle();             
            }
        }

        public static void dropdownduzelt(DropDownList dropdown)
        {

            dropdown.Items.Insert(0, new ListItem(String.Empty, "0"));
            dropdown.SelectedIndex = 0;

        }
        protected void MüsteriEkle()
        {
            
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            SqlCommand com = new SqlCommand("SELECT Id, Firma_Adi FROM müsteriler", baglanti);

            SqlDataReader oku;
            oku = com.ExecuteReader();
            int i = 0;
            dropdownduzelt(DropDownList1);
            while (oku.Read())
            {
                DropDownList1.Items.Add(new ListItem(oku["Firma_Adi"].ToString(), oku["Id"].ToString()));
                i++;
            }
            baglanti.Close();

        }
        
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList2.Items.Clear();
                cihazEkle();
            }
            catch (Exception)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Boş Seçim Yapamazsınız.');</script>");
            }
            
            markasi.Text = "";
            modeli.Text = "";
            seriNo.Text = "";
            adaptörNo.Text = "";
            bataryaSeriNo.Text = "";
            aksesuarDurumu.Text = "";

        }
        protected void cihazEkle()
        {

            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            try
            {
                firma_id = Convert.ToInt32(DropDownList1.SelectedValue);
                
                SqlCommand com = new SqlCommand("Select DISTINCT  seriNo from cihazKayit where firma_id=@id", baglanti);
                com.Parameters.AddWithValue("@id", firma_id);
                SqlDataReader oku;
                oku = com.ExecuteReader();
                dropdownduzelt(DropDownList2);
                while (oku.Read())
                {
                    DropDownList2.Items.Add(oku["seriNo"].ToString());
                }
            
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Boş Seçim Yapamazsınız.');</script>");
            }
            baglanti.Close();
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();



            SqlCommand com3 = new SqlCommand("Select * from cihazKayit where seriNo = @seriNoo",baglanti);
            com3.Parameters.AddWithValue("seriNoo", DropDownList2.SelectedValue);
            SqlDataReader sqlDataReader2 = com3.ExecuteReader();
            sqlDataReader2.Read();

            Session["cihaz_id"] = sqlDataReader2["Id"].ToString();
            cihazMarka = sqlDataReader2["markasi"].ToString();
            markasi.Text = cihazMarka;
            cihazModeli = sqlDataReader2["modeli"].ToString();
            modeli.Text = cihazModeli;
            cihazSeriNo = sqlDataReader2["seriNo"].ToString();
            seriNo.Text = cihazSeriNo;
            cihazAdaptörNo = sqlDataReader2["adaptörNo"].ToString();
            adaptörNo.Text = cihazAdaptörNo;
            cihazBataryaNo = sqlDataReader2["bataryaSeriNo"].ToString();
            bataryaSeriNo.Text = cihazBataryaNo;
            cihazAksesuarDurumu = sqlDataReader2["aksesuarDurumu"].ToString();
            aksesuarDurumu.Text = cihazAksesuarDurumu;
            baglanti.Close();
        }

        protected void kayitekle()
        {
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();            
            string tahminiTeslim = Request.Form[tahmini_teslim_tarihi.UniqueID];
            try
            {
                SqlCommand com2 = new SqlCommand("Select * from müsteriler where Firma_Adi=@FirmaAdi", baglanti);
                com2.Parameters.AddWithValue("@FirmaAdi", DropDownList1.SelectedItem.Text);
                SqlDataReader sqlDataReader = com2.ExecuteReader();
                sqlDataReader.Read();
                müs_adi = sqlDataReader["Firma_Adi"].ToString();
                bakim_kontroll = Convert.ToBoolean(sqlDataReader["periyodik_bakim"].ToString());

                //TahminiTeslimTarihi = Convert.ToString((tahminiTeslim));

                SqlCommand com = new SqlCommand("insert into arizaKayit(kayitEden_id,kul_id,cihaz_id,bakim_kontrol,arıza_nedeni,aciklamalar,verilis_tarihi,tahmini_teslim_tarihi)" +
                        "VALUES(@kayitEdenid,@Kul_id,@cihaz_idd,@bakimkontrol,@arizaNedeni,@aciklamalarr,@verilisTarihi,@tahminiTeslimTarihi)", baglanti);


                if (tahminiTeslim != "")
                {
                    com.Parameters.AddWithValue("@tahminiTeslimTarihi", tahminiTeslim.ToString());
                }
                else
                {
                    com.Parameters.AddWithValue("@tahminiTeslimTarihi", SqlDbType.DateTime).Value = DBNull.Value;
                    //  tahminiTeslim = null;
                }
                com.Parameters.AddWithValue("@kayitEdenid", Session["giris"].ToString());
                com.Parameters.AddWithValue("Kul_id", Session["loggedUserID"].ToString());
                    com.Parameters.AddWithValue("@cihaz_idd", Session["cihaz_id"].ToString());
                    com.Parameters.AddWithValue("@bakimkontrol", bakim_kontroll);   
                    com.Parameters.AddWithValue("@aciklamalarr", aciklamalar.Text);
                    com.Parameters.AddWithValue("@arizaNedeni", ariza_nedeni.Value);
                    //com.Parameters.AddWithValue("@tahminiTeslimTarihi", Convert.ToDateTime(TahminiTeslimTarihi));
                    com.Parameters.AddWithValue("@verilisTarihi", System.DateTime.Now);
                    
                    com.ExecuteNonQuery();             

            }
            catch (SqlException ex)
            {
                throw;
                if (ex.Number == 2627)
                {
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
                    // Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
                }

            }
            catch (Exception ex)
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");

            }
            baglanti.Close();
        }
        protected void kayit_Click1(object sender, EventArgs e)
        {
            try
            {
                if (ariza_nedeni.Value != "" || aciklamalar.Text != "")
                {
                    kayitekle();
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Kayıt Başarılı Teslim Almadan Kontrol Edebilirsiniz.');</script>");
                    ariza_nedeni.Value = "";
                    aciklamalar.Text = "";
                    tahmini_teslim_tarihi.Text = "";
                    markasi.Text = "";
                    modeli.Text = "";
                    seriNo.Text = "";
                    adaptörNo.Text = "";
                    bataryaSeriNo.Text = "";
                    aksesuarDurumu.Text = "";
                    DropDownList1.SelectedValue = null;
                    DropDownList2.SelectedValue = null;
                }
            }
            catch
            {
                //throw;
               Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
            }


        }
    }
}