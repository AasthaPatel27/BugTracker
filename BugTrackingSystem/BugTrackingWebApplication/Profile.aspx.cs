using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BugTrackingWebApplication.UserManagementServiceReference;


namespace BugTrackingWebApplication
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
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

            Person _per = new Person()
            {
                PersonId = Int32.Parse(perId.Text.ToString()),
                Name = name.Text.ToString(),
                Email = email.Text.ToString(),
                Contact = contact.Text.ToString(),
                Password = password.Text.ToString(),
                CreaedBy = Int32.Parse(creater.Text.ToString()),
                Role = uRole
            };
            UserManagementServiceClient userClient = new UserManagementServiceClient("BasicHttpBinding_IUserManagementService");
            string res = userClient.UpdateUserRecord(_per);
            if (res.Contains("Error"))
            {
                errorLabel.Text = res;
                errorLabel.Visible = true;
            }
            else
            {
                errorLabel.Visible = false;
                successLabel.Visible = true;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            UserRole uRole = UserRole.Any;
            switch ((string)Session["p_role"])
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

            UserManagementServiceClient userClient = new UserManagementServiceClient("BasicHttpBinding_IUserManagementService");
            string res = userClient.DeleteUserRecord((int)Session["p_id"], uRole);
            if (res.Contains("Error"))
            {
                errorLabel.Text = res;
                errorLabel.Visible = true;
            }
            else
            {
                errorLabel.Visible = false;
                successLabel.Visible = true;
                Response.Redirect("~/Login");
            }
        }

        protected void btnView_Click(object sender, EventArgs e)
        {
            UserRole uRole = UserRole.Any;
            switch ((string)Session["p_role"])
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

            UserManagementServiceClient userClient = new UserManagementServiceClient("BasicHttpBinding_IUserManagementService");
            Person _per = userClient.GetUserRecordByPersonId((int)Session["p_id"], uRole);

            perId.Text = _per.PersonId.ToString();
            email.Text = _per.Email.ToString();
            name.Text = _per.Name.ToString();
            switch (_per.Role)
            {
                case (UserRole.Admin):
                    role.SelectedValue = "admin";
                    break;
                case (UserRole.Developer):
                    role.SelectedValue = "dev";
                    break;
                case (UserRole.Tester):
                    role.SelectedValue = "tester";
                    break;
            }
            contact.Text = _per.Contact.ToString();
            creater.Text = _per.CreaedBy.ToString();
        }
    }
}