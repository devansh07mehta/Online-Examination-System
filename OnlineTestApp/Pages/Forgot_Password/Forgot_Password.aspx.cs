using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Online_Examination_System.Pages.Student.Forgot_Password
{
    public partial class Forgot_Password : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;User Id=sa;Password=devansh";

            SqlConnection con = new SqlConnection(consString);
            con.Open();

            string query = "select * from StudentDetails where Username=@username and Date=@dte";
            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@username", txtusn.Value);
            cmd.Parameters.AddWithValue("@dte", txtdate.Value);

            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                //textbox value is stored in Session
                Session["Username"] = txtusn.Value;
                Session["Date"] = txtdate.Value;

                Response.Write("<script>window.alert('Username and the Date Entered is Valid!!');window.location='../Reset_Password/Reset_Password.aspx';</script>");
            }

            else
            {
                string consString1 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;User Id=sa;Password=devansh";

                SqlConnection conn = new SqlConnection(consString1);
                conn.Open();

                string queryString = "select * from AdminDetails where Username=@username and Date=@dte";
                SqlCommand cmd1 = new SqlCommand(queryString, conn);

                cmd1.Parameters.AddWithValue("@username", txtusn.Value);
                cmd1.Parameters.AddWithValue("@dte", txtdate.Value);

                SqlDataReader reader1 = cmd1.ExecuteReader();

                if (reader1.Read())
                {
                    reader.Close();


                    Session["Username"] = txtusn.Value;
                    Session["Date"] = txtdate.Value;

                    Response.Write("<script>window.alert('Username and the Date Entered is Valid!!');window.location='../Reset_Password/Reset_Password.aspx';</script>");

                }
                else
                {
                    string consString2 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;User Id=sa;Password=devansh";

                    SqlConnection con1 = new SqlConnection(consString2);
                    con1.Open();

                    string querystring = "select * from TeacherDetails where Username=@username and Date=@dte";
                    SqlCommand cmd2 = new SqlCommand(querystring, con1);

                    cmd2.Parameters.AddWithValue("@username", txtusn.Value);
                    cmd2.Parameters.AddWithValue("@dte", txtdate.Value);

                    SqlDataReader reader2 = cmd2.ExecuteReader();

                    if (reader2.Read())
                    {
                        reader1.Close();

                        //textbox value is stored in Session
                        Session["Username"] = txtusn.Value;
                        Session["Date"] = txtdate.Value;

                        Response.Write("<script>window.alert('Username and the Date Entered is Valid!!');window.location='../Reset_Password/Reset_Password.aspx';</script>");
                        
                    }
                    else
                    {
                        Response.Write("<script>window.alert('Please check whether the Entered Username and Date is Valid!!');</script>");
                    }
                }
            }
        }
    }
}