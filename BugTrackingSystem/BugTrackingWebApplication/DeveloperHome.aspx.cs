using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugTrackingWebApplication
{
    public partial class DeveloperHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string b_title = "";
            string b_status = "";
            string b_category = "";
            string b_description = "";

            this.title.Text = b_title;
            status.Text = b_status;
            category.Text = b_category;
            description.Text = b_description;
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            mydisplay.Text = comment.Text + " successfully done . ";
        }
    }
}