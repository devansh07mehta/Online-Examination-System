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
using System.Net;
using System.Net.Mail;
using System.Collections;

namespace OnlineTestApp.Teacher
{
    public partial class AddExam : System.Web.UI.Page
    {
        MailMessage message = new MailMessage();
        SmtpClient smtp = new SmtpClient("smtp.gmail.com");
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
                    GetExamDetailById(ID);
                    btnSubmit.Text = "Update";
                }

                BindClass();
                BindSubject();

                Calendar1.Visible = false;
                Calendar2.Visible = false;
            }
        }


        public void BindSubject()
        {
            DataSet ds = new DataSet();
            ds = objadmin.GetSubjectList();
            ddlSubject.DataSource = ds;
            ddlSubject.DataTextField = "Name";
            ddlSubject.DataValueField = "SubjectId";
            ddlSubject.DataBind();

            ddlSubject.Items.Insert(0, new ListItem("--Select Subject--", "0"));
        }

        public void BindClass()
        {
            DataSet ds = new DataSet();
            ds = objadmin.GetClassList();
            ddlclass.DataSource = ds;
            ddlclass.DataTextField = "ClassName";
            ddlclass.DataValueField = "ClassId";
            ddlclass.DataBind();

            ddlclass.Items.Insert(0, new ListItem("--Select Class--", "0"));
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int SubjectId = GD.GetInt_Zero(ddlSubject.SelectedValue);
            String Name = Convert.ToString(txtname.Text);
            int ClassId = GD.GetInt_Zero(ddlclass.SelectedValue);

            String Instruction = Convert.ToString(txtinstruction.Text);
            int Duration = GD.GetInt_Zero(txtDuration.Text);
            int PassMark = GD.GetInt_Zero(txtpassMark.Text);

            

            String Start = Convert.ToString(txtStartDate.Text);
            DateTime StartDate = Convert.ToDateTime(Start);
            String End = Convert.ToString(txtEndDate.Text);
            DateTime EndDate = Convert.ToDateTime(End);


            DataSet ds = new DataSet();
            String Msg = "";

            

            string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

            SqlConnection con = new SqlConnection(consString);
            con.Open();

            string queryString = "Select Email from tbl_Students where ClassId=@class";

            SqlCommand cmd = new SqlCommand(queryString, con);
            cmd.Parameters.AddWithValue("@class",ClassId);
            ArrayList emailArray = new ArrayList();

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
               emailArray.Add(reader["Email"].ToString());
            }
            con.Close();

            foreach (string Email in emailArray)
            {
                string from, pass, messageBody;
                
                MailAddress toAddress = new MailAddress(Email);
                message.To.Add(toAddress);
                from = "freeuser65745@gmail.com";
                pass = "ltlbnuckys75";
                messageBody = "Hey, New Examination " + Name + " has been created!! You can attempt this exam between " + StartDate + " and " + EndDate + " as per your convenience.";
                message.From = new MailAddress(from);
                message.Body = messageBody;
                message.Subject = "Exam Notification";
                
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(from, pass);
            }
                
            if (btnSubmit.Text == "Submit")
            {
                int Id = 0;

                Msg = objteacher.SaveExamination(Id, SubjectId, Name, Instruction, Duration, 35, StartDate, EndDate, ClassId, 1);
                smtp.Send(message);
                Response.Write("<script>window.alert('New Exam Created Successfully!!');</script>");
                
            }
            else
            {
                int ID = GD.GetInt_Zero(Request.QueryString["ID"]);
                Msg = objteacher.SaveExamination(ID, SubjectId, Name, Instruction, Duration, 35, StartDate, EndDate, ClassId, 1);
                message.Body = "Hey, New Examination " + Name + " has been created!! You can attempt this exam between " + StartDate + " and " + EndDate + " as per your convenience.";
                smtp.Send(message);
                
            }
            
            string consString1 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con1 = new SqlConnection(consString1);
                con1.Open();

                string queryString1 = "Select * from tbl_Teachers where UserName=@usnm";

                SqlCommand cmd1 = new SqlCommand(queryString1, con1);
                cmd1.Parameters.AddWithValue("@usnm", Session["UserName"]);


                SqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    string name = reader1[1].ToString();

                    Session["Name"] = name;
                    Response.Write("<script>window.location = 'AddQuestion.aspx?name=" + name + "';</script>");

                }
                con1.Close();
           
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            ddlSubject.SelectedValue = null;
            txtname.Text = String.Empty;
            txtinstruction.Text = String.Empty;
            txtDuration.Text = String.Empty;
            ddlclass.SelectedValue = null;
            txtStartDate.Text = String.Empty;

            txtEndDate.Text = String.Empty;
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
                    Response.Redirect("AddExam.aspx?name=" + name);
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

        public void GetExamDetailById(int Id)
        {
            DataSet ds = new DataSet();
            ds = objteacher.GetExaminationById(Id);

            if (ds.Tables[0].Rows.Count > 0)
            {
               ddlSubject.SelectedValue = GD.GetstrEmpty(ds.Tables[0].Rows[0]["SubjectId"]);
                txtname.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["ExamName"]);
                txtinstruction.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["Instruction"]);
                txtDuration.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["DurationInMinute"]);
                txtpassMark.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["PassMark"]);
                txtStartDate.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["ExamStart"]);
                txtEndDate.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["ExamEnd"]);
                ddlclass.SelectedValue = GD.GetstrEmpty(ds.Tables[0].Rows[0]["ClassId"]);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;
            }
            else
            {
                Calendar1.Visible = true;
            }
        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            txtEndDate.Text = Calendar1.SelectedDate.ToShortDateString();
            Calendar1.Visible = false;
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            txtStartDate.Text = Calendar2.SelectedDate.ToShortDateString();
            Calendar2.Visible = false;
        }
    }
}