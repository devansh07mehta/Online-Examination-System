using OnlineTestApp.App_Code;
using OnlineTestApp.App_Code.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OnlineTestApp
{
    public partial class Login : System.Web.UI.Page
    {
        Admin_DAL adminobj = new Admin_DAL();
        Login_DAL loginObj = new Login_DAL();
        clsGetData GD = new clsGetData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["Role"] = String.Empty;
                Session["UserId"] = String.Empty;

            }

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            String Role = GD.GetstrEmpty(ddlrole.Value);
            String UserName = GD.GetstrEmpty(txtuser.Text);
            String Password = GD.GetstrEmpty(txtpassword.Text);

            if (Role != "" && UserName != "" && Password != "")
            {
                if (Role == "Admin")
                {
                    Session["Role"] = "Admin";
                }
                else if (Role == "Teacher")
                {
                    Session["Role"] = "Teacher";
                }
                else if (Role == "Student")
                {
                    Session["Role"] = "Student";
                }

                DataSet ds = new DataSet();


                int UserId = 0;
                ds = loginObj.Login(Role, UserName, Password);
                if (ds.Tables.Count == 1)
                {

                    //if (ds.Tables[0].Rows[0]["Column1"].ToString() == "Invalid Credential")
                    //{
                    //    lblmsg.Text = "Invalid Credential";

                    //}
                    //else
                    //{
                    if (Role == "Admin")
                    {
                        UserId = GD.GetInt_Zero(ds.Tables[0].Rows[0]["AdminId"]);
                        Session["UserId"] = UserId;
                        Session["UserName"] = UserName;
                        string s = ds.Tables[0].Rows[0]["AdminName"].ToString();
                        string[] name = s.Split(' ');
                        string fname = name[0].ToString();
                        Session["Name"] = fname;

                        if (remember_me.Checked == true)
                        {
                            Response.Cookies["userid"].Value = txtuser.Text;
                            Response.Cookies["pwd"].Value = txtpassword.Text;
                            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                        }
                        else
                        {
                            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                        }

                        Response.Redirect("~/Admin/AdminDashboard.aspx?name=" + fname);

                    }
                    else if (Role == "Teacher")
                    {

                        UserId = GD.GetInt_Zero(ds.Tables[0].Rows[0]["TeacherID"]);
                        Session["UserId"] = UserId;
                        Session["UserName"] = UserName;
                        string name = ds.Tables[0].Rows[0]["TeacherName"].ToString();
                        Session["Name"] = name;
                        if (remember_me.Checked == true)
                        {
                            Response.Cookies["userid"].Value = txtuser.Text;
                            Response.Cookies["pwd"].Value = txtpassword.Text;
                            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                        }
                        else
                        {
                            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                        }

                        Response.Redirect("~/Teacher/TeacherDashboard.aspx?name=" +name);

                    }
                    else if (Role == "Student")
                    {
                        UserId = GD.GetInt_Zero(ds.Tables[0].Rows[0]["StudentId"]);
                        Session["UserId"] = UserId;
                        Session["UserName"] = UserName;
                        string s = ds.Tables[0].Rows[0]["StudentName"].ToString();
                        string[] name = s.Split(' ');
                        string fname = name[0].ToString();
                        Session["Name"] = fname;
                        if (remember_me.Checked == true)
                        {
                            Response.Cookies["userid"].Value = txtuser.Text;
                            Response.Cookies["pwd"].Value = txtpassword.Text;
                            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(15);
                            Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(15);
                        }
                        else
                        {
                            Response.Cookies["userid"].Expires = DateTime.Now.AddDays(-1);
                            Response.Cookies["pwd"].Expires = DateTime.Now.AddDays(-1);
                        }

                        Response.Redirect("~/Student/StudentDashboard.aspx?name=" + fname);

                    }
                    else
                    {
                        lblmsg.Text = "**Invalid Role**";
                    }
                    //}


                }
                else
                {
                    lblmsg.Text = "**Invalid Credentials**";
                }
                // if (Msg == "Admin Added Succesully")
                // {
                //     Response.Redirect("~/Admin/AdminDashboard.aspx");
                // }
                // else if (Msg == "Teacher Added Succesully")
                // {
                //     Response.Redirect("~/Teacher/TeacherDashboard.aspx");
                // }
                //else if (Msg == "Student Added Succesully")
                // {
                //     Response.Redirect("~/Student/StudentDashboard.aspx");

                // }
                //else
                //{
                //    lblmsg.Text = "Invalid Credential";

                //}

            }
            else
            {
                Response.Write("<script>alert('Required All Field');</script>");
            }

        }
    }
}