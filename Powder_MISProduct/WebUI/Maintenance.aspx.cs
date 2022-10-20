using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Powder_MISProduct.BL;
using Powder_MISProduct.BO;
using Powder_MISProduct.Common;
using log4net;
using System.Globalization;

namespace Powder_MISProduct.WebUI
{
    public partial class Maintenance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ViewState["Mode"] = "Save";
                    BindMaintenance();
                    ViewState["Id"] = 0;

                }
                catch (Exception ex)
                {
                    //  log.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }

        }

        #region BindMaintenance
        public void BindMaintenance()
        {
            try
            {
                MaintenanceBL objMaintenanceBL = new MaintenanceBL();
                var objResult = objMaintenanceBL.MaintenanceReportSelect();
                if (objResult != null)
                {
                    gvMaintenance.DataSource = objResult.ResultDt;
                    gvMaintenance.DataBind();
                    if (gvMaintenance.Rows.Count > 0)
                    {
                        PanelVisibilityMode(1);
                    }
                    else
                    {
                        PanelVisibilityMode(2);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        protected void gvMaintenance_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvMaintenance.Rows.Count > 0)
                {
                    gvMaintenance.UseAccessibleHeader = true;
                    gvMaintenance.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex)
            {
                // log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }


        }

        protected void gvMaintenance_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                MaintenanceBL objMaintenanceBL = new MaintenanceBL();
                if (e.CommandName.ToString() == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["Id"] = e.CommandArgument.ToString();
                    var objResult = objMaintenanceBL.Maintenance_Select(Convert.ToInt32(e.CommandArgument.ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtDate.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_Date].ToString();
                            txtEquipmentTagNo.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_EquipmentTagNo].ToString();
                            txtEquipmentname.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_EquipmentName].ToString();
                            txtArea.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_Area].ToString();
                            txtStartTime.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_StartTime].ToString();
                            txtEndtime.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_EndTime].ToString();
                          //  txtArea.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_Area].ToString();
                            txtPartNumber.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_PartNo].ToString();
                            txtProblemdetails.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_ProblemDetails].ToString();
                            txtActionTaken.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_ActionTaken].ToString();
                            txtRectifiedBy.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_RectifiedBy].ToString();
                            txtRemarks.Text = objResult.ResultDt.Rows[0][MaintenanceBO.Maintainance_Remark].ToString();

                            BindMaintenance();
                            PanelVisibilityMode(2);
                        }
                    }
                }
                else if (e.CommandName.ToString() == "Delete1")
                {
                    var objResult = objMaintenanceBL.Maintenance_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid]), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully');</script>");
                        PanelVisibilityMode(1);
                        BindMaintenance();
                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                    }
                }
            }
            catch (Exception ex)
            {
                // log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {
                    MaintenanceBO objMaintenanceBO = new MaintenanceBO();
                    MaintenanceBL objMaintenanceBL = new MaintenanceBL();

                    objMaintenanceBO.Date = DateTime.ParseExact(txtDate.Text.Trim() + " " + txtStartTime.Text.Trim(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    objMaintenanceBO.StartTime = txtStartTime.Text.Trim();
                    objMaintenanceBO.EndTime = txtEndtime.Text.Trim();
                    objMaintenanceBO.Area = txtArea.Text.Trim();
                    objMaintenanceBO.EquipmentName = txtEquipmentname.Text.Trim();
                    objMaintenanceBO.EquipmentTagNo = txtEquipmentTagNo.Text.Trim();
                    objMaintenanceBO.PartNo = txtPartNumber.Text.Trim();
                    objMaintenanceBO.ProblemDetails = txtProblemdetails.Text.Trim();
                    objMaintenanceBO.ActionTaken = txtActionTaken.Text.Trim();
                    objMaintenanceBO.RectifiedBy = txtRectifiedBy.Text;
                    objMaintenanceBO.Remark = txtRemarks.Text;

                    if (ViewState["Mode"].ToString() == "Save")
                    {
                        objMaintenanceBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objMaintenanceBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                        var objResult = objMaintenanceBL.Maintenance_Insert(objMaintenanceBO);
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record Saved Successfully!');</script>");
                            BindMaintenance();
                            ClearAll();
                            PanelVisibilityMode(1);
                            ViewState["Mode"] = "Save";
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record already exist.');</script>");
                        }
                    }
                    else if (ViewState["Mode"].ToString() == "Edit")
                    {
                        objMaintenanceBO.Id = Convert.ToInt32(ViewState["Id"].ToString());
                        objMaintenanceBO.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objMaintenanceBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                        var objResult = objMaintenanceBL.Maintenance_Update(objMaintenanceBO);
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record Updated Successfully.');</script>");
                            BindMaintenance();
                            ClearAll();
                            PanelVisibilityMode(1);
                            ViewState["Mode"] = "Save";
                        }
                        else
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record already exist.');</script>");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                //log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }

        }

        protected void btnViewList_Click(object sender, EventArgs e)
        {
            PanelVisibilityMode(1);

        }

        #region PanelVisibilityMode Method
        private void PanelVisibilityMode(int intmode)
        {
            if (intmode == 1)
            {
                divGrid.Visible = true;
                divPanel.Visible = false;
            }
            else if (intmode == 2)
            {
                divGrid.Visible = false;
                divPanel.Visible = true;
            }
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                PanelVisibilityMode(2);
                txtDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                //divIsResignDate.Visible = false;
            }
            catch (Exception ex)
            {
                //log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }

        }
    }
}