using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OnlineTestApp.Pages.Change_Password
{
    public class clsGetData
    {
        public clsGetData()
        {


            //
            // TODO: Add constructor logic here
            //
        }

        public string GetstrEmpty(object strData)
        {
            string StringData = string.Empty;
            try
            {
                StringData = Convert.ToString(strData);
                if (StringData == null)
                    StringData = "";
            }
            catch (Exception ex)
            {
                StringData = "";
            }
            return StringData;
        }

        public int GetInt_Zero(object data)
        {
            int intData = 0;
            try
            {
                intData = Convert.ToInt32(data);
            }
            catch (Exception ex) { }
            return intData;
        }
    }
    public partial class Change_Password : System.Web.UI.Page
    {
        clsGetData GD = new clsGetData();
        string pass;
        protected void Page_Load(object sender, EventArgs e)
        {
            liadmindashboard.Visible = false;
            liteacher.Visible = false;
            listudent.Visible = false;
            lisubject.Visible = false;
            liclass.Visible = false;
            liAllExam.Visible = false;
            liteacherdashboard.Visible = false;
            liexamination.Visible = false;
            liquestion.Visible = false;
            listudentdashboard.Visible = false;
            liavailableexam.Visible = false;
            liexamhistory.Visible = false;

            if (GD.GetstrEmpty(Session["Role"]) == "Admin")
            {
                liadmindashboard.Visible = true;
                liteacher.Visible = true;
                listudent.Visible = true;
                lisubject.Visible = true;
                liclass.Visible = true;
                liAllExam.Visible = true;
            }
            else if (GD.GetstrEmpty(Session["Role"]) == "Teacher")
            {
                liteacherdashboard.Visible = true;
                liexamination.Visible = true;
                liquestion.Visible = true;
            }
            else if (GD.GetstrEmpty(Session["Role"]) == "Student")
            {
                listudentdashboard.Visible = true;
                liavailableexam.Visible = true;
                liexamhistory.Visible = true;
            }
        }

        protected void Change_psw(object sender, EventArgs e)
        {
            try
            {
                string conString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(conString);
                con.Open();

                string query = "select * from tbl_Admin where UserName = @username";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    pass = reader[4].ToString();
                }



                con.Close();
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con1 = new SqlConnection(consString);
                con1.Open();
                string query1 = "update tbl_Admin SET Password=@psw where UserName=@uname";

                SqlCommand cmd1 = new SqlCommand(query1, con1);

                cmd1.Parameters.AddWithValue("@psw", TextBox2.Text);
                cmd1.Parameters.AddWithValue("@uname", Session["UserName"]);

                cmd1.ExecuteNonQuery();

                con1.Close();


                string conString2 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con2 = new SqlConnection(conString2);
                con2.Open();

                string query2 = "select * from tbl_Students where UserName = @username";
                SqlCommand cmd2 = new SqlCommand(query2, con2);
                cmd2.Parameters.AddWithValue("@username", Session["UserName"]);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                while (reader2.Read())
                {
                    pass = reader2[4].ToString();
                }



                con2.Close();
                string consString3 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con3 = new SqlConnection(consString3);
                con3.Open();
                string query3 = "update tbl_Students SET Password=@psw where UserName=@uname";

                SqlCommand cmd3 = new SqlCommand(query3, con3);

                cmd3.Parameters.AddWithValue("@psw", TextBox2.Text);
                cmd3.Parameters.AddWithValue("@uname", Session["UserName"]);

                cmd3.ExecuteNonQuery();

                con3.Close();


                string conString4 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con4 = new SqlConnection(conString4);
                con4.Open();

                string query4 = "select * from tbl_Teachers where UserName = @username";
                SqlCommand cmd4 = new SqlCommand(query4, con4);
                cmd4.Parameters.AddWithValue("@username", Session["UserName"]);
                SqlDataReader reader4 = cmd4.ExecuteReader();
                while (reader4.Read())
                {
                    pass = reader4[4].ToString();
                }


                con4.Close();
                string consString5 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con5 = new SqlConnection(consString5);
                con5.Open();
                string query5 = "update tbl_Teachers SET Password=@psw where UserName=@uname";

                SqlCommand cmd5 = new SqlCommand(query5, con5);

                cmd5.Parameters.AddWithValue("@psw", TextBox2.Text);
                cmd5.Parameters.AddWithValue("@uname", Session["UserName"]);

                cmd5.ExecuteNonQuery();

                con5.Close();
                if (TextBox1.Text.ToString() != pass)
                {
                    Response.Write("<script>alert('Old Password is Not Valid! ');</script>");
                }
                else if (TextBox2.Text == TextBox3.Text)
                {
                    Response.Write("<script>window.alert('Password Changed Sucessfully!!');window.location='../Index/Home_Page/index.html';</script>");
                }
                else
                {
                    Response.Write("<script>window.alert('Password Does Not Match!!');</script>");
                }
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void Image_Click(object sender, EventArgs e)
        {
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

                    Response.Redirect("../../Admin/AdminDashboard.aspx?name=" + fname);

                }
                con.Close();

                string consString1 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con1 = new SqlConnection(consString1);
                con1.Open();

                string queryString1 = "Select * from tbl_Students where UserName=@usnm";

                SqlCommand cmd1 = new SqlCommand(queryString1, con1);
                cmd1.Parameters.AddWithValue("@usnm", Session["UserName"]);


                SqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    string s = reader1[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Student/StudentDashboard.aspx?name=" + fname);

                }
                con1.Close();

                string consString2 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con2 = new SqlConnection(consString2);
                con2.Open();

                string queryString2 = "Select * from tbl_Teachers where UserName=@usnm";

                SqlCommand cmd2 = new SqlCommand(queryString2, con2);
                cmd2.Parameters.AddWithValue("@usnm", Session["UserName"]);


                SqlDataReader reader2 = cmd2.ExecuteReader();

                if (reader2.Read())
                {
                    string s = reader2[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Teacher/TeacherDashboard.aspx?name=" + fname);

                }
                con2.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void AdminDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Admin where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Admin/AdminDashboard.aspx?name=" + fname);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void TeacherList_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Admin where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Admin/TeacherList.aspx?name=" + fname);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void StudentList_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Admin where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Admin/StudentList.aspx?name=" + fname);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void SubjectList_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Admin where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Admin/SubjectList.aspx?name=" + fname);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void ClassList_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Admin where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Admin/ClassList.aspx?name=" + fname);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void ExamList_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Admin where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Admin/ExamList.aspx?name=" + fname);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void TeacherDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Teachers where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader[1].ToString();
                    Session["Name"] = name;

                    Response.Redirect("../../Teacher/TeacherDashboard.aspx?name=" + name);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void Examination_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Teachers where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader[1].ToString();
                    Session["Name"] = name;

                    Response.Redirect("../../Teacher/ExamList.aspx?name=" + name);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void QuestionList_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Teachers where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader[1].ToString();
                    Session["Name"] = name;

                    Response.Redirect("../../Teacher/QuestionList.aspx?name=" + name);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void StudentDashboard_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Students where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Student/StudentDashboard.aspx?name=" + fname);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void AvailableExam_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Students where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Student/AvailableExam.aspx?name=" + fname);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void ExamHistory_Click(object sender, EventArgs e)
        {
            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string query = "Select * from tbl_Students where UserName = @username";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@username", Session["UserName"]);


                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string s = reader[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Redirect("../../Student/ExamHistory.aspx?name=" + fname);

                }
                con.Close();
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
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

                    Response.Redirect("../Profile/Profile_Page.aspx?name=" + fname);


                }
                else
                {

                    string consString1 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                    SqlConnection con1 = new SqlConnection(consString1);
                    con1.Open();

                    string queryString1 = "Select * from tbl_Students where UserName=@usnm";

                    SqlCommand cmd1 = new SqlCommand(queryString1, con1);
                    cmd1.Parameters.AddWithValue("@usnm", Session["UserName"]);


                    SqlDataReader reader1 = cmd1.ExecuteReader();

                    if (reader1.Read())
                    {
                        reader.Close();
                        string s = reader1[1].ToString();
                        string[] name = s.Split(' ');
                        string fname = name[0].ToString();

                        Response.Redirect("../Profile/Profile_Page.aspx?name=" + fname);

                    }

                    else
                    {
                        string consString2 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                        SqlConnection con2 = new SqlConnection(consString2);
                        con2.Open();

                        string queryString2 = "Select * from tbl_Teachers where UserName=@usnm";

                        SqlCommand cmd2 = new SqlCommand(queryString2, con2);
                        cmd2.Parameters.AddWithValue("@usnm", Session["UserName"]);


                        SqlDataReader reader2 = cmd2.ExecuteReader();

                        if (reader2.Read())
                        {
                            reader1.Close();
                            string s = reader2[1].ToString();
                            string[] name = s.Split(' ');
                            string fname = name[0].ToString();

                            Response.Redirect("../Profile/Profile_Page.aspx?name=" + fname);
                            con2.Close();

                        }


                    }
                }
            }

            catch (Exception ex)
            {
                if (ex is SqlException)
                {
                    Response.Write("<script>alert('Do Not Try to Redirect From the URL!!'); window.location='../Index/Home_Page/index.html';</script>");
                }
            }
        }
    }
}