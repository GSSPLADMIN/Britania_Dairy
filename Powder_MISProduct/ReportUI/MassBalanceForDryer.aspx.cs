using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using Powder_MISProduct.BL;
using Powder_MISProduct.Common;
using System.IO;
using System.Text;
using iTextSharp;
using iTextSharp.text.pdf;
using System.Drawing;
using iTextSharp.text;
using Font = iTextSharp.text.Font;
using iTextSharp.text.html.simpleparser;
using System.Globalization;

namespace Powder_MISProduct.ReportUI
{
    public partial class MassBalanceForDryer : System.Web.UI.Page
    {
        /// <summary>
        /// Created By: Farheen
        /// Created Date: 08 July'22
        /// Description: Mass balance for dryer report.
        /// </summary>
        
        private static ILog log = LogManager.GetLogger(typeof(MassBalanceWhey));
        //private Microsoft.Office.Interop.Excel.Application excelApp;
        #region Page load event
        protected void Page_Load(object sender, EventArgs e)
        {
            divExport.Visible = false;
            divNo.Visible = false;
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            }
        }
        #endregion

        #region GridView row-created event

        protected void gvMassBalanceReport_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableHeaderCell headerTableCell = new TableHeaderCell();

                // Code for headerRow1
                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 1;
                headerTableCell.ColumnSpan = 6;
                headerTableCell.Text = "Opening Stock";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 1;
                headerTableCell.ColumnSpan = 6;
                headerTableCell.Text = "Milk Received";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 1;
                headerTableCell.ColumnSpan = 6;
                headerTableCell.Text = "Other Inputs";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 6;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "Dispatch";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 6;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "Closing";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                // Sub header start Here (headerRow2)


                // Code for headerRow3
                TableHeaderCell headerCell1 = new TableHeaderCell();
                TableHeaderCell headerCell2 = new TableHeaderCell();
                TableHeaderCell headerCell3 = new TableHeaderCell();
                TableHeaderCell headerCell4 = new TableHeaderCell();
                TableHeaderCell headerCell5 = new TableHeaderCell();
                TableHeaderCell headerCell6 = new TableHeaderCell();
                TableHeaderCell headerCell7 = new TableHeaderCell();
                TableHeaderCell headerCell8 = new TableHeaderCell();
                TableHeaderCell headerCell9 = new TableHeaderCell();
                TableHeaderCell headerCell10 = new TableHeaderCell();
                TableHeaderCell headerCell11 = new TableHeaderCell();
                TableHeaderCell headerCell12 = new TableHeaderCell();
                TableHeaderCell headerCell13 = new TableHeaderCell();
                TableHeaderCell headerCell14 = new TableHeaderCell();
                TableHeaderCell headerCell15 = new TableHeaderCell();
                TableHeaderCell headerCell16 = new TableHeaderCell();
                TableHeaderCell headerCell17 = new TableHeaderCell();
                TableHeaderCell headerCell18 = new TableHeaderCell();
                TableHeaderCell headerCell19 = new TableHeaderCell();
                TableHeaderCell headerCell20 = new TableHeaderCell();
                TableHeaderCell headerCell21 = new TableHeaderCell();
                TableHeaderCell headerCell22 = new TableHeaderCell();
                TableHeaderCell headerCell23 = new TableHeaderCell();
                TableHeaderCell headerCell24 = new TableHeaderCell();
                TableHeaderCell headerCell25 = new TableHeaderCell();
                TableHeaderCell headerCell26 = new TableHeaderCell();
                TableHeaderCell headerCell27 = new TableHeaderCell();
                TableHeaderCell headerCell28 = new TableHeaderCell();
                TableHeaderCell headerCell29 = new TableHeaderCell();
                TableHeaderCell headerCell30 = new TableHeaderCell();

