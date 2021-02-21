using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugTrackingWebApplication
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["p_email"] = "dpTemp@dp.in";
            Session["p_id"] = 1;
            Session["p_name"] = "deTemp";
            Session["p_role"] = "dev";
            if (Session["p_email"] == null)
            {
                Response.Redirect("dpTemp.aspx");
            }
            switch ((string)Session["p_role"]){
                case ("admin"):
                    adminName.Text = "Hello! " + (string)Session["p_name"];
                    navPanelAdmin.Visible = true;
                    break;
                case ("tester"):
                    testerName.Text = "Hello! " + (string)Session["p_name"];
                    navPanelTester.Visible = true;
                    break;
                case ("dev"):
                    devName.Text = "Hello! " + (string)Session["p_name"];
                    navPanelDev.Visible = true;
                    break;
                default:
                    break;
            }
        }
    }
}