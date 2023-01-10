using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Online_Examination_System.Pages
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("UserName");
            Session.Remove("Email");
            Session.Remove("Name");
            Response.Write("<script>window.alert('Logout Successful!');window.location='../Index/Home_Page/index.html';</script>");
            
        }
    }
}