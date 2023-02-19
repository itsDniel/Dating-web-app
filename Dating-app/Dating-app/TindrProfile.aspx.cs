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
                updateProfileDB newCommand = new updateProfileDB();
                string username = Request.Cookies["Username"].Value.ToString();
                string name = nametxt.Text;
                string age = agetxt.Text;
                string occupation = occupationtxt.Text;
                string address = addresstxt.Text;
                string email = emailtxt.Text;
                string phone = phonetxt.Text;
                string height = heighttxt.Text;
                string goal = goaltxt.Text;
                string commit = commitddl.Text;
                string descrip = descriptiontxt.Text;
                string photo = pictxt.Text;
                string birthday = birthdaytxt.Text;
                string like = liketxt.Text;
                string dislike = disliketxt.Text;
                if (string.IsNullOrEmpty(like))
                {
                    like = "N/A";
                }
                if (string.IsNullOrEmpty(dislike))
                {
                    dislike = "N/A";
                }
                //SqlCommand insertCommand = new SqlCommand("INSERT INTO Dating (username, name, age, occupation, address, email, phone, height, like, dislike, goal, commitment, description, photo, birthday) VALUES (@username, @name, @age, @occupation, @address, @email, @phone, @height, @like, @dislike, @goal, @commitment, @description, @photo, @birthday)");
                //SqlCommand insertCommand = new SqlCommand("INSERT INTO DATING (username) VALUES (@username)");
                SqlCommand insert2 = new SqlCommand("INSERT INTO Test (username, name, age, occupation, address, email, phone, height, like, dislike, goal, commitment, description, photo, birthday) VALUES (@username, @name, @age, @occupation, @address, @email, @phone, @height, @like, @dislike, @goal, @commitment @description, @photo, @birthday)");
                insert2.Parameters.Add("@username", SqlDbType.VarChar, 50).Value =username;
                insert2.Parameters.Add("@name", SqlDbType.VarChar,50).Value = name;
                //insertCommand.Parameters.AddWithValue("username", username);
                //insertCommand.Parameters.AddWithValue("name", name);
                insert2.Parameters.Add("@age", SqlDbType.VarChar,50).Value = age;
                insert2.Parameters.Add("@occupation", SqlDbType.VarChar, 50).Value = occupation;
                insert2.Parameters.Add("@address", SqlDbType.VarChar, 50).Value = address;
                insert2.Parameters.Add("@email", SqlDbType.VarChar, 50).Value = email;
                insert2.Parameters.Add("@phone", SqlDbType.VarChar, 50).Value = phone;
                insert2.Parameters.Add("@height", SqlDbType.VarChar, 50).Value = height;
                insert2.Parameters.Add("@like", SqlDbType.VarChar, 50).Value = like ;
                insert2.Parameters.Add("@dislike", SqlDbType.VarChar,50).Value = dislike;
                insert2.Parameters.Add("@goal", SqlDbType.VarChar, 50).Value = goal;
                insert2.Parameters.Add("@commitment", SqlDbType.VarChar, 50).Value = commit;
                insert2.Parameters.Add("@description", SqlDbType.VarChar, 100).Value = descrip;
                insert2.Parameters.Add("@photo", SqlDbType.VarChar, 100).Value = photo;
                insert2.Parameters.Add("@birthday", SqlDbType.VarChar, 50).Value = birthday;
                //objDB.DoUpdate(newCommand.insertProfile(username, name, age, occupation, address, email, phone, height, like, dislike, goal, commit, descrip, photo, birthday));
                objDB.DoUpdate(insert2);
            
        }

      
    }
}