                // Sub Header for Opening
                headerCell1.Text = "Equipment";
                headerCell2.Text = "Qty (Kg)";
                headerCell3.Text = "Fat (%)";
                headerCell4.Text = "Fat (Kg)";
                headerCell5.Text = "SNF (%)";
                headerCell6.Text = "SNF (Kg)";

                // Sub Header for Receipt
                headerCell7.Text = "Equipment";
                headerCell8.Text = "Qty (Kg)";
                headerCell9.Text = "Fat (%)";
                headerCell10.Text = "Fat (Kg)";
                headerCell11.Text = "SNF (%)";
                headerCell12.Text = "SNF (Kg)";

                // Sub Header for Other Inputs
                headerCell13.Text = "Equipment";
                headerCell14.Text = "Qty (Kg)";
                headerCell15.Text = "Fat (%)";
                headerCell16.Text = "Fat (Kg)";
                headerCell17.Text = "SNF (%)";
                headerCell18.Text = "SNF (Kg)";

                // Sub Header for Dispatch
                headerCell19.Text = "Equipment";
                headerCell20.Text = "Qty (Kg)";
                headerCell21.Text = "Fat (%)";
                headerCell22.Text = "Fat (Kg)";
                headerCell23.Text = "SNF (%)";
                headerCell24.Text = "SNF (Kg)";


                // Sub Header for Closing
                headerCell25.Text = "Equipment";
                headerCell26.Text = "Qty (Kg)";
                headerCell27.Text = "Fat (%)";
                headerCell28.Text = "Fat (Kg)";
                headerCell29.Text = "SNF (%)";
                headerCell30.Text = "SNF (Kg)";

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

