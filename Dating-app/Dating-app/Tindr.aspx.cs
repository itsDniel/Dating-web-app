using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Utilities;
using System.Data.SqlClient;
using DatingAppLibrary;
using System.Web.UI.HtmlControls;

namespace Dating_app
{
    public partial class Tindr : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "logo-animation", @"
            let intro = document.querySelector('.intro');
            let logo = document.querySelector('.logo-header');
            let logoSpan = document.querySelectorAll('.logo');

            function animateLogo() {
              setTimeout(() => {
                  logoSpan.forEach((span, idx) => {
                      setTimeout(() => {
                          span.classList.add('active');
                      }, (idx + 1) * 400)
                  });

                  setTimeout(() => {
                      logoSpan.forEach((span, idx) => {
                          setTimeout(() => {
                              span.classList.remove('active');
                              span.classList.add('fade');

                          }, (idx + 1) * 50)
                      })
                  }, 2000);

                  setTimeout(() => {
                      intro.style.top = '-100vh';
                  }, 2300);
                    
                  
              });
            }

            window.addEventListener('DOMContentLoaded', animateLogo);
        ", true);
                
                accountForm.Visible = false;

            }
            else
            {
                introDiv.Visible = false;
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
            string username = userCreationtxt.Text;
            string password = passCreationtxt.Text;
            string fname = fNametxt.Text;
            string lname = lNametxt.Text;
            string email = emailtxt.Text;
            DBConnect objDB = new DBConnect();
            storedProceduralCommand insert = new storedProceduralCommand();
            int userCount = (int)objDB.ExecuteScalarFunction(insert.executeScalarLogin(username));
            objDB.CloseConnection();
            if (userCount > 0)
            {
                uNameAlertlbl.Visible = true;

            }
            else
            {
                uNameAlertlbl.Visible = false;
                objDB.DoUpdate(insert.insertLogin(username, password, fname, lname, email));
                accountForm.Visible = false;
                form1.Visible = true;

            }


        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String username = userNametxt.Text;
            String password = passWordtxt.Text;
            String cookieName = " ";
            int userCount = 0;
            try
            {
                DBConnect objDB = new DBConnect();
                storedProceduralCommand command = new storedProceduralCommand();
                SqlCommand name = new SqlCommand("SELECT fname FROM Login WHERE username = '" + username + "'");
                userCount = (int)objDB.ExecuteScalarFunction(command.checkLogin(username, password));
                objDB.CloseConnection();
                cookieName = objDB.GetDataSet(name).Tables[0].Rows[0]["fname"].ToString();
                objDB.CloseConnection();
            }
            catch(Exception ex)
            {
                loginTest.Text = "You Must Enter Your Credential";
                return;
            }
            if(userCount > 0)
            {
                HttpCookie uname = new HttpCookie("Username");
                HttpCookie cName = new HttpCookie("Name");
                cName.Value = cookieName;
                uname.Value = userNametxt.Text;
                Response.Cookies.Add(uname);
                Response.Cookies.Add(cName);
                Response.Redirect("TindrMain.aspx");
            }
            else if(string.IsNullOrEmpty(userNametxt.Text) || string.IsNullOrEmpty(passWordtxt.Text))
            {
                loginTest.Text = "You Must Enter Your Credential";
            }
            else
            {
                loginTest.Text = "Wrong Username or Password!";
            }
            
        }

        protected void backbtn_Click(object sender, EventArgs e)
        {
            form1.Visible = true;
            accountForm.Visible = false;
        }
    }
}