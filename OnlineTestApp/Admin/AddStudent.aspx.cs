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

namespace OnlineTestApp.Admin
{
    public partial class AddStudent : System.Web.UI.Page
    {
        Admin_DAL objadmin = new Admin_DAL();
        clsGetData GD = new clsGetData();
        public static string to;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != "0" && Request.QueryString["ID"] != null)
                {
                    int ID = GD.GetInt_Zero(Request.QueryString["ID"]);
                    GetStudentDetailById(ID);
                    btnSubmit.Text = "Update";
                }

                BindClass();
            }
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

        public void GetStudentDetailById(int Id)
        {
            DataSet ds = new DataSet();
            ds = objadmin.GetStudentListById(Id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtname.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["StudentName"]);
                txtuser.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["UserName"]);
                txtemail.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["Email"]);
                txtpassword.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["Password"]);
                ddlclass.SelectedValue = GD.GetstrEmpty(ds.Tables[0].Rows[0]["ClassId"]);
                ddlIntakeYear.Value = GD.GetstrEmpty(ds.Tables[0].Rows[0]["IntakeYear"]);
                txtphone.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["PhoneNumber"]);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String Name = Convert.ToString(txtname.Text);
            String UserName = Convert.ToString(txtuser.Text);
            String Email = Convert.ToString(txtemail.Text);
            int ClassId = GD.GetInt_Zero(ddlclass.SelectedValue);
            String TakeYear = GD.GetstrEmpty(ddlIntakeYear.Value);
            String Password = Convert.ToString(txtpassword.Text);
            String Phone = Convert.ToString(txtphone.Text);
            Application["Name"] = Name;
            Application["Password"] = Password;
            Application["UserName"] = UserName;
            Application["Email"] = Email;
            DataSet ds = new DataSet();
            String Msg = "";
            string from, pass, messageBody;
            MailMessage message = new MailMessage();
            to = txtemail.Text.ToString();
            from = "freeuser65745@gmail.com";
            pass = "ltlbnuckys75";
            messageBody = "Hello "+Name+", Your Login Credentials are: Username = "+UserName+" and Password = "+Password+"";
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Login Credentials";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            
            if (btnSubmit.Text == "Submit")
            {
                int Id = 0;

                Msg = objadmin.SaveStudent(Id, Name, UserName, Email, Password, ClassId, TakeYear, Phone, 1);
                
                smtp.Send(message);
                Session["ClassId"] = ClassId;
                Response.Write("<script>window.alert('Student Successfully Added!!');</script>");
                

            }
            else
            {
                int ID = GD.GetInt_Zero(Request.QueryString["ID"]);
                
                Msg = objadmin.SaveStudent(ID, Name, UserName, Email, Password, ClassId, TakeYear, Phone, 1);

                to = Email.ToString();
                smtp.Send(message);



            }

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
                    Response.Write("<script>window.location = 'StudentList.aspx?name=" + fname + "';</script>");

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

        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtname.Text = String.Empty;
            txtuser.Text = String.Empty;
            txtemail.Text = String.Empty;
            ddlclass.SelectedValue = null;
            ddlIntakeYear.Value = String.Empty;
            txtpassword.Text = String.Empty;
            txtphone.Text = String.Empty;
            
        }
    }
}