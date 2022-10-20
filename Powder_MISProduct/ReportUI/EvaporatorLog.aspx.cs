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
    public partial class EvaporatorLog : System.Web.UI.Page
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

        #region VerifyRenderingInServerForm
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        #endregion

        #region BindGrid
        public void EvaporatorLogReport()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                EvaporatorBL objEvaporatorStorage = new EvaporatorBL();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                  CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);
                if (dtFromDateTime <= dtToDateTime)
                {
                    objResult = objEvaporatorStorage.EvaporatorReport(dtFromDateTime, dtToDateTime);
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvEvaporator.DataSource = objResult.ResultDt;
                        gvEvaporator.DataBind();
                        // imgWordButton.Visible = imgExcelButton.Visible = true;
                        divNo.Visible = false;
                        divExport.Visible = true;
                        gvEvaporator.Visible = true;

                    }
                    else
                    {
                        // imgWordButton.Visible = imgExcelButton.Visible = false;
                        divNo.Visible = true;
                        divExport.Visible = false;
                        gvEvaporator.Visible = false;

                        // ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                        //"<script>alert('No Record Found.');</script>");
                    }
                }
                else
                {
                    gvEvaporator.Visible = false;
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

        #region Export to PDF
        protected void imgPDFButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Session[ApplicationSession.OrganisationName].ToString();
                string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                string text2 = "Evaporator Data Log Report";

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

                        PdfPTable pdfPTable = new PdfPTable(gvEvaporator.HeaderRow.Cells.Count);
                        iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 18, iTextSharp.text.Font.BOLD);



                        PdfPCell headerCell = new PdfPCell(new Phrase("Sr. No."));
                        headerCell.Rowspan = 2;
                        headerCell.Colspan = 1;
                        headerCell.Padding = 5;
                        headerCell.BorderWidth = 1.5f;
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell);

                        PdfPCell headerCell1 = new PdfPCell(new Phrase("Date"));
                        headerCell1.Rowspan = 2;
                        headerCell1.Colspan = 1;
                        headerCell1.Padding = 5;
                        headerCell1.BorderWidth = 1.5f;
                        headerCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell1);

                        PdfPCell headerCell2 = new PdfPCell(new Phrase("Time"));
                        headerCell2.Rowspan = 2;
                        headerCell2.Colspan = 1;
                        headerCell2.Padding = 5;
                        headerCell2.BorderWidth = 1.5f;
                        headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell2);

                        PdfPCell headerCell23 = new PdfPCell(new Phrase("Plant Status"));
                        headerCell23.Rowspan = 2;
                        headerCell23.Colspan = 1;
                        headerCell23.Padding = 5;
                        headerCell23.BorderWidth = 1.5f;
                        headerCell23.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell23.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell23);

                        PdfPCell headerCell3 = new PdfPCell(new Phrase("Evap. Balance Tank Level (%)"));
                        headerCell3.Rowspan = 2;
                        headerCell3.Colspan = 1;
                        headerCell3.Padding = 5;
                        headerCell3.BorderWidth = 1.5f;
                        headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell3);

                        PdfPCell headerCell4 = new PdfPCell(new Phrase("Feed Flow (Kg/Hr)"));
                        headerCell4.Rowspan = 2;
                        headerCell4.Colspan = 1;
                        headerCell4.Padding = 5;
                        headerCell4.BorderWidth = 1.5f;
                        headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell4);

                        PdfPCell headerCell5 = new PdfPCell(new Phrase("Feed Flow Totalizer"));
                        headerCell5.Rowspan = 2;
                        headerCell5.Colspan = 1;
                        headerCell5.Padding = 5;
                        headerCell5.BorderWidth = 1.5f;
                        headerCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell5);

                        PdfPCell headerCell6 = new PdfPCell(new Phrase("Feed Conductivity (mS/cm)"));
                        headerCell6.Rowspan = 2;
                        headerCell6.Colspan = 1;
                        headerCell6.Padding = 5;
                        headerCell6.BorderWidth = 1.5f;
                        headerCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell6);

                        PdfPCell headerCell7 = new PdfPCell(new Phrase("Feed Preheater Temp. (°C)"));
                        headerCell7.Rowspan = 2;
                        headerCell7.Colspan = 1;
                        headerCell7.Padding = 5;
                        headerCell7.BorderWidth = 1.5f;
                        headerCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell7.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell7);

                        PdfPCell headerCell8 = new PdfPCell(new Phrase("PCD Temp. (°C)"));
                        headerCell8.Rowspan = 2;
                        headerCell8.Colspan = 1;
                        headerCell8.Padding = 5;
                        headerCell8.BorderWidth = 1.5f;
                        headerCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell8.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell8);

                        PdfPCell headerCell9 = new PdfPCell(new Phrase("FV-1 Heating Temp. (°C)"));
                        headerCell9.Rowspan = 2;
                        headerCell9.Colspan = 1;
                        headerCell9.Padding = 5;
                        headerCell9.BorderWidth = 1.5f;
                        headerCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell9.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell9);

                        PdfPCell headerCell10 = new PdfPCell(new Phrase("FV-2 Heating Temp. (°C)"));
                        headerCell10.Rowspan = 2;
                        headerCell10.Colspan = 1;
                        headerCell10.Padding = 5;
                        headerCell10.BorderWidth = 1.5f;
                        headerCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell10.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell10);

                        PdfPCell headerCell11 = new PdfPCell(new Phrase("DSI In Temp. (°C)"));
                        headerCell11.Rowspan = 2;
                        headerCell11.Colspan = 1;
                        headerCell11.Padding = 5;
                        headerCell11.BorderWidth = 1.5f;
                        headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell11.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell11);

                        //PdfPCell headerCell12 = new PdfPCell(new Phrase("FV-1 Regeneration Temp. (°C)"));
                        PdfPCell headerCell12 = new PdfPCell(new Phrase("FV-1 Regn. Temp. (°C)"));
                        headerCell12.Rowspan = 2;
                        headerCell12.Colspan = 1;
                        headerCell12.Padding = 5;
                        headerCell12.BorderWidth = 1.5f;
                        headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell12);
                        
                        //PdfPCell headerCell13 = new PdfPCell(new Phrase("FV-2 Regeneration Temp. (°C)"));
                        PdfPCell headerCell13 = new PdfPCell(new Phrase("FV-2 Regn. Temp. (°C)"));
                        headerCell13.Rowspan = 2;
                        headerCell13.Colspan = 1;
                        headerCell13.Padding = 5;
                        headerCell13.BorderWidth = 1.5f;
                        headerCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell13);

                        PdfPCell headerCell14 = new PdfPCell(new Phrase("Cal-1 Temp. (°C)"));
                        headerCell14.Rowspan = 2;
                        headerCell14.Colspan = 1;
                        headerCell14.Padding = 5;
                        headerCell14.BorderWidth = 1.5f;
                        headerCell14.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell14.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell14);

                        PdfPCell headerCell15 = new PdfPCell(new Phrase("Cal-2 Temp. (°C)"));
                        headerCell15.Rowspan = 2;
                        headerCell15.Colspan = 1;
                        headerCell15.Padding = 5;
                        headerCell15.BorderWidth = 1.5f;
                        headerCell15.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell15.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell15);

                        PdfPCell headerCell16 = new PdfPCell(new Phrase("Cal-3 Temp. (°C)"));
                        headerCell16.Rowspan = 2;
                        headerCell16.Colspan = 1;
                        headerCell16.Padding = 5;
                        headerCell16.BorderWidth = 1.5f;
                        headerCell16.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell16.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell16);

                        PdfPCell headerCell17 = new PdfPCell(new Phrase("Cal-4 Temp. (°C)"));
                        headerCell17.Rowspan = 2;
                        headerCell17.Colspan = 1;
                        headerCell17.Padding = 5;
                        headerCell17.BorderWidth = 1.5f;
                        headerCell17.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell17.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell17);

                        PdfPCell headerCell18 = new PdfPCell(new Phrase("Condenser CW In Temp. (°C)"));
                        headerCell18.Rowspan = 2;
                        headerCell18.Colspan = 1;
                        headerCell18.Padding = 5;
                        headerCell18.BorderWidth = 1.5f;
                        headerCell18.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell18.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell18);

                        PdfPCell headerCell19 = new PdfPCell(new Phrase("Condenser CW Out Temp. (°C)"));
                        headerCell19.Rowspan = 2;
                        headerCell19.Colspan = 1;
                        headerCell19.Padding = 5;
                        headerCell19.BorderWidth = 1.5f;
                        headerCell19.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell19.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell19);

                        PdfPCell headerCell20= new PdfPCell(new Phrase("Condenser Temp. (°C)"));
                        headerCell20.Rowspan = 2;
                        headerCell20.Colspan = 1;
                        headerCell20.Padding = 5;
                        headerCell20.BorderWidth = 1.5f;
                        headerCell20.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell20.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell20);
                        
                        PdfPCell headerCell21 = new PdfPCell(new Phrase("Plant Vacuum (mbar)"));
                        headerCell21.Rowspan = 2;
                        headerCell21.Colspan = 1;
                        headerCell21.Padding = 5;
                        headerCell21.BorderWidth = 1.5f;
                        headerCell21.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell21.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell21);
                        
                        PdfPCell headerCell22 = new PdfPCell(new Phrase("PCD TVR Pressure (barg)"));
                        headerCell22.Rowspan = 2;
                        headerCell22.Colspan = 1;
                        headerCell22.Padding = 5;
                        headerCell22.BorderWidth = 1.5f;
                        headerCell22.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell22.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell22);
                        
                        PdfPCell headerCell24 = new PdfPCell(new Phrase("Cal TVR Pressure (barg)"));
                        headerCell24.Rowspan = 2;
                        headerCell24.Colspan = 1;
                        headerCell24.Padding = 5;
                        headerCell24.BorderWidth = 1.5f;
                        headerCell24.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell24.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell24);
                        
                        PdfPCell headerCell25 = new PdfPCell(new Phrase("DSI Back Pressure (barg)"));
                        headerCell25.Rowspan = 2;
                        headerCell25.Colspan = 1;
                        headerCell25.Padding = 5;
                        headerCell25.BorderWidth = 1.5f;
                        headerCell25.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell25.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell25);
                        
                        PdfPCell headerCell26 = new PdfPCell(new Phrase("DSI Steam Supply Pressure (barg)"));
                        headerCell26.Rowspan = 2;
                        headerCell26.Colspan = 1;
                        headerCell26.Padding = 5;
                        headerCell26.BorderWidth = 1.5f;
                        headerCell26.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell26.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell26);
                        
                        PdfPCell headerCell27 = new PdfPCell(new Phrase("DSI Outlet Temp. (°C)"));
                        headerCell27.Rowspan = 2;
                        headerCell27.Colspan = 1;
                        headerCell27.Padding = 5;
                        headerCell27.BorderWidth = 1.5f;
                        headerCell27.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell27.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell27);
                        
                        PdfPCell headerCell28 = new PdfPCell(new Phrase("Condensate Cond. (mS/cm)"));
                        headerCell28.Rowspan = 2;
                        headerCell28.Colspan = 1;
                        headerCell28.Padding = 5;
                        headerCell28.BorderWidth = 1.5f;
                        headerCell28.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell28.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell28);
                        
                        PdfPCell headerCell29 = new PdfPCell(new Phrase("Ejector-1 F1G01 Steam Pressure (barG)"));
                        headerCell29.Rowspan = 2;
                        headerCell29.Colspan = 1;
                        headerCell29.Padding = 5;
                        headerCell29.BorderWidth = 1.5f;
                        headerCell29.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell29.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell29);
                        
                        PdfPCell headerCell30 = new PdfPCell(new Phrase("Ejector-2 S2G01 Steam Pressure (barG)"));
                        headerCell30.Rowspan = 2;
                        headerCell30.Colspan = 1;
                        headerCell30.Padding = 5;
                        headerCell30.BorderWidth = 1.5f;
                        headerCell30.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell30.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell30);
                        
                        PdfPCell headerCell31 = new PdfPCell(new Phrase("Conc. Flow After Cal 3 (kg/hr)"));
                        headerCell31.Rowspan = 2;
                        headerCell31.Colspan = 1;
                        headerCell31.Padding = 5;
                        headerCell31.BorderWidth = 1.5f;
                        headerCell31.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell31.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell31);
                        
                        PdfPCell headerCell32 = new PdfPCell(new Phrase("Flow totalizer"));
                        headerCell32.Rowspan = 2;
                        headerCell32.Colspan = 1;
                        headerCell32.Padding = 5;
                        headerCell32.BorderWidth = 1.5f;
                        headerCell32.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell32.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell32);
                        
                        PdfPCell headerCell33 = new PdfPCell(new Phrase("Final Conc. Density (kg/m3)"));
                        headerCell33.Rowspan = 2;
                        headerCell33.Colspan = 1;
                        headerCell33.Padding = 5;
                        headerCell33.BorderWidth = 1.5f;
                        headerCell33.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell33.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell33);
                        
                        PdfPCell headerCell34 = new PdfPCell(new Phrase("Final Conc. Flow (kg/hr)"));
                        headerCell34.Rowspan = 2;
                        headerCell34.Colspan = 1;
                        headerCell34.Padding = 5;
                        headerCell34.BorderWidth = 1.5f;
                        headerCell34.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell34.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell34);
                        
                        PdfPCell headerCell35 = new PdfPCell(new Phrase("Final Conc. Temp. (°C)"));
                        headerCell35.Rowspan = 2;
                        headerCell35.Colspan = 1;
                        headerCell35.Padding = 5;
                        headerCell35.BorderWidth = 1.5f;
                        headerCell35.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell35.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell35);

                        float[] widthsTAS = {
                            50f, 100f, 90f, 120f, 90f, 
                            90f, 90f, 110f, 110f, 80f,
                            90f, 90f, 80f, 90f, 90f, 
                            80f, 70f, 70f, 70f, 110f,//CAl-1
                            110f, 110f, 80f, 90f, 90f, 
                            90f, 90f, 80f, 110f, 90f,
                            90f, 90f, 80f, 90f, 90f,90f
                        };
                        pdfPTable.SetWidths(widthsTAS);



                        foreach (GridViewRow gridViewRow in gvEvaporator.Rows)
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

                        Response.AddHeader("content-disposition", "attachment;" + "filename=Evaporator_Data_Log_Report_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("HH:mm:ss") + ".pdf");
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
                        ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Evaporator Data Log Report", FONT), 1190, 1665, 0);
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

        #region Export to Excel
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
                string filename = "Evaporator_Data_Log_Report_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("HH:mm:ss") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvEvaporator.AllowPaging = false;
                gvEvaporator.GridLines = GridLines.Both;
                foreach (TableCell cell in gvEvaporator.HeaderRow.Cells)
                {
                    cell.BackColor = gvEvaporator.HeaderStyle.BackColor;
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


                foreach (GridViewRow row in gvEvaporator.Rows)
                {

                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvEvaporator.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvEvaporator.RowStyle.BackColor;
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


                gvEvaporator.RenderControl(hw);
                string strSubTitle = "Evaporator Data Log Report";

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

        #region Go button event
        protected void btnGo_Click(object sender, EventArgs e)
        {
            EvaporatorLogReport();
        }
        #endregion

        #region On row created

        protected void gvEvaporator_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                if (e.Row.RowType == DataControlRowType.Header)
                {
                    GridViewRow headerRow1 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                    //GridViewRow headerRow2 = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);


                    TableHeaderCell headerTableCell = new TableHeaderCell();

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "Sr. No.";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "Date";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.Text = "Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    //headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Plant Status";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Evap. Balance Tank Level (%)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Feed FLow (Kg/Hr)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Feed FLow Totalizer";
                    headerRow1.Controls.Add(headerTableCell);


                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Feed Conductivity (mS/cm)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Feed Preheater Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);


                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "PCD Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "FV-1 Heating Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "FV-2 Heating Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "DSI In Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "FV-1 Regeneration Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "FV-2 Regeneration Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Cal-1 Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Cal-2 Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Cal-3 Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Cal-4 Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);
                    headerTableCell = new TableHeaderCell();
                    
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Condenser CW In Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Condenser CW Out Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Condenser Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Plant Vacuum (mbar)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "PCD TVR Pressure (barg)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Cal TVR Pressure (barg)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "DSI Back Pressure (barg)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "DSI Steam Supply Pressure (barg)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "DSI Outlet Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Condensate Cond. (mS/cm)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Ejector-1 F1G01 Steam Pressure (barG)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Ejector-2 S2G01 Steam Pressure (barG)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Conc. Flow after Cal 3 (kg/hr)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Flow Totalizer";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Final Conc. Density (kg/m3)";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Final Conc. Flow (kg/hr)";
                    headerRow1.Controls.Add(headerTableCell);
                    
                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    // headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "Final Conc Temp. (°C)";
                    headerRow1.Controls.Add(headerTableCell);

                    gvEvaporator.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }

        }

        protected void gvEvaporator_PreRender(object sender, EventArgs e)
        {

        }
        #endregion

    }
}