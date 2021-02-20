using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugTrackingWebApplication
{
    public partial class UnresolvedBugList : System.Web.UI.Page
    {
        string bugId;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
           bugId = GridView1.SelectedRow.Cells[1].Text;
        }
    }
}