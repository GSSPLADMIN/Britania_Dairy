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
    public partial class CrystallizationTankStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                divExport.Visible = false;
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            }

        }

        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
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
                        ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Crystallization Tank Status Report", FONT), 1190, 1665, 0);
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

        #region BindGrid
        public void CrystallizationTankStatusLog()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                CreamBufferTankBL objCreamTankStatus = new CreamBufferTankBL();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                  CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                objResult = objCreamTankStatus.CrystallizationTankStatusReport(dtFromDateTime, dtToDateTime);
                if (objResult.ResultDt.Rows.Count > 0)
                {
                    gvCrystallizationTankStatus.DataSource = objResult.ResultDt;
                    gvCrystallizationTankStatus.DataBind();
                    // imgWordButton.Visible = imgExcelButton.Visible = true;
                    divNo.Visible = false;
                    divExport.Visible = true;
                }
                else
                {
                    // imgWordButton.Visible = imgExcelButton.Visible = false;
                    divNo.Visible = true;
                    divExport.Visible = false;
                    // ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    //"<script>alert('No Record Found.');</script>");
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

        protected void gvCrystallizationTankStatus_RowCreated(object sender, GridViewRowEventArgs e)
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
                    headerTableCell.Text = "SrNo";
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
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 11;
                    headerTableCell.Text = "C11T01";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 11;
                    headerTableCell.Text = "C12T01";
                    headerRow1.Controls.Add(headerTableCell);


                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 11;
                    headerTableCell.Text = "C13T01";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 11;
                    headerTableCell.Text = "C14T01";
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
                    TableHeaderCell headerCell18;
                    TableHeaderCell headerCell19;
                    TableHeaderCell headerCell20;
                    TableHeaderCell headerCell21;
                    TableHeaderCell headerCell22;
                    TableHeaderCell headerCell23;
                    TableHeaderCell headerCell24;
                    TableHeaderCell headerCell25;
                    TableHeaderCell headerCell26;
                    TableHeaderCell headerCell27;
                    TableHeaderCell headerCell28;
                    TableHeaderCell headerCell29;
                    TableHeaderCell headerCell30;
                    TableHeaderCell headerCell31;
                    TableHeaderCell headerCell32;
                    TableHeaderCell headerCell33;
                    TableHeaderCell headerCell34;
                    TableHeaderCell headerCell35;
                    TableHeaderCell headerCell36;
                    TableHeaderCell headerCell37;
                    TableHeaderCell headerCell38;
                    TableHeaderCell headerCell39;
                    TableHeaderCell headerCell40;
                    TableHeaderCell headerCell41;
                    TableHeaderCell headerCell42;
                    TableHeaderCell headerCell43;
                    TableHeaderCell headerCell44;
                    TableHeaderCell headerCell45;






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
                    headerCell18 = new TableHeaderCell();
                    headerCell19 = new TableHeaderCell();
                    headerCell20 = new TableHeaderCell();

                    headerCell21 = new TableHeaderCell();
                    headerCell22 = new TableHeaderCell();
                    headerCell23 = new TableHeaderCell();
                    headerCell24 = new TableHeaderCell();
                    headerCell25 = new TableHeaderCell();
                    headerCell26 = new TableHeaderCell();
                    headerCell27 = new TableHeaderCell();
                    headerCell28 = new TableHeaderCell();
                    headerCell29 = new TableHeaderCell();
                    headerCell30 = new TableHeaderCell();
                    headerCell31 = new TableHeaderCell();
                    headerCell32 = new TableHeaderCell();
                    headerCell33 = new TableHeaderCell();
                    headerCell34 = new TableHeaderCell();
                    headerCell35 = new TableHeaderCell();
                    headerCell36 = new TableHeaderCell();
                    headerCell37 = new TableHeaderCell();
                    headerCell38 = new TableHeaderCell();
                    headerCell39 = new TableHeaderCell();
                    headerCell40 = new TableHeaderCell();
                    headerCell41 = new TableHeaderCell();
                    headerCell42 = new TableHeaderCell();
                    headerCell43 = new TableHeaderCell();
                    headerCell44 = new TableHeaderCell();
                   

                    headerCell1.Text = "Types of Whey";
                    headerCell2.Text = "Tank Status";
                    headerCell3.Text = "Qty (Ltrs)";
                    headerCell4.Text = "CrystallizationTankTemp (°C)";
                    headerCell5.Text = "CrystallizationTankJacketCoolingWaterTemp(°C)";
                    headerCell6.Text = "ForwardPumpSpeed(%)";
                    headerCell7.Text = "InitialTankTemp(°C)";
                    headerCell8.Text = "FinalTankTemp (°C)";
                    headerCell9.Text = "BatchTime (hr)";
                    headerCell10.Text = "Ageing timer(hr)";
                    headerCell11.Text = "Dirty timer(hr)";


                    headerCell12.Text = "Types of Whey";
                    headerCell13.Text = "Tank Status";
                    headerCell14.Text = "Qty (Ltrs)";
                    headerCell15.Text = "CrystallizationTankTemp (°C)";
                    headerCell16.Text = "CrystallizationTankJacketCoolingWaterTemp(°C)";
                    headerCell17.Text = "ForwardPumpSpeed(%)";
                    headerCell18.Text = "InitialTankTemp(°C)";
                    headerCell19.Text = "FinalTankTemp (°C)";
                    headerCell20.Text = "BatchTime (hr)";
                    headerCell21.Text = "Ageing timer(hr)";
                    headerCell22.Text = "Dirty timer(hr)";


                    headerCell23.Text = "Types of Whey";
                    headerCell24.Text = "Tank Status";
                    headerCell25.Text = "Qty (Ltrs)";
                    headerCell26.Text = "CrystallizationTankTemp (°C)";
                    headerCell27.Text = "CrystallizationTankJacketCoolingWaterTemp(°C)";
                    headerCell28.Text = "ForwardPumpSpeed(%)";
                    headerCell29.Text = "InitialTankTemp(°C)";
                    headerCell30.Text = "FinalTankTemp (°C)";
                    headerCell31.Text = "BatchTime (hr)";
                    headerCell32.Text = "Ageing timer(hr)";
                    headerCell33.Text = "Dirty timer(hr)";

                    headerCell34.Text = "Types of Whey";
                    headerCell35.Text = "Tank Status";
                    headerCell36.Text = "Qty (Ltrs)";
                    headerCell37.Text = "CrystallizationTankTemp (°C)";
                    headerCell38.Text = "CrystallizationTankJacketCoolingWaterTemp(°C)";
                    headerCell39.Text = "ForwardPumpSpeed(%)";
                    headerCell40.Text = "InitialTankTemp(°C)";
                    headerCell41.Text = "FinalTankTemp (°C)";
                    headerCell42.Text = "BatchTime (hr)";
                    headerCell43.Text = "Ageing timer(hr)";
                    headerCell44.Text = "Dirty timer(hr)";

                    //headerCell25.Text = "Curd Breaking Time(min)";
                    //headerCell26.Text = "Ageing Time(hr)";
                    //headerCell27.Text = "CIP Time(hr)";
                    //headerCell28.Text = "QC Released Time";








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
                    headerRow2.Controls.Add(headerCell18);
                    headerRow2.Controls.Add(headerCell19);
                    headerRow2.Controls.Add(headerCell20);

                    headerRow2.Controls.Add(headerCell21);
                    headerRow2.Controls.Add(headerCell22);
                    headerRow2.Controls.Add(headerCell23);
                    headerRow2.Controls.Add(headerCell24);
                    headerRow2.Controls.Add(headerCell25);
                    headerRow2.Controls.Add(headerCell26);
                    headerRow2.Controls.Add(headerCell27);
                    headerRow2.Controls.Add(headerCell28);
                    headerRow2.Controls.Add(headerCell29);
                    headerRow2.Controls.Add(headerCell30);
                    headerRow2.Controls.Add(headerCell31);
                    headerRow2.Controls.Add(headerCell32);
                    headerRow2.Controls.Add(headerCell33);
                    headerRow2.Controls.Add(headerCell34);
                    headerRow2.Controls.Add(headerCell35);
                    headerRow2.Controls.Add(headerCell36);
                    headerRow2.Controls.Add(headerCell37);
                    headerRow2.Controls.Add(headerCell38);
                    headerRow2.Controls.Add(headerCell39);
                    headerRow2.Controls.Add(headerCell40);
                    headerRow2.Controls.Add(headerCell41);
                    headerRow2.Controls.Add(headerCell42);
                    headerRow2.Controls.Add(headerCell43);
                    headerRow2.Controls.Add(headerCell44);
                  


                    gvCrystallizationTankStatus.Controls[0].Controls.AddAt(0, headerRow2);
                    gvCrystallizationTankStatus.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }

        }

        protected void gvCrystallizationTankStatus_PreRender(object sender, EventArgs e)
        {

        }

        protected void imgPDFButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Session[ApplicationSession.OrganisationName].ToString();
                string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                string text2 = "Crystallization Tank Status Report";

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
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

                        string content = "<table style='display: table;width: 900px; clear:both;'> <tr> <th colspan='4' style='float: left;padding-left: 275px;'><div align='left'><strong>From Date: </strong>" + txtFromDate.Text +" "+txtFromTime.Text+ "</div></th>";

                        content += "<th style='float:left; padding-left:-180px;'></th>";

                        content += "<th style='float:left; padding-left:-210px;'></th>";

                        content += "<th colspan='1' align='left' style=' float: left; padding-left:-180px;'><strong> To Date: </strong>" +
                        txtToDate.Text +" "+txtToTime.Text +"</th>" +
                        "</tr></table>";
                        sb.Append(content);
                        sb.Append("<br/>");

                        PdfPTable pdfPTable = new PdfPTable(gvCrystallizationTankStatus.HeaderRow.Cells.Count);
                        iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);



                        PdfPCell headerCel20 = new PdfPCell(new Phrase("Sr No"));
                        headerCel20.Rowspan = 2;
                        headerCel20.Colspan = 1;
                        headerCel20.Padding = 5;
                        headerCel20.BorderWidth = 1.5f;
                        headerCel20.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCel20.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCel20);

                        PdfPCell headerCell = new PdfPCell(new Phrase("Date"));
                        headerCell.Rowspan = 2;
                        headerCell.Colspan = 1;
                        headerCell.Padding = 5;
                        headerCell.BorderWidth = 1.5f;
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell);

                        PdfPCell headerCell1 = new PdfPCell(new Phrase("Time"));
                        headerCell1.Rowspan = 2;
                        headerCell1.Colspan = 1;
                        headerCell1.Padding = 5;
                        headerCell1.BorderWidth = 1.5f;
                        headerCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell1);

                        PdfPCell headerCell2 = new PdfPCell(new Phrase("C11T01"));
                        headerCell2.Rowspan = 1;
                        headerCell2.Colspan = 11;
                        headerCell2.Padding = 5;
                        headerCell2.BorderWidth = 1.5f;
                        headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell2);

                        PdfPCell headerCell3 = new PdfPCell(new Phrase("C12T01"));
                        headerCell3.Rowspan = 1;
                        headerCell3.Colspan = 11;
                        headerCell3.Padding = 5;
                        headerCell3.BorderWidth = 1.5f;
                        headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell3);

                        PdfPCell headerCell4 = new PdfPCell(new Phrase("C13T01"));
                       headerCell4.Rowspan = 1;
                       headerCell4.Colspan = 11;
                       headerCell4.Padding = 5;
                       headerCell4.BorderWidth = 1.5f;
                        headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell4);


                        PdfPCell headerCell5 = new PdfPCell(new Phrase("C14T01"));
                        headerCell5.Rowspan = 1;
                        headerCell5.Colspan = 11;
                        headerCell5.Padding = 5;
                        headerCell5.BorderWidth = 1.5f;
                        headerCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell5);






                        PdfPCell headerCell8 = new PdfPCell(new Phrase("Types Of Whey"));
                        headerCell8.Rowspan = 1;
                        headerCell8.Colspan = 1;
                        headerCell8.Padding = 5;
                        headerCell8.BorderWidth = 1.5f;
                        headerCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell8);


                        PdfPCell headerCell9 = new PdfPCell(new Phrase("Tank Status"));
                        headerCell9.Rowspan = 1;
                        headerCell9.Colspan = 1;
                        headerCell9.Padding = 5;
                        headerCell9.BorderWidth = 1.5f;
                        headerCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell9);

                        PdfPCell headerCell10 = new PdfPCell(new Phrase("Qty(Ltrs)"));
                        headerCell10.Rowspan = 1;
                        headerCell10.Colspan = 1;
                        headerCell10.Padding = 5;
                        headerCell10.BorderWidth = 1.5f;
                        headerCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell10);

                        PdfPCell headerCell11 = new PdfPCell(new Phrase("CrystallizationTankTemp (°C)"));
                        headerCell11.Rowspan = 1;
                        headerCell11.Colspan = 1;
                        headerCell11.Padding = 5;
                        headerCell11.BorderWidth = 1.5f;
                        headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell11);

                        PdfPCell headerCell12 = new PdfPCell(new Phrase("CrystallizationTankJacketCoolingWaterTemp(°C)"));
                        headerCell12.Rowspan = 1;
                        headerCell12.Colspan = 1;
                        headerCell12.Padding = 5;
                        headerCell12.BorderWidth = 1.5f;
                        headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell12);

                        PdfPCell headerCell13 = new PdfPCell(new Phrase("ForwardPumpSpeed(%)"));
                        headerCell13.Rowspan = 1;
                        headerCell13.Colspan = 1;
                        headerCell13.Padding = 5;
                        headerCell13.BorderWidth = 1.5f;
                        headerCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell13);



                        PdfPCell headerCell16 = new PdfPCell(new Phrase("InitialTankTemp (°C)"));
                        headerCell16.Rowspan = 1;
                        headerCell16.Colspan = 1;
                        headerCell16.Padding = 5;
                        headerCell16.BorderWidth = 1.5f;
                        headerCell16.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell16.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell16);

                        PdfPCell headerCell17 = new PdfPCell(new Phrase("FinalTankTemp (°C)"));
                        headerCell17.Rowspan = 1;
                        headerCell17.Colspan = 1;
                        headerCell17.Padding = 5;
                        headerCell17.BorderWidth = 1.5f;
                        headerCell17.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell17.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell17);

                        PdfPCell headerCell18 = new PdfPCell(new Phrase("BatchTimer (hr)"));
                        headerCell18.Rowspan = 1;
                        headerCell18.Colspan = 1;
                        headerCell18.Padding = 5;
                        headerCell18.BorderWidth = 1.5f;
                        headerCell18.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell18.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell18);

                        PdfPCell headerCell19 = new PdfPCell(new Phrase("AgeingTimer (hr)"));
                        headerCell19.Rowspan = 1;
                        headerCell19.Colspan = 1;
                        headerCell19.Padding = 5;
                        headerCell19.BorderWidth = 1.5f;
                        headerCell19.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell19.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell19);



                        PdfPCell headerCell20 = new PdfPCell(new Phrase("Dirty Time(hr)"));
                        headerCell20.Rowspan = 1;
                        headerCell20.Colspan = 1;
                        headerCell20.Padding = 5;
                        headerCell20.BorderWidth = 1.5f;
                        headerCell20.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell20.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell20);



                        PdfPCell headerCell21 = new PdfPCell(new Phrase("Types Of Whey"));
                        headerCell21.Rowspan = 1;
                        headerCell21.Colspan = 1;
                        headerCell21.Padding = 5;
                        headerCell21.BorderWidth = 1.5f;
                        headerCell21.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell21.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell21);

                        PdfPCell headerCell22 = new PdfPCell(new Phrase("TankStatus"));
                        headerCell22.Rowspan = 1;
                        headerCell22.Colspan = 1;
                        headerCell22.Padding = 5;
                        headerCell22.BorderWidth = 1.5f;
                        headerCell22.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell22.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell22);

                        PdfPCell headerCell23 = new PdfPCell(new Phrase("Qty(Ltrs)"));
                        headerCell23.Rowspan = 1;
                        headerCell23.Colspan = 1;
                        headerCell23.Padding = 5;
                        headerCell23.BorderWidth = 1.5f;
                        headerCell23.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell23.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell23);

                        PdfPCell headerCell24 = new PdfPCell(new Phrase("CrystallizationTankTemp(°C)"));
                        headerCell24.Rowspan = 1;
                        headerCell24.Colspan = 1;
                        headerCell24.Padding = 5;
                        headerCell24.BorderWidth = 1.5f;
                        headerCell24.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell24.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell24);



                        PdfPCell headerCell25 = new PdfPCell(new Phrase("CrystallizationTankJacketCoolingWaterTemp (°C)"));
                        headerCell25.Rowspan = 1;
                        headerCell25.Colspan = 1;
                        headerCell25.Padding = 5;
                        headerCell25.BorderWidth = 1.5f;
                        headerCell25.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell25.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell25);



                        PdfPCell headerCell26 = new PdfPCell(new Phrase("ForwardPumpSpeed (%)"));
                        headerCell26.Rowspan = 1;
                        headerCell26.Colspan = 1;
                        headerCell26.Padding = 5;
                        headerCell26.BorderWidth = 1.5f;
                        headerCell26.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell26.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell26);

                        PdfPCell headerCell27 = new PdfPCell(new Phrase("InitialTankTemp(°C) "));
                        headerCell27.Rowspan = 1;
                        headerCell27.Colspan = 1;
                        headerCell27.Padding = 5;
                        headerCell27.BorderWidth = 1.5f;
                        headerCell27.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell27.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell27);

                        PdfPCell headerCell28 = new PdfPCell(new Phrase("FinalTankTemp(°C)"));
                        headerCell28.Rowspan = 1;
                        headerCell28.Colspan = 1;
                        headerCell28.Padding = 5;
                        headerCell28.BorderWidth = 1.5f;
                        headerCell28.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell28.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell28);

                        PdfPCell headerCell29 = new PdfPCell(new Phrase("Batch Time(hr)"));
                        headerCell29.Rowspan = 1;
                        headerCell29.Colspan = 1;
                        headerCell29.Padding = 5;
                        headerCell29.BorderWidth = 1.5f;
                        headerCell29.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell29.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell29);


                        PdfPCell headerCell30 = new PdfPCell(new Phrase("Ageing Time(hr)"));
                       headerCell30.Rowspan = 1;
                       headerCell30.Colspan = 1;
                       headerCell30.Padding = 5;
                       headerCell30.BorderWidth = 1.5f;
                       headerCell30.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell30.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell30);

                        PdfPCell headerCell31 = new PdfPCell(new Phrase("Dirty Time(hr)"));
                       headerCell31.Rowspan = 1;
                       headerCell31.Colspan = 1;
                       headerCell31.Padding = 5;
                       headerCell31.BorderWidth = 1.5f;
                       headerCell31.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell31.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell31);

                        PdfPCell headerCell32 = new PdfPCell(new Phrase("Types Of Whey"));
                        headerCell32.Rowspan = 1;
                        headerCell32.Colspan = 1;
                        headerCell32.Padding = 5;
                        headerCell32.BorderWidth = 1.5f;
                        headerCell32.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell32.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell32);

                        PdfPCell headerCell33 = new PdfPCell(new Phrase("TankStatus"));
                       headerCell33.Rowspan = 1;
                       headerCell33.Colspan = 1;
                       headerCell33.Padding = 5;
                       headerCell33.BorderWidth = 1.5f;
                       headerCell33.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell33.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell33);

                        PdfPCell headerCell34 = new PdfPCell(new Phrase("Qty(Ltrs)"));
                        headerCell34.Rowspan = 1;
                        headerCell34.Colspan = 1;
                        headerCell34.Padding = 5;
                        headerCell34.BorderWidth = 1.5f;
                        headerCell34.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell34.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell34);

                        PdfPCell headerCell35 = new PdfPCell(new Phrase("CrystallizationTankTemp(°C)"));
                        headerCell35.Rowspan = 1;
                        headerCell35.Colspan = 1;
                        headerCell35.Padding = 5;
                        headerCell35.BorderWidth = 1.5f;
                        headerCell35.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell35.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell35);



                        PdfPCell headerCell36 = new PdfPCell(new Phrase("CrystallizationTankJacketCoolingWaterTemp (°C)"));
                       headerCell36.Rowspan = 1;
                       headerCell36.Colspan = 1;
                       headerCell36.Padding = 5;
                       headerCell36.BorderWidth = 1.5f;
                       headerCell36.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell36.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell36);



                        PdfPCell headerCell37 = new PdfPCell(new Phrase("ForwardPumpSpeed (%)"));
                        headerCell37.Rowspan = 1;
                        headerCell37.Colspan = 1;
                        headerCell37.Padding = 5;
                        headerCell37.BorderWidth = 1.5f;
                        headerCell37.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell37.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell37);

                        PdfPCell headerCell38 = new PdfPCell(new Phrase("InitialTankTemp(°C) "));
                        headerCell38.Rowspan = 1;
                        headerCell38.Colspan = 1;
                        headerCell38.Padding = 5;
                        headerCell38.BorderWidth = 1.5f;
                        headerCell38.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell38.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell38);

                        PdfPCell headerCell39 = new PdfPCell(new Phrase("FinalTankTemp(°C)"));
                        headerCell39.Rowspan = 1;
                        headerCell39.Colspan = 1;
                        headerCell39.Padding = 5;
                        headerCell39.BorderWidth = 1.5f;
                        headerCell39.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell39.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell39);

                        PdfPCell headerCell40 = new PdfPCell(new Phrase("Batch Time(hr)"));
                        headerCell40.Rowspan = 1;
                        headerCell40.Colspan = 1;
                        headerCell40.Padding = 5;
                        headerCell40.BorderWidth = 1.5f;
                        headerCell40.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell40.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell40);


                        PdfPCell headerCell41 = new PdfPCell(new Phrase("Ageing Time(hr)"));
                        headerCell41.Rowspan = 1;
                        headerCell41.Colspan = 1;
                        headerCell41.Padding = 5;
                        headerCell41.BorderWidth = 1.5f;
                        headerCell41.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell41.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell41);

                        PdfPCell headerCell42 = new PdfPCell(new Phrase("Dirty Time(hr)"));
                        headerCell42.Rowspan = 1;
                        headerCell42.Colspan = 1;
                        headerCell42.Padding = 5;
                        headerCell42.BorderWidth = 1.5f;
                        headerCell42.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell42.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell42);

                        PdfPCell headerCell43 = new PdfPCell(new Phrase("Types Of Whey"));
                        headerCell43.Rowspan = 1;
                        headerCell43.Colspan = 1;
                        headerCell43.Padding = 5;
                        headerCell43.BorderWidth = 1.5f;
                        headerCell43.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell43.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell43);

                        PdfPCell headerCell44 = new PdfPCell(new Phrase("TankStatus"));
                       headerCell44.Rowspan = 1;
                       headerCell44.Colspan = 1;
                       headerCell44.Padding = 5;
                       headerCell44.BorderWidth = 1.5f;
                       headerCell44.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell44.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell44);

                        PdfPCell headerCell45 = new PdfPCell(new Phrase("Qty(Ltrs)"));
                        headerCell45.Rowspan = 1;
                        headerCell45.Colspan = 1;
                        headerCell45.Padding = 5;
                        headerCell45.BorderWidth = 1.5f;
                        headerCell45.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell45.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell45);

                        PdfPCell headerCell46 = new PdfPCell(new Phrase("CrystallizationTankTemp(°C)"));
                        headerCell46.Rowspan = 1;
                        headerCell46.Colspan = 1;
                        headerCell46.Padding = 5;
                        headerCell46.BorderWidth = 1.5f;
                        headerCell46.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell46.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell46);



                        PdfPCell headerCell47 = new PdfPCell(new Phrase("CrystallizationTankJacketCoolingWaterTemp (°C)"));
                        headerCell47.Rowspan = 1;
                        headerCell47.Colspan = 1;
                        headerCell47.Padding = 5;
                        headerCell47.BorderWidth = 1.5f;
                        headerCell47.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell47.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell47);



                        PdfPCell headerCell48 = new PdfPCell(new Phrase("ForwardPumpSpeed (%)"));
                        headerCell48.Rowspan = 1;
                        headerCell48.Colspan = 1;
                        headerCell48.Padding = 5;
                        headerCell48.BorderWidth = 1.5f;
                        headerCell48.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell48.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell48);

                        PdfPCell headerCell49 = new PdfPCell(new Phrase("InitialTankTemp(°C) "));
                        headerCell49.Rowspan = 1;
                        headerCell49.Colspan = 1;
                        headerCell49.Padding = 5;
                        headerCell49.BorderWidth = 1.5f;
                        headerCell49.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell49.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell49);

                        PdfPCell headerCell50 = new PdfPCell(new Phrase("FinalTankTemp(°C)"));
                        headerCell50.Rowspan = 1;
                        headerCell50.Colspan = 1;
                        headerCell50.Padding = 5;
                        headerCell50.BorderWidth = 1.5f;
                        headerCell50.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell50.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell50);

                        PdfPCell headerCell51 = new PdfPCell(new Phrase("Batch Time(hr)"));
                        headerCell51.Rowspan = 1;
                        headerCell51.Colspan = 1;
                        headerCell51.Padding = 5;
                        headerCell51.BorderWidth = 1.5f;
                        headerCell51.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell51.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell51);


                        PdfPCell headerCell52 = new PdfPCell(new Phrase("Ageing Time(hr)"));
                        headerCell52.Rowspan = 1;
                        headerCell52.Colspan = 1;
                        headerCell52.Padding = 5;
                        headerCell52.BorderWidth = 1.5f;
                        headerCell52.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell52.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell52);

                        PdfPCell headerCell53 = new PdfPCell(new Phrase("Dirty Time(hr)"));
                        headerCell53.Rowspan = 1;
                        headerCell53.Colspan = 1;
                        headerCell53.Padding = 5;
                        headerCell53.BorderWidth = 1.5f;
                        headerCell53.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell53.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell53);


                        float[] widthsTAS = { 90f,90f, 90f, 90f, 90f, 90f, 90f, 90f, 90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,90f,
                        90f,90f,90f

                        };
                        pdfPTable.SetWidths(widthsTAS);



                        foreach (GridViewRow gridViewRow in gvCrystallizationTankStatus.Rows)
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
                        jpg.SetAbsolutePosition(80, 1560);

                        jpg1.Alignment = Element.ALIGN_RIGHT;
                        jpg1.SetAbsolutePosition(2050, 1530);

                        StringReader sr = new StringReader(sb.ToString());

                        Document pdfDoc = new Document(iTextSharp.text.PageSize.A1.Rotate(), -200f, -200f, 40f, 30f);

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

                        Response.AddHeader("content-disposition", "attachment;" + "filename=Crystallization_Tank_Status_Report_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("HH:mm:ss") + ".pdf");
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

        }

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
                string filename = "Crystallization_Tank_Status_Report_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("HH:mm:ss") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvCrystallizationTankStatus.AllowPaging = false;
                gvCrystallizationTankStatus.GridLines = GridLines.Both;
                foreach (TableCell cell in gvCrystallizationTankStatus.HeaderRow.Cells)
                {
                    cell.BackColor = gvCrystallizationTankStatus.HeaderStyle.BackColor;
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


                foreach (GridViewRow row in gvCrystallizationTankStatus.Rows)
                {

                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvCrystallizationTankStatus.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvCrystallizationTankStatus.RowStyle.BackColor;
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


                gvCrystallizationTankStatus.RenderControl(hw);
                string strSubTitle = "Crystallization Tank Status Report";

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

        protected void btnGo_Click(object sender, EventArgs e)
        {
            CrystallizationTankStatusLog();
        }
    }
}