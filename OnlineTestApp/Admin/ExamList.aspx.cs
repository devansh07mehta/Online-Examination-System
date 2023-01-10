using OnlineTestApp.App_Code;
using OnlineTestApp.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTestApp.Admin
{
    public partial class ExamList : System.Web.UI.Page
    {
        Admin_DAL objadmin = new Admin_DAL();
        Teacher_DAL objteacher = new Teacher_DAL();
        clsGetData GD = new clsGetData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();

            }
        }

        public void BindGrid()
        {
            DataSet ds = new DataSet();
            ds = objadmin.GetAllExaminationList();
            grvAvailableExam.DataSource = ds;
            grvAvailableExam.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            LinkButton lnk = sender as LinkButton;
            GridViewRow row = (GridViewRow)lnk.NamingContainer;
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con = new SqlConnection(consString);
                con.Open();

                string queryString = "Select * from tbl_Admin where UserName=@usnm";

                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@usnm", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();
                    Session["Name"] = fname;
                    Response.Redirect("~/Admin/QuestionList.aspx?ExamId=" + lnk.CommandArgument + "&StudentId=" + row.Cells[0].Text + "&name=" + fname);


                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Pages/Index/Home_Page/index.html';</script>");
                }
            }

            //Response.Redirect("~/Admin/QuestionList.aspx?ID=" + ID);


        }

        protected void grvAvailableExam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvAvailableExam.PageIndex=e.NewPageIndex;
            DataSet ds = new DataSet();
            ds = objadmin.GetAllExaminationList();
            grvAvailableExam.DataSource = ds;
            grvAvailableExam.DataBind();
        }
    }
}