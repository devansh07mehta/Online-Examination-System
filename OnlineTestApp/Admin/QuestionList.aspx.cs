
using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;
using OnlineTestApp.App_Code;
using OnlineTestApp.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTestApp.Admin
{
    public partial class QuestionList : System.Web.UI.Page
    {
        int ExamId = 0;
        int StudentId = 0;
        Student_DAL objstudent = new Student_DAL();
        clsGetData GD = new clsGetData();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["ExamId"] != "0" && Request.QueryString["ExamId"] != null)
                {
                    ExamId = GD.GetInt_Zero(Request.QueryString["ExamId"]);
             

                }

                if (Request.QueryString["StudentId"] != "0" && Request.QueryString["StudentId"] != null)
                {
                     StudentId = GD.GetInt_Zero(Request.QueryString["StudentId"]);
                   

                }

                BindGrid(StudentId, ExamId);


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


        protected void btnExport_Click(object sender, EventArgs e)
        {
            ExportGridToPDF();
        }

        private void ExportGridToPDF()
        {

            Response.ContentType = "application/pdf";
            Response.AddHeader("content-disposition", "attachment;filename=Answer_Key.pdf");
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            grvQuestionList.RenderControl(hw);
            StringReader sr = new StringReader(sw.ToString());
            Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
            HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
            PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
            pdfDoc.Open();
            htmlparser.Parse(sr);
            pdfDoc.Close();
            Response.Write(pdfDoc);
            Response.End();
            grvQuestionList.AllowPaging = true;
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
    }
}