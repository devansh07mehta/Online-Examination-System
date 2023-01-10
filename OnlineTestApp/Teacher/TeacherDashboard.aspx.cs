using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OnlineTestApp.Teacher
{
    public partial class TeacherDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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

                    Label1.Text = reader[1].ToString();

                }
                con.Close();
            }
            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try To Redirect From the URL!!'); window.location='../Pages/Index/Home_Page/index.html';</script>");
                }
            }

            string constring1 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Persist Security Info=True;User ID=sa;Password=devansh";
            SqlConnection con1 = new SqlConnection(constring1);
            con1.Open();
            string query1 = "Select COUNT(*) from tbl_Examination";
            SqlCommand cmd1 = new SqlCommand(query1, con1);

            SqlDataReader reader1 = cmd1.ExecuteReader();
            if (reader1.Read())
            {
                Label2.Text = reader1[0].ToString();
            }
            con1.Close();

            string constring2 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Persist Security Info=True;User ID=sa;Password=devansh";
            SqlConnection con2 = new SqlConnection(constring2);
            con2.Open();
            string query2 = "Select COUNT(*) from tblQuestions";
            SqlCommand cmd2 = new SqlCommand(query2, con2);

            SqlDataReader reader2 = cmd2.ExecuteReader();
            if (reader2.Read())
            {
                Label3.Text = reader2[0].ToString();
            }
            con2.Close();
        }

        protected void btnExamination_Click(object sender, EventArgs e)
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
                    Response.Redirect("~/Teacher/ExamList.aspx?name=" + name);

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

        protected void btnQuestion_Click(object sender, EventArgs e)
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

        protected void Teacher_Profile_Click(object sender, EventArgs e)
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
                    Response.Redirect("../Pages/Profile/Profile_Page.aspx?name=" + name);

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