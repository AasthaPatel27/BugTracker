using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BugTrackingWebApplication.UserManagementServiceReference;

namespace BugTrackingWebApplication
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            errorLabel.Visible = false;
		}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
			UserManagementServiceClient userClient = new UserManagementServiceClient("BasicHttpBinding_IUserManagementService");
			Person _per = userClient.Login(email.Text.ToString(), password.Text.ToString());
			if(_per.PersonId == -1)
            {
                errorLabel.Text = "Invalid Credentials";
                errorLabel.Visible = true;
            }
            else
            {
                errorLabel.Visible = false;
                Session["p_email"] = _per.Email.ToString();
                Session["p_id"] = _per.PersonId;
                Session["p_name"] = _per.Name.ToString();
                switch (_per.Role)
                {
                    case (UserRole.Admin):
                        Session["p_role"] = "admin";
                        break;
                    case (UserRole.Developer):
                        Session["p_role"] = "dev";
                        break;
                    case (UserRole.Tester):
                        Session["p_role"] = "tester";
                        break;
                }
                Response.Redirect("~/Profile");
                
            }
        }
    }
}