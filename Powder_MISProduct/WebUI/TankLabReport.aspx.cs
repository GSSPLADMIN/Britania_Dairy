using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Powder_MISProduct.BL;
using Powder_MISProduct.BO;
using Powder_MISProduct.Common;


namespace Powder_MISProduct.WebUI
{
    public partial class TankLabReport : System.Web.UI.Page
    {
        //private static ILog log = LogManager.GetLogger(typeof(TankLabReport));

        #region Page load event

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack) return;
                if (Session[ApplicationSession.Userid] != null)
                {
                    ViewState["Mode"] = "Save";
                    BindTankReport();
                    PanelVisibilityMode(true, false);
                    //ViewState["Id"] = 0;
                }
                else
                {
                    Response.Redirect("../Default.aspx?SessionMode=Logout", false);
                }
            }
            catch (Exception ex)
            {
                //log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion  

        #region BindTankReport
        public void BindTankReport()
        {
            try
            {
                TankLabReportBL TankLabReportBL = new TankLabReportBL();
                var objResult = TankLabReportBL.TankerLabReportSelect();
                if (objResult != null)
                {
                    gvTankReport.DataSource = objResult.ResultDt;
                    gvTankReport.DataBind();
                    PanelVisibilityMode(true, false);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region AddNew Button
        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                txtDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txttime.Text = DateTime.UtcNow.AddHours(5.5).ToString("HH:mm:ss", CultureInfo.InvariantCulture);
                txtSampleDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                PanelVisibilityMode(false, true);
                //divIsResignDate.Visible = false;
            }
            catch (Exception ex)
            {
                //log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }
        #endregion

        #region SaveBtn
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                TankLabReportBO objTankLabReportBO = new TankLabReportBO();
                TankLabReportBL TankLabReportBL = new TankLabReportBL();

                objTankLabReportBO.DateTime = DateTime.ParseExact(txtDate.Text.Trim() + " " + txttime.Text.Trim(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString(); ;
                //objTankLabReportBO.Time = txttime.Text.Trim();
                //objTankLabReportBO.SampleDate = txtSampleDate.Text.Trim() + " " + txtSampleTime.Text.Trim();
                //objTankLabReportBO.SampleTime = txtSampleTime.Text.Trim();
                objTankLabReportBO.SampleTime = DateTime.ParseExact(txtSampleDate.Text.Trim() + " " + txtSampleTime.Text.Trim(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString(); ;
                objTankLabReportBO.SampleID = txtSampleID.Text.Trim();
                objTankLabReportBO.SiloTagNo = DropDownListTankName.SelectedValue.ToString();

                objTankLabReportBO.TankName = txtTankName.Text;

                objTankLabReportBO.Temp = txtTemp.Text.Trim();
                objTankLabReportBO.FAT = txtFAT.Text.Trim();
                objTankLabReportBO.SNF = txtSNF.Text.Trim();
                objTankLabReportBO.Acidity = txtAcidity.Text.Trim();
                objTankLabReportBO.TS = txtTS.Text.Trim();
                objTankLabReportBO.pH = txtpH.Text.Trim();
                objTankLabReportBO.Acidity = txtAcidity.Text.Trim();
                objTankLabReportBO.Protein = txtProtein.Text.Trim();
                objTankLabReportBO.tankStatus = ddTank_Status.SelectedValue.ToString();
                objTankLabReportBO.TDS = txtTDS.Text;
                objTankLabReportBO.Remarks = txtRemarks.Text;

                if (ViewState["Mode"].ToString() == "Save")
                {
                    objTankLabReportBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objTankLabReportBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                    objTankLabReportBO.IsDeleted = 0;
                    var objResult = TankLabReportBL.TankerLabReportInsert(objTankLabReportBO);
                    if (objResult != null)
                    {
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record Saved Successfully!');</script>");
                            ClearAll();
                            BindTankReport();
                            PanelVisibilityMode(true, false);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Issue in insertion!');</script>");
                        }

                    }
                }
                else if (ViewState["Mode"].ToString() == "Edit")
                {
                    objTankLabReportBO.Id = Convert.ToInt32(ViewState["Id"].ToString());
                    objTankLabReportBO.IsDeleted = '0';
                    objTankLabReportBO.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                    objTankLabReportBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                    var objResult = TankLabReportBL.TankerLabReportUpdate(objTankLabReportBO);

                    if (objResult != null)
                    {
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record Updated Successfully!');</script>");
                            ClearAll();
                            BindTankReport();
                            PanelVisibilityMode(true, false);
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Issue while updating this record!');</script>");
                        }
                    }
                }

            }
            catch (Exception ex)
            {

                //log.Error("Error", ex);
                //ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                string message = string.Format("Message: {0}\\n\\n", ex.Message);
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + message + "\");", true);
            }
        }
        #endregion 

        #region ViewList
        protected void btnViewList_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                PanelVisibilityMode(true, false);
                BindTankReport();
            }
            catch (Exception ex)
            {
                //log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

        //#region RowCommand Event for Edit and Delete
        //protected void gvTankReport_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        TankLabReportBL TankLabReportBL = new TankLabReportBL();
        //        if (e.CommandName.ToString() == "Edit1")
        //        {
        //            ViewState["Mode"] = "Edit";
        //            ViewState["Id"] = e.CommandArgument.ToString();
        //            var objResult = TankLabReportBL.TankerLabReportSelect(Convert.ToInt32(e.CommandArgument.ToString()));
        //            if (objResult != null)
        //            {
        //                if (objResult.ResultDt.Rows.Count > 0)
        //                {
        //                    var Date = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_DateTime].ToString().Split(' ');

        //                    //var Date = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_Date].ToString().Split(' ');
        //                    var SampleDate = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_SampleTime].ToString().Split(' ');
        //                    txtDate.Text = Date[0];
        //                    txttime.Text = Date[1];
        //                    txtSampleDate.Text = SampleDate[0];
        //                    txtSampleTime.Text = SampleDate[1];

        //                    txtSampleID.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_SampleID].ToString();
        //                    DropDownListTankName.SelectedValue = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_SiloTagNo].ToString();
        //                    txtTankName.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_TankName].ToString();
        //                    txtTemp.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_Temp].ToString();
        //                    txtSNF.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_SNF].ToString();
        //                    txtFAT.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_Fat].ToString();
        //                    txtTS.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_TS].ToString();
        //                    txtpH.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_pH].ToString();
        //                    txtAcidity.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_Acidity].ToString();
        //                    txtProtein.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_Protein].ToString();
        //                    ddTank_Status.SelectedValue= objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_TankStatus].ToString();
        //                    txtTDS.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_TDS].ToString();
        //                    txtRemarks.Text = objResult.ResultDt.Rows[0][TankLabReportBO.TankLab_Remarks].ToString();

        //                    //BindMaintenance();
        //                    PanelVisibilityMode(false, true);
        //                }
        //            }
        //        }
        //        else if (e.CommandName.ToString() == "Delete1")
        //        {
        //            var objResult = TankLabReportBL.TankerLabReportDelete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid]), DateTime.UtcNow.AddHours(5.5).ToString());
        //            if (objResult.Status == ApplicationResult.CommonStatusType.Success)
        //            {
        //                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully!');</script>");
        //                PanelVisibilityMode(true, false);
        //                BindTankReport();
        //            }
        //            else
        //            {
        //                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // log.Error("Error", ex);
        //        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
        //    }
        //}
        //#endregion //
        
        #region Bind tanker no dropdown
        protected void DropDownListTankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            var temp= DropDownListTankName.SelectedValue;
            if(temp== "W11T01")
                txtTankName.Text = "Raw Whey Silo-1";
            else if(temp== "W12T01")
                txtTankName.Text = "Raw Whey Silo-2";
            else if(temp== "W21T01")
                txtTankName.Text = "Past. Whey Silo-1";
            else if(temp== "W22T01")
                txtTankName.Text = "Past. Whey Silo-2";
            else if(temp== "B31T01")
                txtTankName.Text = "Cream buffer Tank";
            else if(temp== "B51T01")
                txtTankName.Text = "Past Cream Tank";
            else if(temp== "W41T01")
                txtTankName.Text = "Nf Whey Tank-1";
            else if(temp== "W42T01")
                txtTankName.Text = "Nf Whey Tank-2";
            else if(temp== "W43T01")
                txtTankName.Text = "Nf Whey Tank-3";
            else if(temp== "W51T01")
                txtTankName.Text = "RO Permeat Tank";
            else if(temp== "C11T01")
                txtTankName.Text = "Crystallization Tank-1";
            else if(temp== "C12T01")
                txtTankName.Text = "Crystallization Tank-2";
            else if(temp== "C13T01")
                txtTankName.Text = "Crystallization Tank-3";
            else if(temp== "C14T01")
                txtTankName.Text = "Crystallization Tank-4";
            else if(temp== "F11T01")
                txtTankName.Text = "Dryer Feed Tank-1";
            else if(temp== "F12T01")
                txtTankName.Text = "Dryer Feed Tank-2";
            else if(temp== "Whey Frop TP")
                txtTankName.Text = "Whey Reception From Whey Section";
            else if(temp== "Yogurt Frop Tp")
                txtTankName.Text = "Yogurt Reception From Yogurt  Section";
            else if(temp== "SMP/WMP/DW From TP")
                txtTankName.Text = "Milk recived from LMP to Evap";
            else if(temp== "Evap Product Out")
                txtTankName.Text = "Product Outlet From Evap";
            else if(temp== "Dryer Product In")
                txtTankName.Text = "Product Inlet to Dryer";

        }

        #endregion
        
        #region PanelVisibilityMode Method
        private void PanelVisibilityMode(bool blDivGrid, bool blDivPanel)
        {
            divGrid.Visible = blDivGrid;
            divPanel.Visible = blDivPanel;
        }
        #endregion

        #region ClearAll Method
        private void ClearAll()
        {
            Controls objcontrol = new Controls();
            objcontrol.ClearForm(Master.FindControl("ContentPlaceHolder1"));
            ViewState["Mode"] = "Save";

        }
        #endregion

        #region preRender
        //protected void gvTankReport_PreRender(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (gvTankReport.Rows.Count > 0)
        //        {
        //            gvTankReport.UseAccessibleHeader = true;
        //            gvTankReport.HeaderRow.TableSection = TableRowSection.TableHeader;

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        // log.Error("Error", ex);
        //        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
        //    }
        //}
        #endregion


    }
}