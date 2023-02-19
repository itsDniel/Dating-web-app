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
            String username = userCreationtxt.Text;
            DBConnect objDB = new DBConnect();
            SqlCommand updateCommand = new SqlCommand("insertLogin");
            updateCommand.Parameters.AddWithValue("username", userCreationtxt.Text);
            updateCommand.Parameters.AddWithValue("password", passCreationtxt.Text);
            updateCommand.Parameters.AddWithValue("fname", fNametxt.Text);
            updateCommand.Parameters.AddWithValue("lname", lNametxt.Text);
            updateCommand.Parameters.AddWithValue("email", emailtxt.Text);
            updateCommand.CommandType = CommandType.StoredProcedure;
            SqlCommand checkUname = new SqlCommand("SELECT COUNT(*) FROM Login WHERE username = '" + username + "'");
            int userCount = (int)objDB.ExecuteScalarFunction(checkUname);
            objDB.CloseConnection();
            if (userCount > 0)
            {
                uNameAlertlbl.Visible = true;

            }
            else
            {
                uNameAlertlbl.Visible = false;
                objDB.DoUpdate(updateCommand);
                accountForm.Visible = false;
                form1.Visible = true;

            }


        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String username = userNametxt.Text;
            String password = passWordtxt.Text;
            DBConnect objDB = new DBConnect();
            String sql = "SELECT COUNT(*) FROM Login WHERE username = '" + username + "' AND password = '" + password + "'";
            SqlCommand name = new SqlCommand("SELECT fname FROM Login WHERE username = '" + username + "'");
            SqlCommand retrieve = new SqlCommand(sql);
            int userCount = (int)objDB.ExecuteScalarFunction(retrieve);
            objDB.CloseConnection();
            String cookieName = objDB.GetDataSet(name).Tables[0].Rows[0]["fname"].ToString();
            if(userCount > 0)
            {
                HttpCookie uname = new HttpCookie("Username");
                HttpCookie cName = new HttpCookie("Name");
                cName.Value = cookieName;
                uname.Value = userNametxt.Text;
                Response.Cookies.Add(uname);
                Response.Cookies.Add(cName);
                Response.Redirect("TindrProfile.aspx");
            }
            else
            {
                loginTest.Text = "Wrong Username or Password!";
            }
            
        }
    }
}