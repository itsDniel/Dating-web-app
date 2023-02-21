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
                storedProceduralCommand insert = new storedProceduralCommand();
                Time now = new Time();
                string username = Request.Cookies["Username"].Value.ToString();
                welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString();
                int userCount = (int)objDB.ExecuteScalarFunction(insert.executeScalar(username));
                objDB.CloseConnection();
                
                if (userCount > 0)
                {
                    foreach (Control control in profileForm.Controls)
                    {
                        if (control is TextBox || control is Label || control is DropDownList)
                        {
                            control.Visible = false;
                        }
                        else
                        {
                            control.Visible = true;
                        }
                        
                    }
                    welcomelbl.Visible = true;
                    greetinglbl.Visible = true;
                    submitbtn.Visible = false;
                    greetinglbl.Text = "You Already Have A Profile Set Up What Would You Like To Do?";
                    profilePic.ImageUrl = objDB.GetDataSet(insert.getPic(username)).Tables[0].Rows[0]["photo"].ToString();
                    gvProfile.DataSource = objDB.GetDataSet(insert.getProfile(username));
                    gvProfile.DataBind();

                }
                else
                {
                    foreach(Control control in profileForm.Controls)
                    {
                        if(control is GridView || control is Image || control is Button)
                        {
                            control.Visible = false;
                        }
                        else
                        {
                            control.Visible = true;
                        }
                    }
                    homebtn.Visible = true;
                    profilebtn.Visible = true;
                    logoutbtn.Visible = true;
                    submitbtn.Visible = true;
                    logoutbtn.Visible = true;

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
            storedProceduralCommand insert = new storedProceduralCommand();
            string like = liketxt.Text;
            string username = Request.Cookies["Username"].Value.ToString();
            string name = nametxt.Text;
            string age = agetxt.Text;
            string occupation = occupationtxt.Text;
            string addr = addresstxt.Text;
            string email = emailtxt.Text;
            string phone = phonetxt.Text;
            string height = heighttxt.Text;
            string dislike = disliketxt.Text;
            string goal = goaltxt.Text;
            string commit = commitddl.Text;
            string des = descriptiontxt.Text;
            string pic = pictxt.Text;
            string birthday = birthdaytxt.Text;
                if (string.IsNullOrEmpty(like))
                {
                    like = "N/A";
                }
                if (string.IsNullOrEmpty(dislike))
                {
                    dislike = "N/A";
                }
            int userCount = (int)objDB.ExecuteScalarFunction(insert.executeScalar(username));
            objDB.CloseConnection();
            if (userCount > 0)
            {
                objDB.DoUpdate(insert.getUpdateCommand(username, name, age, occupation, addr, email, phone, height, like, dislike, goal, commit, des, pic, birthday));
                foreach (Control control in profileForm.Controls)
                {
                    if (control is TextBox || control is Label || control is DropDownList)
                    {
                        control.Visible = false;
                    }
                    else
                    {
                        control.Visible = true;
                    }
                }
                submitbtn.Visible = false;
                welcomelbl.Visible = true;
                greetinglbl.Visible = true;
                greetinglbl.Text = "Here's Your Profile What Would You Like To Do?";
                profilePic.ImageUrl = objDB.GetDataSet(insert.getPic(username)).Tables[0].Rows[0]["photo"].ToString();
                gvProfile.DataSource = objDB.GetDataSet(insert.getProfile(username));
                gvProfile.DataBind();
            }
            else
            {

                objDB.DoUpdate(insert.getInsertCommand(username, name, age, occupation, addr, email, phone, height, like, dislike, goal, commit, des, pic, birthday));
                foreach (Control control in profileForm.Controls)
                {
                    if (control is TextBox || control is Label || control is DropDownList)
                    {
                        control.Visible = false;
                    }
                    else
                    {
                        control.Visible = true;
                    }
                }
                submitbtn.Visible = false;
                welcomelbl.Visible = true;
                greetinglbl.Visible = true;
                greetinglbl.Text = "Here's Your Profile What Would You Like To Do?";
                profilePic.ImageUrl = objDB.GetDataSet(insert.getPic(username)).Tables[0].Rows[0]["photo"].ToString();
                gvProfile.DataSource = objDB.GetDataSet(insert.getProfile(username));
                gvProfile.DataBind();

            }
        }

        protected void modifybtn_Click(object sender, EventArgs e)
        {
            foreach (Control control in profileForm.Controls)
            {
                if (control is GridView || control is Image || control is Button)
                {
                    control.Visible = false;
                }
                else
                {
                    control.Visible = true;
                }
            }
            homebtn.Visible = true;
            profilebtn.Visible = true;
            logoutbtn.Visible = true;
            welcomelbl.Visible = true;
            submitbtn.Visible = true;
            greetinglbl.Visible = true;

            greetinglbl.Text = "Hi There, Let's Modify Your Profile";
        }

        protected void deletebtn_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            storedProceduralCommand insert = new storedProceduralCommand();
            string username = Request.Cookies["Username"].Value.ToString();
            objDB.DoUpdate(insert.deleteProfile(username));
            greetinglbl.Text = "Ok Your Old Profile Is Now Deleted, Let's Set Up A New One";
            foreach (Control control in profileForm.Controls)
            {
                if (control is GridView || control is Image || control is Button)
                {
                    control.Visible = false;
                }
                else
                {
                    control.Visible = true;
                }
            }
            
            homebtn.Visible = true;
            profilebtn.Visible = true;
            logoutbtn.Visible = true;
            submitbtn.Visible = true;


        }

        protected void logoutbtn2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tindr.aspx");
            Request.Cookies["Username"].Expires = DateTime.Now.AddDays(-1);
            Request.Cookies["Name"].Expires = DateTime.Now.AddDays(-1);
        }

        protected void homebtn_Click(object sender, EventArgs e)
        {
            HttpCookie cName = new HttpCookie("Username");
            HttpCookie uName = new HttpCookie("Name");
            cName.Value = Request.Cookies["Username"].Value.ToString();
            uName.Value = Request.Cookies["Name"].Value.ToString();
            Response.Cookies.Add(uName);
            Response.Cookies.Add(cName);
            Response.Redirect("TindrMain.aspx");
        }

        protected void profilebtn_Click(object sender, EventArgs e)
        {
            this.Page_Load(sender, e);
        }
    }
}