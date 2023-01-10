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
    public partial class TestPage : System.Web.UI.Page
    {
        Admin_DAL objadmin = new Admin_DAL();
        Teacher_DAL objteacher = new Teacher_DAL();
        Student_DAL objstudent = new Student_DAL();
        clsGetData GD = new clsGetData();
        int Selected = 0;
        int Duration = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != "0" && Request.QueryString["ID"] != null)
                {
                    int ExamId = GD.GetInt_Zero(Request.QueryString["ID"]);
                    Session["ExamId"] = ExamId;
                    BindGrid(ExamId);

                    int InSeconds = GetDuration(ExamId) * 60;

                    HiddenField1.Value = GD.GetstrEmpty(InSeconds);

                    
                }


            }

        }

        public int GetDuration(int ExamId)
        {
            DataSet ds = new DataSet();
            ds = objstudent.GetDurationByExamId(ExamId);
            if (ds.Tables.Count > 0)
            {
                Duration = GD.GetInt_Zero(ds.Tables[0].Rows[0]["DurationInMinute"].ToString());
            }

            return Duration;

        }

        public void BindGrid(int ExamId)
        {
            //int ExamId = GD.GetInt_Zero(Request.QueryString["ID"]);

            DataSet ds = new DataSet();
            ds = objstudent.GetQuestionListByExamID(ExamId);
            rgtest.DataSource = ds;
            rgtest.DataBind();

        }

        public void NextQuestion(int QuestionId)
        {
            DataSet dsQuestionList = new DataSet();
            dsQuestionList = objstudent.GetQuestionListByExamID(QuestionId);
            if (dsQuestionList.Tables.Count > 0)
            {
                //lblQuestion.Text = GD.GetstrEmpty(dsQuestionList.Tables[0].Rows[0]["Question"]);
                //lblA.Text = GD.GetstrEmpty(dsQuestionList.Tables[0].Rows[0]["Option1"]);
                //id1.Text = GD.GetstrEmpty(dsQuestionList.Tables[0].Rows[0]["Option1"]);
                //lblB.Text = GD.GetstrEmpty(dsQuestionList.Tables[0].Rows[0]["Option2"]);
                //id2.Text = GD.GetstrEmpty(dsQuestionList.Tables[0].Rows[0]["Option2"]);
                //lblC.Text = GD.GetstrEmpty(dsQuestionList.Tables[0].Rows[0]["Option3"]);
                //id3.Text = GD.GetstrEmpty(dsQuestionList.Tables[0].Rows[0]["Option3"]);
                //lblD.Text = GD.GetstrEmpty(dsQuestionList.Tables[0].Rows[0]["Option4"]);
                //id4.Text = GD.GetstrEmpty(dsQuestionList.Tables[0].Rows[0]["Option4"]);
            }


        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in rgtest.Rows)
            {
                Label lblQuestion = row.FindControl("lblQuestionId") as Label;
                RadioButton R1 = row.FindControl("id1") as RadioButton;
                RadioButton R2 = row.FindControl("id2") as RadioButton;
                RadioButton R3 = row.FindControl("id3") as RadioButton;
                RadioButton R4 = row.FindControl("id4") as RadioButton;

                if (R1.Checked)
                {
                    Selected = 1;
                }
                else if (R2.Checked)
                {
                    Selected = 2;
                }
                else if (R3.Checked)
                {
                    Selected = 3;
                }
                else if (R4.Checked)
                {
                    Selected = 4;
                }

                int StudentId = GD.GetInt_Zero(Session["UserId"]);
                int QuestionId = GD.GetInt_Zero(lblQuestion.Text);

                SaveAnswer(StudentId, GD.GetInt_Zero(Request.QueryString["ID"].ToString()), QuestionId, Selected);
            }

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
                    Response.Redirect("~/Student/ThankYou.aspx?name=" + fname);

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

        public void SaveAnswer(int StudentId, int ExamId, int QuestionId, int Answer)
        {
            DataSet ds = new DataSet();
            ds = objstudent.SaveAnswer(StudentId, ExamId, QuestionId, Answer);
        }
    }
}