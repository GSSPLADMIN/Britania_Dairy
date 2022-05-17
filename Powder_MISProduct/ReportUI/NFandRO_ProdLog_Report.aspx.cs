﻿using System;
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
    public partial class NFandRO_ProdLog_Report : System.Web.UI.Page
    {
        private static ILog log = LogManager.GetLogger(typeof(NFandRO_ProdLog_Report));

        protected void Page_Load(object sender, EventArgs e)
        {
            divExport.Visible = false;  //Set exporting buttons visibility.
            divNo.Visible = false;
            if (!IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                txtToDate.Text = DateTime.Today.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            }
        }

        #region Export to PDF Button Click
        protected void imgbtnPDF_OnClick(object sender, EventArgs e)
        {
            try
            {
                if (HttpContext.Current.Session != null)
                {
                    string text = Session[ApplicationSession.OrganisationName].ToString();
                    string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                    string text2 = "NF and ROP Report";
                    using (StringWriter sw = new StringWriter())
                    {
                        using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                        {
                            System.Text.StringBuilder sb = new StringBuilder();
                            sb.Append("<div align='center' style='font-size:25px;font-weight:bold;color:Black;'>");
                            sb.Append(text);
                            sb.Append("</div>");
                            sb.Append("<br/>");
                            sb.Append("<div align='center' style='font-size:20px;font-weight:bold;color:Black;'>");
                            sb.Append(text1);
                            sb.Append("</div>");
                            sb.Append("<br/>");
                            sb.Append("<div align='center' style='font-size:26px;color:Maroon;'><b>");
                            sb.Append(text2);
                            sb.Append("</b></div>");
                            sb.Append("<br/>");

                            string content = "<table style='display: table;width: 900px; clear:both;'> <tr> <th colspan='7'"
                                + "style='float: left;padding-left: 265px;'><div align='left'><strong>From Date : </strong>" +
                                txtFromDate.Text + " " + txtFromTime.Text + "</div></th>";

                            content += "<th style='float:left; padding-left:-180px;'></th>";

                            content += "<th style='float:left; padding-left:-210px;'></th>";

                            content += "<th colspan='1' align='left' style=' float: left; padding-left:-165px;'><strong> To Date: </strong>" + //colspan='4' 
                            txtToDate.Text + " " + txtToTime.Text + "</th>" +
                            "</tr></table>";
                            sb.Append(content);
                            sb.Append("<br/>");

                            PdfPTable pdfPTable = new PdfPTable(gvMassBalanceReport.HeaderRow.Cells.Count);
                            PdfPTable pdfPTable1 = new PdfPTable(gvTotal.HeaderRow.Cells.Count);
                            iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);
                            //TableCell headerCell = new TableCell();
                            Font header = new Font(Font.FontFamily.TIMES_ROMAN, 15f, Font.BOLD, BaseColor.BLACK);

                           /* PdfPCell headerCell = new PdfPCell(new Phrase("Sr No.", header));
                            headerCell.Rowspan = 3;
                            headerCell.Colspan = 1;
                            headerCell.Padding = 5;
                            headerCell.BorderWidth = 1.5f;
                            headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell);*/


                            PdfPCell headerCell1 = new PdfPCell(new Phrase("Date-Time", header));
                            headerCell1.Rowspan = 3;
                            headerCell1.Colspan = 1;
                            headerCell1.Padding = 5;
                            headerCell1.BorderWidth = 1.5f;
                            headerCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                            headerCell1.MinimumHeight = 50f;
                            pdfPTable.AddCell(headerCell1);

                            PdfPCell headerCell2 = new PdfPCell(new Phrase("OPER. NAME", header));
                            headerCell2.Rowspan = 3;
                            headerCell2.Colspan = 1;
                            headerCell2.Padding = 5;
                            headerCell2.BorderWidth = 1.5f;
                            headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                            headerCell2.MinimumHeight = 50f;
                            pdfPTable.AddCell(headerCell2);

                            PdfPCell headerCell3 = new PdfPCell(new Phrase("NANO FILTRATION", header));
                            headerCell3.Rowspan = 1;
                            headerCell3.Colspan = 17;
                            headerCell3.Padding = 5;
                            headerCell3.BorderWidth = 1.5f;
                            headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell3);

                            PdfPCell headerCell4 = new PdfPCell(new Phrase("REVERSE OSMOSIS POLISHER", header));
                            headerCell4.Rowspan = 1;
                            headerCell4.Colspan = 11;
                            headerCell4.Padding = 5;
                            headerCell4.BorderWidth = 1.5f;
                            headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell4);

                            //Sub-headers of Nano filtration
                            PdfPCell headerCell35 = new PdfPCell(new Phrase("FILTER BANK", header));
                            headerCell35.Rowspan = 1;
                            headerCell35.Colspan = 2;
                            headerCell35.Padding = 5;
                            headerCell35.BorderWidth = 1.5f;
                            headerCell35.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell35.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell35);


                            PdfPCell headerCell5 = new PdfPCell(new Phrase("FEED BALANCE TANK -NF", header));
                            headerCell5.Rowspan = 1;
                            headerCell5.Colspan = 5;
                            headerCell5.Padding = 5;
                            headerCell5.BorderWidth = 1.5f;
                            headerCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell5);

                            PdfPCell headerCell6 = new PdfPCell(new Phrase("LOOP 1", header));
                            headerCell6.Rowspan = 1;
                            headerCell6.Colspan = 3;
                            headerCell6.Padding = 5;
                            headerCell6.BorderWidth = 1.5f;
                            headerCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell6);

                            PdfPCell headerCell7 = new PdfPCell(new Phrase("LOOP 2", header));
                            headerCell7.Rowspan = 1;
                            headerCell7.Colspan = 3;
                            headerCell7.Padding = 5;
                            headerCell7.BorderWidth = 1.5f;
                            headerCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell7.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell7);

                            PdfPCell headerCell8 = new PdfPCell(new Phrase("CONCENTRATE", header));
                            headerCell8.Rowspan = 1;
                            headerCell8.Colspan = 4;
                            headerCell8.Padding = 5;
                            headerCell8.BorderWidth = 1.5f;
                            headerCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell8.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell8);

                            //Sub-headers of Reverse osmosis polisher
                            PdfPCell headerCell9 = new PdfPCell(new Phrase("FEED", header));
                            headerCell9.Rowspan = 1;
                            headerCell9.Colspan = 3;
                            headerCell9.Padding = 5;
                            headerCell9.BorderWidth = 1.5f;
                            headerCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell9.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell9);

                            PdfPCell headerCell10 = new PdfPCell(new Phrase("LOOP 1", header));
                            headerCell10.Rowspan = 1;
                            headerCell10.Colspan = 3;
                            headerCell10.Padding = 5;
                            headerCell10.BorderWidth = 1.5f;
                            headerCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell10.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell10);

                            PdfPCell headerCell11 = new PdfPCell(new Phrase("LOOP 2", header));
                            headerCell11.Rowspan = 1;
                            headerCell11.Colspan = 3;
                            headerCell11.Padding = 5;
                            headerCell11.BorderWidth = 1.5f;
                            headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell11.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell11);

                            PdfPCell headerCell12 = new PdfPCell(new Phrase("CONCENTRATE", header));
                            headerCell12.Rowspan = 1;
                            headerCell12.Colspan = 2;
                            headerCell12.Padding = 5;
                            headerCell12.BorderWidth = 1.5f;
                            headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell12);

                            //Sub-headers of NF Filter Bank.
                            PdfPCell headerCell13 = new PdfPCell(new Phrase("PRESS. IN (BAR)", header));
                            headerCell13.Rowspan = 1;
                            headerCell13.Colspan = 1;
                            headerCell13.Padding = 5;
                            headerCell13.BorderWidth = 1.5f;
                            headerCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell13);

                            PdfPCell headerCell14 = new PdfPCell(new Phrase("PRESS. OUT (BAR)", header));
                            headerCell14.Rowspan = 1;
                            headerCell14.Colspan = 1;
                            headerCell14.Padding = 5;
                            headerCell14.BorderWidth = 1.5f;
                            headerCell14.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell14.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell14);

                            //Sub-headers of NF Feed balance tank -NF.
                            PdfPCell headerCell15 = new PdfPCell(new Phrase("Level (%)", header));
                            headerCell15.Rowspan = 1;
                            headerCell15.Colspan = 1;
                            headerCell15.Padding = 5;
                            headerCell15.BorderWidth = 1.5f;
                            headerCell15.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell15.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell15);

                            PdfPCell headerCell16 = new PdfPCell(new Phrase("FLOW (M³/HR)", header));
                            headerCell16.Rowspan = 1;
                            headerCell16.Colspan = 1;
                            headerCell16.Padding = 5;
                            headerCell16.BorderWidth = 1.5f;
                            headerCell16.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell16.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell16);

                            PdfPCell headerCell17 = new PdfPCell(new Phrase("PRESS. (BAR)", header));
                            headerCell17.Rowspan = 1;
                            headerCell17.Colspan = 1;
                            headerCell17.Padding = 5;
                            headerCell17.BorderWidth = 1.5f;
                            headerCell17.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell17.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell17);

                            PdfPCell headerCell18 = new PdfPCell(new Phrase("BRIX (%)", header));
                            headerCell18.Rowspan = 1;
                            headerCell18.Colspan = 1;
                            headerCell18.Padding = 5;
                            headerCell18.BorderWidth = 1.5f;
                            headerCell18.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell18.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell18);

                            PdfPCell headerCell19 = new PdfPCell(new Phrase("pH", header));
                            headerCell19.Rowspan = 1;
                            headerCell19.Colspan = 1;
                            headerCell19.Padding = 5;
                            headerCell19.BorderWidth = 1.5f;
                            headerCell19.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell19.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell19);

                            //Sub-headers of NF Loop 1.
                            PdfPCell headerCell20 = new PdfPCell(new Phrase("PRESS. (BAR)", header));
                            headerCell20.Rowspan = 1;
                            headerCell20.Colspan = 1;
                            headerCell20.Padding = 5;
                            headerCell20.BorderWidth = 1.5f;
                            headerCell20.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell20.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell20);

                            PdfPCell headerCell21 = new PdfPCell(new Phrase("TEMP. (°C)", header));
                            headerCell21.Rowspan = 1;
                            headerCell21.Colspan = 1;
                            headerCell21.Padding = 5;
                            headerCell21.BorderWidth = 1.5f;
                            headerCell21.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell21.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell21);

                            PdfPCell headerCell22 = new PdfPCell(new Phrase("PERM. FLOW (M³/HR)", header));
                            headerCell22.Rowspan = 1;
                            headerCell22.Colspan = 1;
                            headerCell22.Padding = 5;
                            headerCell22.BorderWidth = 1.5f;
                            headerCell22.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell22.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell22);

                            //Sub-headers of NF Loop 2.
                            PdfPCell headerCell23 = new PdfPCell(new Phrase("PRESS. (BAR)", header));
                            headerCell23.Rowspan = 1;
                            headerCell23.Colspan = 1;
                            headerCell23.Padding = 5;
                            headerCell23.BorderWidth = 1.5f;
                            headerCell23.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell23.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell23);

                            PdfPCell headerCell24 = new PdfPCell(new Phrase("TEMP. (°C)", header));
                            headerCell24.Rowspan = 1;
                            headerCell24.Colspan = 1;
                            headerCell24.Padding = 5;
                            headerCell24.BorderWidth = 1.5f;
                            headerCell24.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell24.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell24);

                            PdfPCell headerCell25 = new PdfPCell(new Phrase("PERM. FLOW (M³/HR)", header));
                            headerCell25.Rowspan = 1;
                            headerCell25.Colspan = 1;
                            headerCell25.Padding = 5;
                            headerCell25.BorderWidth = 1.5f;
                            headerCell25.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell25.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell25);

                            //Sub-headers of NF Concentrate.
                            PdfPCell headerCell26 = new PdfPCell(new Phrase("FLOW (M³/HR)", header));
                            headerCell26.Rowspan = 1;
                            headerCell26.Colspan = 1;
                            headerCell26.Padding = 5;
                            headerCell26.BorderWidth = 1.5f;
                            headerCell26.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell26.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell26);

                            PdfPCell headerCell27 = new PdfPCell(new Phrase("RATIO (%)", header));
                            headerCell27.Rowspan = 1;
                            headerCell27.Colspan = 1;
                            headerCell27.Padding = 5;
                            headerCell27.BorderWidth = 1.5f;
                            headerCell27.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell27.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell27);

                            PdfPCell headerCell28 = new PdfPCell(new Phrase("BRIX (%)", header));
                            headerCell28.Rowspan = 1;
                            headerCell28.Colspan = 1;
                            headerCell28.Padding = 5;
                            headerCell28.BorderWidth = 1.5f;
                            headerCell28.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell28.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell28);

                            PdfPCell headerCell29 = new PdfPCell(new Phrase("pH", header));
                            headerCell29.Rowspan = 1;
                            headerCell29.Colspan = 1;
                            headerCell29.Padding = 5;
                            headerCell29.BorderWidth = 1.5f;
                            headerCell29.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell29.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell29);

                            //Sub-headers of ROP Feed
                            PdfPCell headerCell30 = new PdfPCell(new Phrase("FLOW (M³/HR)", header));
                            headerCell30.Rowspan = 1;
                            headerCell30.Colspan = 1;
                            headerCell30.Padding = 5;
                            headerCell30.BorderWidth = 1.5f;
                            headerCell30.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell30.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell30);

                            PdfPCell headerCell31 = new PdfPCell(new Phrase("PRESS. (BAR)", header));
                            headerCell31.Rowspan = 1;
                            headerCell31.Colspan = 1;
                            headerCell31.Padding = 5;
                            headerCell31.BorderWidth = 1.5f;
                            headerCell31.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell31.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell31);

                            PdfPCell headerCell32 = new PdfPCell(new Phrase("Level (%)", header));
                            headerCell32.Rowspan = 1;
                            headerCell32.Colspan = 1;
                            headerCell32.Padding = 5;
                            headerCell32.BorderWidth = 1.5f;
                            headerCell32.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell32.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell32);

                            //Sub-header for ROP Loop 1
                            PdfPCell headerCell33 = new PdfPCell(new Phrase("PRESS. (BAR)", header));
                            headerCell33.Rowspan = 1;
                            headerCell33.Colspan = 1;
                            headerCell33.Padding = 5;
                            headerCell33.BorderWidth = 1.5f;
                            headerCell33.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell33.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell33);

                            PdfPCell headerCell34 = new PdfPCell(new Phrase("TEMP. (°C)", header));
                            headerCell34.Rowspan = 1;
                            headerCell34.Colspan = 1;
                            headerCell34.Padding = 5;
                            headerCell34.BorderWidth = 1.5f;
                            headerCell34.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell34.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell34);

                            PdfPCell headerCell40 = new PdfPCell(new Phrase("PERM. FLOW (M³/HR)", header));
                            headerCell40.Rowspan = 1;
                            headerCell40.Colspan = 1;
                            headerCell40.Padding = 5;
                            headerCell40.BorderWidth = 1.5f;
                            headerCell40.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell40.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell40);

                            //Sub-header for ROP Loop 2
                            PdfPCell headerCell41 = new PdfPCell(new Phrase("PRESS. (BAR)", header));
                            headerCell41.Rowspan = 1;
                            headerCell41.Colspan = 1;
                            headerCell41.Padding = 5;
                            headerCell41.BorderWidth = 1.5f;
                            headerCell41.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell41.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell41);

                            PdfPCell headerCell42 = new PdfPCell(new Phrase("TEMP. (°C)", header));
                            headerCell42.Rowspan = 1;
                            headerCell42.Colspan = 1;
                            headerCell42.Padding = 5;
                            headerCell42.BorderWidth = 1.5f;
                            headerCell42.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell42.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell42);

                            PdfPCell headerCell43 = new PdfPCell(new Phrase("PERM. FLOW (M³/HR)", header));
                            headerCell43.Rowspan = 1;
                            headerCell43.Colspan = 1;
                            headerCell43.Padding = 5;
                            headerCell43.BorderWidth = 1.5f;
                            headerCell43.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell43.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell43);

                            //Sub-header for ROP Concentrate
                            PdfPCell headerCell44 = new PdfPCell(new Phrase("FLOW (M³/HR)", header));
                            headerCell44.Rowspan = 1;
                            headerCell44.Colspan = 1;
                            headerCell44.Padding = 5;
                            headerCell44.BorderWidth = 1.5f;
                            headerCell44.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell44.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell44);

                            PdfPCell headerCell45 = new PdfPCell(new Phrase("RATIO", header));
                            headerCell45.Rowspan = 1;
                            headerCell45.Colspan = 1;
                            headerCell45.Padding = 5;
                            headerCell45.BorderWidth = 1.5f;
                            headerCell45.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell45.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable.AddCell(headerCell45);

                            //////////////////////////////////////////////Adding header for Table2 /////////////////

                            PdfPCell headerCell36 = new PdfPCell(new Phrase("NANO FEED TOTAL LITERS", header));
                            headerCell36.Rowspan = 1;
                            headerCell36.Colspan = 1;
                            headerCell36.Padding = 5;
                            headerCell36.BorderWidth = 1.5f;
                            headerCell36.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell36.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable1.AddCell(headerCell36);

                            PdfPCell headerCell47 = new PdfPCell(new Phrase("NANO CONC TOTAL LITERS", header));
                            headerCell47.Rowspan = 1;
                            headerCell47.Colspan = 1;
                            headerCell47.Padding = 5;
                            headerCell47.BorderWidth = 1.5f;
                            headerCell47.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell47.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable1.AddCell(headerCell47);

                            PdfPCell headerCell46 = new PdfPCell(new Phrase("RO FEED TOTAL LITERS", header));
                            headerCell46.Rowspan = 1;
                            headerCell46.Colspan = 1;
                            headerCell46.Padding = 5;
                            headerCell46.BorderWidth = 1.5f;
                            headerCell46.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell46.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable1.AddCell(headerCell46);

                            PdfPCell headerCell37 = new PdfPCell(new Phrase("RO CONC TOTAL LITERS", header));
                            headerCell37.Rowspan = 1;
                            headerCell37.Colspan = 1;
                            headerCell37.Padding = 5;
                            headerCell37.BorderWidth = 1.5f;
                            headerCell37.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell37.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable1.AddCell(headerCell37);

                            PdfPCell headerCell38 = new PdfPCell(new Phrase("PERMEATE TOTAL LITERS", header));
                            headerCell38.Rowspan = 1;
                            headerCell38.Colspan = 1;
                            headerCell38.Padding = 5;
                            headerCell38.BorderWidth = 1.5f;
                            headerCell38.HorizontalAlignment = Element.ALIGN_CENTER;
                            headerCell38.VerticalAlignment = Element.ALIGN_MIDDLE;
                            pdfPTable1.AddCell(headerCell38);

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
                                pdfPTable.HeaderRows = 1;
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
                                pdfPTable1.HeaderRows = 1;
                            }

                            var imageURL = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Britania.png";
                            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageURL);

                            jpg.Alignment = Element.ALIGN_CENTER;
                            //jpg.SetAbsolutePosition(30, 1075);
                            jpg.SetAbsolutePosition(120, 1560);

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

                            Response.AddHeader("content-disposition", "attachment;" + "filename=NF_RO_Prod_Report_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("hh:mm:ss") + ".pdf");
                            Response.Cache.SetCacheability(HttpCacheability.NoCache);
                            Response.Write(pdfDoc);
                            Response.Flush();
                            Response.Clear();
                            Response.End();

                        }
                    }
                }
                else
                {
                    Response.Redirect("Login.aspx");
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

                if (HttpContext.Current.Session != null)
                {
                    int count = 0;
                    Response.Clear();
                    Response.Buffer = true;
                    Response.ContentType = "application/vnd.ms-excel";
                    Response.ContentEncoding = System.Text.Encoding.Unicode;
                    Response.BinaryWrite(System.Text.Encoding.Unicode.GetPreamble());
                    string filename = "NF_&_RO_Prod_Report" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("hh:mm:ss") + ".xls";
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

                    // colh for set colspan for Ornanisation Name, Adress and Report Name
                    // cold for set colspan  for Date
                    int colh, cold;
                    colh = count - 4;
                    cold = count - 8;
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
                    string strSubTitle = "NF and ROP Report";

                    var imageURL = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Britania.png";

                    string content = "<div align='center' style='font-family:verdana;font-size:16px; width:800px;'>" +
                      "<table style='display: table; width: 800px; clear:both;'>" +
                      "<tr> </tr>" +
                      "<tr><th></th><th><img height='80' width='100' src='" + imageURL + "'/></th>" +
                      "<th colspan='" + colh + "' style='width: 600px; float: left; font-weight:bold;font-size:16px;'>" + Session[ApplicationSession.OrganisationName] +

                         "</tr>" +
                         "<tr><th colspan='2'></th><th colspan='" + colh + "' style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</th></tr>" +
                         "<tr><th colspan='2'></th><th colspan='" + colh + "'></th></tr>" +
                         "<tr><th colspan='2'></th><th colspan='" + colh + "' style='font-size:22px;color:Maroon;'><b>" + strSubTitle + "</b></th></tr>" +
                         "<tr></tr>" +

                         "<tr><th colspan='4' align='left' style='width: 200px; float: left;'><strong> From Date&Time : </strong>" +
                    (DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)).ToString() + "</th>" +
                    "<th colspan='" + cold + "'></th>" +
                    "<th colspan = '4' align = 'right' style = 'width: 200px; float: right;'><strong> To Date&Time : </strong>" +
                                (DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)).ToString() + "</th></tr>" +

                             "</tr>" +
                    "</table>" +

                          "<br/>" + sw.ToString() + "<br/>" + sw1.ToString() + "<br/></div>";

                    string style = @"<!--mce:2-->";
                    Response.Write(style);
                    Response.Output.Write(content);
                    Response.Flush();
                    Response.Clear();
                    Response.End();
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                log.Error("Button EXCEL", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }
        }
        #endregion

        #region Go button Click Event
        protected void btnGo_OnClick(object sender, EventArgs e)
        {
            try
            {
                NFandRO_ProdLog_ReportBL objBL = new NFandRO_ProdLog_ReportBL();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                //string tankNo = ddlTankNumber.SelectedValue.ToString();
                if (dtFromDateTime <= dtToDateTime)
                {
                    var objResult = objBL.NFandRO_ProdReportData(dtFromDateTime, dtToDateTime);

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

                    if (gvMassBalanceReport.Rows.Count > 0 || gvTotal.Rows.Count>0)
                    {
                        gvMassBalanceReport.Visible = true;
                        gvTotal.Visible = true;

                        divExport.Visible = true;
                        divNo.Visible = false;
                    }
                    else
                    {
                        divExport.Visible = false;
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
                    ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Plant Mass Balance Report", FONT), 1100, 1660, 0);
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

        #region GridView row-created event

        protected void gvMassBalanceReport_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                GridViewRow headerRow3 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                TableHeaderCell headerTableCell = new TableHeaderCell();

                // Code for headerRow1
                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 3;
                headerTableCell.ColumnSpan = 1;
                headerTableCell.Text = "Date - Time";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 3;
                headerTableCell.ColumnSpan = 1;
                headerTableCell.Text = "OPER. NAME";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 1;
                headerTableCell.ColumnSpan = 17;
                headerTableCell.Text = "NANO FILTRATION";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 1;
                headerTableCell.ColumnSpan = 11;
                headerTableCell.Text = "REVERSE OSMOSIS POLISHER";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                // Sub header start Here (headerRow2)
                // Sub Header for Nano filtration

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 2;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "FILTER BANK";
                headerTableCell.Wrap = true;
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 5;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "FEED BALANCE TANK -NF";
                headerTableCell.Wrap = true;
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "LOOP 1";
                headerTableCell.Wrap = true;
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "LOOP 2";
                headerTableCell.Wrap = true;
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 4;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "CONCENTRATE";
                headerTableCell.Wrap = true;
                headerRow2.Controls.Add(headerTableCell);

                // Sub Header for Reverse osmosis polisher.
                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "FEED";
                headerTableCell.Wrap = true;
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "LOOP 1";
                headerTableCell.Wrap = true;
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 3;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "LOOP 2";
                headerTableCell.Wrap = true;
                headerRow2.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 2;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "CONCENTRATE";
                headerTableCell.Wrap = true;
                headerRow2.Controls.Add(headerTableCell);

                // Sub header start Here (headerRow3)
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

                // Sub Header for Filter bank
                headerCell1.Text = "PRESS. IN (BAR)";
                headerCell2.Text = "PRESS. OUT (BAR)";

                // Sub Header for Feed balance tank - NF
                headerCell3.Text = "Level (%)";
                headerCell4.Text = "Flow (M³/HR)";
                headerCell5.Text = "PRESS. (BAR)";
                headerCell6.Text = "BRIX (%)";
                headerCell7.Text = "pH";

                // Sub Header for Loop1
                headerCell8.Text = "PRESS. (BAR)";
                headerCell9.Text = "TEMP. (°C)";
                headerCell10.Text = "PERM. FLOW (M³/HR)";

                // Sub Header for Loop2
                headerCell11.Text = "PRESS. (BAR)";
                headerCell12.Text = "TEMP. (°C)";
                headerCell13.Text = "PERM. FLOW (M³/HR)";

                // Sub Header for Concentrate
                headerCell14.Text = "FLOW (M³/HR)";
                headerCell15.Text = "RATIO (%)";
                headerCell16.Text = "BRIX (%)";
                headerCell17.Text = "pH";

                // Sub Header for Feed
                headerCell18.Text = "FLOW (M³/HR)";
                headerCell19.Text = "PRESS. (BAR)";
                headerCell20.Text = "Level (%)";

                // Sub Header for Loop1
                headerCell21.Text = "PRESS. (BAR)";
                headerCell22.Text = "TEMP. (°C)";
                headerCell23.Text = "PERM. FLOW (M³/HR)";

                // Sub Header for Loop2
                headerCell24.Text = "PRESS. (BAR)";
                headerCell25.Text = "TEMP. (°C)";
                headerCell26.Text = "PERM. FLOW (M³/HR)";

                // Sub Header for Concentrate
                headerCell27.Text = "FLOW (M³/HR)";
                headerCell28.Text = "RATIO";

                headerRow3.Controls.Add(headerCell1);
                headerRow3.Controls.Add(headerCell2);
                headerRow3.Controls.Add(headerCell3);
                headerRow3.Controls.Add(headerCell4);
                headerRow3.Controls.Add(headerCell5);
                headerRow3.Controls.Add(headerCell6);
                headerRow3.Controls.Add(headerCell7);
                headerRow3.Controls.Add(headerCell8);
                headerRow3.Controls.Add(headerCell9);
                headerRow3.Controls.Add(headerCell10);
                headerRow3.Controls.Add(headerCell11);
                headerRow3.Controls.Add(headerCell12);
                headerRow3.Controls.Add(headerCell13);
                headerRow3.Controls.Add(headerCell14);
                headerRow3.Controls.Add(headerCell15);
                headerRow3.Controls.Add(headerCell16);
                headerRow3.Controls.Add(headerCell17);
                headerRow3.Controls.Add(headerCell18);
                headerRow3.Controls.Add(headerCell19);
                headerRow3.Controls.Add(headerCell20);
                headerRow3.Controls.Add(headerCell21);
                headerRow3.Controls.Add(headerCell22);
                headerRow3.Controls.Add(headerCell23);
                headerRow3.Controls.Add(headerCell24);
                headerRow3.Controls.Add(headerCell25);
                headerRow3.Controls.Add(headerCell26);
                headerRow3.Controls.Add(headerCell27);
                headerRow3.Controls.Add(headerCell28);

                gvMassBalanceReport.Controls[0].Controls.AddAt(0, headerRow3);
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
                headerTableCell.Text = "NANO FEED TOTAL LITERS";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 1;
                headerTableCell.ColumnSpan = 1;
                headerTableCell.Text = "NANO CONC TOTAL LITERS";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 1;
                headerTableCell.ColumnSpan = 1;
                headerTableCell.Text = "RO FEED TOTAL LITERS";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);


                headerTableCell = new TableHeaderCell();
                headerTableCell.RowSpan = 1;
                headerTableCell.ColumnSpan = 1;
                headerTableCell.Text = "RO CONC TOTAL LITERS";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                headerTableCell = new TableHeaderCell();
                headerTableCell.ColumnSpan = 1;
                headerTableCell.RowSpan = 1;
                headerTableCell.Text = "PERMEATE TOTAL LITERS";
                headerTableCell.Wrap = true;
                headerRow1.Controls.Add(headerTableCell);

                gvTotal.Controls[0].Controls.AddAt(0, headerRow1);
            }
        }

        #endregion
    }
}