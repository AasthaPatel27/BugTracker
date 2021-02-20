using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugTrackingWebApplication
{
    public partial class DetailView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string bugID = Request.QueryString["bugId"];

            string b_title = "";
            string b_status = "";
            string b_category = "";
            string b_description = "";
            string b_comments = "";
            
            
            
            
        }
    }
}