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

namespace OnlineTestApp.Teacher
{
    public partial class AddQuestion : System.Web.UI.Page
    {
        Admin_DAL objadmin = new Admin_DAL();
        Teacher_DAL objteacher = new Teacher_DAL();
        clsGetData GD = new clsGetData();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != "0" && Request.QueryString["ID"] != null)
                {
                    int ID = GD.GetInt_Zero(Request.QueryString["ID"]);
                    GetQuestionDetailById(ID);
                    btnSubmit.Text = "Update";

                    
                }

                BinExam();

            }
        }

        public void BinExam()
        {
            DataSet ds = new DataSet();
            ds = objteacher.GetExaminationListByDate();
            ddlExam.DataSource = ds;
            ddlExam.DataTextField = "ExamName";
            ddlExam.DataValueField = "ExamId";
            ddlExam.DataBind();

            ddlExam.Items.Insert(0, new ListItem("--Select Examination--", "0"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int ExamId = GD.GetInt_Zero(ddlExam.SelectedValue);
            String Question = Convert.ToString(txtQuestion.Text);


            String Option1 = Convert.ToString(txtoption1.Text);
            string Option2 = GD.GetstrEmpty(txtoption2.Text);
            String Option3 = GD.GetstrEmpty(txtoption3.Text);
            String Option4 = Convert.ToString(txtoption4.Text);


            int CorrectOption = GD.GetInt_Zero(ddlAnswer.SelectedValue);




            DataSet ds = new DataSet();
            String Msg = "";
            if (btnSubmit.Text == "Submit")
            {
                int Id = 0;

                ds = objteacher.SaveQuestions(Id, Question, Option1, Option2, Option3, Option4, 1, ExamId, CorrectOption);

            }
            else
            {
                int ID = GD.GetInt_Zero(Request.QueryString["ID"]);
                ds = objteacher.SaveQuestions(ID, Question, Option1, Option2, Option3, Option4, 1, ExamId, CorrectOption);




            }
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con = new SqlConnection(consString);
                con.Open();

                string queryString = "Select * from tbl_Teachers where UserName=@usnm";

                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@usnm", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string name = reader[1].ToString();

                    Session["Name"] = name;
                    Response.Redirect("~/Teacher/QuestionList.aspx?name=" + name);

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

        public void GetQuestionDetailById(int Id)
        {
            DataSet ds = new DataSet();
            ds = objteacher.GetQuestionById(Id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                //ddlExam.SelectedValue = GD.GetstrEmpty(ds.Tables[0].Rows[0]["AvailableExam"]);
                txtQuestion.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["Question"]);
                txtoption1.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["Option1"]);
                txtoption2.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["Option2"]);
                txtoption3.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["Option3"]);
                txtoption4.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["Option4"]);
                ddlAnswer.SelectedValue = GD.GetstrEmpty(ds.Tables[0].Rows[0]["QuestionAnswer"]);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlExam.SelectedValue = null;
            txtQuestion.Text = String.Empty;
            txtoption1.Text = String.Empty;
            txtoption2.Text = String.Empty;
            txtoption3.Text = String.Empty;
            txtoption4.Text = String.Empty;
            ddlAnswer.SelectedValue = null;

            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con = new SqlConnection(consString);
                con.Open();

                string queryString = "Select * from tbl_Teachers where UserName=@usnm";

                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@usnm", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    string name = reader[1].ToString();
                    Session["Name"] = name;
                    Response.Redirect("AddQuestion.aspx?name=" + name);
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