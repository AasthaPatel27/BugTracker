using System;
using System.Collections.Generic;
using System.Data;
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
            DataSet categoriesDataSet ;
            BTSBugManagementService.BugManagementServiceClient bugManagementServiceClient = new BTSBugManagementService.BugManagementServiceClient();
            categoriesDataSet = bugManagementServiceClient.GetBugCategories();
            category.Items.Add(new ListItem("Select a item", ""));
            foreach (DataRow dr in categoriesDataSet.Tables[0].Rows)
            {
                string catTitle = dr["Title"].ToString();
                string Id = dr["Id"].ToString();
                category.Items.Add(new ListItem(catTitle,Id));
            }
            category.AppendDataBoundItems = true;
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
            BTSBugManagementService.BugManagementServiceClient bugManagementServiceClient = new BTSBugManagementService.BugManagementServiceClient();
            BTSBugManagementService.BugAlert bugAlert = new BTSBugManagementService.BugAlert();
            bugAlert.Title = bugTitle.Text;
            bugAlert.CategoryId = int.Parse(category.SelectedValue);
            bugAlert.Description = description.Text;
            bugAlert.CreatedBy = getPersonId();
            displayLabel.Text = bugManagementServiceClient.AddBugAlertRecord(bugAlert);
            Response.Redirect("TesterHome");
        }
    }
}