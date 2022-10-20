using System;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Powder_MISProduct.BL;
using Powder_MISProduct.BO;
using Powder_MISProduct.Common;

namespace Powder_MISProduct.WebUI
{
    public partial class WeighAnalysis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    ViewState["Mode"] = "Save";
                    BindWheyAnalysis();
                    ViewState["Id"] = 0;

                }
                catch (Exception ex)
                {
                    //  log.Error("Error", ex);
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
                }
            }
        }

        #region BindWheyAnalysis
        public void BindWheyAnalysis()
        {
            try
            {
                WheyAnalysisBL objWeighAnalysisBL = new WheyAnalysisBL();
                var objResult = objWeighAnalysisBL.WheyAnalysisReportSelect();
                if (objResult != null)
                {
                    gvWheyAnalysis.DataSource = objResult.ResultDt;
                    gvWheyAnalysis.DataBind();
                    if (gvWheyAnalysis.Rows.Count > 0)
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

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            try
            {
                ClearAll();
                txtDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txttime.Text = DateTime.UtcNow.AddHours(5.5).ToString("HH:mm:ss", CultureInfo.InvariantCulture);
                txtSampleDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                PanelVisibilityMode(2);
                //divIsResignDate.Visible = false;
            }
            catch (Exception ex)
            {
                //log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical issue. Please Contact to your administrator.');</script>");
            }
        }

        //protected void gvWheyAnalysis_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        WheyAnalysisBL objWheyAnalysisBL = new WheyAnalysisBL();
        //        if (e.CommandName.ToString() == "Edit1")
        //        {
        //            ViewState["Mode"] = "Edit";
        //            ViewState["Id"] = e.CommandArgument.ToString();
        //            var objResult = objWheyAnalysisBL.WheyAnalysis_Select(Convert.ToInt32(e.CommandArgument.ToString()));
        //            if (objResult != null)
        //            {
        //                if (objResult.ResultDt.Rows.Count > 0)
        //                {
        //                    var Date = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_DateTime].ToString().Split(' ');
        //                    var SampleDate = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_SampleDateTime].ToString().Split(' ');

        //                    //txtDate.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_DateTime].ToString();
        //                    //txttime.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Time].ToString();
                            
        //                    txtDate.Text = Date[0];
        //                    txttime.Text = Date[1];
        //                    txtSampleDate.Text = SampleDate[0];
        //                    txtSampleTime.Text = SampleDate[1];

        //                    txtSampleNo.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_SampleNo].ToString();
        //                    txtsamplename.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_SampleName].ToString();
        //                    txtProductName.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_ProductName].ToString();
        //                    txtOT.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_OT].ToString();
        //                    txtTemp.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Temp].ToString();
        //                    txtFat.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Fat].ToString();
        //                    txtSNF.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_SNF].ToString();
        //                    txtAcidity.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Acidity].ToString();
        //                    ddlCOB.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_COB].ToString();
        //                    ddlAlcholtest.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_AlcholTest65].ToString();
        //                    ddlAlcholtests.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_AlcholTest].ToString();
        //                    ddlAntibiotictest.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Blactumantibiotictest].ToString();
        //                    ddlMineraloiltest.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_MineralOilTest].ToString();
        //                    ddlAnyothertest1.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_AnyOtherTest01].ToString();
        //                    ddlAnyothertest2.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_AnyOtherTest02].ToString();
        //                    ddlAnyothertest3.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_AnyOtherTest03].ToString();
        //                    ddlAnyothertest4.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_AnyOtherTest04].ToString();
        //                    ddlNeutrilize.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Neutrilize].ToString();
        //                    ddlUrea.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Urea].ToString();
        //                    ddlsalt.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Salt].ToString();
        //                    ddlstarch.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Startch].ToString();
        //                    ddlfpd.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_FPD].ToString();
        //                    ddlstatus.SelectedItem.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Status].ToString();
        //                    txtRemarks.Text = objResult.ResultDt.Rows[0][WheyAnalysisBO.WheyAnalysis_Remarks].ToString();
        //                    //BindMaintenance();
        //                    PanelVisibilityMode(2);
        //                }
        //            }
        //        }
        //        else if (e.CommandName.ToString() == "Delete1")
        //        {
        //            var objResult = objWheyAnalysisBL.WheyAnalysis_Delete(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(Session[ApplicationSession.Userid]), DateTime.UtcNow.AddHours(5.5).ToString());
        //            if (objResult.Status == ApplicationResult.CommonStatusType.Success)
        //            {
        //                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Record Deleted Successfully');</script>");
        //                PanelVisibilityMode(1);
        //                BindWheyAnalysis();
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

        protected void gvWheyAnalysis_PreRender(object sender, EventArgs e)
        {
            try
            {
                if (gvWheyAnalysis.Rows.Count > 0)
                {
                    gvWheyAnalysis.UseAccessibleHeader = true;
                    gvWheyAnalysis.HeaderRow.TableSection = TableRowSection.TableHeader;

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
                    WheyAnalysisBO objWheyAnalysisBO = new WheyAnalysisBO();
                    WheyAnalysisBL objWheyAnalysisBL = new WheyAnalysisBL();

                    //objWheyAnalysisBO.Date = txtDate.Text.Trim() +" "+ txttime.Text.Trim();
                    objWheyAnalysisBO.Date = DateTime.ParseExact(txtDate.Text + " " + txttime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString();
                    //objWheyAnalysisBO.Time = txttime.Text.Trim();
                    objWheyAnalysisBO.SampleDate = DateTime.ParseExact(txtSampleDate.Text + " " + txtSampleTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString();
                    //objWheyAnalysisBO.SampleTime = txtSampleTime.Text.Trim();
                    objWheyAnalysisBO.SampleName = txtsamplename.Text.Trim();
                    objWheyAnalysisBO.SampleNo = txtSampleNo.Text.Trim();
                    objWheyAnalysisBO.ProductName = txtProductName.Text.Trim();
                    objWheyAnalysisBO.OT = txtOT.Text.Trim();
                    objWheyAnalysisBO.Temp = txtTemp.Text.Trim();
                    objWheyAnalysisBO.Fat = txtFat.Text.Trim();
                    objWheyAnalysisBO.SNF = txtSNF.Text.Trim();
                    objWheyAnalysisBO.Acidity = txtAcidity.Text.Trim();
                    //objWheyAnalysisBO.COB = ddlCOB.SelectedItem.Text;
                    //objWheyAnalysisBO.AlcholTest65 = ddlAlcholtest.SelectedItem.Text;
                    //objWheyAnalysisBO.AlcholTest = ddlAlcholtests.SelectedItem.Text;
                    //objWheyAnalysisBO.Blactumantibiotictest = ddlAntibiotictest.SelectedItem.Text;
                    //objWheyAnalysisBO.MineralOilTest = ddlMineraloiltest.SelectedItem.Text;
                    objWheyAnalysisBO.AnyOtherTest01 = ddlAnyothertest1.SelectedItem.Text;
                    objWheyAnalysisBO.AnyOtherTest02 = ddlAnyothertest2.SelectedItem.Text;
                    objWheyAnalysisBO.AnyOtherTest03 = ddlAnyothertest3.SelectedItem.Text;
                    objWheyAnalysisBO.AnyOtherTest04 = ddlAnyothertest4.SelectedItem.Text;
                   // objWheyAnalysisBO.Neutrilize = ddlNeutrilize.SelectedItem.Text;
                    objWheyAnalysisBO.Urea = ddlUrea.SelectedItem.Text;
                    objWheyAnalysisBO.Salt = ddlsalt.SelectedItem.Text;
                    objWheyAnalysisBO.Startch = ddlstarch.SelectedItem.Text;
                    objWheyAnalysisBO.FPD = ddlfpd.SelectedItem.Text;
                    objWheyAnalysisBO.Status = ddlstatus.SelectedItem.Text;
                    objWheyAnalysisBO.Remarks = txtRemarks.Text;

                    if (ViewState["Mode"].ToString() == "Save")
                    {
                        objWheyAnalysisBO.CreatedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objWheyAnalysisBO.CreatedDate = DateTime.UtcNow.AddHours(5.5).ToShortDateString();
                        objWheyAnalysisBO.IsDeleted = 0;
                        var objResult = objWheyAnalysisBL.WheyAnalysis_Insert(objWheyAnalysisBO);
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record Saved Successfully!');</script>");
                            BindWheyAnalysis();
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
                        objWheyAnalysisBO.Id = Convert.ToInt32(ViewState["Id"].ToString());
                        objWheyAnalysisBO.LastModifiedBy = Convert.ToInt32(Session[ApplicationSession.Userid]);
                        objWheyAnalysisBO.LastModifiedDate = DateTime.UtcNow.AddHours(5.5).ToString();
                        var objResult = objWheyAnalysisBL.WheyAnalysis_Update(objWheyAnalysisBO);
                        if (objResult.Status == ApplicationResult.CommonStatusType.Success)
                        {
                            ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                                "<script>alert('Record Updated Successfully.');</script>");
                            BindWheyAnalysis();
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
    }
}