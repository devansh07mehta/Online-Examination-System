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

namespace OnlineTestApp.Admin
{
    public partial class TeacherList : System.Web.UI.Page
    {
        Admin_DAL objadmin = new Admin_DAL();
        clsGetData GD = new clsGetData();

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
            ds = objadmin.GetTeacherList();
            grvTeacher.DataSource = ds;
            grvTeacher.DataBind();
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
                    Response.Redirect("~/Admin/AddTeacher.aspx?ID=" + ID + "&name=" + fname);


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

        protected void lnkDelete_Click(object sender, EventArgs e)
        {
            LinkButton lnk = (LinkButton)sender;
            int ID = Convert.ToInt32(lnk.CommandArgument);
            DeleteTeacherListById(ID);
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
                    Response.Redirect("~/Admin/TeacherList.aspx?ID=" + ID + " & name=" + fname);

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

        public void DeleteTeacherListById(int Id)
        {
            DataSet ds = new DataSet();
            ds = objadmin.DeleteTeacherListById(Id);
        }

        protected void btnNew_Click(object sender, EventArgs e)
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
                    Session["Name"] = fname;
                    Response.Redirect("~/Admin/AddTeacher.aspx?name=" + fname);

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

        protected void grvTeacher_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvTeacher.PageIndex = e.NewPageIndex;
            DataSet ds = new DataSet();
            ds = objadmin.GetTeacherList();
            grvTeacher.DataSource = ds;
            grvTeacher.DataBind();
        }
    }
}