using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BugTrackingWebApplication.UserManagementServiceReference;

namespace BugTrackingWebApplication
{
	public partial class Registration : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if( (string)Session["p_role"] != "admin")
            {
				notAdminErrorLabel.Visible = true;
				regPanel.Visible = false;
            }
            else
            {
				notAdminErrorLabel.Visible = false;
				regPanel.Visible = true;
			}
			errorLabel.Visible = false;
		}

        protected void btnRegister_Click(object sender, EventArgs e)
        {
			UserRole uRole = UserRole.Any;
            switch (role.SelectedValue.ToString())
            {
				case ("admin"):
					uRole = UserRole.Admin;
					break;
				case ("dev"):
					uRole = UserRole.Developer;
					break;
				case ("tester"):
					uRole = UserRole.Tester;
					break;
			}

			Person _per = new Person() {
				PersonId = -1,
				Name = name.Text.ToString(),
				Email = email.Text.ToString(),
				Contact = contact.Text.ToString(),
				Password = password.Text.ToString(),
				CreaedBy = (int)Session["p_id"],
				Role = uRole
			};
			UserManagementServiceClient userClient = new UserManagementServiceClient("BasicHttpBinding_IUserManagementService");
			string res = userClient.AddUserRecord(_per);
			if (res.Contains("Error")){
				errorLabel.Text = res;
				errorLabel.Visible = true;
			}
            else
            {
				errorLabel.Visible = false;
				successLabel.Visible = true;
				btnNewReg.Visible = true;
			}
		}

        protected void btnNewReg_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/Registration");
        }

        protected void btnGoProfile_Click(object sender, EventArgs e)
        {
			Response.Redirect("~/Profile");
		}
    }
}