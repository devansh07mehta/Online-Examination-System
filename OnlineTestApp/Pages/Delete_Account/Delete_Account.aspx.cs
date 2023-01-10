using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace OnlineTestApp.Pages.Delete_Account
{
    public partial class Delete_Account : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string conString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
            SqlConnection con = new SqlConnection(conString);
            con.Open();

            string query = "delete tbl_Admin where UserName = @usern";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("usern", Session["UserName"]);
            cmd.ExecuteNonQuery();
            Response.Write("<script type='text/javascript'>");
            Response.Write("alert('Account Deleted Successfully!!');");
            Response.Write("window.location ='../Index/Home_Page/index.html'");
            Response.Write("</script>");
            con.Close();

            string conString1 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
            SqlConnection con1 = new SqlConnection(conString1);
            con1.Open();

            string query1 = "delete tbl_Students where UserName = @usern";
            SqlCommand cmd1 = new SqlCommand(query1, con1);

            cmd1.Parameters.AddWithValue("usern", Session["UserName"]);
            cmd1.ExecuteNonQuery();
            Response.Write("<script type='text/javascript'>");
            Response.Write("alert('Account Deleted Successfully!!');");
            Response.Write("window.location ='../Index/Home_Page/index.html'");
            Response.Write("</script>");
            con1.Close();

            string conString2 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
            SqlConnection con2 = new SqlConnection(conString2);
            con2.Open();

            string query2 = "delete tbl_Teachers where UserName = @usern";
            SqlCommand cmd2 = new SqlCommand(query2, con2);

            cmd2.Parameters.AddWithValue("usern", Session["UserName"]);
            cmd2.ExecuteNonQuery();
            Response.Write("<script type='text/javascript'>");
            Response.Write("alert('Account Deleted Successfully!!');");
            Response.Write("window.location ='../Index/Home_Page/index.html'");
            Response.Write("</script>");
            con2.Close();
        }
    }
}