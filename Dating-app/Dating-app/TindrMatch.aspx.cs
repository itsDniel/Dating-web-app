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
    public partial class TindrMatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {
                if (Request.Cookies["Username"] != null)
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
                    welcomelbl.Text = now.getTime() + Request.Cookies["Name"].Value.ToString();
                    gvMatch.DataSource = objDB.GetDataSet(insert.getMatch(username));
                    gvMatch.DataBind();
                    if (notiCount > 0 && dateRequest > 0)
                    {
                        instructionlbl.Text = "You Have " + notiCount + " New Match And " + dateRequest + " New Date Request";
                        okbtn.Visible = true;
                    }
                    else if(notiCount > 0)
                    {
                            instructionlbl.Text = "You Have " + notiCount + " New Match";
                            okbtn.Visible = true;
                    }else if(dateRequest > 0)
                        {
                            instructionlbl.Text = "You Have " + dateRequest + " New Date Request";
                            okbtn.Visible = true;
                        }
                        else
                        {
                            instructionlbl.Text = "Here Are Your Matches";
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
            }   else
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
            HttpCookie cName = new HttpCookie("Username");
            HttpCookie uName = new HttpCookie("Name");
            cName.Value = Request.Cookies["Username"].Value.ToString();
            uName.Value = Request.Cookies["Name"].Value.ToString();
            Response.Cookies.Add(uName);
            Response.Cookies.Add(cName);
            Response.Redirect("TindrProfile.aspx");
        }

        protected void matchbtn_Click(object sender, EventArgs e)
        {
            this.Page_Load(sender, e);
        }

        protected void okbtn_Click(object sender, EventArgs e)
        {
            string username = Request.Cookies["Username"].Value.ToString();
            string status = "viewed";
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            instructionlbl.Text = "Here Are Your Matches";
            objDB.DoUpdate(command.updateView(username, status));
            okbtn.Visible = false;
        }

        protected void datebtn_Click(object sender, EventArgs e)
        {
            string unview = "Unview";
            GridViewRow row = (GridViewRow)(sender as Control).Parent.Parent;
            int rowIndex = row.RowIndex;
            string currentUser = Request.Cookies["Username"].Value.ToString();
            string targetUser = gvMatch.DataKeys[rowIndex].Value.ToString();
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            int checkRequest = (int)objDB.ExecuteScalarFunction(command.checkDate(currentUser, targetUser));
            objDB.CloseConnection();
            int reverseCheck = (int)objDB.ExecuteScalarFunction(command.checkDate(targetUser, currentUser));
            objDB.CloseConnection();
            int datePlanCheck = (int)objDB.ExecuteScalarFunction(command.checkDatePlan(currentUser));
            objDB.CloseConnection();
            if (datePlanCheck > 0)
            {
                instructionlbl.Text = "You Can't Send A Date Request When You Have A Date Plan, Don't Be An Asshole";
            }
            else 
            { 
            if (checkRequest > 0 || reverseCheck > 0)
            {
                if (checkRequest > 0)
                {
                    instructionlbl.Text = "You Already Sent A Date Request To This User";
                }
                else if (reverseCheck > 0)
                {
                    instructionlbl.Text = "This User Sent You A Date Request Please Check Your Date Requests";
                }
            }
            else
            {
                instructionlbl.Text = "You Sent A Date Request To This User";
                objDB.DoUpdate(command.insertDate(currentUser, targetUser, unview));
            }
        }
        }

        protected void unMatchbtn_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            GridViewRow row = (GridViewRow)(sender as Control).Parent.Parent;
            int rowIndex = row.RowIndex;
            string username = gvMatch.DataKeys[rowIndex].Value.ToString();
            string currentUser = Request.Cookies["Username"].Value.ToString();
            objDB.DoUpdate(command.unMatch(currentUser, username));
            objDB.DoUpdate(command.unMatch(username, currentUser));
            this.Page_Load(sender, e);
        }

        protected void acceptbtn_Click(object sender, EventArgs e)
        {
            string currentUser_Name = Request.Cookies["Name"].Value.ToString();
            string currentUser = Request.Cookies["Username"].Value.ToString();
            GridViewRow row = (GridViewRow)(sender as Control).Parent.Parent;
            int rowIndex = row.RowIndex;
            string username = gvDate.DataKeys[rowIndex].Value.ToString();
            string username_Name = gvDate.Rows[rowIndex].Cells[2].Text;
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            int datePlanCheck = (int)objDB.ExecuteScalarFunction(command.checkDatePlan(currentUser));
            objDB.CloseConnection();
            if (datePlanCheck > 0)
            {
                instructionlbl.Text = "You Can't Accept Date Requests When You Have A Date Plan";
            }
            else
            {
                objDB.DoUpdate(command.insertDatePlan(currentUser, username, currentUser_Name, username_Name));
                objDB.DoUpdate(command.deleteDate(currentUser, username));
                objDB.DoUpdate(command.deleteDate(username, currentUser));
                objDB.DoUpdate(command.unMatch(currentUser, username));
                objDB.DoUpdate(command.unMatch(username, currentUser));
            }
        }

        protected void rejectbtn_Click(object sender, EventArgs e)
        {
            string currentUser = Request.Cookies["Username"].Value.ToString();
            GridViewRow row = (GridViewRow)(sender as Control).Parent.Parent;
            int rowIndex = row.RowIndex;
            string username = gvDate.DataKeys[rowIndex].Value.ToString();
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            objDB.DoUpdate(command.deleteDate(currentUser, username));
            objDB.DoUpdate(command.deleteDate(username, currentUser));
            objDB.DoUpdate(command.unMatch(currentUser, username));
            objDB.DoUpdate(command.unMatch(username, currentUser));

        }

        protected void checkDate_Click(object sender, EventArgs e)
        {
            string currentUser = Request.Cookies["Username"].Value.ToString();
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            instructionlbl.Text = "Here Are Your Date Request";
            gvDate.Visible = true;
            gvMatch.Visible = false;
            gvDate.DataSource = objDB.GetDataSet(command.getDateRequest(currentUser));
            gvDate.DataBind();
            gvPlan.Visible = false;
            gvProfile.Visible = false;
            descriptionlbl.Visible = false;
            descriptiontxt.Visible = false;
            locationlbl.Visible = false;
            locationtxt.Visible = false;
            timelbl.Visible = false;
            timetxt.Visible = false;
            updatePlanbtn.Visible = false;
        }

        protected void checkMatchbtn_Click(object sender, EventArgs e)
        {
            instructionlbl.Text = "Here Are Your Matches";
            gvDate.Visible = false;
            gvMatch.Visible = true;
            gvPlan.Visible = false;
            gvProfile.Visible = false;
            descriptionlbl.Visible = false;
            descriptiontxt.Visible = false;
            locationlbl.Visible = false;
            locationtxt.Visible = false;
            timelbl.Visible = false;
            timetxt.Visible = false;
            updatePlanbtn.Visible = false;
        }

        protected void datePlanbtn_Click(object sender, EventArgs e)
        {
            descriptionlbl.Visible = true;
            descriptiontxt.Visible = true;
            locationlbl.Visible = true;
            locationtxt.Visible = true;
            timelbl.Visible = true;
            timetxt.Visible = true;
            updatePlanbtn.Visible = true;
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            string currentUser = Request.Cookies["Username"].Value.ToString();
            int count = (int)objDB.ExecuteScalarFunction(command.checkDatePlan(currentUser));
            objDB.CloseConnection();
            if (count > 0)
            {
                string username1 = objDB.GetDataSet(command.getDatePlan(currentUser)).Tables[0].Rows[0]["user1"].ToString();
                string username2 = objDB.GetDataSet(command.getDatePlan(currentUser)).Tables[0].Rows[0]["user2"].ToString();
                gvPlan.DataSource = objDB.GetDataSet(command.getDatePlan(currentUser));
                gvPlan.DataBind();
                gvDate.Visible = false;
                gvMatch.Visible = false;
                gvPlan.Visible = true;
                gvProfile.Visible = true;
                if (currentUser == username1)
                {
                    gvProfile.DataSource = objDB.GetDataSet(command.getProfile(username2));
                    gvProfile.DataBind();
                }
                else
                {
                    gvProfile.DataSource = objDB.GetDataSet(command.getProfile(username1));
                    gvProfile.DataBind();
                }
            }
            else
            {
                instructionlbl.Text = "You Have No Date Plan";
            }
        }

        protected void updatePlanbtn_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            string currentUser = Request.Cookies["Username"].Value.ToString();
            objDB.DoUpdate(command.updateDatePlan(currentUser, timetxt.Text, locationtxt.Text, descriptiontxt.Text));
            gvPlan.DataSource = objDB.GetDataSet(command.getDatePlan(currentUser));
            gvPlan.DataBind();
        }

        protected void cancelbtn_Click(object sender, EventArgs e)
        {
            DBConnect objDB = new DBConnect();
            storedProceduralCommand command = new storedProceduralCommand();
            string currentUser = Request.Cookies["Username"].Value.ToString();
            objDB.DoUpdate(command.deleteDatePlan(currentUser));
            instructionlbl = "You Cancel The Date You Prick!!";
        }
    }
}