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
                table.Visible = false;
                Time now = new Time();
                string username = Request.Cookies["Username"].Value.ToString();
                welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString();
                storedProceduralCommand insert = new storedProceduralCommand();
                DBConnect objDB = new DBConnect();
                int userCount = (int)objDB.ExecuteScalarFunction(insert.executeScalar(username));
                if(userCount > 0)
                {

                }
                else
                {
                    HttpCookie cName = new HttpCookie("Username");
                    HttpCookie uName = new HttpCookie("Name");
                    cName.Value = Request.Cookies["Username"].Value.ToString();
                    uName.Value = Request.Cookies["Name"].Value.ToString();
                    Response.Cookies.Add(uName);
                    Response.Cookies.Add(cName);
                    Response.Redirect("TindrProfile.aspx");
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



        private void generateGridview(string value)
        {
            gvCity.Columns[5].Visible = false;
            gvCity.Columns[6].Visible = false;
            gvCity.Columns[7].Visible = false;
            string username = Request.Cookies["Username"].Value.ToString();
            DBConnect objDB = new DBConnect();
            storedProceduralCommand insert = new storedProceduralCommand();
            string uCity = objDB.GetDataSet(insert.getInfo(username)).Tables[0].Rows[0]["address"].ToString();
            string like = objDB.GetDataSet(insert.getInfo(username)).Tables[0].Rows[0]["favorite"].ToString();
            string dislike = objDB.GetDataSet(insert.getInfo(username)).Tables[0].Rows[0]["dislike"].ToString();
            string commit = objDB.GetDataSet(insert.getInfo(username)).Tables[0].Rows[0]["commitment"].ToString();
            if (value == "0")
            {
                instructionlbl.Text = "These Are The Profile That Match Your City";
                gvCity.Visible = true;
                gvCity.DataSource = objDB.GetDataSet(insert.getInfo(username, uCity));
                gvCity.DataBind();
            }else if(value == "1")
            {
                instructionlbl.Text = "These Are The Profile That Like The Same Thing As You";
                gvCity.Columns[4].Visible = false;
                gvCity.Columns[5].Visible = true;
                gvCity.DataSource = objDB.GetDataSet(insert.getLike(username, like));
                gvCity.DataBind();
            }else if(value == "2")
            {
                instructionlbl.Text = "These Are The Profile That Dislike The Same Thing As You";
                gvCity.Columns[5].Visible = false;
                gvCity.Columns[6].Visible = true;
                gvCity.DataSource = objDB.GetDataSet(insert.getDislike(username, dislike));
                gvCity.DataBind();
            }
            else
            {
                instructionlbl.Text = "These Are The Profile That Are Looking For The Same Commitment Type As You";
                gvCity.Columns[6].Visible = false;
                gvCity.Columns[7].Visible = true;
                gvCity.DataSource = objDB.GetDataSet(insert.getCommit(username, commit));
                gvCity.DataBind();
                
            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            generateGridview(searchddl.SelectedValue);
        }


        protected void profilebtn_Click1(object sender, EventArgs e)
        {
            
            nobtn.Visible = true;
            likebtn.Visible = true;
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            GridViewRow row = (GridViewRow)(sender as Control).Parent.Parent;
            int rowIndex = row.RowIndex;
            string username = gvCity.DataKeys[rowIndex].Value.ToString();
            table.Visible = true;
            rprProfile.Visible = true;
            profileImg.Visible = true;
            rprProfile.DataSource = objDB.GetDataSet(command.getProfile(username));
            rprProfile.DataBind();
            profileImg.ImageUrl = objDB.GetDataSet(command.getProfile(username)).Tables[0].Rows[0]["photo"].ToString();
            usernamePlaceholder.Text = username;
            namePlaceholder.Text = objDB.GetDataSet(command.getProfile(username)).Tables[0].Rows[0]["name"].ToString();
            

        }

        protected void nobtn_Click(object sender, EventArgs e)
        {
            
            table.Visible = false;
            nobtn.Visible = false;
            likebtn.Visible = false;
            rprProfile.Visible = false;
            profileImg.Visible = false;

        }

        protected void likebtn_Click(object sender, EventArgs e)
        {
            closebtn.Visible = true;
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            string username1 = Request.Cookies["Username"].Value.ToString();
            string username2 = usernamePlaceholder.Text;
            instructionlbl.Text = "You Liked " + namePlaceholder.Text + ", If They Like You Back Then Your Match Will Show Up In The Match Page";
            int count = (int)objDB.ExecuteScalarFunction(command.executeScalarLike(username1, username2));
            objDB.CloseConnection();
            if (count > 0)
            {
                instructionlbl.Text = "You Either Already Liked This User Or Was Liked By This User, Please Go To My Match Page To See The Match";
                nobtn.Visible = false;
                likebtn.Visible = false;
            }
            else
            {
                objDB.DoUpdate(command.insertLike(username1, username2));
                nobtn.Visible = false;
                likebtn.Visible = false;
            }
        }

        protected void closebtn_Click(object sender, EventArgs e)
        {
            table.Visible = false;
            nobtn.Visible = false;
            likebtn.Visible = false;
            rprProfile.Visible = false;
            profileImg.Visible = false;
            closebtn.Visible = false;
            instructionlbl.Text = "Let's Look For People That Have Something In Common With You";
        }
    }
}