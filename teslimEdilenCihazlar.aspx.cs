using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TeknikTakip
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            listele();
        }
        string searhEdilen =null;

        private string kontrol = null;

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
            if (searhEdilen==null)
            {
                DbConnection connection = new DbConnection();
                SqlConnection baglanti = connection.Baglan();
                SqlCommand com = new SqlCommand("select  müs.Firma_Adi, ck.markasi,ck.modeli,ck.seriNo,ak.bakim_kontrol,ak.arıza_nedeni,ak.aciklamalar,ik.Id,ik.teslim_eden_id,ik.kayit_tarihi,ik.degisiklikler,ik.ücret,ik.yapilan_is " +
                    "from müsteriler as müs " +
                    "inner join cihazKayit as ck  on müs.Id =ck.firma_id " +
                    "inner join arizaKayit as ak on ck.Id = ak.cihaz_id  " +
                    "inner join islemKayit as ik on ak.Id=ik.arizaKayit_id  ORDER BY Id DESC", baglanti);

                //SELECT * FROM islemKayit ORDER BY ID DESC
               
                SqlDataReader reader;

                reader = com.ExecuteReader();

                Repeater1.DataSource = reader;
                Repeater1.DataBind();
                reader.Close();
                baglanti.Close();
            }
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string searhEdilen = searchInput.Text;

            DbConnection connection = new DbConnection();
            SqlConnection baglanti = connection.Baglan();           

            //using(SqlConnection sqlConnection = new DbConnection().Baglan())
            //{
            
            //}
            
                try
                {
                    SqlCommand com = new SqlCommand("select müs.Firma_Adi, ck.markasi,ck.modeli,ck.seriNo,ak.bakim_kontrol,ak.arıza_nedeni,ak.aciklamalar,ik.Id,ik.teslim_eden_id,ik.kayit_tarihi,ik.degisiklikler,ik.ücret,ik.yapilan_is " +
              "from müsteriler as müs " +
              "inner join cihazKayit as ck  on müs.Id =ck.firma_id " +
              "inner join arizaKayit as ak on ck.Id = ak.cihaz_id  " +
              "inner join islemKayit as ik on ak.Id=ik.arizaKayit_id  where müs.Firma_Adi LIKE '%" + searhEdilen.Trim() + "%' ORDER BY Id DESC", baglanti);

                    SqlDataReader reader;

                    reader = com.ExecuteReader();

                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                    reader.Close();
                   
                }
                catch (Exception ex)
                {
                   // throw;
                    Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "BİLGİLENDİRME ", "<script>alert("+ex.Message+");</script>");
                }
            baglanti.Close();
        }


    }
    
}