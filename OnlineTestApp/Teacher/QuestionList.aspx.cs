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
    public partial class QuestionList : System.Web.UI.Page
    {
        Admin_DAL objadmin = new Admin_DAL();
        clsGetData GD = new clsGetData();
        Teacher_DAL objteacher = new Teacher_DAL();

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
            ds = objteacher.GetQuestionList();
            grvQuestion.DataSource = ds;
            grvQuestion.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int ID = Convert.ToInt32(lnk.CommandArgument);
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
                    Response.Redirect("~/Teacher/AddQuestion.aspx?ID=" + ID + "&name=" + name);


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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int ID = Convert.ToInt32(lnk.CommandArgument);
            DeleteQuestionById(ID);
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
                    Response.Redirect("~/Admin/ClassList.aspx?ID=" + ID + " & name=" + name);

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

        public void DeleteQuestionById(int Id)
        {
            DataSet ds = new DataSet();
            ds = objteacher.DeleteQuestionById(Id);
        }

        protected void btnNew_Click(object sender, EventArgs e)
        {
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
                    Response.Redirect("~/Teacher/AddQuestion.aspx?name=" + name);

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