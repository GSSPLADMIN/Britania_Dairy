using System;
using System.Collections.Generic;
using System.Globalization;
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
using Font = iTextSharp.text.Font;
using System.IO;

namespace Powder_MISProduct.ReportUI
{
    public partial class CrystallizationTankStatus_SCM : System.Web.UI.Page
    {
        #region Page Load
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

        #region BindGrid
        public void BindGridCrystallizationSCMReport()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                CrystallizationTankStatus_SCMBL objBL = new CrystallizationTankStatus_SCMBL();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                  CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);

                if (dtFromDateTime <= dtToDateTime)
                {
                    objResult = objBL.BindGridCrystallizationSCMReport(dtFromDateTime, dtToDateTime);
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvCrystallization.DataSource = objResult.ResultDt;
                        gvCrystallization.DataBind();
                        // imgWordButton.Visible = imgExcelButton.Visible = true;
                        divExport.Visible = true;
                        divNo.Visible = false;
                        gvCrystallization.Visible = true;

                    }
                    else
                    {
                        // imgWordButton.Visible = imgExcelButton.Visible = false;
                        divExport.Visible = false;
                        divNo.Visible = true;
                        gvCrystallization.Visible = false;
                        // ClientScript.RegisterStartupScript(typeof(Page), "MessagePopUp",
                        //"<script>alert('No Record Found.');</script>");
                    }
                }
                else
                {
                    gvCrystallization.Visible = false;
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

        #region On click Go button event
        protected void btnGo_Click(object sender, EventArgs e)
        {
            BindGridCrystallizationSCMReport();
        }
        #endregion

        #region Grid view row created event

        protected void gvCrystallization_SCM_RowCreated(object sender, GridViewRowEventArgs e)
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
                    headerTableCell.Text = "Date & Time";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan =3;
                    headerTableCell.Text = "Crystallization Tank - 1";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 3;
                    headerTableCell.Text = "Crystallization Tank - 2";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 3;
                    headerTableCell.Text = "Crystallization Tank - 3";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 3;
                    headerTableCell.Text = "Crystallization Tank - 4";
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

                    headerCell1.Text = "Tank Temp. (°C)";
                    headerCell2.Text = "Chilling Temp. (°C)";
                    headerCell3.Text = "Tank Level (%)";
                    
                    headerCell4.Text = "Tank Temp. (°C)";
                    headerCell5.Text = "Chilling Temp. (°C)";
                    headerCell6.Text = "Tank Level (%)";
                    
                    headerCell7.Text = "Tank Temp. (°C)";
                    headerCell8.Text = "Chilling Temp. (°C)";
                    headerCell9.Text = "Tank Level (%)";

                    headerCell10.Text = "Tank Temp. (°C)";
                    headerCell11.Text = "Chilling Temp. (°C)";
                    headerCell12.Text = "Tank Level (%)";

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

                    gvCrystallization.Controls[0].Controls.AddAt(0, headerRow2);
                    gvCrystallization.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }
        }

        #endregion

        #region PDF export.
        protected void imgPDFButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Session[ApplicationSession.OrganisationName].ToString();
                string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                string text2 = "Crystallization SCM Tank Status Report";

                using (StringWriter sw = new StringWriter())
                {
                    using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                    {
                        DateTime dtfromDateTime = DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);

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

                        PdfPTable pdfPTable = new PdfPTable(gvCrystallization.HeaderRow.Cells.Count);
                        iTextSharp.text.Font fontHeader = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 25, iTextSharp.text.Font.BOLD);
                        Font header = new Font(Font.FontFamily.TIMES_ROMAN, 20f, Font.BOLD, BaseColor.BLACK);



                        PdfPCell headerCell1 = new PdfPCell(new Phrase("Sr. No."));
                        headerCell1.Rowspan = 2;
                        headerCell1.Colspan = 1;
                        headerCell1.Padding = 5;
                        headerCell1.BorderWidth = 1.5f;
                        headerCell1.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell1.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell1);

                        PdfPCell headerCell = new PdfPCell(new Phrase("Date & Time"));
                        headerCell.Rowspan = 2;
                        headerCell.Colspan = 1;
                        headerCell.Padding = 5;
                        headerCell.BorderWidth = 1.5f;
                        headerCell.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell);

                        PdfPCell headerCell2 = new PdfPCell(new Phrase("Crystallization Tank - 1"));
                        headerCell2.Rowspan = 1;
                        headerCell2.Colspan = 3;
                        headerCell2.Padding = 5;
                        headerCell2.BorderWidth = 1.5f;
                        headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell2.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell2);

                        PdfPCell headerCell3 = new PdfPCell(new Phrase("Crystallization Tank - 2"));
                        headerCell3.Rowspan = 1;
                        headerCell3.Colspan = 3;
                        headerCell3.Padding = 5;
                        headerCell3.BorderWidth = 1.5f;
                        headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell3.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell3);

                        PdfPCell headerCell4 = new PdfPCell(new Phrase("Crystallization Tank - 3"));
                        headerCell4.Rowspan = 1;
                        headerCell4.Colspan = 3;
                        headerCell4.Padding = 5;
                        headerCell4.BorderWidth = 1.5f;
                        headerCell4.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell4.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell4);

                        PdfPCell headerCell5 = new PdfPCell(new Phrase("Crystallization Tank - 4"));
                        headerCell5.Rowspan = 1;
                        headerCell5.Colspan = 3;
                        headerCell5.Padding = 5;
                        headerCell5.BorderWidth = 1.5f;
                        headerCell5.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell5.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell5);

                        //Sub header of Crystallization Tank - 1
                        PdfPCell headerCell6 = new PdfPCell(new Phrase("Tank Temp. (°C)"));
                        headerCell6.Rowspan = 1;
                        headerCell6.Colspan = 1;
                        headerCell6.Padding = 5;
                        headerCell6.BorderWidth = 1.5f;
                        headerCell6.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell6.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell6);

                        PdfPCell headerCell7 = new PdfPCell(new Phrase("Chilling Temp. (°C)"));
                        headerCell7.Rowspan = 1;
                        headerCell7.Colspan = 1;
                        headerCell7.Padding = 5;
                        headerCell7.BorderWidth = 1.5f;
                        headerCell7.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell7.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell7);

                        PdfPCell headerCell8 = new PdfPCell(new Phrase("Tank Level (%)"));
                        headerCell8.Rowspan = 1;
                        headerCell8.Colspan = 1;
                        headerCell8.Padding = 5;
                        headerCell8.BorderWidth = 1.5f;
                        headerCell8.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell8.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell8);

                        //Sub header of Crystallization Tank - 2
                        PdfPCell headerCell9 = new PdfPCell(new Phrase("Tank Temp. (°C)"));
                        headerCell9.Rowspan = 1;
                        headerCell9.Colspan = 1;
                        headerCell9.Padding = 5;
                        headerCell9.BorderWidth = 1.5f;
                        headerCell9.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell9.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell9);

                        PdfPCell headerCell10 = new PdfPCell(new Phrase("Chilling Temp. (°C)"));
                        headerCell10.Rowspan = 1;
                        headerCell10.Colspan = 1;
                        headerCell10.Padding = 5;
                        headerCell10.BorderWidth = 1.5f;
                        headerCell10.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell10.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell10);

                        PdfPCell headerCell11 = new PdfPCell(new Phrase("Tank Level (%)"));
                        headerCell11.Rowspan = 1;
                        headerCell11.Colspan = 1;
                        headerCell11.Padding = 5;
                        headerCell11.BorderWidth = 1.5f;
                        headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell11.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell11);

                        //Sub header of Crystallization Tank - 3
                        PdfPCell headerCell12 = new PdfPCell(new Phrase("Tank Temp. (°C)"));
                        headerCell12.Rowspan = 1;
                        headerCell12.Colspan = 1;
                        headerCell12.Padding = 5;
                        headerCell12.BorderWidth = 1.5f;
                        headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell12);

                        PdfPCell headerCell13 = new PdfPCell(new Phrase("Chilling Temp. (°C)"));
                        headerCell13.Rowspan = 1;
                        headerCell13.Colspan = 1;
                        headerCell13.Padding = 5;
                        headerCell13.BorderWidth = 1.5f;
                        headerCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell13);

                        PdfPCell headerCell14 = new PdfPCell(new Phrase("Tank Level (%)"));
                        headerCell14.Rowspan = 1;
                        headerCell14.Colspan = 1;
                        headerCell14.Padding = 5;
                        headerCell14.BorderWidth = 1.5f;
                        headerCell14.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell14.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell14);

                        //Sub header of Crystallization Tank - 4
                        PdfPCell headerCell15 = new PdfPCell(new Phrase("Tank Temp. (°C)"));
                        headerCell15.Rowspan = 1;
                        headerCell15.Colspan = 1;
                        headerCell15.Padding = 5;
                        headerCell15.BorderWidth = 1.5f;
                        headerCell15.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell15.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell15);

                        PdfPCell headerCell16 = new PdfPCell(new Phrase("Chilling Temp. (°C)"));
                        headerCell16.Rowspan = 1;
                        headerCell16.Colspan = 1;
                        headerCell16.Padding = 5;
                        headerCell16.BorderWidth = 1.5f;
                        headerCell16.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell16.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell16);

                        PdfPCell headerCell17 = new PdfPCell(new Phrase("Tank Level (%)"));
                        headerCell17.Rowspan = 1;
                        headerCell17.Colspan = 1;
                        headerCell17.Padding = 5;
                        headerCell17.BorderWidth = 1.5f;
                        headerCell17.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell17.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell17);

                        //float[] widthsTAS = {
                        //    20f, 40f, 40f, 40f, 25f,
                        //    25f, 30f, 45f, 40f, 35f,
                        //    29f, 29f, 25f, 25f, 30f,//FV-1 Regeneration Temp.(°C)
                        //    30f, 34f, 30f, 30f, 30f,
                        //    30f, 30f, 30f, 30f, 30f,//FV-2 Vacuum
                        //    35f, 35f, 35f, 35f, 35f,
                        //    35f, 35f, 35f, 45f, 45f,
                        //    43f, 43f, 43f
                        //};

                        // pdfPTable.SetWidths(widthsTAS);

                        foreach (GridViewRow gridViewRow in gvCrystallization.Rows)
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

                        Response.AddHeader("content-disposition", "attachment;" + "filename=Crystallization_SCM_Report_" + DateTime.Now.ToString("dd/MM/yyyy") + "_" + DateTime.Now.ToString("HH:mm:ss") + ".pdf");
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

        #region Excel export.
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
                string filename = "Crystallization_SCM_Report_" + DateTime.Now.ToString("dd-MM-yyyy") + "_" + DateTime.Now.ToString("HH:mm:ss") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                Response.Cache.SetCacheability(HttpCacheability.NoCache);

                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvCrystallization.AllowPaging = false;
                gvCrystallization.GridLines = GridLines.Both;
                foreach (TableCell cell in gvCrystallization.HeaderRow.Cells)
                {
                    cell.BackColor = gvCrystallization.HeaderStyle.BackColor;
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


                foreach (GridViewRow row in gvCrystallization.Rows)
                {

                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gvCrystallization.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gvCrystallization.RowStyle.BackColor;
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


                gvCrystallization.RenderControl(hw);
                string strSubTitle = "Crystallization SCM Tank Status Report";

                string imageURL = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath());
                string imageURL1 = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath1());

                string content = "<div align='center' style='font-family:verdana;font-size:16px; width:800px;'>" +
                  "<table style='display: table; width: 800px; clear:both;'>" +
                  "<tr> </tr>" +
                  "<tr><th></th><th><img height='90' width='120' src='" + imageURL1 + "'/></th>" +
                   strTh +
                  "<th colspan='" + colh + "' style='width: 600px; float: left; font-weight:bold;font-size:16px;'>" + Session[ApplicationSession.OrganisationName] + strTh +
                  "<th></th><th><img  height= '80' width= '100' src='" + imageURL + "'/></th>" +
                     "</tr>" +
                     "<tr><th colspan='2'>'" + strTh + "'</th><th colspan='" + colh + "' style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</th></tr>" +
                     "<tr><th colspan='2'>'" + strTh + "'</th><th colspan='" + colh + "'></th></tr>" +
                     "<tr><th colspan='2'>'" + strTh + "'</th><th colspan='" + colh + "' style='font-size:22px;color:Maroon;'><b>" + strSubTitle + "</b></th></tr>" +
                     "<tr></tr>" +
                     "<tr><th colspan='4' align='left' style='width: 200px; float: left;'><strong> From Date & Time : </strong>" +
                (DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture)).ToString() + "</th>" +
                "<th colspan='" + cold + "'></th>" + strTh + strTh +
                "<th colspan = '4' align = 'right' style = 'width: 200px; float: right;'><strong> To Date & Time : </strong>" +
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
                        ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("Crystallization SCM Tank Status Report", FONT), 1190, 1665, 0);
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
    }
}