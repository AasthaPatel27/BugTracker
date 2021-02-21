using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugTrackingWebApplication
{
    public partial class TesterHome : System.Web.UI.Page
    {
        int personId;
        string bugId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                personId = getPersonId();
                BTSBugManagementService.BugManagementServiceClient bugManagementServiceClient = new BTSBugManagementService.BugManagementServiceClient();
                var unresolvedBugAlerts = bugManagementServiceClient.GetAllBugAlertRecords(BTSBugManagementService.BugAlertFilter.AllByTester, personId);
                GridView1.DataSource = unresolvedBugAlerts;
                GridView1.DataBind();
            }
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

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["bugId"] = GridView1.SelectedRow.Cells[1].Text;
        }
        
       

        protected void Button2_Click(object sender, EventArgs e)
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

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (ViewState["bugId"] != null)
            {
                bugId = ViewState["bugId"].ToString();
                BTSBugManagementService.BugManagementServiceClient bugManagementServiceClient = new BTSBugManagementService.BugManagementServiceClient();
                DisplayLabel.Text = bugManagementServiceClient.DeleteBugAlertRecord(int.Parse(bugId));
                Response.Redirect("");
            }
            else
            {
                DisplayLabel.Text = "Please select a bug to Delete";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewBugAlert.aspx");
        }
    }
}