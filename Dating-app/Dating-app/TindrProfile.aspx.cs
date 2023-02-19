using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatingAppLibrary;
using Utilities;
using System.Data.SqlClient;
using System.Data;

namespace Dating_app
{
    public partial class TindrProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (Request.Cookies["Username"] != null)
                {
                    Time now = new Time();
                    welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString();

                }
                else
                {
                    Response.Redirect("Tindr.aspx");
                }
            
        }

        protected void logoutbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tindr.aspx");
            Request.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
            Request.Cookies["Name"].Expires = DateTime.Now.AddDays(-1);
        }

        protected void submitbtn_Click(object sender, EventArgs e)
        {
                DBConnect objDB = new DBConnect();
                string like = liketxt.Text;
                string username = Request.Cookies["Username"].Value.ToString();
                string dislike = disliketxt.Text;
                if (string.IsNullOrEmpty(like))
                {
                    like = "N/A";
                }
                if (string.IsNullOrEmpty(dislike))
                {
                    dislike = "N/A";
                }
            SqlCommand uNamecheck = new SqlCommand("SELECT COUNT(*) FROM Login WHERE username = '" + username + "'");
            int userCount = (int)objDB.ExecuteScalarFunction(uNamecheck);
            objDB.CloseConnection();
            if (userCount > 0)
            {
                welcomelbl.Text = "User already exist";
            }
            else
            {

                SqlCommand insert2 = new SqlCommand("insertDating");
                insert2.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                insert2.Parameters.Add("@name", SqlDbType.VarChar).Value = nametxt.Text;
                insert2.Parameters.Add("@age", SqlDbType.VarChar).Value = agetxt.Text;
                insert2.Parameters.Add("@occupation", SqlDbType.VarChar).Value = occupationtxt.Text;
                insert2.Parameters.Add("@address", SqlDbType.VarChar).Value = addresstxt.Text;
                insert2.Parameters.Add("@email", SqlDbType.VarChar).Value = emailtxt.Text;
                insert2.Parameters.Add("@phone", SqlDbType.VarChar).Value = phonetxt.Text;
                insert2.Parameters.Add("@height", SqlDbType.VarChar).Value = heighttxt.Text;
                insert2.Parameters.Add("@favorite", SqlDbType.VarChar).Value = like;
                insert2.Parameters.Add("@dislike", SqlDbType.VarChar).Value = dislike;
                insert2.Parameters.Add("@goal", SqlDbType.VarChar).Value = goaltxt.Text;
                insert2.Parameters.Add("@commitment", SqlDbType.VarChar).Value = commitddl.Text;
                insert2.Parameters.Add("@description", SqlDbType.VarChar).Value = descriptiontxt.Text;
                insert2.Parameters.Add("@photo", SqlDbType.VarChar).Value = pictxt.Text;
                insert2.Parameters.Add("@birthday", SqlDbType.VarChar).Value = birthdaytxt.Text;
                insert2.CommandType = CommandType.StoredProcedure;
                objDB.DoUpdate(insert2);
            }
        }

      
    }
}