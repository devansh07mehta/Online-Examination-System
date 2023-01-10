using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.SqlClient;

namespace OnlineTestApp.Pages.Forgot_Password
{

    public partial class Password_Recovery : System.Web.UI.Page
    {
        
        static string OTPCode;
        public static string to;
        Random ran = new Random();
        string email;
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btncode_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            OTPCode = ran.Next(111111, 999999).ToString();
            MailMessage message = new MailMessage();
            to = txtemailadd.Text.ToString();
            from = "freeuser65745@gmail.com";
            pass = "ltlbnuckys75";
            messageBody = "Your Password Recovery OTP is " + OTPCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "Password Recovery OTP";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                SqlConnection con = new SqlConnection(consString);
                con.Open();

                string queryString = "Select * from tbl_Admin where Email=@eml";

                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@eml", txtemailadd.Text.ToString());

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    email = reader[3].ToString();
                    
                    Session["Email"] = email;
                    smtp.Send(message);
                    
                    Response.Write("<script>alert('OTP Sent Successfully!!')</script>");
                    
                    con.Close();
                }


                else
                {

                    string consString1 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                    SqlConnection con1 = new SqlConnection(consString1);
                    con1.Open();

                    string queryString1 = "Select * from tbl_Students where Email=@eml";

                    SqlCommand cmd1 = new SqlCommand(queryString1, con1);
                    cmd1.Parameters.AddWithValue("@eml", txtemailadd.Text.ToString());

                    SqlDataReader reader1 = cmd1.ExecuteReader();
                    if (reader1.Read())
                    {
                        email = reader[3].ToString();
                        Session["Email"] = email;

                        smtp.Send(message);
                        Response.Write("<script>alert('OTP Sent Successfully!!')</script>");
                        con1.Close();
                    }


                    else
                    {

                        string consString2 = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";

                        SqlConnection con2 = new SqlConnection(consString2);
                        con2.Open();

                        string queryString2 = "Select * from tbl_Teachers where Email=@eml";

                        SqlCommand cmd2 = new SqlCommand(queryString2, con2);
                        cmd2.Parameters.AddWithValue("@eml", txtemailadd.Text.ToString());

                        SqlDataReader reader2 = cmd2.ExecuteReader();
                        if (reader2.Read())
                        {
                            email = reader[3].ToString();
                            Session["Email"] = email;

                            smtp.Send(message);
                            Response.Write("<script>alert('OTP Sent Successfully!!')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Email Id not registered!!')</script>");
                        }
                        con2.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

        }

        protected void Btnotp_Click(object sender, EventArgs e)
        {
            if (txtotp.Text == OTPCode)
            {
                to = txtemailadd.Text.ToString();
                Response.Write("<script>window.alert('OTP is valid!!');window.location='../Reset_Password/Reset_Password.aspx';</script>");

            }
            else if(txtotp.Text != OTPCode && txtotp.Text == string.Empty)
            {
                Response.Write("<script>window.alert('Please fill out the OTP!!');</script>");
            }

            else
            {
                Response.Write("<script>alert('Wrong OTP!!')</script>");
            }
        }
    }
}