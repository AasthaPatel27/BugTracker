using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugTrackingWebApplication
{
    public partial class BugDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int bugID = int.Parse(Request.QueryString["bugId"]);
            if (bugID > 0)
            {
                BTSBugManagementService.BugManagementServiceClient bugManagementServiceClient = new BTSBugManagementService.BugManagementServiceClient();
                var bugAlert = bugManagementServiceClient.GetBugAlertRecord(bugID);
                bugId.Text = bugID.ToString();
                bugTitle.Text = bugAlert.Title;
                description.Text = bugAlert.Description;
                status.Text = bugAlert.Status.ToString();
                category.Text = bugAlert.CategoryId.ToString();
                resolutionDescription.Text = bugAlert.ResolutionDescription;
            }
        }
    }
}