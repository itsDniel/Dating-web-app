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
                string status = "Unview";
                Time now = new Time();
                string username = Request.Cookies["Username"].Value.ToString();
                storedProceduralCommand insert = new storedProceduralCommand();
                DBConnect objDB = new DBConnect();
                int userCount = (int)objDB.ExecuteScalarFunction(insert.executeScalar(username));
                objDB.CloseConnection();
                int notiCount = (int)objDB.ExecuteScalarFunction(insert.matchNotification(username, status));
                objDB.CloseConnection();
                int dateRequest = (int)objDB.ExecuteScalarFunction(insert.getDateRequest(username, status));
                objDB.CloseConnection();
                if (userCount > 0)
                {
                    if (notiCount > 0 && dateRequest > 0)
                    {
                        welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString() + "<br>" + "You Have " + notiCount + " New Match And " + dateRequest + " New Date Request";
                    }
                    else if(notiCount > 0)
                    {
                        welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString() + "<br>" + "You Have " + notiCount + " New Match";
                    }
                    else if( dateRequest > 0)
                    {
                        welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString() + "<br>" + "You Have " + dateRequest + " New Date Requests";
                    }
                    else
                    {
                        welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString();
                    }
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
                rprDisplay.Visible = true;
                rprDisplay.DataSource = objDB.GetDataSet(insert.getInfo(username, uCity));
                rprDisplay.DataBind();
            }else if(value == "1")
            {
                instructionlbl.Text = "These Are The Profile That Like The Same Thing As You";
                rprDisplay.Visible = true;
                rprDisplay.DataSource = objDB.GetDataSet(insert.getLike(username, like));
                rprDisplay.DataBind();
            }else if(value == "2")
            {
                instructionlbl.Text = "These Are The Profile That Dislike The Same Thing As You";
                rprDisplay.Visible = true;
                rprDisplay.DataSource = objDB.GetDataSet(insert.getDislike(username, dislike));
                rprDisplay.DataBind();
            }
            else
            {
                instructionlbl.Text = "These Are The Profile That Are Looking For The Same Commitment Type As You";
                rprDisplay.Visible = true;
                rprDisplay.DataSource = objDB.GetDataSet(insert.getCommit(username, commit));
                rprDisplay.DataBind();
                
            }
        }



        protected void Button2_Click(object sender, EventArgs e)
        {
            generateGridview(searchddl.SelectedValue);
        }


        protected void nobtn_Click(object sender, EventArgs e)
        {


            nobtn.Visible = false;
            likebtn.Visible = false;
            rprProfile.Visible = false;

            

        }

        protected void likebtn_Click(object sender, EventArgs e)
        {
            DataSet ds1 = new DataSet();
            DataSet ds2 = new DataSet();
            string unviewed = "Unview";
            string userthatLike = "";
            string userthatwasLiked = "";
            closebtn.Visible = true;
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            string username1 = Request.Cookies["Username"].Value.ToString();
            string username2 = usernamePlaceholder.Text;
            ds1 = objDB.GetDataSet(command.getUserThatLike(username1, username2));
            ds2 = objDB.GetDataSet(command.getUserWasLiked(username1, username2));
            if (ds1.Tables[0].Rows.Count > 0)
            {
                userthatLike = ds1.Tables[0].Rows[0]["UserThatLike"].ToString();
            }
            else
            {
                userthatLike = " ";
            }
            if (ds2.Tables[0].Rows.Count > 0){
                userthatwasLiked = ds2.Tables[0].Rows[0]["UserThatWasLiked"].ToString();
            }
            else
            {
                userthatwasLiked = " ";
            }
            instructionlbl.Text = "You Liked " + namePlaceholder.Text + ", If They Like You Back Then Your Match Will Show Up In The Match Page";
            int count = (int)objDB.ExecuteScalarFunction(command.executeScalarLike(username1, username2));
            objDB.CloseConnection();
            int reverseCount = (int)objDB.ExecuteScalarFunction(command.executeScalarLike(username2, username1));
            objDB.CloseConnection();
            if (count > 0 || reverseCount >0)
            {
                if (username1 == userthatLike) 
                { 
                    instructionlbl.Text = "You Have Liked This User Already";

                }
                else if(username1 == userthatwasLiked)
                {
                    int userCount = (int)objDB.ExecuteScalarFunction(command.executeScalarLike(username1, username2));
                    objDB.CloseConnection();
                    if (userCount > 0)
                    {
                        instructionlbl.Text = "You Already Match With This User";

                    }
                    else
                    {
                        instructionlbl.Text = "This User Liked You Already, So You Have A Match";

                        objDB.DoUpdate(command.updateView(username2, unviewed, username1));
                        objDB.DoUpdate(command.insertLike(username1, username2));
                        objDB.DoUpdate(command.updateView(username1, unviewed, username2));
                    }
                }
            }
            else
            {
                objDB.DoUpdate(command.insertLike(username1, username2));
                
            }
        }

        protected void closebtn_Click(object sender, EventArgs e)
        {

            nobtn.Visible = false;
            likebtn.Visible = false;
            rprProfile.Visible = false;
            closebtn.Visible = false;
            instructionlbl.Text = "Let's Look For People That Have Something In Common With You";
        }

        protected void matchbtn_Click(object sender, EventArgs e)
        {
            HttpCookie cName = new HttpCookie("Username");
            HttpCookie uName = new HttpCookie("Name");
            cName.Value = Request.Cookies["Username"].Value.ToString();
            uName.Value = Request.Cookies["Name"].Value.ToString();
            Response.Cookies.Add(uName);
            Response.Cookies.Add(cName);
            Response.Redirect("TindrMatch.aspx");
        }

        protected void rptProducts_ItemCommand(Object sender, System.Web.UI.WebControls.RepeaterCommandEventArgs e)

        {

            instructionlbl.Text = "Let's Look For People That Have Something In Common With You";
            int rowIndex = e.Item.ItemIndex;
            Label myLabel = (Label)rprDisplay.Items[rowIndex].FindControl("lblUsername");
            string username = myLabel.Text;
            usernamePlaceholder.Text = username;
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            rprProfile.Visible = true;
            rprProfile.DataSource = objDB.GetDataSet(command.getProfile(username));
            rprProfile.DataBind();
            namePlaceholder.Text = objDB.GetDataSet(command.getProfile(username)).Tables[0].Rows[0]["name"].ToString();
        }

    }
}