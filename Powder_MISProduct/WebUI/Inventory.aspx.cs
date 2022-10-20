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
    public partial class Inventory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ViewState["Mode"] = "Save";
                    BindInventory();
                    ViewState["Id"] = 0;

                }
                catch (Exception ex)
                {
                  //  log.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }

        }

        #region BindInventory
        public void BindInventory()
        {
            try
            {
                InventoryBL objInventoryBL = new InventoryBL();
                var objResult = objInventoryBL.InventoryReportSelect();
                if (objResult != null)
                {
                    gvInventory.DataSource = objResult.ResultDt;
                    gvInventory.DataBind();
                    if (gvInventory.Rows.Count > 0)
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
              
                if (Page.IsValid)
                {
                    InventoryBO objInventoryBO = new InventoryBO();
                    InventoryBL objInventoryBL = new InventoryBL();

                    objInventoryBO.Itemdesc = txtitemdescription.Text.Trim();
                    objInventoryBO.MakeType = txtMaketype.Text.Trim();
                    objInventoryBO.BatchNumber = txtPartNo.Text.Trim();
                    objInventoryBO.Quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                    objInventoryBO.Remarks = txtRemarks.Text.Trim();
                    objInventoryBO.Date = DateTime.ParseExact(txtDate.Text.Trim() + " 00:00:00", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                   
                    if (ViewState["Mode"].ToString() == "Save")
                    {
                        objInventoryBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objInventoryBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                        var objResult = objInventoryBL.Inventory_Insert(objInventoryBO);
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record Saved Successfully!');</script>");
                            BindInventory();
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
                        objInventoryBO.Id = Convert.ToInt32(ViewState["Id"].ToString());
                        objInventoryBO.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objInventoryBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                        var objResult = objInventoryBL.Inventory_Update(objInventoryBO);
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record Updated Successfully.');</script>");
                            BindInventory();
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

        protected void gvInventory_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvInventory.Rows.Count > 0)
                {
                    gvInventory.UseAccessibleHeader = true;
                    gvInventory.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex)
            {
               // log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }

        protected void gvInventory_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                InventoryBL objInventoryBL = new InventoryBL();
                if (e.CommandName.ToString() == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["Id"] = e.CommandArgument.ToString();
                    var objResult = objInventoryBL.Inventory_Select(Convert.ToInt32(e.CommandArgument.ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            txtDate.Text = objResult.ResultDt.Rows[0][InventoryBO.Inventory_Date].ToString();
                            txtitemdescription.Text = objResult.ResultDt.Rows[0][InventoryBO.Inventory_Itemdesc].ToString();
                            txtMaketype.Text = objResult.ResultDt.Rows[0][InventoryBO.Inventory_MakeType].ToString();
                            txtPartNo.Text = objResult.ResultDt.Rows[0][InventoryBO.Inventory_BatchNumber].ToString();
                            txtQuantity.Text = objResult.ResultDt.Rows[0][InventoryBO.Inventory_Quantity].ToString();
                            txtRemarks.Text = objResult.ResultDt.Rows[0][InventoryBO.Inventory_Remarks].ToString();                          
                            BindInventory();
                            PanelVisibilityMode(2);
                        }
                    }
                }
                else if (e.CommandName.ToString() == "Delete1")
                {
                    var objResult = objInventoryBL.Inventory_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid]), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully');</script>");
                        PanelVisibilityMode(1);
                        BindInventory();
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
    }
}