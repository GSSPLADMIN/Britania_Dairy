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
    public partial class RWSTStorage : System.Web.UI.Page
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
        public void RWSTStorageLog()
        {
            try
            {
                ApplicationResult objResult = new ApplicationResult();
                RWSTStorageBL objRwstStorage = new RWSTStorageBL();
                DateTime dtFromDateTime = DateTime.ParseExact(txtFromDate.Text + " " + txtFromTime.Text, "dd/MM/yyyy HH:mm:ss",
                  CultureInfo.InvariantCulture);
                DateTime dtToDateTime = DateTime.ParseExact(txtToDate.Text + " " + txtToTime.Text, "dd/MM/yyyy HH:mm:ss",
                    CultureInfo.InvariantCulture);

                if (dtFromDateTime <= dtToDateTime)
                {
                    objResult = objRwstStorage.RWSTStorageReport(dtFromDateTime, dtToDateTime);
                    if (objResult.ResultDt.Rows.Count > 0)
                    {
                        gvRWSTStorage.DataSource = objResult.ResultDt;
                        gvRWSTStorage.DataBind();
                        // imgWordButton.Visible = imgExcelButton.Visible = true;
                        divNo.Visible = false;
                        divExport.Visible = true;
                        gvRWSTStorage.Visible = true;
                    }
                    else
                    {
                        divNo.Visible = true;
                        divExport.Visible = false;
                        gvRWSTStorage.Visible = false;
                    }
                }
                else
                {
                    gvRWSTStorage.Visible = false;
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



        protected void LinkButton1_Click(object sender, EventArgs e)
        {

        }

        protected void imgPDFButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Session[ApplicationSession.OrganisationName].ToString();
                string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                string text2 = "RWST STORAGE  REPORT";

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

                        string content = "<table style='display: table;width: 900px; clear:both;'> <tr> <th colspan='4' style='float: left;padding-left: 350px;'><div align='left'><strong>From Date: </strong>" + txtFromDate.Text + "</div></th>";

                        content += "<th style='float:left; padding-left:-180px;'></th>";

                        content += "<th style='float:left; padding-left:-210px;'></th>";

                        content += "<th colspan='1' align='left' style=' float: left; padding-left:-200px;'><strong> To Date: </strong>" +
                        txtToDate.Text + "</th>" +
                        "</tr></table>";
                        sb.Append(content);
                        sb.Append("<br/>");

                        PdfPTable pdfPTable = new PdfPTable(gvRWSTStorage.HeaderRow.Cells.Count);
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

                        PdfPCell headerCell2 = new PdfPCell(new Phrase("W11T01"));
                        headerCell2.Rowspan = 1;
                        headerCell2.Colspan = 6;
                        headerCell2.Padding = 5;
                        headerCell2.BorderWidth = 1.5f;
                        headerCell2.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell2);

                        PdfPCell headerCell3 = new PdfPCell(new Phrase("W12T02"));
                        headerCell3.Rowspan = 1;
                        headerCell3.Colspan = 6;
                        headerCell3.Padding = 5;
                        headerCell3.BorderWidth = 1.5f;
                        headerCell3.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell3);






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

                        PdfPCell headerCell11 = new PdfPCell(new Phrase("Temp (°C)"));
                        headerCell11.Rowspan = 1;
                        headerCell11.Colspan = 1;
                        headerCell11.Padding = 5;
                        headerCell11.BorderWidth = 1.5f;
                        headerCell11.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell11);

                        PdfPCell headerCell12 = new PdfPCell(new Phrase("Ageing Time(hr)"));
                        headerCell12.Rowspan = 1;
                        headerCell12.Colspan = 1;
                        headerCell12.Padding = 5;
                        headerCell12.BorderWidth = 1.5f;
                        headerCell12.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell12.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell12);

                        PdfPCell headerCell13 = new PdfPCell(new Phrase("Dirty Timer(hr)"));
                        headerCell13.Rowspan = 1;
                        headerCell13.Colspan = 1;
                        headerCell13.Padding = 5;
                        headerCell13.BorderWidth = 1.5f;
                        headerCell13.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell13.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell13);



                        PdfPCell headerCell16 = new PdfPCell(new Phrase("Types Of Whey"));
                        headerCell16.Rowspan = 1;
                        headerCell16.Colspan = 1;
                        headerCell16.Padding = 5;
                        headerCell16.BorderWidth = 1.5f;
                        headerCell16.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell16.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell16);

                        PdfPCell headerCell17 = new PdfPCell(new Phrase("Tank Status"));
                        headerCell17.Rowspan = 1;
                        headerCell17.Colspan = 1;
                        headerCell17.Padding = 5;
                        headerCell17.BorderWidth = 1.5f;
                        headerCell17.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell17.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell17);

                        PdfPCell headerCell18 = new PdfPCell(new Phrase("Qty(Ltrs)"));
                        headerCell18.Rowspan = 1;
                        headerCell18.Colspan = 1;
                        headerCell18.Padding = 5;
                        headerCell18.BorderWidth = 1.5f;
                        headerCell18.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell18.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell18);

                        PdfPCell headerCell19 = new PdfPCell(new Phrase("Temp (°C)"));
                        headerCell19.Rowspan = 1;
                        headerCell19.Colspan = 1;
                        headerCell19.Padding = 5;
                        headerCell19.BorderWidth = 1.5f;
                        headerCell19.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell19.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell19);



                        PdfPCell headerCell20 = new PdfPCell(new Phrase("Ageing Time(hr)"));
                        headerCell20.Rowspan = 1;
                        headerCell20.Colspan = 1;
                        headerCell20.Padding = 5;
                        headerCell20.BorderWidth = 1.5f;
                        headerCell20.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell20.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell20);



                        PdfPCell headerCell21 = new PdfPCell(new Phrase("Dirty Timer(hr)"));
                        headerCell21.Rowspan = 1;
                        headerCell21.Colspan = 1;
                        headerCell21.Padding = 5;
                        headerCell21.BorderWidth = 1.5f;
                        headerCell21.HorizontalAlignment = Element.ALIGN_CENTER;
                        headerCell21.VerticalAlignment = Element.ALIGN_MIDDLE;
                        pdfPTable.AddCell(headerCell21);

                        //PdfPCell headerCell22 = new PdfPCell(new Phrase("Inoculation Time(min) "));
                        //headerCell22.Rowspan = 1;
                        //headerCell22.Colspan = 1;
                        //headerCell22.Padding = 5;
                        //headerCell22.BorderWidth = 1.5f;
                        //headerCell22.HorizontalAlignment = Element.ALIGN_CENTER;
                        //headerCell22.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //pdfPTable.AddCell(headerCell22);

                        //PdfPCell headerCell23 = new PdfPCell(new Phrase("Curd Breaking Time(min)"));
                        //headerCell23.Rowspan = 1;
                        //headerCell23.Colspan = 1;
                        //headerCell23.Padding = 5;
                        //headerCell23.BorderWidth = 1.5f;
                        //headerCell23.HorizontalAlignment = Element.ALIGN_CENTER;
                        //headerCell23.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //pdfPTable.AddCell(headerCell23);

                        //PdfPCell headerCell24 = new PdfPCell(new Phrase("Ageing Time(hr)"));
                        //headerCell24.Rowspan = 1;
                        //headerCell24.Colspan = 1;
                        //headerCell24.Padding = 5;
                        //headerCell24.BorderWidth = 1.5f;
                        //headerCell24.HorizontalAlignment = Element.ALIGN_CENTER;
                        //headerCell24.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //pdfPTable.AddCell(headerCell24);



                        //PdfPCell headerCell25 = new PdfPCell(new Phrase("Qty (Kgs)"));
                        //headerCell25.Rowspan = 1;
                        //headerCell25.Colspan = 1;
                        //headerCell25.Padding = 5;
                        //headerCell25.BorderWidth = 1.5f;
                        //headerCell25.HorizontalAlignment = Element.ALIGN_CENTER;
                        //headerCell25.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //pdfPTable.AddCell(headerCell25);



                        //PdfPCell headerCell26 = new PdfPCell(new Phrase("Temp (°C)"));
                        //headerCell26.Rowspan = 1;
                        //headerCell26.Colspan = 1;
                        //headerCell26.Padding = 5;
                        //headerCell26.BorderWidth = 1.5f;
                        //headerCell26.HorizontalAlignment = Element.ALIGN_CENTER;
                        //headerCell26.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //pdfPTable.AddCell(headerCell26);

                        //PdfPCell headerCell27 = new PdfPCell(new Phrase("Inoculation Time(min) "));
                        //headerCell27.Rowspan = 1;
                        //headerCell27.Colspan = 1;
                        //headerCell27.Padding = 5;
                        //headerCell27.BorderWidth = 1.5f;
                        //headerCell27.HorizontalAlignment = Element.ALIGN_CENTER;
                        //headerCell27.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //pdfPTable.AddCell(headerCell27);

                        //PdfPCell headerCell28 = new PdfPCell(new Phrase("Curd Breaking Time(min)"));
                        //headerCell28.Rowspan = 1;
                        //headerCell28.Colspan = 1;
                        //headerCell28.Padding = 5;
                        //headerCell28.BorderWidth = 1.5f;
                        //headerCell28.HorizontalAlignment = Element.ALIGN_CENTER;
                        //headerCell28.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //pdfPTable.AddCell(headerCell28);

                        //PdfPCell headerCell29 = new PdfPCell(new Phrase("Ageing Time(hr)"));
                        //headerCell29.Rowspan = 1;
                        //headerCell29.Colspan = 1;
                        //headerCell29.Padding = 5;
                        //headerCell29.BorderWidth = 1.5f;
                        //headerCell29.HorizontalAlignment = Element.ALIGN_CENTER;
                        //headerCell29.VerticalAlignment = Element.ALIGN_MIDDLE;
                        //pdfPTable.AddCell(headerCell29);





                        float[] widthsTAS = { 90f,90f, 90f, 90f, 90f, 90f, 90f, 90f, 90f, 90f,
                                            90f, 90f, 90f, 90f, 90f
                        };
                        pdfPTable.SetWidths(widthsTAS);



                        foreach (GridViewRow gridViewRow in gvRWSTStorage.Rows)
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

                        Response.AddHeader("content-disposition", "attachment;" + "filename=RWST STORAGE  REPORT" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".pdf");
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
                        ColumnText.ShowTextAligned(cb, Element.ALIGN_LEFT, new Phrase("RWST Storage REPORT", FONT), 1190, 1665, 0);
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

        protected void imgExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                string text = Session[ApplicationSession.OrganisationName].ToString();
                string text1 = Session[ApplicationSession.OrganisationAddress].ToString();
                string text2 = " RWST STORAGE STATUS REPORT";
                string filename = "RWST STORAGE STATUS REPORT_" + DateTime.Now.Date.ToString("dd-MM-yyyy") + ".xls";
                Response.AddHeader("content-disposition", "attachment;filename=" + filename);
                //Response.AddHeader("content-disposition", "attachment;filename=WeighbridgeSummaryReport.xls");
                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                HtmlTextWriter hw = new HtmlTextWriter(sw);
                gvRWSTStorage.AllowPaging = false;
                gvRWSTStorage.RenderControl(hw);
                string strTitle = text;
                string Date = DateTime.UtcNow.AddHours(5.5).ToString();
                string strSubTitle = text2 + "</br>";
                //string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + "/images/Logo1.gif";
                string strPath = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath());
                string strPath1 = Request.Url.GetLeftPart(UriPartial.Authority) + (new CommonClass().SetLogoPath1());

                string content = "<div align='left' style='font-family:verdana;font-size:16px'><img width='100' height='100' src='" + strPath + "'/></div><div align='center' style='font-family:verdana;font-size:16px;style='text-align:center'><img width='100' height='100' src='" + strPath1 + "'/></div><div align='center' style='font-family:verdana;font-size:16px'><span style='font-size:16px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationName] +
                       "</span><br/><span style='font-size:13px;font-weight:bold;color:Black;'>" + Session[ApplicationSession.OrganisationAddress] + "</span><br/>" +
                          "<span align='center' style='font-family:verdana;font-size:13px'><strong>" + strSubTitle + "</strong></span><br/>" +
                          "<div align='center' style='font-family:verdana;font-size:12px'><strong>From Date :</strong>" +
                      DateTime.ParseExact(txtFromDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) +
                       "&nbsp;&nbsp;&nbsp;&nbsp;<strong> To Date :</strong>" +
                       DateTime.ParseExact(txtToDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture) +
                       "</div><br/> "
                       + sw.ToString() + "<br/></div>";
                Response.Output.Write(content);
                Response.Flush();
                Response.End();
            }
            catch (Exception ex)
            {
                // log.Error("Button EXCEL", ex);
                ScriptManager.RegisterStartupScript(this, GetType(), "alert", "alert('Oops! There is some technical issue. Please Contact to your administrator.');", true);
            }
        }

        protected void gvRWSTStorage_RowCreated(object sender, GridViewRowEventArgs e)
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
                    headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "W11T01";
                    headerRow1.Controls.Add(headerTableCell);

                    headerTableCell = new TableHeaderCell();
                    headerTableCell.RowSpan = 1;
                    headerTableCell.ColumnSpan = 6;
                    headerTableCell.Text = "W12T01";
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
                    //headerCell13 = new TableHeaderCell();
                    //headerCell14 = new TableHeaderCell();
                    //headerCell15 = new TableHeaderCell();

                    //headerCell16 = new TableHeaderCell();
                    //headerCell17 = new TableHeaderCell();
                    //headerCell18 = new TableHeaderCell();
                    //headerCell19 = new TableHeaderCell();
                    //headerCell20 = new TableHeaderCell();

                    //headerCell21 = new TableHeaderCell();
                    //headerCell22 = new TableHeaderCell();
                    //headerCell23 = new TableHeaderCell();
                    //headerCell24 = new TableHeaderCell();
                    //headerCell25 = new TableHeaderCell();
                    //headerCell26 = new TableHeaderCell();
                    //headerCell27 = new TableHeaderCell();
                    //headerCell28 = new TableHeaderCell();



                    headerCell1.Text = "Types of Whey";
                    headerCell2.Text = "Tank Status";
                    headerCell3.Text = "Qty (Ltrs)";
                    headerCell4.Text = "Temp (°C)";
                    headerCell5.Text = "Ageing timer(hr)";
                    headerCell6.Text = "Dirty Time(hr)";



                    headerCell7.Text = "Types of Whey";
                    headerCell8.Text = "Tank Status";
                    headerCell9.Text = "Qty (Ltrs)";
                    headerCell10.Text = "Temp (°C)";
                    headerCell11.Text = "Ageing timer(hr)";
                    headerCell12.Text = "Dirty Time(hr)";


                    //headerCell15.Text = "Qty (Ltrs)";
                    //headerCell16.Text = "Temp (°C)";
                    //headerCell17.Text = "Inoculation Time(min)";
                    //headerCell18.Text = "Curd Breaking Time(min)";
                    //headerCell19.Text = "Ageing Time(hr)";
                    //headerCell20.Text = "CIP Time(hr)";
                    //headerCell21.Text = "QC Released Time";

                    //headerCell22.Text = "Qty (Ltrs)";
                    //headerCell23.Text = "Temp (°C)";
                    //headerCell24.Text = "Inoculation Time(min)";
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
                    //headerRow2.Controls.Add(headerCell13);
                    //headerRow2.Controls.Add(headerCell14);
                    //headerRow2.Controls.Add(headerCell15);

                    //headerRow2.Controls.Add(headerCell16);
                    //headerRow2.Controls.Add(headerCell17);
                    //headerRow2.Controls.Add(headerCell18);
                    //headerRow2.Controls.Add(headerCell19);
                    //headerRow2.Controls.Add(headerCell20);

                    //headerRow2.Controls.Add(headerCell21);
                    //headerRow2.Controls.Add(headerCell22);
                    //headerRow2.Controls.Add(headerCell23);
                    //headerRow2.Controls.Add(headerCell24);
                    //headerRow2.Controls.Add(headerCell25);
                    //headerRow2.Controls.Add(headerCell26);
                    //headerRow2.Controls.Add(headerCell27);
                    //headerRow2.Controls.Add(headerCell28);


                    gvRWSTStorage.Controls[0].Controls.AddAt(0, headerRow2);
                    gvRWSTStorage.Controls[0].Controls.AddAt(0, headerRow1);
                }
            }
        }

        protected void gvRWSTStorage_PreRender(object sender, EventArgs e)
        {

        }

        protected void btnGo_Click(object sender, EventArgs e)
        {
            RWSTStorageLog();
        }
    }
}