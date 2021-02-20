using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BugTrackingWebApplication
{
	public partial class Registration : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Button1_Click(object sender, EventArgs e)
        {
			string c_name = name.Text;
			string c_email = email.Text;
			string c_contact = contact.Text;
			string c_password = password.Text;
			string c_role = role.SelectedValue;

		}
		
    }
}