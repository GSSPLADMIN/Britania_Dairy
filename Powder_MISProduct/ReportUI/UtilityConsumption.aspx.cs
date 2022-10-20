using System;
using System.Data;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Powder_MISProduct.BL;
using log4net;
using Powder_MISProduct.Common;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using System.Drawing;
using System.Text;

namespace Powder_MISProduct.ReportUI
{
    public partial class UtilityConsumption : System.Web.UI.Page
    {
        #region Load page event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divExport.Visible = false;
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
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

        #region PDFBackgroundHelper Event
        class PDFBackgroundHelper : PdfPageEventHelper
        {

            private PdfContentByte cb;
            private List<PdfTemplate> templates;

            iTextSharp.text.Font FONT = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
            int iCount = 0;

            //constructor
            public PDFBackgroundHelper()
            {
                this.templates = new List<PdfTemplate>();
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                try
                {
                    base.OnEndPage(writer, document);
                    cb = writer.DirectContentUnder;
                    PdfTemplate templateM = cb.CreateTemplate(500, 500);
                    templates.Add(templateM);
                    int pageN = writer.CurrentPageNumber;
                    String pageText = "Page No : " + (writer.PageNumber);
                    DateTime dtTime = DateTime.Now;
                    BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                    if (this.iCount != 0)
                    {
                        ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("UtilityConsumption REPORT", FONT), 1190, 1665, 0);
                    }
                    iCount = iCount + 1;

                    float len = bf.GetWidthPoint(pageText, 9);
                    float len1 = bf.GetWidthPoint(dtTime.ToString(), 9);
                    cb.BeginText();
                    cb.SetFontAndSize(bf, 12);
                    cb.SetTextMatrix(document.LeftMargin + 300, document.PageSize.GetBottom(document.BottomMargin) - 13);
                    cb.ShowText(dtTime.ToString());
                    cb.SetTextMatrix(document.LeftMargin + 1390, document.PageSize.GetBottom(document.BottomMargin) - 13);
                    cb.ShowText(pageText);
                    cb.EndText();
                    cb.AddTemplate(templateM, document.LeftMargin + 1650 + len, document.PageSize.GetBottom(document.BottomMargin) - 13);
                }
                catch (Exception ex)
                {

                }
            }
        }
        #endregion

        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion

