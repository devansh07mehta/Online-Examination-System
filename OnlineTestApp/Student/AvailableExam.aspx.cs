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
    public partial class AvailableExam : System.Web.UI.Page
    {

        Admin_DAL objadmin = new Admin_DAL();
        Teacher_DAL objteacher = new Teacher_DAL();
        clsGetData GD = new clsGetData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int StudentId = GD.GetInt_Zero(Session["UserId"]);

                BindGrid(StudentId);

            }

        }

        public void BindGrid(int StudentId)
        {
            DataSet ds = new DataSet();
            ds = objteacher.GetExaminationListByStudentId(StudentId);
            grvAvailableExam.DataSource = ds;
            grvAvailableExam.DataBind();
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int ID = Convert.ToInt32(lnk.CommandArgument);

            string time = DateTime.Now.ToString("t");
            DateTime newtime = Convert.ToDateTime(time);

            DateTime starttime = new DateTime(1, 1, 1, 10, 0, 0); //change fourth number to change start time
            string start = starttime.ToString("hh:mm tt");
            DateTime newstarttime = Convert.ToDateTime(start);


            DateTime endtime = new DateTime(1, 1, 1, 16, 0, 0); //change fourth number to change end time
            String end = endtime.ToString("hh:mm tt");
            DateTime newendtime = Convert.ToDateTime(end);

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
                    Response.Redirect("~/Student/TestPage.aspx?ID=" + ID + "&name=" + fname);


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
            //if (newstarttime <= newtime && newendtime >= newtime)
            //{
            //}
            //else
            //{
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Try Between 10 AM to 4 PM')", true);
            //}


        }

        protected void grvAvailableExam_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grvAvailableExam.PageIndex = e.NewPageIndex;
            int StudentId = GD.GetInt_Zero(Session["UserId"]);

            BindGrid(StudentId);
        }
    }
}