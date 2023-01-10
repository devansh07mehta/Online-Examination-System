using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OnlineTestApp.Pages.Profile
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
    public partial class Profile_Page : System.Web.UI.Page
    {
        clsGetData GD = new clsGetData();
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
            if (!Page.IsPostBack)
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
                    if (reader.Read())
                    {
                        TextBox1.Text = reader[1].ToString();
                        TextBox2.Text = reader[5].ToString();
                        TextBox3.Text = reader[2].ToString();
                        TextBox4.Text = reader[3].ToString();

                    }
                    else
                    {

                        string consString1 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                        SqlConnection con1 = new SqlConnection(consString1);
                        con1.Open();
                        string query1 = "Select * from tbl_Students where UserName = @username";

                        SqlCommand cmd1 = new SqlCommand(query1, con1);
                        cmd1.Parameters.AddWithValue("@username", Session["UserName"]);


                        SqlDataReader reader1 = cmd1.ExecuteReader();
                        if (reader1.Read())
                        {
                            reader.Close();
                            TextBox1.Text = reader1[1].ToString();
                            TextBox2.Text = reader1[7].ToString();
                            TextBox3.Text = reader1[2].ToString();
                            TextBox4.Text = reader1[3].ToString();

                        }
                        else
                        {

                            string consString2 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                            SqlConnection con2 = new SqlConnection(consString2);
                            con2.Open();
                            string query2 = "Select * from tbl_Teachers where UserName = @username";

                            SqlCommand cmd2 = new SqlCommand(query2, con2);
                            cmd2.Parameters.AddWithValue("@username", Session["UserName"]);


                            SqlDataReader reader2 = cmd2.ExecuteReader();
                            if (reader2.Read())
                            {
                                reader1.Close();
                                TextBox1.Text = reader2[1].ToString();
                                TextBox2.Text = reader2[6].ToString();
                                TextBox3.Text = reader2[2].ToString();
                                TextBox4.Text = reader2[3].ToString();

                            }
                            con2.Close();
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {

                string conString2 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection conn2 = new SqlConnection(conString2);
                conn2.Open();

                string query2 = "select * from tbl_Admin where UserName=@usn";
                SqlCommand cmd2 = new SqlCommand(query2, conn2);
                cmd2.Parameters.AddWithValue("@usn", Session["UserName"]);
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.Read())
                {
                    if (TextBox1.Text == reader2[1].ToString() && TextBox2.Text == reader2[5].ToString() && TextBox3.Text == reader2[2].ToString() && TextBox4.Text == reader2[3].ToString())
                    {
                        Response.Write("<script>alert('Please first update the details!!');</script>");
                    }
                    else
                    {
                        string s = reader2[1].ToString();
                        string[] name = s.Split(' ');
                        string fname = name[0].ToString();

                        Response.Write("<script type='text/javascript'>");
                        Response.Write("alert('Your Details are Successfully Updated!!');");
                        Response.Write("window.location ='../../Admin/AdminDashboard.aspx?name=" + fname + "';");
                        Response.Write("</script>");
                    }

                }
                conn2.Close();

                string consString1 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con1 = new SqlConnection(consString1);
                con1.Open();

                string query1 = "update tbl_Admin SET AdminName=@admn, PhoneNumber=@cn, Email=@em where UserName=@usern";
                SqlCommand cmd1 = new SqlCommand(query1, con1);

                cmd1.Parameters.AddWithValue("@admn", TextBox1.Text);
                cmd1.Parameters.AddWithValue("@cn", TextBox2.Text);
                cmd1.Parameters.AddWithValue("@em", TextBox4.Text);
                cmd1.Parameters.AddWithValue("@usern", Session["UserName"]);
                cmd1.ExecuteNonQuery();
                con1.Close();

                string conString4 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection conn4 = new SqlConnection(conString4);
                conn4.Open();

                string query4 = "select * from tbl_Students where UserName=@usn";
                SqlCommand cmd4 = new SqlCommand(query4, conn4);
                cmd4.Parameters.AddWithValue("@usn", Session["UserName"]);
                SqlDataReader reader4 = cmd4.ExecuteReader();
                if (reader4.Read())
                {
                    string s = reader4[1].ToString();
                    string[] name = s.Split(' ');
                    string fname = name[0].ToString();

                    Response.Write("<script type='text/javascript'>");
                    Response.Write("alert('Your Details are Successfully Updated!!');");
                    Response.Write("window.location ='../../Student/StudentDashboard.aspx?name=" + fname + "';");
                    Response.Write("</script>");
                }
                conn4.Close();

                string consString3 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con3 = new SqlConnection(consString3);
                con3.Open();

                string query3 = "update tbl_Students SET StudentName=@admn, PhoneNumber=@cn, Email=@em where UserName=@usern";
                SqlCommand cmd3 = new SqlCommand(query3, con3);

                cmd3.Parameters.AddWithValue("@admn", TextBox1.Text);
                cmd3.Parameters.AddWithValue("@cn", TextBox2.Text);
                cmd3.Parameters.AddWithValue("@em", TextBox4.Text);
                cmd3.Parameters.AddWithValue("@usern", Session["UserName"]);
                cmd3.ExecuteNonQuery();
                con3.Close();

                string conString6 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection conn6 = new SqlConnection(conString6);
                conn6.Open();

                string query6 = "select * from tbl_Teachers where UserName=@usn";
                SqlCommand cmd6 = new SqlCommand(query6, conn6);
                cmd6.Parameters.AddWithValue("@usn", Session["UserName"]);
                SqlDataReader reader6 = cmd6.ExecuteReader();
                if (reader6.Read())
                {
                    string name = reader6[1].ToString();
                    Session["Name"] = name;

                    Response.Write("<script type='text/javascript'>");
                    Response.Write("alert('Your Details are Successfully Updated!!');");
                    Response.Write("window.location ='../../Teacher/TeacherDashboard.aspx?name=" + name + "';");
                    Response.Write("</script>");
                }
                conn6.Close();

                string consString5 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con5 = new SqlConnection(consString5);
                con5.Open();

                string query5 = "update tbl_Teachers SET TeacherName=@admn, PhoneNo=@cn, Email=@em where UserName=@usern";
                SqlCommand cmd5 = new SqlCommand(query5, con5);

                cmd5.Parameters.AddWithValue("@admn", TextBox1.Text);
                cmd5.Parameters.AddWithValue("@cn", TextBox2.Text);
                cmd5.Parameters.AddWithValue("@em", TextBox4.Text);
                cmd5.Parameters.AddWithValue("@usern", Session["UserName"]);
                cmd5.ExecuteNonQuery();
                con5.Close();
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

        protected void Button2_Click(object sender, EventArgs e)
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

                    Response.Redirect("../Change_Password/Change_Password.aspx?name=" + fname);


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

                        Response.Redirect("../Change_Password/Change_Password.aspx?name=" + fname);

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

                            Response.Redirect("../Change_Password/Change_Password.aspx?name=" + fname);
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