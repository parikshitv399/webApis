using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsApp
{
    public partial class UserRegistration : System.Web.UI.Page
    {
        List<AppUser> _users = new List<AppUser>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ViewState["Users"] == null)
            {
                ViewState["Users"] = _users;
            }
            else
            {
                _users = (List<AppUser>)ViewState["Users"];
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            _users.Add(new AppUser() { Name = txtName.Text, Username = txtName.Text, Password = txtPassword.Text, Gender = ddlGender.SelectedValue });
            lblStatus.Text = "Registration Successful!";
            lblStatus.Visible = true;
            ViewState["Users"] = _users;
        }

        protected void lnkBtn_Click(object sender, EventArgs e)
        {
            lstUsers.DataSource = _users;
            lstUsers.DataTextField = "Name";
            lstUsers.DataValueField = "Username";
            //bind
            lstUsers.DataBind();
            lstUsers.Visible = true;
        }
    }
}