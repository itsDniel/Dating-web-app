using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatingAppLibrary;

namespace Dating_app
{
    public partial class TindrProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["Username"] != null)
                {
                    Time now = new Time();
                    Label1.Text = Request.Cookies["Username"].Value.ToString();
                    welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString();

                }
                else
                {
                    Response.Redirect("Tindr.aspx");
                }
            }
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tindr.aspx");
            Request.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
            Request.Cookies["Name"].Expires = DateTime.Now.AddDays(-1);
        }
    }
}