        #region BindUtilityConsumption
        public void BindUtilityConsumption()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                UtilityConsumptionBl objUtility = new UtilityConsumptionBl();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                  CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);

                if (dtFromDateTime <= dtToDateTime)
                {
                    objResult = objUtility.UtilityConsumptionLogReport(dtFromDateTime, dtToDateTime);
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvUtilityConsumption.DataSource = objResult.ResultDt;
                        gvUtilityConsumption.DataBind();
                        // imgWordButton.Visible = imgExcelButton.Visible = true;
                        divNo.Visible = false;
                        divExport.Visible = true;
                        gvUtilityConsumption.Visible = true;

                    }
                    else
                    {
                        // imgWordButton.Visible = imgExcelButton.Visible = false;
                        divNo.Visible = true;
                        divExport.Visible = false;
                        gvUtilityConsumption.Visible = false;
                    }

                }
                else
                {
                    gvUtilityConsumption.Visible = false;
                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                   "<script>alert('You cannot select From Date greater than To Date.');</script>");
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

        #region Export PDF function
        protected void imgPDFButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Session[ApplicationSession.OrganisationName].ToString();
                string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                string text2 = "Utility Consumption Report";

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        DateTime dtfromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
                        DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

                        System.Text.StringBuilder sb = new StringBuilder();
                        sb.Append("<div align='center' style='font-size:16px;font-weight:bold;color:Black;'>");
                        sb.Append(text);
                        sb.Append("</div>");
                        sb.Append("<br/>");
                        sb.Append("<div align='center' style='font-size:13px;font-weight:bold;color:Black;'>");
                        sb.Append(text1);
                        sb.Append("</div>");
                        sb.Append("<br/>");
                        sb.Append("<div align='center' style='font-size:26px;color:Maroon;'><b>");
                        sb.Append(text2);
                        sb.Append("</b></div>");
                        sb.Append("<br/>");

                        string content = "<table style='display: table;width: 900px; clear:both;'> <tr> <th colspan='7'"
                            + "style='float: left;padding-left: 290px;'><div align='left'><strong>From Date : </strong>" +
                            dtfromDateTime + "</div></th>";

                        content += "<th style='float:left; padding-left:-180px;'></th>";

                        content += "<th style='float:left; padding-left:-210px;'></th>";

                        content += "<th colspan='1' align='left' style=' float: left; padding-left:-200px;'><strong> To DateTime: </strong>" +
                        dtToDateTime + "</th>" +
                        "</tr></table>";
                        sb.Append(content);
                        sb.Append("<br/>");

                        PdfPTable pdfPTable = new PdfPTable(gvUtilityConsumption.HeaderRow.Cells.Count);
                        iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);



                        PdfPCell headerCell = new PdfPCell(new Phrase("Sr. No."));
                        headerCell.Rowspan = 2;
                        headerCell.Colspan = 1;
                        headerCell.Padding = 5;
                        headerCell.BorderWidth = 1.5f;
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell);

                        PdfPCell headerCell2 = new PdfPCell(new Phrase("Date"));
                        headerCell2.Rowspan = 2;
                        headerCell2.Colspan = 1;
                        headerCell2.Padding = 5;
                        headerCell2.BorderWidth = 1.5f;
                        headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell2);

                        PdfPCell headerCell4 = new PdfPCell(new Phrase("Time"));
                        headerCell4.Rowspan = 2;
                        headerCell4.Colspan = 1;
                        headerCell4.Padding = 5;
                        headerCell4.BorderWidth = 1.5f;
                        headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell4);

                        //PdfPCell headerCell1 = new PdfPCell(new Phrase("MCC1 Whey Processes (kVAh)"));
                        PdfPCell headerCell1 = new PdfPCell(new Phrase("MCC1 Whey Proc. (kVAh)"));
                        headerCell1.Rowspan = 2;
                        headerCell1.Colspan = 1;
                        headerCell1.Padding = 5;
                        headerCell1.BorderWidth = 1.5f;
                        headerCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell1);

                        //PdfPCell headerCell6 = new PdfPCell(new Phrase("MCC2 Evaporator (kVAh)"));
                        PdfPCell headerCell6 = new PdfPCell(new Phrase("MCC2 Evap. (kVAh)"));
                        headerCell6.Rowspan = 2;
                        headerCell6.Colspan = 1;
                        headerCell6.Padding = 5;
                        headerCell6.BorderWidth = 1.5f;
                        headerCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell6);

                        PdfPCell headerCell3 = new PdfPCell(new Phrase("MCC3 Dryer (kVAh)"));
                        headerCell3.Rowspan = 2;
                        headerCell3.Colspan = 1;
                        headerCell3.Padding = 5;
                        headerCell3.BorderWidth = 1.5f;
                        headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell3);

                        //PdfPCell headerCell5 = new PdfPCell(new Phrase("Total Power Consumption (KW)"));
                        PdfPCell headerCell5 = new PdfPCell(new Phrase("Total Power Consm. (kVAh)"));
                        headerCell5.Rowspan = 2;
                        headerCell5.Colspan = 1;
                        headerCell5.Padding = 5;
                        headerCell5.BorderWidth = 1.5f;
                        headerCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell5);

                        PdfPCell headerCell7 = new PdfPCell(new Phrase("Sub PCC (kVAh)"));
                        headerCell7.Rowspan = 2;
                        headerCell7.Colspan = 1;
                        headerCell7.Padding = 5;
                        headerCell7.BorderWidth = 1.5f;
                        headerCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell7.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell7);

                        //PdfPCell headerCell8 = new PdfPCell(new Phrase("Steam Consumption in Whey Plant (Kg)"));
                        PdfPCell headerCell8 = new PdfPCell(new Phrase("Steam Consm. in Whey Plant (Kg)"));
                        headerCell8.Rowspan = 2;
                        headerCell8.Colspan = 1;
                        headerCell8.Padding = 5;
                        headerCell8.BorderWidth = 1.5f;
                        headerCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell8.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell8);

                        //PdfPCell headerCell9 = new PdfPCell(new Phrase("Steam Consumption in Evaporator (Kg)"));
                        PdfPCell headerCell9 = new PdfPCell(new Phrase("Steam Consm. in Evap. (Kg)"));
                        headerCell9.Rowspan = 2;
                        headerCell9.Colspan = 1;
                        headerCell9.Padding = 5;
                        headerCell9.BorderWidth = 1.5f;
                        headerCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell9.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell9);

                        //PdfPCell headerCell10 = new PdfPCell(new Phrase("HP Steam Consumption in Dryer (Kg)"));
                        PdfPCell headerCell10 = new PdfPCell(new Phrase("HP Steam Consm. in Dryer (Kg)"));
                        headerCell10.Rowspan = 2;
                        headerCell10.Colspan = 1;
                        headerCell10.Padding = 5;
                        headerCell10.BorderWidth = 1.5f;
                        headerCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell10.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell10);

                        //PdfPCell headerCell12 = new PdfPCell(new Phrase("Steam Consumption in Dryer LP (Kg)"));
                        PdfPCell headerCell12 = new PdfPCell(new Phrase("Steam Consm. in Dryer LP (Kg)"));
                        headerCell12.Rowspan = 2;
                        headerCell12.Colspan = 1;
                        headerCell12.Padding = 5;
                        headerCell12.BorderWidth = 1.5f;
                        headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell12);

                        //PdfPCell headerCell14 = new PdfPCell(new Phrase("Total Steam Consumption (Kg)"));
                        PdfPCell headerCell14 = new PdfPCell(new Phrase("Total Steam Consm. (Kg)"));
                        headerCell14.Rowspan = 2;
                        headerCell14.Colspan = 1;
                        headerCell14.Padding = 5;
                        headerCell14.BorderWidth = 1.5f;
                        headerCell14.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell14.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell14);

                        //PdfPCell headerCell13 = new PdfPCell(new Phrase("Chilled Water in Whey Processing Area (Ltr/day)"));
                        PdfPCell headerCell13 = new PdfPCell(new Phrase("Chilled Water in Whey Proces. Ar. (Ltr/ day)"));
                        headerCell13.Rowspan = 2;
                        headerCell13.Colspan = 1;
                        headerCell13.Padding = 5;
                        headerCell13.BorderWidth = 1.5f;
                        headerCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell13);

                        PdfPCell headerCell15 = new PdfPCell(new Phrase("Chilled Water in Powder Plant (Ltr/ day)"));
                        headerCell15.Rowspan = 2;
                        headerCell15.Colspan = 1;
                        headerCell15.Padding = 5;
                        headerCell15.BorderWidth = 1.5f;
                        headerCell15.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell15.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell15);

                        PdfPCell headerCell16 = new PdfPCell(new Phrase("Chilled Water Inlet Temp. (°C)"));
                        headerCell16.Rowspan = 2;
                        headerCell16.Colspan = 1;
                        headerCell16.Padding = 5;
                        headerCell16.BorderWidth = 1.5f;
                        headerCell16.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell16.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell16);


                        PdfPCell headerCell17 = new PdfPCell(new Phrase("Chilled Water Outlet Temp. (°C)"));
                        headerCell17.Rowspan = 2;
                        headerCell17.Colspan = 1;
                        headerCell17.Padding = 5;
                        headerCell17.BorderWidth = 1.5f;
                        headerCell17.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell17.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell17);

                        //PdfPCell headerCell18 = new PdfPCell(new Phrase("Average Temp. (°C)"));
                        PdfPCell headerCell18 = new PdfPCell(new Phrase("Avg. Temp. (°C)"));
                        headerCell18.Rowspan = 2;
                        headerCell18.Colspan = 1;
                        headerCell18.Padding = 5;
                        headerCell18.BorderWidth = 1.5f;
                        headerCell18.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell18.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell18);

                        //PdfPCell headerCell11 = new PdfPCell(new Phrase("CHW Consumption in TR Whey Plant"));
                        PdfPCell headerCell11 = new PdfPCell(new Phrase("CHW Consm. in TR Whey Plant"));
                        headerCell11.Rowspan = 2;
                        headerCell11.Colspan = 1;
                        headerCell11.Padding = 5;
                        headerCell11.BorderWidth = 1.5f;
                        headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell11.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell11);
                        
                        //PdfPCell headerCell19 = new PdfPCell(new Phrase("CHW Consumption in TR PP"));
                        PdfPCell headerCell19 = new PdfPCell(new Phrase("CHW Consm. in TR PP"));
                        headerCell19.Rowspan = 2;
                        headerCell19.Colspan = 1;
                        headerCell19.Padding = 5;
                        headerCell19.BorderWidth = 1.5f;
                        headerCell19.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell19.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell19);

                        PdfPCell headerCell20 = new PdfPCell(new Phrase("Soft Water (Ltr/ day)"));
                        headerCell20.Rowspan = 2;
                        headerCell20.Colspan = 1;
                        headerCell20.Padding = 5;
                        headerCell20.BorderWidth = 1.5f;
                        headerCell20.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell20.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell20);

                        PdfPCell headerCell21 = new PdfPCell(new Phrase("RO Water (Ltr/ day)"));
                        headerCell21.Rowspan = 2;
                        headerCell21.Colspan = 1;
                        headerCell21.Padding = 5;
                        headerCell21.BorderWidth = 1.5f;
                        headerCell21.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell21.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell21);

                        //PdfPCell headerCell22 = new PdfPCell(new Phrase("Compressed Air (Nm3)"));
                        PdfPCell headerCell22 = new PdfPCell(new Phrase("Comp. Air (Nm3)"));
                        headerCell22.Rowspan = 2;
                        headerCell22.Colspan = 1;
                        headerCell22.Padding = 5;
                        headerCell22.BorderWidth = 1.5f;
                        headerCell22.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell22.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell22);


                        PdfPCell headerCell23 = new PdfPCell(new Phrase("Raw Water (Ltr/ day)"));
                        headerCell23.Rowspan = 2;
                        headerCell23.Colspan = 1;
                        headerCell23.Padding = 5;
                        headerCell23.BorderWidth = 1.5f;
                        headerCell23.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell23.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell23);

                        //PdfPCell headerCell24 = new PdfPCell(new Phrase("Powder Produced (Kg)"));
                        PdfPCell headerCell24 = new PdfPCell(new Phrase("Powder Prod. (Kg)"));
                        headerCell24.Rowspan = 2;
                        headerCell24.Colspan = 1;
                        headerCell24.Padding = 5;
                        headerCell24.BorderWidth = 1.5f;
                        headerCell24.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell24.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell24);

                        PdfPCell headerCell25 = new PdfPCell(new Phrase("Specific Utility Cost"));
                        headerCell25.Rowspan = 1;
                        headerCell25.Colspan = 10;
                        headerCell25.Padding = 5;
                        headerCell25.BorderWidth = 1.5f;
                        headerCell25.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell25.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell25);

                        PdfPCell headerCell26 = new PdfPCell(new Phrase("Utility Cost In Database"));
                        headerCell26.Rowspan = 1;
                        headerCell26.Colspan = 7;
                        headerCell26.Padding = 5;
                        headerCell26.BorderWidth = 1.5f;
                        headerCell26.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell26.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell26);
                        
                        PdfPCell headerCell44 = new PdfPCell(new Phrase("Total Utility Cost/ Day"));
                        headerCell44.Rowspan = 2;
                        headerCell44.Colspan = 1;
                        headerCell44.Padding = 5;
                        headerCell44.BorderWidth = 1.5f;
                        headerCell44.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell44.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell44);
                        
                        PdfPCell headerCell45 = new PdfPCell(new Phrase("Utility Cost/ Kg Powder (RS)"));
                        headerCell45.Rowspan = 2;
                        headerCell45.Colspan = 1;
                        headerCell45.Padding = 5;
                        headerCell45.BorderWidth = 1.5f;
                        headerCell45.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell45.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell45);
                        
                        PdfPCell headerCell46 = new PdfPCell(new Phrase("Remarks"));
                        headerCell46.Rowspan = 2;
                        headerCell46.Colspan = 1;
                        headerCell46.Padding = 5;
                        headerCell46.BorderWidth = 1.5f;
                        headerCell46.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell46.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell46);


                        ////////////////Sub-Headers/////////////////////////////////////
                        
                        //PdfPCell headerCell27 = new PdfPCell(new Phrase("Chilled water For Whey Area"));
                        PdfPCell headerCell27 = new PdfPCell(new Phrase("Chilled Water For Whey Ar."));
                        headerCell27.Rowspan = 1;
                        headerCell27.Colspan = 1;
                        headerCell27.Padding = 5;
                        headerCell27.BorderWidth = 1.5f;
                        headerCell27.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell27.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell27);

                        //PdfPCell headerCell28 = new PdfPCell(new Phrase("Chilled water For PP Area"));
                        PdfPCell headerCell28 = new PdfPCell(new Phrase("Chilled Water For PP Ar."));
                        headerCell28.Rowspan = 1;
                        headerCell28.Colspan = 1;
                        headerCell28.Padding = 5;
                        headerCell28.BorderWidth = 1.5f;
                        headerCell28.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell28.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell28);


                        //PdfPCell headerCell29 = new PdfPCell(new Phrase("Steam For Whey Area"));
                        PdfPCell headerCell29 = new PdfPCell(new Phrase("Steam For Whey Ar."));
                        headerCell29.Rowspan = 1;
                        headerCell29.Colspan = 1;
                        headerCell29.Padding = 5;
                        headerCell29.BorderWidth = 1.5f;
                        headerCell29.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell29.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell29);

                        //PdfPCell headerCell30 = new PdfPCell(new Phrase("Steam For PP Area"));
                        PdfPCell headerCell30 = new PdfPCell(new Phrase("Steam For PP Ar."));
                        headerCell30.Rowspan = 1;
                        headerCell30.Colspan = 1;
                        headerCell30.Padding = 5;
                        headerCell30.BorderWidth = 1.5f;
                        headerCell30.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell30.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell30);

                        //PdfPCell headerCell31 = new PdfPCell(new Phrase("Power For Whey Area"));
                        PdfPCell headerCell31 = new PdfPCell(new Phrase("Power For Whey Ar."));
                        headerCell31.Rowspan = 1;
                        headerCell31.Colspan = 1;
                        headerCell31.Padding = 5;
                        headerCell31.BorderWidth = 1.5f;
                        headerCell31.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell31.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell31);

                        //PdfPCell headerCell32 = new PdfPCell(new Phrase("Power For PP Area"));
                        PdfPCell headerCell32 = new PdfPCell(new Phrase("Power For PP Ar."));
                        headerCell32.Rowspan = 1;
                        headerCell32.Colspan = 1;
                        headerCell32.Padding = 5;
                        headerCell32.BorderWidth = 1.5f;
                        headerCell32.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell32.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell32);

                        PdfPCell headerCell33 = new PdfPCell(new Phrase("Soft Water All Plant"));
                        headerCell33.Rowspan = 1;
                        headerCell33.Colspan = 1;
                        headerCell33.Padding = 5;
                        headerCell33.BorderWidth = 1.5f;
                        headerCell33.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell33.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell33);

                        PdfPCell headerCell34 = new PdfPCell(new Phrase("RO Water All Plant"));
                        headerCell34.Rowspan = 1;
                        headerCell34.Colspan = 1;
                        headerCell34.Padding = 5;
                        headerCell34.BorderWidth = 1.5f;
                        headerCell34.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell34.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell34);

                        PdfPCell headerCell35 = new PdfPCell(new Phrase("Raw Water All Plant"));
                        headerCell35.Rowspan = 1;
                        headerCell35.Colspan = 1;
                        headerCell35.Padding = 5;
                        headerCell35.BorderWidth = 1.5f;
                        headerCell35.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell35.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell35);

                        //PdfPCell headerCell36 = new PdfPCell(new Phrase("Compressed air All Plant"));
                        PdfPCell headerCell36 = new PdfPCell(new Phrase("Comp. Air All Plant"));
                        headerCell36.Rowspan = 1;
                        headerCell36.Colspan = 1;
                        headerCell36.Padding = 5;
                        headerCell36.BorderWidth = 1.5f;
                        headerCell36.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell36.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell36);

                        PdfPCell headerCell37 = new PdfPCell(new Phrase("Chilled water /TR"));
                        headerCell37.Rowspan = 1;
                        headerCell37.Colspan = 1;
                        headerCell37.Padding = 5;
                        headerCell37.BorderWidth = 1.5f;
                        headerCell37.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell37.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell37);

                        PdfPCell headerCell38 = new PdfPCell(new Phrase("Steam/ Kg"));
                        headerCell38.Rowspan = 1;
                        headerCell38.Colspan = 1;
                        headerCell38.Padding = 5;
                        headerCell38.BorderWidth = 1.5f;
                        headerCell38.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell38.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell38);

                        PdfPCell headerCell39 = new PdfPCell(new Phrase("Power/ kVAh"));
                        headerCell39.Rowspan = 1;
                        headerCell39.Colspan = 1;
                        headerCell39.Padding = 5;
                        headerCell39.BorderWidth = 1.5f;
                        headerCell39.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell39.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell39);
                        
                        PdfPCell headerCell40 = new PdfPCell(new Phrase("Soft Water/ Kl"));
                        headerCell40.Rowspan = 1;
                        headerCell40.Colspan = 1;
                        headerCell40.Padding = 5;
                        headerCell40.BorderWidth = 1.5f;
                        headerCell40.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell40.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell40);
                        
                        PdfPCell headerCell41 = new PdfPCell(new Phrase("RO Water/ Kl"));
                        headerCell41.Rowspan = 1;
                        headerCell41.Colspan = 1;
                        headerCell41.Padding = 5;
                        headerCell41.BorderWidth = 1.5f;
                        headerCell41.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell41.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell41);

                        PdfPCell headerCell42 = new PdfPCell(new Phrase("Raw Water/ Kl"));
                        headerCell42.Rowspan = 1;
                        headerCell42.Colspan = 1;
                        headerCell42.Padding = 5;
                        headerCell42.BorderWidth = 1.5f;
                        headerCell42.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell42.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell42);
                        
                        //PdfPCell headerCell43 = new PdfPCell(new Phrase("Compressed air/Nm3"));
                        PdfPCell headerCell43 = new PdfPCell(new Phrase("Comp. Air/ Nm3"));
                        headerCell43.Rowspan = 1;
                        headerCell43.Colspan = 1;
                        headerCell43.Padding = 5;
                        headerCell43.BorderWidth = 1.5f;
                        headerCell43.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell43.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell43);

                        float[] widthsTAS = {
                            50f, 130f, 100f, 90f, 90f,
                            90f, 90f, 90f, 90f, 90f,
                            90f, 90f, 90f, 90f, 90f,
                            90f, 90f, 90f, 90f, 90f,//CAl-1
                            90f, 90f, 90f, 90f, 90f,
                            90f, 90f, 90f, 90f, 90f,
                            90f, 90f, 90f, 90f, 90f,
                            90f, 90f, 90f, 90f, 90f,
                            90f, 90f, 90f, 90f, 110f
                        };
                        pdfPTable.SetWidths(widthsTAS);



                        foreach (GridViewRow gridViewRow in gvUtilityConsumption.Rows)
                        {
                            foreach (TableCell tableCell in gridViewRow.Cells)
                            {
                                string cellText = Server.HtmlDecode(tableCell.Text);
                                iTextSharp.text.Font fontH1 = new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 23);

                                DateTime dDate;
                                double dbvalue;
                                int intvalue;

                                if (DateTime.TryParse(cellText, out dDate))
                                {
                                    PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
                                    CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
                                    CellTwoHdr.Padding = 5;
                                    pdfPTable.AddCell(CellTwoHdr);
                                }
                                else if (double.TryParse(cellText, out dbvalue) || Int32.TryParse(cellText, out intvalue))
                                {
                                    PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
                                    CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
                                    CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    CellTwoHdr.Padding = 5;
                                    pdfPTable.AddCell(CellTwoHdr);
                                }
                                else
                                {
                                    PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
                                    CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
                                    CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    CellTwoHdr.Padding = 5;
                                    pdfPTable.AddCell(CellTwoHdr);
                                }
                            }
                            pdfPTable.HeaderRows = 2;
                        }

                        //var imageURL = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                        var imageURL = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath());
                        var imageURL1 = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath1());

                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                        iTextSharp.text.Image jpg1 = iTextSharp.text.Image.GetInstance(imageURL1);


                        jpg.Alignment = Element.ALIGN_CENTER;
                        //jpg.SetAbsolutePosition(30, 1075);
                        jpg.SetAbsolutePosition(20, 1560);

                        jpg1.Alignment = Element.ALIGN_RIGHT;
                        jpg1.SetAbsolutePosition(2150, 1530);

                        StringReader sr = new StringReader(sb.ToString());

                        Document pdfDoc = new Document(iTextSharp.text.PageSize.A1.Rotate(), -270f, -270f, 40f, 30f);

                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        PDFBackgroundHelper pageEventHelper = new PDFBackgroundHelper();
                        writer.PageEvent = pageEventHelper;
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Add(jpg);
                        pdfDoc.Add(jpg1);
                        pdfDoc.Add(pdfPTable);

                        //----------- FOOTER -----------
                        PdfPTable footer = new PdfPTable(2);
                        PdfPTable footer2 = new PdfPTable(2);

                        float[] cols = new float[] { 100, 300 };

                        footer.SetWidthPercentage(cols, iTextSharp.text.PageSize.A3);
                        footer2.SetWidthPercentage(cols, iTextSharp.text.PageSize.A3);

                        footer.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 130, 90, writer.DirectContent);
                        footer2.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 130, 70, writer.DirectContent);
                        //----------- /FOOTER -----------

                        pdfDoc.Close();
                        Response.ContentType = "application/pdf";

                        Response.AddHeader("content-disposition", "attachment;" + "filename=Utility_Consumption_Report_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("HH:mm:ss") + ".pdf");
                        Response.Cache.SetCacheability(HttpCacheability.NoCache);
                        Response.Write(pdfDoc);
                        Response.Flush();
                        Response.Clear();
                        Response.End();

                    }
                }
            }
            catch (Exception ex)
            {
                // log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }

            //try
            //{
            //    string text = Session[ApplicationSession.OrganisationName].ToString();
            //    string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
            //    string text2 = "Utility Consumption Report";

            //    using (StringWriter sw = new StringWriter())
            //    {
            //        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
            //        {

            //            //DateTime dtFromDateTime = Convert.ToDateTime(tempFDt); ;
            //            DateTime dtfromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            //            DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            //            StringBuilder sb = new StringBuilder();
            //            sb.Append("<div align='center' style='font-size:13px;font-weight:bold;color:Black;'>");
            //            sb.Append(text);
            //            sb.Append("</div>");
            //            sb.Append("<br/>");
            //            sb.Append("<div align='center' style='font-size:11px;font-weight:bold;color:Black;'>");
            //            sb.Append(text1);
            //            sb.Append("</div>");
            //            sb.Append("<br/>");
            //            sb.Append("<div align='center' style='font-size:15px;color:Maroon;'><b>");
            //            sb.Append(text2);
            //            sb.Append("</b></div>");
            //            sb.Append("<br/><br/><br/>");

            //            string content = "<table style='display: table;width: 900px; clear:both;'> <tr> <th colspan='4' style='float: left;padding-left: 150px;'><div align='left'><strong>From DateTime : </strong>" + dtfromDateTime + " " + "</div></th>";
            //            content += "<th style='float:left; padding-left:-180px;'></th>";
            //            content += "<th style='float:left; padding-left:-210px;'></th>";
            //            content += "<th colspan='1' align='left' style=' float: left; padding-left:-80px;'><strong> To DateTime: </strong>" +
            //            dtToDateTime + " " + "</th>" +
            //            "</tr></table>";
            //            sb.Append(content);

            //            string strDate = DateTime.UtcNow.AddHours(5.5).ToString().Replace("/", "-").Replace(" ", "-").Replace(":", "-");
            //            object filename = "Utility_Consumption_Report_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("HH:mm:ss") + ".pdf";
            //            UtilityConsumptionBl objReportBL = new UtilityConsumptionBl();

            //            ApplicationResult objDSResult = new ApplicationResult();
            //            objDSResult = new UtilityConsumptionBl().UtilityConsumptionLogReport(dtfromDateTime, dtToDateTime);

            //            ApplicationResult objResult = new ApplicationResult();
            //            objResult.ResultDt = objDSResult.ResultDt;
            //            gvUtilityConsumption.DataSource = objResult.ResultDt;
            //            gvUtilityConsumption.DataBind();

            //            if (gvUtilityConsumption.Rows.Count > 0)
            //            {
            //                iTextSharp.text.pdf.PdfPTable table = new PdfPTable(objResult.ResultDt.Columns.Count);
            //                table.PaddingTop = 5;
            //                table.SpacingBefore = 0;
            //                float[] widths = new float[objResult.ResultDt.Columns.Count];
            //                for (int x = 0; x < objResult.ResultDt.Columns.Count; x++)
            //                {
            //                    string cellText = Server.HtmlDecode(gvUtilityConsumption.HeaderRow.Cells[x].Text);
            //                    PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
            //                    CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
            //                    CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
            //                    CellTwoHdr.Padding = 5;
            //                    CellTwoHdr.BorderWidth = 1.5f;
            //                    table.AddCell(CellTwoHdr);
            //                    int maxlength = 0;
            //                    var firstSpaceIndex = cellText.IndexOf(" ");
            //                    if (firstSpaceIndex == -1)
            //                    {
            //                        maxlength = cellText.Length;
            //                    }
            //                    else
            //                    {
            //                        var firstString = cellText.Substring(0, firstSpaceIndex);
            //                        var secondString = cellText.Substring(firstSpaceIndex + 1);
            //                        if (firstString.Length > secondString.Length)
            //                        {
            //                            maxlength = firstString.Length;
            //                        }
            //                        else
            //                        {
            //                            maxlength = secondString.Length;
            //                        }
            //                    }

            //                    if (maxlength <= 18 && maxlength >= 15)
            //                    {
            //                        widths[x] = 80.00F;
            //                    }
            //                    else if (maxlength <= 15 && maxlength >= 12)
            //                    {
            //                        widths[x] = 95.00F;
            //                    }
            //                    else if (maxlength <= 12 && maxlength >= 9)
            //                    {
            //                        widths[x] = 90.00F;
            //                    }
            //                    else if (maxlength <= 8)
            //                    {
            //                        widths[x] = 80.00F;
            //                    }

            //                    else if (maxlength <= 30 && maxlength >= 19)
            //                    {
            //                        widths[x] = 80.00F;

            //                    }
            //                    table.SetWidths(widths);
            //                }

            //                for (int i = 0; i < gvUtilityConsumption.Rows.Count; i++)
            //                {
            //                    if (gvUtilityConsumption.Rows[i].RowType == DataControlRowType.DataRow)
            //                    {
            //                        for (int j = 0; j < objResult.ResultDt.Columns.Count; j++)
            //                        {
            //                            string cellText = Server.HtmlDecode(gvUtilityConsumption.Rows[i].Cells[j].Text);

            //                            DateTime dDate;
            //                            double dbvalue;
            //                            int intvalue;

            //                            if (DateTime.TryParse(cellText, out dDate))
            //                            {
            //                                PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
            //                                CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
            //                                CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
            //                                table.AddCell(CellTwoHdr);
            //                            }
            //                            else if (double.TryParse(cellText, out dbvalue) || Int32.TryParse(cellText, out intvalue))
            //                            {
            //                                PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
            //                                CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
            //                                CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
            //                                table.AddCell(CellTwoHdr);
            //                            }
            //                            else
            //                            {
            //                                PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
            //                                CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
            //                                CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
            //                                table.AddCell(CellTwoHdr);
            //                            }
            //                        }
            //                        table.HeaderRows = 1;
            //                    }
            //                }

            //                var imageURL = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath());
            //                var imageURL1 = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath1());

            //                iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
            //                iTextSharp.text.Image jpg1 = iTextSharp.text.Image.GetInstance(imageURL1);


            //                jpg.Alignment = Element.ALIGN_CENTER;
            //                //jpg.SetAbsolutePosition(30, 1075);
            //                jpg.SetAbsolutePosition(80, 1560);

            //                jpg1.Alignment = Element.ALIGN_RIGHT;
            //                jpg1.SetAbsolutePosition(2050, 1530);

            //                StringReader sr = new StringReader(sb.ToString());

            //                Document pdfDoc = new Document(iTextSharp.text.PageSize.A1.Rotate(), -200f, -200f, 40f, 30f);

            //                //   Document pdfDoc = new Document(iTextSharp.text.PageSize.A1, -40f, -40f, 20f, 30f);
            //                // pdfDoc.SetPageSize(iTextSharp.text.PageSize.A3.Rotate());
            //                HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //                PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //                PDFBackgroundHelper pageEventHelper = new PDFBackgroundHelper();
            //                writer.PageEvent = pageEventHelper;
            //                pdfDoc.Open();
            //                htmlparser.Parse(sr);
            //                pdfDoc.Add(jpg);
            //                pdfDoc.Add(jpg1);
            //                pdfDoc.Add(table);

            //                PdfPTable footer = new PdfPTable(2);
            //                PdfPTable footer2 = new PdfPTable(2);

            //                float[] cols = new float[] { 100, 300 };

            //                footer.SetWidthPercentage(cols, iTextSharp.text.PageSize.A3);
            //                footer2.SetWidthPercentage(cols, iTextSharp.text.PageSize.A3);
            //                footer.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 95, 90, writer.DirectContent);
            //                footer2.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 95, 70, writer.DirectContent);
            //                //----------- /FOOTER -----------

            //                pdfDoc.Close();
            //                Response.ContentType = "application/pdf";
            //                Response.AddHeader("content-disposition", "attachment;" + "filename=" + filename);
            //                Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //                Response.Write(pdfDoc);
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    //  log.Error("PDF Export Button", ex);
            //    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp", "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            //}
        }
        #endregion

        #region Export excel function
        protected void imgExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "Utility_Consumption_Report_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("HH:mm:ss") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvUtilityConsumption.AllowPaging = false;
                gvUtilityConsumption.GridLines = GridLines.Both;
                foreach (TableCell cell in gvUtilityConsumption.HeaderRow.Cells)
                {
                    cell.BackColor = gvUtilityConsumption.HeaderStyle.BackColor;
                    count++;
                }

                // colh for set colspan for Ornanisation Name, Adress and Report Name
                // cold for set colspan  for Date
                int colh, cold;
                int temp = 0;
                string strTh = string.Empty;

                if (count <= 9)
                {
                    temp = 9 - count;
                    count = count + temp;
                    if (temp > 1)
                    {
                        temp = 1;
                    }
                    for (int i = 0; i < temp; i++)
                    {
                        strTh = strTh + "<th></th>";
                    }

                }

                colh = count - 4;
                cold = count - 8;


                foreach (GridViewRow row in gvUtilityConsumption.Rows)
                {

                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvUtilityConsumption.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvUtilityConsumption.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                        cell.HorizontalAlign = HorizontalAlign.Center;
                        List<Control> controls = new List<Control>();

                        //Add controls to be removed to Generic List
                        foreach (Control control in cell.Controls)
                        {
                            controls.Add(control);
                        }

                        //Loop through the controls to be removed and replace then with Literal
                        foreach (Control control in controls)
                        {
                            switch (control.GetType().Name)
                            {
                                case "HyperLink":
                                    cell.Controls.Add(new Literal { Text = (control as HyperLink).Text });
                                    break;
                                case "TextBox":
                                    cell.Controls.Add(new Literal { Text = (control as TextBox).Text });
                                    break;
                                case "LinkButton":
                                    cell.Controls.Add(new Literal { Text = (control as LinkButton).Text });
                                    break;
                                case "CheckBox":
                                    cell.Controls.Add(new Literal { Text = (control as CheckBox).Text });
                                    break;
                                case "RadioButton":
                                    cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });
                                    break;
                            }
                            cell.Controls.Remove(control);
                        }
                    }
                }


                gvUtilityConsumption.RenderControl(hw);
                string strSubTitle = "Utility Consumption Report";

                string imageURL = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath());
                string imageURL1 = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath1());

                string content = "<div align='center' style='font-family:verdana;font-size:16px; width:800px;'>" +
                  "<table style='display: table; width: 800px; clear:both;'>" +
                  "<tr> </tr>" +
                  "<tr><th></th><th><img height='90' width='120' src='" + imageURL1 + "'/></th>" +
                   strTh +
                  "<th colspan='" + colh + "' style='width: 600px; float: left; font-weight:bold;font-size:16px;'>" + Session[ApplicationSession.OrganisationName] + strTh +
                  "<th><img  height= '80' width= '100' src='" + imageURL + "'/></th>" +
                     "</tr>" +
                     "<tr><th colspan='2'>'" + strTh + "'</th><th colspan='" + colh + "' style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</th></tr>" +
                     "<tr><th colspan='2'>'" + strTh + "'</th><th colspan='" + colh + "'></th></tr>" +
                     "<tr><th colspan='2'>'" + strTh + "'</th><th colspan='" + colh + "' style='font-size:22px;color:Maroon;'><b>" + strSubTitle + "</b></th></tr>" +
                     "<tr></tr>" +
                     "<tr><th colspan='4' align='left' style='width: 200px; float: left;'><strong> From Date&Time : </strong>" +
                (DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)).ToString() + "</th>" +
                "<th colspan='" + cold + "'></th>" + strTh + strTh +
                "<th colspan = '4' align = 'right' style = 'width: 200px; float: right;'><strong> To Date&Time : </strong>" +
                            (DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)).ToString() + "</th></tr>" +
                "</table>" +

                      "<br/>" + sw.ToString() + "<br/></div>";

                string style = @"<!--mce:2-->";
                Response.Write(style);
                Response.Output.Write(content);
                Response.Flush();
                Response.Clear();
                Response.End();

            }
            catch (Exception ex)
            {
                //log.Error("Button EXCEL", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }
        }
        #endregion

        #region OnClick Go button
        protected void btnGo_Click(object sender, EventArgs e)
        {
            BindUtilityConsumption();
        }
        #endregion

        #region On row created event
        protected void gvUtilityConsumption_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                    TableHeaderCell headerTableCell = new TableHeaderCell();

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Sr. No.";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Date";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Time";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "MCC1 Whey Processes (kVAh)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "MCC2 Evaporator (kVAh)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "MCC3 Dryer (kVAh)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Total Power Consumption (kVAh)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Sub PCC (kVAh)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Steam Consumption in Whey Plant (Kg)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Steam Consumption in Evaporator (Kg)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "HP Steam Consumption in Dryer (Kg)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Steam Consumption in Dryer LP (Kg)";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Total Steam Consumption (Kg)";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Chilled Water in Whey Processing Area (Ltr/day)";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Chilled Water in Powder Plant (Ltr/day)";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Chilled Water Inlet Temp (°C)";
                    headerTableCell.VerticalAlign = VerticalAlign.Middle;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Chilled Water Outlet Temp (°C)";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Average Temp (°C)";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "CHW Consumption in TR Whey Plant";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "CHW Consumption in TR PP";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Soft Water (Ltr/day)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "RO Water (Ltr/day)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Compressed Air (Nm3)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Raw Water (Ltr/day)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Powder Produced (Kg)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 10;
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "Specific Utility Cost";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.ColumnSpan = 7;
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "Utility Cost In Database";
                    headerTableCell.HorizontalAlign = HorizontalAlign.Center;
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Total Utility Cost/Day";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Utility Cost Per Kg Powder (RS)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 2;
                    headerTableCell.Text = "Remarks";
                    headerRow1.Controls.Add(headerTableCell);


                    TableHeaderCell headerCell1;
                    TableHeaderCell headerCell2;
                    TableHeaderCell headerCell3;
                    TableHeaderCell headerCell4;
                    TableHeaderCell headerCell5;
                    TableHeaderCell headerCell6;
                    TableHeaderCell headerCell7;
                    TableHeaderCell headerCell8;
                    TableHeaderCell headerCell9;
                    TableHeaderCell headerCell10;
                    TableHeaderCell headerCell11;
                    TableHeaderCell headerCell12;
                    TableHeaderCell headerCell13;
                    TableHeaderCell headerCell14;
                    TableHeaderCell headerCell15;
                    TableHeaderCell headerCell16;
                    TableHeaderCell headerCell17;


                    headerCell1 = new TableHeaderCell();
                    headerCell2 = new TableHeaderCell();
                    headerCell3 = new TableHeaderCell();
                    headerCell4 = new TableHeaderCell();
                    headerCell5 = new TableHeaderCell();
                    headerCell6 = new TableHeaderCell();
                    headerCell7 = new TableHeaderCell();
                    headerCell8 = new TableHeaderCell();
                    headerCell9 = new TableHeaderCell();
                    headerCell10 = new TableHeaderCell();
                    headerCell11 = new TableHeaderCell();
                    headerCell12 = new TableHeaderCell();
                    headerCell13 = new TableHeaderCell();
                    headerCell14 = new TableHeaderCell();
                    headerCell15 = new TableHeaderCell();
                    headerCell16 = new TableHeaderCell();
                    headerCell17 = new TableHeaderCell();

                    headerCell1.Text = "Chilled water For Whey Area";
                    headerCell2.Text = "Chilled water For PP Area";
                    headerCell3.Text = "Steam For Whey Area";
                    headerCell4.Text = "Steam For PP Area";
                    headerCell5.Text = "Power For Whey Area";
                    headerCell6.Text = "Power For PP Area";
                    headerCell7.Text = "Soft water All Plant";
                    headerCell8.Text = "RO Water All Plant";
                    headerCell9.Text = "Raw Water All Plant";
                    headerCell10.Text = "Compressed air All Plant";
                    
                    headerCell11.Text = "Chilled water /TR";
                    headerCell12.Text = "Steam/Kg";
                    headerCell13.Text = "Power/kVAh";
                    headerCell14.Text = "Soft water/Kl";
                    headerCell15.Text = "RO Water/Kl";
                    headerCell16.Text = "Raw Water/Kl";
                    headerCell17.Text = "Compressed air/Nm3";
                    
                    headerRow2.Controls.Add(headerCell1);
                    headerRow2.Controls.Add(headerCell2);
                    headerRow2.Controls.Add(headerCell3);
                    headerRow2.Controls.Add(headerCell4);
                    headerRow2.Controls.Add(headerCell5);
                    headerRow2.Controls.Add(headerCell6);
                    headerRow2.Controls.Add(headerCell7);
                    headerRow2.Controls.Add(headerCell8);
                    headerRow2.Controls.Add(headerCell9);
                    headerRow2.Controls.Add(headerCell10);
                    headerRow2.Controls.Add(headerCell11);
                    headerRow2.Controls.Add(headerCell12);
                    headerRow2.Controls.Add(headerCell13);
                    headerRow2.Controls.Add(headerCell14);
                    headerRow2.Controls.Add(headerCell15);
                    headerRow2.Controls.Add(headerCell16);
                    headerRow2.Controls.Add(headerCell17);



                    gvUtilityConsumption.Controls[0].Controls.AddAt(0, headerRow2);
                    gvUtilityConsumption.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }
        }
        #endregion
    }
}