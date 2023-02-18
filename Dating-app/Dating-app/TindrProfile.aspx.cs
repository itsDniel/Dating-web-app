﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dating_app
{
    public partial class TindrProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.Cookies["Username"] != null)
            {
                Label1.Text = Request.Cookies["Username"].Value.ToString();
            }
            else
            {
                Response.Redirect("Tindr.aspx");
            }
        }
    }
}