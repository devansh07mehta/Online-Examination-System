using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OnlineTestApp.Pages.Reset_Password
{
    public partial class Reset_Password : System.Web.UI.Page
    {
        string email = Forgot_Password.Password_Recovery.to;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btnreset_Click(object sender, EventArgs e)
        {
            if (txtpwd.Value == txtconpwd.Value)
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-CNISGKB3\\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;");

                con.Open();
                string query = "update tbl_Students SET Password=@psw where Email=@eml";

                SqlCommand cmd = new SqlCommand(query, con);

                cmd.Parameters.AddWithValue("@psw", txtpwd.Value);
                
                cmd.Parameters.AddWithValue("@eml", Session["Email"]);
               

                cmd.ExecuteNonQuery();

                Response.Write("<script>window.alert('Password Reseted Successfully!!');window.location='../../Pages/Index/Home_Page/index.html';</script>");
                con.Close();

                SqlConnection con1 = new SqlConnection("Data Source=LAPTOP-CNISGKB3\\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;");

                con1.Open();
                string query1 = "update tbl_Teachers SET Password=@psw where Email=@eml";

                SqlCommand cmd1 = new SqlCommand(query1, con1);

                cmd1.Parameters.AddWithValue("@psw", txtpwd.Value);
                cmd1.Parameters.AddWithValue("@eml", Session["Email"]);

                cmd1.ExecuteNonQuery();

                Response.Write("<script>window.alert('Password Reseted Successfully!!');window.location='../../Pages/Index/Home_Page/index.html';</script>");
                con1.Close();

                SqlConnection con2 = new SqlConnection("Data Source=LAPTOP-CNISGKB3\\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;");

                con2.Open();
                string query2 = "update tbl_Admin SET Password=@psw where Email=@eml";

                SqlCommand cmd2 = new SqlCommand(query2, con2);

                cmd2.Parameters.AddWithValue("@psw", txtpwd.Value);
                cmd2.Parameters.AddWithValue("@eml", Session["Email"]);

                cmd2.ExecuteNonQuery();

                Response.Write("<script>window.alert('Password Reseted Successfully!!');window.location='../../Pages/Index/Home_Page/index.html';</script>");
                con2.Close();
            }


            else
            {
                Response.Write("<script>window.alert('Password Does Not Match!! Please Try Again.');</script>");
            }
        }
    }
}