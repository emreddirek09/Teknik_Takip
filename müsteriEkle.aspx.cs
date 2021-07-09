using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknikTakip
{

    //MasaÜstüTeknikTakip
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listele();
            }

        }
        int bakim;
        private string deger;
        private int bakimm;
        private int TelefonKontrol ;
        private void IletisimFormati(string telefon)
        {
            try
            {
                string s = telefon;
                if (s.Length == 10)
                {
                    double sAsD = double.Parse(s);
                    iletisim.Value = string.Format("{0:###-###-####}", sAsD).ToString();
                    telefon_popup.Value = string.Format("{0:###-###-####}", sAsD).ToString();
                    TelefonKontrol = 1;
                }
            }
            catch (System.FormatException ex)
            {

                TelefonKontrol = 0;
            }
        }


        protected void ekle()
        {
            string baslangic = Request.Form[baslangic_tarihi.UniqueID];
            string bitis = Request.Form[bitis_tarihi.UniqueID];
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            if (periyodik_bakim_CheckBox1.Checked==true)
            {
                bakim = 1;
            }
            else
            {
                bakim = 0;
            }
                try
                {
                    if (Firma_Adi.Value != "" || Yetkili_Kisi.Value != "" || emailaddress.Value != "" || iletisim.Value != "")
                    {
                    if (iletisim.Value.Length == 10)
                    {
                        IletisimFormati(iletisim.Value);

                        if (TelefonKontrol==1)
                        {
                            SqlCommand com = new SqlCommand("insert into müsteriler(Firma_Adi,Yetkili_Kisi,mail,iletisim,periyodik_bakim,bakim_baslangic,bakim_bitis,kayit_tarihi)VALUES(@Firma_Adi,@Yetkili_Kisi,@E_posta,@iletisim,@periyodikbakim,@bakimbaslangic,@bakimbitis,@kayittarihi)", baglanti);



                            if (periyodik_bakim_CheckBox1.Checked == true)
                            {
                                if (baslangic == "" && bitis == "")
                                {
                                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Periyodik Bakıma Dahil Ürünlerde Tarihi Girişi Zorunludur');</script>");
                                }
                                else
                                {

                                    com.Parameters.AddWithValue("@bakimbaslangic", Convert.ToDateTime(baslangic).ToString());
                                    com.Parameters.AddWithValue("@bakimbitis", Convert.ToDateTime(bitis).ToString());
                                }
                            }
                            else
                            {
                                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Periyodik Bakıma Dahil Ürünlerde Tarihi Girişi Yapılamaz');</script>");
                                com.Parameters.AddWithValue("@bakimbaslangic", SqlDbType.DateTime).Value = DBNull.Value;
                                com.Parameters.AddWithValue("@bakimbitis", SqlDbType.DateTime).Value = DBNull.Value;
                            }
                            com.Parameters.AddWithValue("@Firma_Adi", Firma_Adi.Value);
                            com.Parameters.AddWithValue("@Yetkili_Kisi", Yetkili_Kisi.Value);
                            com.Parameters.AddWithValue("@periyodikbakim", bakim);
                            com.Parameters.AddWithValue("@E_posta", emailaddress.Value);
                            com.Parameters.AddWithValue("@iletisim", iletisim.Value);
                            com.Parameters.AddWithValue("@kayittarihi", System.DateTime.Now);

                            com.ExecuteNonQuery();
                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Lütfen Sayısal Değer Girip Telefon Numaranızı Kontrol Ediniz. ');</script>");
                        }
                        
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('10 Haneli Telefon Boyutunu Giriniz ');</script>");
                    }   
                    }
                    else
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
                    }
                }
                catch (SqlException ex)
                {

                   // throw;
                    if (ex.Number == 2627)
                    {
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Aynı Firma Adını Kullanamazsınız..');</script>");
                   
                    }
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
                }
                

            baglanti.Close();
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Firma_Adi.Value == "" || Yetkili_Kisi.Value == "" || iletisim.Value == "" || emailaddress.Value == "")
            {

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('LÜTFEN BOŞ ALANLARI DOLDURUNUZ');</script>");
            }
            else
            {

                ekle();
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Kayit İşlemi Başarılı');</script>");
                listele();
                Firma_Adi.Value = "";
                Yetkili_Kisi.Value = "";
                iletisim.Value = "";
                emailaddress.Value = "";
                periyodik_bakim_CheckBox1.Checked = false;
                baslangic_tarihi.Text = "";
                bitis_tarihi.Text = ""; 
            }

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

            SqlCommand com = new SqlCommand("SELECT Id,Firma_Adi,Yetkili_Kisi,mail,iletisim,bakim_baslangic,bakim_bitis,kayit_tarihi , REPLACE(periyodik_bakim,'True','✔') AS periyodik_bakim , REPLACE(periyodik_bakim,'False','X') AS periyodik_bakim FROM müsteriler ORDER BY ID DESC", baglanti);

           
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

                SqlCommand com = new SqlCommand("DELETE FROM müsteriler WHERE ID=@id", baglanti);
                com.Parameters.AddWithValue("@id",deger);
                com.ExecuteNonQuery();
                listele();
               
            }
            catch (Exception)
            {

                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert(' Müşteri İle Bağlantılı Cihaz Kaydı Bulunmaktadır. Silme Başarısız.');</script>");
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

                SqlCommand sqlCommand = new SqlCommand("SELECT Firma_Adi,Yetkili_Kisi,mail,periyodik_bakim,bakim_baslangic,bakim_bitis , REPLACE (iletisim,'-','') AS iletisim FROM müsteriler where Id=@id", baglanti);
                sqlCommand.Parameters.AddWithValue("@id", deger);

                SqlDataReader reader = sqlCommand.ExecuteReader();

                if (reader.Read())
                {
                    firma_Adi_popup.Value = reader["Firma_Adi"].ToString();
                    yetkili_kisi_popup.Value = reader["Yetkili_Kisi"].ToString();
                    email1_popup.Value = reader["mail"].ToString();
                    telefon_popup.Value = reader["iletisim"].ToString();
                    if (reader["periyodik_bakim"].ToString() == "True")
                    {
                        periyodik_Bakim_CheckBox1_popup.Checked = true;
                    }
                    else
                    {
                        periyodik_Bakim_CheckBox1_popup.Checked = false;
                    }
                    baslangic_tarihi_popup.Text = reader["bakim_baslangic"].ToString();
                    bitis_tarihi_popup.Text = reader["bakim_bitis"].ToString();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "güncelle_popup();", true);
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

        protected void PopUpGüncelle_Click1(object sender, EventArgs e)
        {

            string baslangicc = Request.Form[baslangic_tarihi_popup.UniqueID];
            string bitiss = Request.Form[bitis_tarihi_popup.UniqueID];
            
            
            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();
            SqlCommand comm;
            if (periyodik_Bakim_CheckBox1_popup.Checked == true)
            {
                bakimm = 1;
            }
            else
            {
                bakimm = 0;
            }
            try
                {

                    if (firma_Adi_popup.Value != "" || yetkili_kisi_popup.Value != "" || email1_popup.Value != "" || telefon_popup.Value != "")
                    {
                        if (telefon_popup.Value.Length == 10)
                        {
                        IletisimFormati(telefon_popup.Value);
                            if (TelefonKontrol == 1)
                            {
                            comm = new SqlCommand("UPDATE müsteriler SET Firma_Adi=@FirmaAdi,Yetkili_Kisi=@YetkiliKisi, mail=@maill,iletisim=@iletisimm , periyodik_bakim=@periyodikbakim,bakim_baslangic=@bakimbaslangic, bakim_bitis=@bakimbitis,kayit_tarihi=@kayittarihi  WHERE ID=@id", baglanti);

                            if (periyodik_Bakim_CheckBox1_popup.Checked == true)
                            {
                                if (baslangicc == "" && bitiss == "")
                                {
                                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Periyodik Bakıma Dahil Ürünlerde Tarih Girişi Zorunludur');</script>");
                                }
                                else
                                {

                                    comm.Parameters.AddWithValue("@bakimbaslangic", baslangicc.ToString().ToString());
                                    comm.Parameters.AddWithValue("@bakimbitis", bitiss.ToString().ToString());
                                }
                            }
                            else
                            {
                                comm.Parameters.AddWithValue("@bakimbaslangic", SqlDbType.DateTime).Value = DBNull.Value;
                                comm.Parameters.AddWithValue("@bakimbitis", SqlDbType.DateTime).Value = DBNull.Value;
                            }

                            comm.Parameters.AddWithValue("@FirmaAdi", firma_Adi_popup.Value);
                            comm.Parameters.AddWithValue("@YetkiliKisi", yetkili_kisi_popup.Value);
                            comm.Parameters.AddWithValue("@maill", email1_popup.Value);
                            comm.Parameters.AddWithValue("@iletisimm", telefon_popup.Value);
                            comm.Parameters.AddWithValue("@periyodikbakim", bakimm);

                            comm.Parameters.AddWithValue("@kayittarihi", System.DateTime.Now);
                            comm.Parameters.AddWithValue("@id", sec_id_HiddenField1.Value);

                            firma_Adi_popup.Value = "";
                            yetkili_kisi_popup.Value = "";
                            telefon_popup.Value = "";
                            email1_popup.Value = "";
                            periyodik_Bakim_CheckBox1_popup.Checked = false;
                            baslangic_tarihi_popup.Text = "";
                            baslangic_tarihi_popup.Text = "";
                            iletisim.Value = "";
                            comm.ExecuteNonQuery();
                            listele();
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Güncelleme İşlemi Başarılı');</script>");

                        }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Lütfen Sayısal Değer Girip Telefon Numaranızı Kontrol Ediniz. ');</script>");
                        }

                    }
                        else
                        {
                            Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Telefon Boyutu Max: 10');</script>");
                        }
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
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('Aynı Firma Adını Kullanamazsınız..');</script>");
                }
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert('" + ex.Message + "');</script>");
                 }
            baglanti.Close();
            

        }
    }
}