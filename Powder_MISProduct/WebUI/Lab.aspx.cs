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
    public partial class Lab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ViewState["Mode"] = "Save";
                    BindLab();
                    ViewState["Id"] = 0;

                }
                catch (Exception ex)
                {
                    //  log.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }
        }

        #region Lab
        public void BindLab()
        {
            try
            {
                LabBL objLabBL = new LabBL();
                var objResult = objLabBL.LabReportReportSelectAll();
                if (objResult != null)
                {
                    gvLab.DataSource = objResult.ResultDt;
                    gvLab.DataBind();
                    if (gvLab.Rows.Count > 0)
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                if (Page.IsValid)
                {
                    LabBO objLabBO = new LabBO();
                    LabBL objLabBL = new LabBL();

                    objLabBO.Date= DateTime.ParseExact(txtDate.Text.Trim() + " " + txttime.Text.Trim(), "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                    //objLabBO.Date = txtDate.Text.Trim();
                    objLabBO.TypeofPowder = txtPowder.Text.Trim();
                    objLabBO.Time = txttime.Text.Trim();
                    objLabBO.SampleId = txtsampleId.Text.Trim();
                    objLabBO.BatchNo = txtBatchNo.Text.Trim();
                    objLabBO.BagNo = txtBagNo.Text.Trim();
                    objLabBO.Weight = txtWeight.Text.Trim();
                    objLabBO.TempOC = txtTemp.Text.Trim();
                    objLabBO.Fat = txtFat.Text.Trim();
                    objLabBO.SNF = txtSNF.Text;
                    objLabBO.Acidity = txtAcidity.Text;
                    objLabBO.Moisture = txtMoisture.Text.Trim();
                    objLabBO.Sugar = txtSugar.Text.Trim();
                    objLabBO.SolIndex = txtSolIndex.Text.Trim();
                    objLabBO.Coffetest = txtCoffeetest.Text.Trim();
                    objLabBO.Particleontop = txtParticleontop.Text.Trim();
                    objLabBO.ParticleonBottom = txtParticleonbottom.Text.Trim();
                    objLabBO.Sendiments = txtsediments.Text.Trim();
                    objLabBO.BulkDensity = txtbulkdensity.Text.Trim();
                    objLabBO.Scorchedparticle = txtScorchedParticle.Text;
                    objLabBO.Wettability = txtwettability.Text;
                    objLabBO.Dispersibility = txtDispersilbility.Text.Trim();
                    objLabBO.FreeFat = txtfreefat.Text.Trim();
                    objLabBO.TotalPlatecount = txttotalplatecount.Text.Trim();
                    objLabBO.Coliform = txtColiform.Text.Trim();
                    objLabBO.YestMould = txtyeastmouldcount.Text.Trim();
                    objLabBO.Ecoli = txtEcoli.Text.Trim();
                    objLabBO.Salmonella = txtSalmonella.Text.Trim();
                    objLabBO.Saureus = txtSaureus.Text;
                    objLabBO.Anerobicsporecount = txtAnaerobicsporecount.Text;
                    objLabBO.Listeriamonocytogen = txtListeriamonocytogens.Text;
                    objLabBO.Username = txtusername.Text;
                    objLabBO.Remarks = txtRemarks.Text;

                    if (ViewState["Mode"].ToString() == "Save")
                    {
                        objLabBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objLabBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                        var objResult = objLabBL.Lab_Insert(objLabBO);
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record Saved Successfully!');</script>");
                            BindLab();
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
                       objLabBO.Id = Convert.ToInt32(ViewState["Id"].ToString());
                       objLabBO.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objLabBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                        var objResult = objLabBL.Lab_Update(objLabBO);
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record Updated Successfully.');</script>");
                            BindLab();
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

        protected void gvLab_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvLab.Rows.Count > 0)
                {
                    gvLab.UseAccessibleHeader = true;
                    gvLab.HeaderRow.TableSection = TableRowSection.TableHeader;

                }
            }
            catch (Exception ex)
            {
                // log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }

        protected void gvLab_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                LabBL objLabBL = new LabBL();
                if (e.CommandName.ToString() == "Edit1")
                {
                    ViewState["Mode"] = "Edit";
                    ViewState["Id"] = e.CommandArgument.ToString();
                    var objResult = objLabBL.Lab_Select(Convert.ToInt32(e.CommandArgument.ToString()));
                    if (objResult != null)
                    {
                        if (objResult.ResultDt.Rows.Count > 0)
                        {
                            
                            txtDate.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Date].ToString();
                            txtPowder.Text = objResult.ResultDt.Rows[0][LabBO.Lab_TypeofPowder].ToString();
                            txttime.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Time].ToString();
                            txtsampleId.Text = objResult.ResultDt.Rows[0][LabBO.Lab_SampleId].ToString();
                            txtBatchNo.Text = objResult.ResultDt.Rows[0][LabBO.Lab_BatchNo].ToString();
                            txtBagNo.Text = objResult.ResultDt.Rows[0][LabBO.Lab_BagNo].ToString();
                            txtWeight.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Weight].ToString();
                            txtTemp.Text = objResult.ResultDt.Rows[0][LabBO.Lab_TempOC].ToString();
                            txtFat.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Fat].ToString();
                            txtSNF.Text = objResult.ResultDt.Rows[0][LabBO.Lab_SNF].ToString();
                            txtAcidity.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Acidity].ToString();
                            txtMoisture.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Moisture].ToString();
                            txtSugar.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Sugar].ToString();
                            txtSolIndex.Text = objResult.ResultDt.Rows[0][LabBO.Lab_SolIndex].ToString();
                            txtCoffeetest.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Coffetest].ToString();
                            txtParticleonbottom.Text = objResult.ResultDt.Rows[0][LabBO.Lab_ParticleonBottom].ToString();
                            txtParticleontop.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Particleontop].ToString();
                            txtsediments.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Sendiments].ToString();
                            txtbulkdensity.Text = objResult.ResultDt.Rows[0][LabBO.Lab_BulkDensity].ToString();
                            txtScorchedParticle.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Scorchedparticle].ToString();
                            txtwettability.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Wettability].ToString();
                            txtDispersilbility.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Dispersibility].ToString();
                            txtfreefat.Text = objResult.ResultDt.Rows[0][LabBO.Lab_FreeFat].ToString();
                            txttotalplatecount.Text = objResult.ResultDt.Rows[0][LabBO.Lab_TotalPlatecount].ToString();
                            txtColiform.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Coliform].ToString();
                            txtyeastmouldcount.Text = objResult.ResultDt.Rows[0][LabBO.Lab_YestMould].ToString();
                            txtEcoli.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Ecoli].ToString();
                            txtSalmonella.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Salmonella].ToString();
                            txtSaureus.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Saureus].ToString();
                            txtAnaerobicsporecount.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Anerobicsporecount].ToString();
                            txtListeriamonocytogens.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Listeriamonocytogen].ToString();
                            txtusername.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Username].ToString();                          
                            txtRemarks.Text = objResult.ResultDt.Rows[0][LabBO.Lab_Remarks].ToString();

                            BindLab();
                            PanelVisibilityMode(2);
                        }
                    }
                }
                else if (e.CommandName.ToString() == "Delete1")
                {
                    var objResult = objLabBL.Lab_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid]), DateTime.UtcNow.AddHours(5.5).ToString());
                    if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                    {
                        ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully');</script>");
                        PanelVisibilityMode(1);
                        BindLab();
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
    }
}