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

namespace OnlineTestApp.Student
{
    public partial class ExamHistory : System.Web.UI.Page
    {
        Admin_DAL objadmin = new Admin_DAL();
        Teacher_DAL objteacher = new Teacher_DAL();
        clsGetData GD = new clsGetData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //if (Request.QueryString["ID"] != "0" && Request.QueryString["ID"] != null)
                //{
                //    int ID = GD.GetInt_Zero(Request.QueryString["ID"]);
                //    //BindQuestionList(ID);

                //}

                int StudentId = GD.GetInt_Zero(Session["UserId"]);

                BindGrid(StudentId);


            }
        }

        public void BindGrid(int StudentId)
        {
            DataSet ds = new DataSet();
            ds = objteacher.GetAppearedExaminationListByStudentId(StudentId);
            grvAvailableExam.DataSource = ds;
            grvAvailableExam.DataBind();
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int ID = Convert.ToInt32(lnk.CommandArgument);
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con = new SqlConnection(consString);
                con.Open();

                string queryString = "Select * from tbl_Students where UserName=@usnm";

                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@usnm", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();
                    Session["Name"] = fname;
                    Response.Redirect("~/Student/AttemptedQuestionList.aspx?ID=" + ID + "&name=" + fname);


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
        }
    }
}