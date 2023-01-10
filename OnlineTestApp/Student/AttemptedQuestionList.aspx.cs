using OnlineTestApp.App_Code;
using OnlineTestApp.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;
using System.IO;
using Syncfusion.HtmlConverter;
using Syncfusion.Pdf;

namespace OnlineTestApp.Student
{
    public partial class AttemptedQuestionList : System.Web.UI.Page
    {
        //Teacher_DAL objteacher = new Teacher_DAL();
        Student_DAL objstudent = new Student_DAL();
        clsGetData GD = new clsGetData();
        protected void Page_Load(object sender, EventArgs e)
        {
            int StudentId = GD.GetInt_Zero(Session["UserId"]);

            if (Request.QueryString["ID"] != "0" && Request.QueryString["ID"] != null)
            {
                int ID = GD.GetInt_Zero(Request.QueryString["ID"]);
                BindGrid(StudentId, ID);

            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //required to avoid the runtime error "  
            //Control 'GridView1' of type 'GridView' must be placed inside a form tag with runat=server."  
        }


        public void BindGrid(int StudentId, int ExamId)
        {
            DataSet ds = new DataSet();
            ds = objstudent.GetExamResultListById(StudentId, ExamId);
            grvQuestionList.DataSource = ds;
            grvQuestionList.DataBind();
        }

        protected void grvQuestionList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //TableCell cell = e.Row.Cells[9];
                //int IsPass = GD.GetInt_Zero(cell.Text);
                if (e.Row.Cells[9].Text == "1")
                {
                    e.Row.Cells[7].BackColor = Color.Green;
                }
                if (e.Row.Cells[9].Text == "0")
                {
                    e.Row.Cells[7].BackColor = Color.Red;
                }

            }
        }

        protected void grvQuestionList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvQuestionList.PageIndex = e.NewPageIndex;
            grvQuestionList.DataBind();
        }

        private void Export()
        {
            //Initialize HTML to PDF converter 
            HtmlToPdfConverter htmlConverter = new HtmlToPdfConverter(HtmlRenderingEngine.WebKit);
            WebKitConverterSettings settings = new WebKitConverterSettings();
            //Set WebKit path
            settings.WebKitPath = Server.MapPath("~/QtBinaries");
            //Assign WebKit settings to HTML converter
            htmlConverter.ConverterSettings = settings;
            //Get the current URL
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            //Convert URL to PDF
            Syncfusion.Pdf.PdfDocument document = htmlConverter.Convert(url);
            //Save the document
            document.Save("Output.pdf", HttpContext.Current.Response, HttpReadType.Save);
        }

        private void ExportGridToPDF()
        {

            //Response.ContentType = "application/pdf";
            //Response.AddHeader("content-disposition", "attachment;filename=Vithal_Wadje.pdf");
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //StringWriter sw = new StringWriter();
            //HtmlTextWriter hw = new HtmlTextWriter(sw);
            //grvQuestionList.RenderControl(hw);
            //StringReader sr = new StringReader(sw.ToString());
            //Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            //pdfDoc.Open();
            //htmlparser.Parse(sr);
            //pdfDoc.Close();
            //Response.Write(pdfDoc);
            //Response.End();
            //grvQuestionList.AllowPaging = true;
            //grvQuestionList.DataBind();


            int StudentId = GD.GetInt_Zero(Session["UserId"]);
            int ID = 0;
            if (Request.QueryString["ID"] != "0" && Request.QueryString["ID"] != null)
            {
                 ID = GD.GetInt_Zero(Request.QueryString["ID"]);

            }

            using (StringWriter sw = new StringWriter())
            {
                using (HtmlTextWriter hw = new HtmlTextWriter(sw))
                {
                    //To Export all pages
                    grvQuestionList.AllowPaging = false;
                    BindGrid(StudentId, ID);


                    grvQuestionList.RenderControl(hw);
                    //this.Page.RenderControl(hw);
                    StringReader sr = new StringReader(sw.ToString());
                    Document pdfDoc = new Document(PageSize.A2, 10f, 10f, 10f, 0f);
                    HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
                    PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
                    pdfDoc.Open();
                    htmlparser.Parse(sr);
                    pdfDoc.Close();

                    Response.ContentType = "application/pdf";
                    Response.AddHeader("content-disposition", "attachment;filename=Answer_Key.pdf");
                    Response.Cache.SetCacheability(HttpCacheability.NoCache);
                    Response.Write(pdfDoc);
                    Response.End();
                }
            }
        }



        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
            //Export();
        }
    }
}