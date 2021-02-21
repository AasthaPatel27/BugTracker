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
        int personId;
        protected void Page_Load(object sender, EventArgs e)
        {
            personId = 5;
            BTSBugManagementService.BugManagementServiceClient bugManagementServiceClient = new BTSBugManagementService.BugManagementServiceClient();
            var unresolvedBugAlerts = bugManagementServiceClient.GetAllBugAlertRecords(BTSBugManagementService.BugAlertFilter.UnresolvedByTester, personId);
            GridView1.DataSource = unresolvedBugAlerts;
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            bugId = GridView1.SelectedRow.Cells[1].Text;
            ViewState["bugId"] = bugId;
        }

        protected int getPersonId()
        {
            int pId = 0;
            if (Session["personId"] != null)
            {
                pId = (int)Session["personId"];
            }
            else
            {
                pId = 5;
            }
            return pId;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (ViewState["bugId"] != null)
            {
                bugId = ViewState["bugId"].ToString();
                Response.Redirect("BugDetail.aspx?bugId=" + bugId);
            }
            else
            {
                DisplayLabel.Text = "Please select a bug to View";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (ViewState["bugId"] != null)
            {
                bugId = ViewState["bugId"].ToString();
                personId = getPersonId();
                BTSBugManagementService.BugManagementServiceClient bugManagementServiceClient = new BTSBugManagementService.BugManagementServiceClient();
                DisplayLabel.Text = bugManagementServiceClient.ClaimBugAlertResolution(int.Parse(bugId), personId, personId);
            }
            else
            {
                DisplayLabel.Text = "Please select a bug to Delete";
            }
        }
    }
}