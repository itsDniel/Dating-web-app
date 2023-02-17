using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilities;
using System.Data.SqlClient;

namespace Dating_app
{
    public partial class Tindr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                accountForm.Visible = false;
            }
            
        }

        protected void accountBtn_Click(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                accountForm.Visible = true;
                form1.Visible = false;
                
            }
        }

        protected void createAccountbtn_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand updateCommand = new SqlCommand("INSERT INTO Login (username, password, fname, lname, email) VALUES (@username, @password, @fname, @lname, @email)");
            updateCommand.Parameters.AddWithValue("username", userCreationtxt.Text);
            updateCommand.Parameters.AddWithValue("password", passCreationtxt.Text);
            updateCommand.Parameters.AddWithValue("fname", fNametxt.Text);
            updateCommand.Parameters.AddWithValue("lname", lNametxt.Text);
            updateCommand.Parameters.AddWithValue("email", emailtxt.Text);
            objDB.DoUpdate(updateCommand);
            accountForm.Visible = false;
            form1.Visible = true;
            


        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String username = userNametxt.Text;
            String password = passWordtxt.Text;
            DBConnect objDB = new DBConnect();
            String sql = "SELECT COUNT(*) FROM Login WHERE username LIKE '" + username + "' AND password LIKE '" + password + "'";
            SqlCommand retrieve = new SqlCommand(sql);
            objDB.GetConnection();
            int userCount = (int)objDB.ExecuteScalarFunction(retrieve);
            if(userCount > 0)
            {
                loginTest.Text = "Login successful";
                Response.Redirect("TindrProfile.aspx");
            }
            else
            {
                loginTest.Text = "Login failed";
            }
            
        }
    }
}