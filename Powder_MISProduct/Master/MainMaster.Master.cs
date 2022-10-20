using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Powder_MISProduct.BL;
using Powder_MISProduct.Common;
using System.Web.UI.HtmlControls;


namespace Powder_MISProduct.Master
{
    public partial class MainMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            if (Session[ApplicationSession.Userid] != null)
            {
                lblUserName.Text = Session[ApplicationSession.Username].ToString();
                #region Manage Role Rights

                string sPath = Page.Page.AppRelativeVirtualPath;
                string sRet = sPath.Substring(sPath.LastIndexOf('/') + 1);

                RoleRightsBl objRoleRightsBL = new RoleRightsBl();
                ApplicationResult objResults = new ApplicationResult();

                int flagMaster = 0;
                int flagReport = 0;
                int flagUser = 0;
                int flag = 0;

                objResults = objRoleRightsBL.RoleRights_SelectAll_ForAuthorization(Convert.ToInt32(Session[ApplicationSession.Roleid].ToString()));
                if (objResults != null)
                {
                    for (int i = 0; i < objResults.ResultDt.Rows.Count; i++)
                    {
                        #region Menu Hide
                        Control MyList = FindControl("cssmenu");
                        foreach (Control MyControl in MyList.Controls)
                        {
                            if (MyControl is HtmlGenericControl)
                            {
                                HtmlGenericControl li = MyControl as HtmlGenericControl;

                                if (li.ID == objResults.ResultDt.Rows[i]["DisplayName"].ToString())
                                {
                                    li.Visible = true;
                                    break;
                                }
                            }
                        }
                        if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Shift")
                            flagMaster = 1;
                        if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "MilkAnalysis")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "EvapPlantStatus")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "PackingMachine")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Route")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Silo")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Recipe")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "DryerPlantStatus")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "DryerTag")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Evaporator2Tag")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Evaporator1Tag")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Role")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Employee")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "RoleRights")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "DesiccantTag1")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "DesiccantTag2")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "CompressedAirTag")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "MassBalanceFactor")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "BreakDownMaintainance")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "RoutineMaintainance")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "EquipmentMaster")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "DeviceMaster")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "PackingEntry")
                            flagMaster = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "SKUMaster")
                            flagMaster = 1;

                        if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "WheyAnalysisReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Transfer")
                            flagReport = 1;                    
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "RWSTStorage")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "PastwheyStorage")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "NFWheyStorage")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "ROPermeateStatus")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "CreamBufferTankStatus")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "CreamTankStatus")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "WPLLog")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "CPLLog")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "UtilityConsumption")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "TankerDispatch")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "CIP")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "ChemicalConsumption")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "InventoryReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "MaintenanceReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "LabReport")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "EvaporatorLog")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "DryerDataLog")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "ConcFeedTankStatus")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "CrystallizationTankStatus")
                            flagReport = 1;
                        else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "Lab")
                            flagReport = 1;
                       
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "EvaporatorLogReport")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "EvaporatorLogReport2")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "PackingMachineLog")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "CompressedAirLog")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "InventoryReport")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "RO_Logsheet")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "MassBalanceReport")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "DailyActivityReport")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "BreakdownReport")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "RoutineReport")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "PowderProcessingCostReport")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "ROCIP")
                        //    flagReport = 1;
                        //else if (objResults.ResultDt.Rows[i]["DisplayName"].ToString() == "UtilityGeneration1")
                        //    flagReport = 1;


                        #endregion
                    }
                    if (sRet != "NotAuthorized.aspx")
                    {
                        for (int j = 0; j < objResults.ResultDt.Rows.Count; j++)
                        {
                            #region Not Authorized

                            if (sRet == "Home.aspx")
                            {
                                flag = 0;
                                break;
                            }
                            if (sRet == "WebUI/AboutSoftware.aspx")
                            {
                                flag = 0;
                                break;
                            }
                            if (objResults.ResultDt.Rows[j]["ScreenName"].ToString() == sRet)
                            {
                                flag = 0;
                                break;
                            }
                            flag = 1;
                            #endregion
                        }
                    }
                    //if (flagMaster == 1)
                    //{
                    //    liMaster.Visible = true;
                    //}
                    //else
                    //{
                    //    liMaster.Visible = false;
                    //}
                    //if (flagReport == 1)
                    //{
                    //    liReport.Visible = true;
                    //}
                    //else
                    //{
                    //    liReport.Visible = false;
                    //}
                    if (flag == 1)
                    {
                        Response.Redirect("../WebUI/NotAuthorized.aspx", false);
                    }
                }
                #endregion
            }
            else
            {
                Response.Redirect("../Login.aspx", false);
            }
        }

    }
}