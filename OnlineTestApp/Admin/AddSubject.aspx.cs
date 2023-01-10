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
    public partial class AddSubject : System.Web.UI.Page
    {

        Admin_DAL adminobj = new Admin_DAL();
        clsGetData GD = new clsGetData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                if (Request.QueryString["ID"] != "0" && Request.QueryString["ID"] != null)
                {
                    int ID = GD.GetInt_Zero(Request.QueryString["ID"]);
                    GetSubjectDetailById(ID);
                    btnSubmit.Text = "Update";
                }
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            String Name = Convert.ToString(txtname.Text);
           
            String Code = Convert.ToString(txtcode.Text);
            

            DataSet ds = new DataSet();
            String Msg = "";
            if (btnSubmit.Text == "Submit")
            {
                int Id = 0;

                Msg = adminobj.SaveSubject(Id, Name,  Code);

            }
            else
            {
                int ID = GD.GetInt_Zero(Request.QueryString["ID"]);

                Msg = adminobj.SaveSubject(ID, Name, Code);

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
                    Response.Redirect("~/Admin/SubjectList.aspx?name=" + fname);

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

            txtcode.Text = String.Empty;
        }

        public void GetSubjectDetailById(int Id)
        {
            DataSet ds = new DataSet();
            ds = adminobj.GetSubjectListById(Id);

            if (ds.Tables[0].Rows.Count > 0)
            {
                txtname.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["Name"]);
               
                txtcode.Text = GD.GetstrEmpty(ds.Tables[0].Rows[0]["Code"]);
               
            }
        }
    }
}