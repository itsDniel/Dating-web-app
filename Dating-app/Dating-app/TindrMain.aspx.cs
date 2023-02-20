using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Utilities;
using DatingAppLibrary;

namespace Dating_app
{
    public partial class TindrMain : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Username"] != null)
            {
                Time now = new Time();
                string username = Request.Cookies["Username"].Value.ToString();
                welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString();
            }
            else
            {
                Response.Redirect("TindrProfile.aspx");
            }

        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tindr.aspx");
            Request.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
            Request.Cookies["Name"].Expires = DateTime.Now.AddDays(-1);
        }

        protected void profilebtn_Click(object sender, EventArgs e)
        {
            HttpCookie cName = new HttpCookie("Username");
            HttpCookie uName = new HttpCookie("Name");
            cName.Value = Request.Cookies["Username"].Value.ToString();
            uName.Value = Request.Cookies["Name"].Value.ToString();
            Response.Cookies.Add(uName);
            Response.Cookies.Add(cName);
            Response.Redirect("TindrProfile.aspx");
        }

        protected void homebtn_Click(object sender, EventArgs e)
        {
            this.Page_Load(sender, e);
        }
    }
}