                gvMassBalanceReport.Controls[0].Controls.AddAt(0, headerRow2);
                gvMassBalanceReport.Controls[0].Controls.AddAt(0, headerRow1);

            }
        }

        protected void gvTotal_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableHeaderCell headerTableCell = new TableHeaderCell();

                // Code for headerRow1
                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 1;
                headerTableCell.ColumnSpan = 1;
                headerTableCell.Text = "Plant Mass Balance For Dryer";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 1;
                headerTableCell.ColumnSpan = 1;
                headerTableCell.Text = "Units (Kg)";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 1;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "Fat (Kg)";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 1;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "SNF (Kg)";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 1;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "TS";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);


                gvTotal.Controls[0].Controls.AddAt(0, headerRow1);
            }
        }

        #endregion
        
        #region Export to PDF Button Click
        protected void imgbtnPDF_OnClick(object sender, EventArgs e)
        {
            try
            {
                string text = Session[ApplicationSession.OrganisationName].ToString();
                string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                string text2 = "Performance Qualification Report - Mass Balance Of Dryer";

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
                            + "style='float: left;padding-left: 275px;'><div align='left'><strong>From Date : </strong>" +
                            dtfromDateTime + "</div></th>";

                        content += "<th style='float:left; padding-left:-180px;'></th>";

                        content += "<th style='float:left; padding-left:-210px;'></th>";

                        content += "<th colspan='1' align='left' style=' float: left; padding-left:-200px;'><strong> To DateTime: </strong>" +
                        dtToDateTime + "</th>" +
                        "</tr></table>";
                        sb.Append(content);
                        sb.Append("<br/>");

                        PdfPTable pdfPTable = new PdfPTable(gvMassBalanceReport.HeaderRow.Cells.Count);
                        PdfPTable pdfPTable1 = new PdfPTable(gvTotal.HeaderRow.Cells.Count);
                        iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);
                        //TableCell headerCell = new TableCell();
                        Font header = new Font(Font.FontFamily.TIMES_ROMAN, 15f, Font.BOLD, BaseColor.BLACK);

                        PdfPCell headerCell1 = new PdfPCell(new Phrase("Opening Stock", header));
                        headerCell1.Rowspan = 1;
                        headerCell1.Colspan = 6;
                        headerCell1.Padding = 5;
                        //headerCell1.BorderWidth = 1.5f;
                        headerCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell1);

                        PdfPCell headerCell2 = new PdfPCell(new Phrase("Milk Received", header));
                        headerCell2.Rowspan = 1;
                        headerCell2.Colspan = 6;
                        headerCell2.Padding = 5;
                        //headerCell2.BorderWidth = 1.5f;
                        headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell2);

                        PdfPCell headerCell3 = new PdfPCell(new Phrase("Other Inputs", header));
                        headerCell3.Rowspan = 1;
                        headerCell3.Colspan = 6;
                        headerCell3.Padding = 5;
                        //headerCell3.BorderWidth = 1.5f;
                        headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell3);

                        PdfPCell headerCell4 = new PdfPCell(new Phrase("Dispatch", header));
                        headerCell4.Rowspan = 1;
                        headerCell4.Colspan = 6;
                        headerCell4.Padding = 5;
                        //headerCell4.BorderWidth = 1.5f;
                        headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell4);

                        PdfPCell headerCell35 = new PdfPCell(new Phrase("Closing", header));
                        headerCell35.Rowspan = 1;
                        headerCell35.Colspan = 6;
                        headerCell35.Padding = 5;
                        //headerCell35.BorderWidth = 1.5f;
                        headerCell35.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell35.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell35);

                        //Sub-headers of Opening
                        PdfPCell headerCell5 = new PdfPCell(new Phrase("Equipment", header));
                        headerCell5.Rowspan = 1;
                        headerCell5.Colspan = 1;
                        headerCell5.Padding = 5;
                        // headerCell5.BorderWidth = 1.5f;
                        headerCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell5);

                        PdfPCell headerCell6 = new PdfPCell(new Phrase("Qty (kg)", header));
                        headerCell6.Rowspan = 1;
                        headerCell6.Colspan = 1;
                        headerCell6.Padding = 5;
                        // headerCell6.BorderWidth = 1.5f;
                        headerCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell6);

                        PdfPCell headerCell7 = new PdfPCell(new Phrase("Fat (%)", header));
                        headerCell7.Rowspan = 1;
                        headerCell7.Colspan = 1;
                        headerCell7.Padding = 5;
                        //headerCell7.BorderWidth = 1.5f;
                        headerCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell7.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell7);

                        PdfPCell headerCell8 = new PdfPCell(new Phrase("SNF (%)", header));
                        headerCell8.Rowspan = 1;
                        headerCell8.Colspan = 1;
                        headerCell8.Padding = 5;
                        //headerCell8.BorderWidth = 1.5f;
                        headerCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell8.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell8);

                        PdfPCell headerCell9 = new PdfPCell(new Phrase("Fat (Kg)", header));
                        headerCell9.Rowspan = 1;
                        headerCell9.Colspan = 1;
                        headerCell9.Padding = 5;
                        //headerCell9.BorderWidth = 1.5f;
                        headerCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell9.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell9);

                        PdfPCell headerCell10 = new PdfPCell(new Phrase("SNF (Kg)", header));
                        headerCell10.Rowspan = 1;
                        headerCell10.Colspan = 1;
                        headerCell10.Padding = 5;
                        //headerCell10.BorderWidth = 1.5f;
                        headerCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell10.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell10);

                        //Sub-headers of Receipt
                        PdfPCell headerCell11 = new PdfPCell(new Phrase("Equipment", header));
                        headerCell11.Rowspan = 1;
                        headerCell11.Colspan = 1;
                        headerCell11.Padding = 5;
                        //headerCell11.BorderWidth = 1.5f;
                        headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell11.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell11);

                        PdfPCell headerCell12 = new PdfPCell(new Phrase("Qty (kg)", header));
                        headerCell12.Rowspan = 1;
                        headerCell12.Colspan = 1;
                        headerCell12.Padding = 5;
                        //headerCell12.BorderWidth = 1.5f;
                        headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell12);

                        PdfPCell headerCell13 = new PdfPCell(new Phrase("Fat (%)", header));
                        headerCell13.Rowspan = 1;
                        headerCell13.Colspan = 1;
                        headerCell13.Padding = 5;
                        //headerCell13.BorderWidth = 1.5f;
                        headerCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell13);

                        PdfPCell headerCell14 = new PdfPCell(new Phrase("SNF (%)", header));
                        headerCell14.Rowspan = 1;
                        headerCell14.Colspan = 1;
                        headerCell14.Padding = 5;
                        //headerCell14.BorderWidth = 1.5f;
                        headerCell14.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell14.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell14);

                        PdfPCell headerCell15 = new PdfPCell(new Phrase("Fat (Kg)", header));
                        headerCell15.Rowspan = 1;
                        headerCell15.Colspan = 1;
                        headerCell15.Padding = 5;
                        //headerCell15.BorderWidth = 1.5f;
                        headerCell15.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell15.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell15);

                        PdfPCell headerCell16 = new PdfPCell(new Phrase("SNF (Kg)", header));
                        headerCell16.Rowspan = 1;
                        headerCell16.Colspan = 1;
                        headerCell16.Padding = 5;
                        //headerCell16.BorderWidth = 1.5f;
                        headerCell16.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell16.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell16);

                        //Sub-headers of Other Inputs
                        PdfPCell headerCell17 = new PdfPCell(new Phrase("Equipment", header));
                        headerCell17.Rowspan = 1;
                        headerCell17.Colspan = 1;
                        headerCell17.Padding = 5;
                        //headerCell17.BorderWidth = 1.5f;
                        headerCell17.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell17.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell17);

                        PdfPCell headerCell18 = new PdfPCell(new Phrase("Qty (kg)", header));
                        headerCell18.Rowspan = 1;
                        headerCell18.Colspan = 1;
                        headerCell18.Padding = 5;
                        //headerCell18.BorderWidth = 1.5f;
                        headerCell18.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell18.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell18);

                        PdfPCell headerCell19 = new PdfPCell(new Phrase("Fat (%)", header));
                        headerCell19.Rowspan = 1;
                        headerCell19.Colspan = 1;
                        headerCell19.Padding = 5;
                        //headerCell19.BorderWidth = 1.5f;
                        headerCell19.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell19.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell19);

                        PdfPCell headerCell20 = new PdfPCell(new Phrase("SNF (%)", header));
                        headerCell20.Rowspan = 1;
                        headerCell20.Colspan = 1;
                        headerCell20.Padding = 5;
                        //headerCell20.BorderWidth = 1.5f;
                        headerCell20.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell20.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell20);

                        PdfPCell headerCell21 = new PdfPCell(new Phrase("Fat (Kg)", header));
                        headerCell21.Rowspan = 1;
                        headerCell21.Colspan = 1;
                        headerCell21.Padding = 5;
                        //headerCell21.BorderWidth = 1.5f;
                        headerCell21.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell21.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell21);

                        PdfPCell headerCell22 = new PdfPCell(new Phrase("SNF (Kg)", header));
                        headerCell22.Rowspan = 1;
                        headerCell22.Colspan = 1;
                        headerCell22.Padding = 5;
                        //headerCell22.BorderWidth = 1.5f;
                        headerCell22.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell22.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell22);

                        //Sub-headers of Dispatch
                        PdfPCell headerCell23 = new PdfPCell(new Phrase("Equipment", header));
                        headerCell23.Rowspan = 1;
                        headerCell23.Colspan = 1;
                        headerCell23.Padding = 5;
                        //headerCell23.BorderWidth = 1.5f;
                        headerCell23.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell23.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell23);

                        PdfPCell headerCell24 = new PdfPCell(new Phrase("Qty (kg)", header));
                        headerCell24.Rowspan = 1;
                        headerCell24.Colspan = 1;
                        headerCell24.Padding = 5;
                        //headerCell24.BorderWidth = 1.5f;
                        headerCell24.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell24.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell24);

                        PdfPCell headerCell25 = new PdfPCell(new Phrase("Fat (%)", header));
                        headerCell25.Rowspan = 1;
                        headerCell25.Colspan = 1;
                        headerCell25.Padding = 5;
                        //headerCell25.BorderWidth = 1.5f;
                        headerCell25.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell25.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell25);

                        PdfPCell headerCell26 = new PdfPCell(new Phrase("SNF (%)", header));
                        headerCell26.Rowspan = 1;
                        headerCell26.Colspan = 1;
                        headerCell26.Padding = 5;
                        //headerCell26.BorderWidth = 1.5f;
                        headerCell26.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell26.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell26);

                        PdfPCell headerCell27 = new PdfPCell(new Phrase("Fat (Kg)", header));
                        headerCell27.Rowspan = 1;
                        headerCell27.Colspan = 1;
                        headerCell27.Padding = 5;
                        //headerCell27.BorderWidth = 1.5f;
                        headerCell27.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell27.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell27);

                        PdfPCell headerCell28 = new PdfPCell(new Phrase("SNF (Kg)", header));
                        headerCell28.Rowspan = 1;
                        headerCell28.Colspan = 1;
                        headerCell28.Padding = 5;
                        //headerCell28.BorderWidth = 1.5f;
                        headerCell28.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell28.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell28);

                        //Sub-headers of Closing
                        PdfPCell headerCell29 = new PdfPCell(new Phrase("Equipment", header));
                        headerCell29.Rowspan = 1;
                        headerCell29.Colspan = 1;
                        headerCell29.Padding = 5;
                        //headerCell29.BorderWidth = 1.5f;
                        headerCell29.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell29.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell29);

                        PdfPCell headerCell30 = new PdfPCell(new Phrase("Qty (kg)", header));
                        headerCell30.Rowspan = 1;
                        headerCell30.Colspan = 1;
                        headerCell30.Padding = 5;
                        //headerCell30.BorderWidth = 1.5f;
                        headerCell30.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell30.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell30);

                        PdfPCell headerCell31 = new PdfPCell(new Phrase("Fat (%)", header));
                        headerCell31.Rowspan = 1;
                        headerCell31.Colspan = 1;
                        headerCell31.Padding = 5;
                        //headerCell31.BorderWidth = 1.5f;
                        headerCell31.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell31.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell31);

                        PdfPCell headerCell32 = new PdfPCell(new Phrase("SNF (%)", header));
                        headerCell32.Rowspan = 1;
                        headerCell32.Colspan = 1;
                        headerCell32.Padding = 5;
                        //headerCell32.BorderWidth = 1.5f;
                        headerCell32.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell32.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell32);

                        PdfPCell headerCell33 = new PdfPCell(new Phrase("Fat (Kg)", header));
                        headerCell33.Rowspan = 1;
                        headerCell33.Colspan = 1;
                        headerCell33.Padding = 5;
                        //headerCell33.BorderWidth = 1.5f;
                        headerCell33.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell33.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell33);

                        PdfPCell headerCell34 = new PdfPCell(new Phrase("SNF (Kg)", header));
                        headerCell34.Rowspan = 1;
                        headerCell34.Colspan = 1;
                        headerCell34.Padding = 5;
                        //headerCell34.BorderWidth = 1.5f;
                        headerCell34.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell34.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell34);

                        //////////////////////////////////////////////Adding header for Table2 /////////////////

                        PdfPCell headerCell36 = new PdfPCell(new Phrase("Plant Mass Balance for Dryer", header));
                        headerCell36.Rowspan = 1;
                        headerCell36.Colspan = 1;
                        headerCell36.Padding = 5;
                        headerCell36.BorderWidth = 1.5f;
                        headerCell36.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell36.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable1.AddCell(headerCell36);

                        PdfPCell headerCell37 = new PdfPCell(new Phrase("Units (Kg)", header));
                        headerCell37.Rowspan = 1;
                        headerCell37.Colspan = 1;
                        headerCell37.Padding = 5;
                        headerCell37.BorderWidth = 1.5f;
                        headerCell37.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell37.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable1.AddCell(headerCell37);

                        PdfPCell headerCell38 = new PdfPCell(new Phrase("Fat (Kg)", header));
                        headerCell38.Rowspan = 1;
                        headerCell38.Colspan = 1;
                        headerCell38.Padding = 5;
                        headerCell38.BorderWidth = 1.5f;
                        headerCell38.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell38.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable1.AddCell(headerCell38);

                        PdfPCell headerCell39 = new PdfPCell(new Phrase("SNF (Kg)", header));
                        headerCell39.Rowspan = 1;
                        headerCell39.Colspan = 1;
                        headerCell39.Padding = 5;
                        headerCell39.BorderWidth = 1.5f;
                        headerCell39.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell39.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable1.AddCell(headerCell39);

                        PdfPCell headerCell40 = new PdfPCell(new Phrase("TS", header));
                        headerCell40.Rowspan = 1;
                        headerCell40.Colspan = 1;
                        headerCell40.Padding = 5;
                        headerCell40.BorderWidth = 1.5f;
                        headerCell40.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell40.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable1.AddCell(headerCell40);

                        float[] widthsTAS = new float[30]{
                            210f, 140f, 140f, 150f, 140f, 160f,
                            190f, 140f, 140f, 150f, 140f, 160f,
                            190f, 140f, 140f, 150f, 140f, 160f,
                            190f, 140f, 140f, 150f, 140f, 160f,
                            210f, 140f, 140f, 150f, 140f, 160f

                        };
                        pdfPTable.SetWidths(widthsTAS);

                        //pdfPTable1.WidthPercentage = 30.0f;
                        //pdfPTable1.SpacingBefore = 200;
                        //float[] widths = new float[] { 1f, 1f, 1f };
                        //pdfPTable1.TotalWidth = 300f;
                        //pdfPTable1.LockedWidth = true;
                        pdfPTable1.WidthPercentage = 30;
                        //pdfPTable1.HorizontalAlignment = Element.ALIGN_LEFT;
                        //pdfPTable1.SetWidths(widths);

                        foreach (GridViewRow gridViewRow in gvMassBalanceReport.Rows)
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
                            //pdfPTable.HeaderRows = 1;
                        }

                        foreach (GridViewRow gridViewRow in gvTotal.Rows)
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
                                    pdfPTable1.AddCell(CellTwoHdr);
                                }
                                else if (double.TryParse(cellText, out dbvalue) || Int32.TryParse(cellText, out intvalue))
                                {
                                    PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
                                    CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
                                    CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    CellTwoHdr.Padding = 5;
                                    pdfPTable1.AddCell(CellTwoHdr);
                                }
                                else
                                {
                                    PdfPCell CellTwoHdr = new PdfPCell(new Phrase(cellText));
                                    CellTwoHdr.HorizontalAlignment = Element.ALIGN_CENTER;
                                    CellTwoHdr.VerticalAlignment = Element.ALIGN_MIDDLE;
                                    CellTwoHdr.Padding = 5;
                                    pdfPTable1.AddCell(CellTwoHdr);
                                }
                            }
                            //pdfPTable1.HeaderRows = 1;
                        }

                        var imageURL = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath());
                        var imageURL1 = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath1());

                        iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);
                        iTextSharp.text.Image jpg1 = iTextSharp.text.Image.GetInstance(imageURL1);


                        jpg.Alignment = Element.ALIGN_CENTER;
                        //jpg.SetAbsolutePosition(30, 1075);
                        jpg.SetAbsolutePosition(120, 1560);

                        jpg1.Alignment = Element.ALIGN_RIGHT;
                        jpg1.SetAbsolutePosition(2050, 1530);

                        StringReader sr = new StringReader(sb.ToString());
                        StringReader sr1 = new StringReader("<br/><br/><br/>");
                        Document pdfDoc = new Document(iTextSharp.text.PageSize.A1.Rotate(), -150f, -150f, 40f, 30f);

                        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                        PDFBackgroundHelper pageEventHelper = new PDFBackgroundHelper();
                        writer.PageEvent = pageEventHelper;
                        pdfDoc.Open();
                        htmlparser.Parse(sr);
                        pdfDoc.Add(jpg);
                        pdfDoc.Add(jpg1);

                        pdfDoc.Add(pdfPTable);
                        htmlparser.Parse(sr1);
                        pdfDoc.Add(pdfPTable1);

                        //htmlparser.Parse(sr1);

                        //----------- FOOTER -----------
                        PdfPTable footer = new PdfPTable(2);
                        PdfPTable footer2 = new PdfPTable(2);

                        float[] cols = new float[] { 100, 300 };

                        footer.SetWidthPercentage(cols, iTextSharp.text.PageSize.A1.Rotate());
                        footer2.SetWidthPercentage(cols, iTextSharp.text.PageSize.A1.Rotate());

                        footer.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 130, 90, writer.DirectContent);
                        footer2.WriteSelectedRows(0, -1, pdfDoc.LeftMargin + 130, 70, writer.DirectContent);
                        //----------- /FOOTER -----------

                        pdfDoc.Close();
                        Response.ContentType = "application/pdf";

                        Response.AddHeader("content-disposition", "attachment;" + "filename=Mass_Balance_Dryer_Report_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("hh:mm:ss") + ".pdf");
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
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }

        }
        #endregion

        #region Export to Excel Button Click
        protected void imgbtnExcel_OnClick(object sender, EventArgs e)
        {
            try
            {
                int count = 0;
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = "application/vnd.ms-excel";
                Response.ContentEncoding = System.Text.Encoding.Unicode;
                Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                string filename = "Mass_Balance_Dryer_Report_" + DateTime.Now.ToString("dd/MM/yyyy") + "_" + DateTime.Now.ToString("HH:mm:ss") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvMassBalanceReport.AllowPaging = false;
                gvMassBalanceReport.GridLines = GridLines.Both;
                foreach (TableCell cell in gvMassBalanceReport.HeaderRow.Cells)
                {
                    cell.BackColor = gvMassBalanceReport.HeaderStyle.BackColor;
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


                foreach (GridViewRow row in gvMassBalanceReport.Rows)
                {

                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvMassBalanceReport.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvMassBalanceReport.RowStyle.BackColor;
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


                gvMassBalanceReport.RenderControl(hw);

                /////////////////////////////////////////////////////

                StringWriter sw1 = new StringWriter();
                HtmlTextWriter hw1 = new HtmlTextWriter(sw1);

                gvTotal.AllowPaging = false;
                gvTotal.GridLines = GridLines.Both;
                foreach (TableCell cell in gvTotal.HeaderRow.Cells)
                {
                    cell.BackColor = gvTotal.HeaderStyle.BackColor;
                    count++;
                }
                foreach (GridViewRow row in gvTotal.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvTotal.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvTotal.RowStyle.BackColor;
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

                // colh for set colspan for Ornanisation Name, Adress and Report Name
                // cold for set colspan  for Date
                // int colh1, cold1;
                // colh = count - 4;
                //cold = count - 8;
                gvTotal.RenderControl(hw1);


                //////////////////////////////////////////////////////

                string strSubTitle = "Performance Qualification Report - Mass Balance Of Dryer";

                string imageURL = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath());
                string imageURL1 = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath1());

                string content = "<div align='center' style='font-family:verdana;font-size:16px; width:800px;'>" +
                  "<table style='display: table; width: 800px; clear:both;'>" +
                  "<tr> </tr>" +
                  "<tr><th><img height='90' width='180' src='" + imageURL1 + "'/></th>" +
                   strTh +
                  "<th colspan='" + colh + "' style='width: 600px; float: left; font-weight:bold;font-size:16px;'>" + Session[ApplicationSession.OrganisationName] + strTh +
                  "<th><img  height= '80' width= '120' src='" + imageURL + "'/></th>" +
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

                      "<br/>" + sw.ToString() + "<br/>" + sw1.ToString() + "<br/></div>";

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

        #region Go button Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                MassBalanceForDryerBL objBL = new MassBalanceForDryerBL();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                //string tankNo = ddlTankNumber.SelectedValue.ToString();
                if (dtFromDateTime <= dtToDateTime)
                {
                    var objResult = objBL.MassBalanceReportForDryer(dtFromDateTime, dtToDateTime);

                    if (objResult.ResutlDs.Tables[0].Rows.Count > 0)
                    {
                        gvMassBalanceReport.DataSource = objResult.ResutlDs.Tables[0];
                        gvMassBalanceReport.DataBind();
                    }
                    if (objResult.ResutlDs.Tables[1].Rows.Count > 0)
                    {
                        gvTotal.DataSource = objResult.ResutlDs.Tables[1];
                        gvTotal.DataBind();
                    }

                    if (gvMassBalanceReport.Rows.Count > 0 && gvTotal.Rows.Count > 0)
                    {
                        gvMassBalanceReport.Visible = true;
                        gvTotal.Visible = true;

                        divExport.Visible = true;
                        divNo.Visible = false;
                    }
                    else
                    {
                        divExport.Visible = false;
                        gvTotal.Visible = false;
                        divNo.Visible = true;

                    }
                }
                else
                {
                    gvMassBalanceReport.Visible = false;
                    gvTotal.Visible = false;

                    ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                   "<script>alert('From date is greater than To Date!');</script>");
                }
            }
            catch (Exception ex)
            {
                log.Error("Error", ex);
                ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                    "<script>alert('Oops! There is some technical Problem. Contact to your Administrator.');</script>");
            }
        }
        #endregion

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
            iTextSharp.text.Font FONT = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 15, iTextSharp.text.Font.BOLD);
            int iCount = 0;
            //constructor
            public PDFBackgroundHelper()
            {
                this.templates = new List<PdfTemplate>();
            }

            public override void OnEndPage(PdfWriter writer, Document document)
            {
                base.OnEndPage(writer, document);

                cb = writer.DirectContentUnder;
                PdfTemplate templateM = cb.CreateTemplate(500, 500);
                templates.Add(templateM);

                int pageN = writer.CurrentPageNumber;
                String pageText = "Page No : " + (writer.PageNumber);
                DateTime dtTime = DateTime.Now;
                BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA_BOLD, BaseFont.CP1257, BaseFont.NOT_EMBEDDED);
                if (this.iCount != 0)
                {
                    ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Mass Balance Of Dryer Report", FONT), 1100, 1660, 0);
                }
                iCount = iCount + 1;

                float len = bf.GetWidthPoint(pageText, 25);
                float len1 = bf.GetWidthPoint(dtTime.ToString(), 25);
                cb.BeginText();
                cb.SetFontAndSize(bf, 15);
                cb.SetTextMatrix(document.LeftMargin + 200, document.PageSize.GetBottom(document.BottomMargin) - 13);
                cb.ShowText(dtTime.ToString());
                cb.SetTextMatrix(document.LeftMargin + 2400, document.PageSize.GetBottom(document.BottomMargin) - 13);
                cb.ShowText(pageText);
                cb.EndText();
                cb.AddTemplate(templateM, document.LeftMargin + 800 + len, document.PageSize.GetBottom(document.BottomMargin) - 13);
            }
        }
        #endregion

    }
}