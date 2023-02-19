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
                DBConnect objDB = new DBConnect();
                Time now = new Time();
                string username = Request.Cookies["Username"].Value.ToString();
                welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString();
                SqlCommand uNamecheck = new SqlCommand("SELECT COUNT(*) FROM DatingProfile WHERE username = '" + username + "'");
                int userCount = (int)objDB.ExecuteScalarFunction(uNamecheck);
                objDB.CloseConnection();
                if (userCount > 0)
                {
                    profileForm2.Visible = true;
                    profileForm.Visible = false;
                    greetinglbl.Text = "You Already Have A Profile Set Up What Would You Like To Do?";
                    SqlCommand getProfile = new SqlCommand("getProfile");
                    SqlCommand getPic = new SqlCommand("getPic");
                    getPic.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    getPic.CommandType = CommandType.StoredProcedure;
                    getProfile.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                    getProfile.CommandType = CommandType.StoredProcedure;
                    string imageURL = objDB.GetDataSet(getPic).Tables[0].Rows[0]["photo"].ToString();
                    profilePic.ImageUrl = imageURL;
                    gvProfile.DataSource = objDB.GetDataSet(getProfile);
                    gvProfile.DataBind();

                }
                else
                {
                    profileForm.Visible = true;
                    profileForm2.Visible = false;
                }

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
            SqlCommand uNamecheck = new SqlCommand("SELECT COUNT(*) FROM DatingProfile WHERE username = '" + username + "'");
            int userCount = (int)objDB.ExecuteScalarFunction(uNamecheck);
            objDB.CloseConnection();
            if (userCount > 0)
            {
                SqlCommand update = new SqlCommand("updateProfile");
                update.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                update.Parameters.Add("@name", SqlDbType.VarChar).Value = nametxt.Text;
                update.Parameters.Add("@age", SqlDbType.VarChar).Value = agetxt.Text;
                update.Parameters.Add("@occupation", SqlDbType.VarChar).Value = occupationtxt.Text;
                update.Parameters.Add("@address", SqlDbType.VarChar).Value = addresstxt.Text;
                update.Parameters.Add("@email", SqlDbType.VarChar).Value = emailtxt.Text;
                update.Parameters.Add("@phone", SqlDbType.VarChar).Value = phonetxt.Text;
                update.Parameters.Add("@height", SqlDbType.VarChar).Value = heighttxt.Text;
                update.Parameters.Add("@favorite", SqlDbType.VarChar).Value = like;
                update.Parameters.Add("@dislike", SqlDbType.VarChar).Value = dislike;
                update.Parameters.Add("@goal", SqlDbType.VarChar).Value = goaltxt.Text;
                update.Parameters.Add("@commitment", SqlDbType.VarChar).Value = commitddl.Text;
                update.Parameters.Add("@description", SqlDbType.VarChar).Value = descriptiontxt.Text;
                update.Parameters.Add("@photo", SqlDbType.VarChar).Value = pictxt.Text;
                update.Parameters.Add("@birthday", SqlDbType.VarChar).Value = birthdaytxt.Text;
                update.CommandType = CommandType.StoredProcedure;
                objDB.DoUpdate(update);
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
                profileForm.Visible = false;
                profileForm2.Visible = true;
                greetinglbl.Text = "Here's Your Profile What Would You Like To Do?";
                SqlCommand getProfile = new SqlCommand("getProfile");
                SqlCommand getPic = new SqlCommand("getPic");
                getPic.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                getPic.CommandType = CommandType.StoredProcedure;
                getProfile.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
                getProfile.CommandType = CommandType.StoredProcedure;
                string imageURL = objDB.GetDataSet(getPic).Tables[0].Rows[0]["photo"].ToString();
                profilePic.ImageUrl = imageURL;
                gvProfile.DataSource = objDB.GetDataSet(getProfile);
                gvProfile.DataBind();
            }
        }

        protected void modifybtn_Click(object sender, EventArgs e)
        {
            profileForm.Visible = true;
            profileForm2.Visible = false;
            greetinglbl.Text = "Hi There, Let's Modify Your Profile";
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            SqlCommand delete = new SqlCommand("deleteProfile");
            string username = Request.Cookies["Username"].Value.ToString();
            delete.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            delete.CommandType = CommandType.StoredProcedure;
            objDB.DoUpdate(delete);
            greetinglbl.Text = "Ok Your Old Profile Is Now Deleted, Let's Set Up A New One";
            profileForm.Visible = true;
            profileForm2.Visible = false;
        }
    }
}