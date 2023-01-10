using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Online_Examination_System.Pages
{
    public partial class Contact_Us : System.Web.UI.Page
    {

        public static string to;
        string fullname, contact, emailid, query;

        public void TransferContactData()
        {
            fullname = Request.Form["fn"];
            contact = Request.Form["mob"];
            emailid = Request.Form["eid"];
            query = Request.Form["qr"];
        }
        public void StoreContactData()
        {
            
                string consString = @"Data Source=LAPTOP-CNISGKB3\DEVANSH;Initial Catalog=Online_Examination_System;Integrated Security=True;";
                SqlConnection con = new SqlConnection(consString);
                con.Open();
                string queryString = "Insert into ContactUs values(@FullName, @ContactNum, @Emailid, @Query)";
                SqlCommand cmd = new SqlCommand(queryString, con);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                cmd.Parameters.AddWithValue("@ContactNum", contact);
                cmd.Parameters.AddWithValue("@Emailid", emailid);
                cmd.Parameters.AddWithValue("@Query", query);
                cmd.ExecuteNonQuery();
                Response.Write("<script type='text/javascript'>");
                Response.Write("alert('Thank you " +fullname+ " for approaching us, we will contact you asap!!');");
                Response.Write("window.location='../Home_Page/index.html';");
                Response.Write("</script>");

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                TransferContactData();
                StoreContactData();
            }
            catch (SqlException ex)
            {

                if (ex.Number == 2627)
                {
                    Response.Write("<script>window.alert('Response Already Submitted!!');window.location='../Home_Page/index.html';</script>");
                }
            }

        }
    }
}