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
        int personId, bugAlertId;

        protected void Page_Load(object sender, EventArgs e)
        {
            personId = getPersonId();
            ViewState["personId"]=personId;
            BTSBugManagementService.BugManagementServiceClient bugManagementServiceClient = new BTSBugManagementService.BugManagementServiceClient();
            var unresolvedBugAlerts = bugManagementServiceClient.GetAllBugAlertRecords(BTSBugManagementService.BugAlertFilter.UnresolvedByDeveloper, personId);

            if (unresolvedBugAlerts.Tables[0].Rows.Count>0 && !IsPostBack)
            {
                var row = unresolvedBugAlerts.Tables[0].Rows[0];
                BugIdLable.Text = row["Id"].ToString();
                bugTitle.Text = row["Title"].ToString();
                status.Text = Enum.GetName(typeof(BTSBugManagementService.BugAlertStatus), row["Status"]);
                description.Text = row["Description"].ToString();
                category.Text = row["CategoryName"].ToString();
                resolutionDescription.Text = row["ResolutionDescription"].ToString();
            }
            else
            {
                /*show message*/
                bugTitle.Text = "-";
                mydisplay.Text = "Visit the Unresolved Bugs Page to claim some new bugs";
                mydisplay.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected int getPersonId()
        {
            int pId = 0;
            if (Session["p_id"] != null)
            {
                pId = (int)Session["p_id"];
            }
            return pId;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (BugIdLable.Text!="-")
            {
                string rDescription = resolutionDescription.Text.ToString() ;
                mydisplay.Text = rDescription.ToString()+ " successfully done . ";
                personId = (int)ViewState["personId"];
                bugAlertId = int.Parse(BugIdLable.Text);
                BTSBugManagementService.BugManagementServiceClient bugManagementServiceClient = new BTSBugManagementService.BugManagementServiceClient();
                
                bugManagementServiceClient.ResolveBugAlert(bugAlertId, rDescription);
                Response.Redirect("DeveloperHome.aspx");
            }
            
        }
    }
}