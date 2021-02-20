using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugTrackingWebApplication
{
    public partial class NewBugAlert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            category.Items.Add(new ListItem("Select a item",""));
            category.Items.Add(new ListItem("General", "General"));
            category.Items.Add(new ListItem("UI bug", "UI bug"));
            category.Items.Add(new ListItem("Server bug", "Server bug"));
            category.AppendDataBoundItems = true;

        }
    }
}