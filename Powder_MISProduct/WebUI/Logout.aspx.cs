using System;
using Powder_MISProduct.Common;

namespace Powder_MISProduct.WebUI
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session[ApplicationSession.Userid] == null)
            {
                Response.Redirect("WebUI/Login.aspx", false);
            }
            if (!IsPostBack)
            {
                if (Session[ApplicationSession.Username] != null)
                {
                    Session.Abandon();
                }
                Response.Redirect("Logout.aspx", false);
            }
        }
    }
}