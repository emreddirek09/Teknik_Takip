using System;

namespace TeknikTakip
{
    public partial class _default : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string girisyapan = kullanici_Label.Text;
            try
            {
                kullanici_Label.Text = Session["giris"].ToString();
                if (Session["kul_id"].ToString() == "1")
                {

                }
                else
                {
                    Response.Redirect("login.aspx");
                }

            }
            catch (Exception)
            {

                Response.Redirect("login.aspx");
            }
        }
    }
}