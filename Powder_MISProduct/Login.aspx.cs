using System;
using System.Web.UI;
using Powder_MISProduct.BL;
using Powder_MISProduct.BO;
using Powder_MISProduct.Common;
//using AMULFED.ReportUI;
//using log4net;

namespace Powder_MISProduct
{
    public partial class Login : System.Web.UI.Page
    {
      //  private static ILog log = LogManager.GetLogger(typeof(Login));

        #region Page Load Event
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                lblMsg.Visible = false;
                if (Session[ApplicationSession.Userid] != null)
                {
                    //Response.Redirect("WebUI/Home.aspx", false);
                    //Changed by Farheen, since there is no Home.aspx page therefore user must 
                    //get redirect to the home page i.e. Dashboard.aspx 
                    Response.Redirect("WebUI/Dashboard.aspx", false);
                }
            }
            catch (Exception ex)
            {
               // log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        #region Button btnLogin OnClick Event
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            try
            {
                EmployeeBl objEmployeeBl = new EmployeeBl();
                ApplicationResult objResult = new ApplicationResult();
                objResult = objEmployeeBl.Employee_Select_ForLogin(txtUserName.Text.Trim(), txtPassword.Text.Trim());
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    Session[ApplicationSession.Userid] = objResult.ResultDt.Rows[0][EmployeeBo.EMPLOYEE_ID];
                    Session[ApplicationSession.Username] = txtUserName.Text.Trim();
                    Session[ApplicationSession.Roleid] = objResult.ResultDt.Rows[0][EmployeeBo.EMPLOYEE_ROLEID];
                    Session[ApplicationSession.OrganisationName] = "Britannia DAIRY";
                    Session[ApplicationSession.OrganisationAddress] = "Britannia Industries Ltd. Survey No 504,514-519,522,523,524,525, Post - Dhoksangvi,Taluk - Shirur. Adjacent to Ranjangaon Five Star MIDC";
                    Session[ApplicationSession.Logo] = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/logo.gif";
                    Response.Redirect("WebUI/DashBoard.aspx", false);
                }
                else
                {
                    lblMsg.Text = "Invalid Username or Password";
                    lblMsg.Visible = true;
                }
            }
            catch (Exception ex)
            {
              //  log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion
    }
}