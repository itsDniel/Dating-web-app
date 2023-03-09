using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace DatingAppLibrary
{
    public class storedProceduralCommand
    {
        //Use this to insert data into DatingProfile Table
        public SqlCommand getInsertCommand(string username, string name, string age, string occupation, string address, string email, string phone, string height, string favorite, string dislike, string goal, string commitment, string description, string photo, string birthday)
        {
            SqlCommand insert2 = new SqlCommand("insertDating");
            insert2.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            insert2.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            insert2.Parameters.Add("@age", SqlDbType.VarChar).Value = age;
            insert2.Parameters.Add("@occupation", SqlDbType.VarChar).Value = occupation;
            insert2.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            insert2.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            insert2.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            insert2.Parameters.Add("@height", SqlDbType.VarChar).Value = height;
            insert2.Parameters.Add("@favorite", SqlDbType.VarChar).Value = favorite;
            insert2.Parameters.Add("@dislike", SqlDbType.VarChar).Value = dislike;
            insert2.Parameters.Add("@goal", SqlDbType.VarChar).Value = goal;
            insert2.Parameters.Add("@commitment", SqlDbType.VarChar).Value = commitment;
            insert2.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
            insert2.Parameters.Add("@photo", SqlDbType.VarChar).Value = photo;
            insert2.Parameters.Add("@birthday", SqlDbType.VarChar).Value = birthday;
            insert2.CommandType = CommandType.StoredProcedure;

            return insert2;
        }

        //Use this to update data to DatingProfile Table
        public SqlCommand getUpdateCommand(string username, string name, string age, string occupation, string address, string email, string phone, string height, string favorite, string dislike, string goal, string commitment, string description, string photo, string birthday)
        {
            SqlCommand insert2 = new SqlCommand("updateProfile");
            insert2.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            insert2.Parameters.Add("@name", SqlDbType.VarChar).Value = name;
            insert2.Parameters.Add("@age", SqlDbType.VarChar).Value = age;
            insert2.Parameters.Add("@occupation", SqlDbType.VarChar).Value = occupation;
            insert2.Parameters.Add("@address", SqlDbType.VarChar).Value = address;
            insert2.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            insert2.Parameters.Add("@phone", SqlDbType.VarChar).Value = phone;
            insert2.Parameters.Add("@height", SqlDbType.VarChar).Value = height;
            insert2.Parameters.Add("@favorite", SqlDbType.VarChar).Value = favorite;
            insert2.Parameters.Add("@dislike", SqlDbType.VarChar).Value = dislike;
            insert2.Parameters.Add("@goal", SqlDbType.VarChar).Value = goal;
            insert2.Parameters.Add("@commitment", SqlDbType.VarChar).Value = commitment;
            insert2.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
            insert2.Parameters.Add("@photo", SqlDbType.VarChar).Value = photo;
            insert2.Parameters.Add("@birthday", SqlDbType.VarChar).Value = birthday;
            insert2.CommandType = CommandType.StoredProcedure;

            return insert2;
        }

        //Use this to retrieve profile from DatingProfile table
        public SqlCommand getProfile(string username)
        {
            SqlCommand getProfile = new SqlCommand("getProfile");
            getProfile.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            getProfile.CommandType = CommandType.StoredProcedure;
            return getProfile;
        }

        //Use this to get profile pic url from DatingProfile Table
        public SqlCommand getPic(string username)
        {
            SqlCommand getPic = new SqlCommand("getPic");
            getPic.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            getPic.CommandType = CommandType.StoredProcedure;
            return getPic;
        }

        //Use this to delete a profile from the DatingProfile Table
        public SqlCommand deleteProfile(string username)
        {
            SqlCommand delete = new SqlCommand("deleteProfile");
            delete.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            delete.CommandType = CommandType.StoredProcedure;
            return delete;
        }

        //Use this to check if record exist in DatingProfile Table
        public SqlCommand executeScalar(string username)
        {
            SqlCommand uNamecheck = new SqlCommand("SELECT COUNT(*) FROM DatingProfile WHERE username = '" + username + "'");
            return uNamecheck;
        }

        //Use this to check if record exist in userLike Table
        public SqlCommand executeScalarLike(string username1, string username2)
        {
            SqlCommand uNamecheck = new SqlCommand("SELECT COUNT(*) FROM userLike WHERE UserThatLike = '" + username1 + "' AND UserThatWasLiked = '" + username2 + "'");
            return uNamecheck;
        }

        //Use this to insert data into Login table
        public SqlCommand insertLogin(string username, string password, string fname, string lname, string email)
        {
            SqlCommand updateCommand = new SqlCommand("insertLogin");
            updateCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            updateCommand.Parameters.Add("@password", SqlDbType.VarChar).Value = password;
            updateCommand.Parameters.Add("@fname", SqlDbType.VarChar).Value = fname;
            updateCommand.Parameters.Add("@lname", SqlDbType.VarChar).Value = lname;
            updateCommand.Parameters.Add("@email", SqlDbType.VarChar).Value = email;
            updateCommand.CommandType = CommandType.StoredProcedure;

            return updateCommand;
        }

        //Use this to check if record exist in Login table
        public SqlCommand executeScalarLogin(string username)
        {
            SqlCommand checkUname = new SqlCommand("SELECT COUNT(*) FROM Login WHERE username = '" + username + "'");
            return checkUname;
        }

        //Use this to retrieve first name
        public SqlCommand getfName(string username)
        {
            SqlCommand name = new SqlCommand("SELECT fname FROM Login WHERE username = '" + username + "'");
            return name;
        }

        //Use this to retrive your own info
        public SqlCommand getInfo(string username)
        {
            SqlCommand cityCommand = new SqlCommand("getPersonalInfo");
            cityCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            cityCommand.CommandType = CommandType.StoredProcedure;
            return cityCommand;
        }

        //Use this to retrieve all users with same city
        public SqlCommand getInfo(string username, string city)
        {
            SqlCommand cityCommand = new SqlCommand("getCity");
            cityCommand.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            cityCommand.Parameters.Add("@city", SqlDbType.VarChar).Value = city;
            cityCommand.CommandType = CommandType.StoredProcedure;
            return cityCommand;
        }

        //Use this to retrieve all users with same like
        public SqlCommand getLike(string username, string like)
        {
            SqlCommand command = new SqlCommand("getLike");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@like", SqlDbType.VarChar).Value = like;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to retrieve all users with the same dislike
        public SqlCommand getDislike(string username, string dislike)
        {
            SqlCommand command = new SqlCommand("getDislike");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@dislike", SqlDbType.VarChar).Value = dislike;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to retrieve all users with the same commitment type
        public SqlCommand getCommit(string username, string commit)
        {
            SqlCommand command = new SqlCommand("getCommitment");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@commit", SqlDbType.VarChar).Value = commit;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to update the userLike table
        public SqlCommand insertLike(string username1, string username2)
        {
            SqlCommand command = new SqlCommand("updateUserLike");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = username1;
            command.Parameters.Add("@username2", SqlDbType.VarChar).Value = username2;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to get user that was liked in userLike table
        public SqlCommand getUserWasLiked(string username1, string username2)
        {
            SqlCommand command = new SqlCommand("getUserThatWasLiked");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = username1;
            command.Parameters.Add("@username2", SqlDbType.VarChar).Value = username2;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to get user that like in userLike table
        public SqlCommand getUserThatLike(string username1, string username2)
        {
            SqlCommand command = new SqlCommand("getUserThatLike");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = username1;
            command.Parameters.Add("@username2", SqlDbType.VarChar).Value = username2;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to update the view status for User That Like, username must be the one in the UserThatLike column in userLike table
        public SqlCommand updateView(string username, string status, string username2)
        {
            SqlCommand command = new SqlCommand("insertViewStatus");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@username2", SqlDbType.VarChar).Value = username2;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }
        //Use thiis to update the view status when user have seen their matches
        public SqlCommand updateView(string username, string status)
        {
            SqlCommand command = new SqlCommand("notificationSeen");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to get how many match that user have
        public SqlCommand matchNotification(string username, string status)
        {
            SqlCommand command = new SqlCommand("matchNotification");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to get the list of matched people
        public SqlCommand getMatch(string username)
        {
            SqlCommand command = new SqlCommand("getMatch");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this for unmatch button in TindrMatch and to delete record in userLike table
        public SqlCommand unMatch (string username1, string username2)
        {
            SqlCommand command = new SqlCommand("unMatch");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = username1;
            command.Parameters.Add("@username2", SqlDbType.VarChar).Value = username2;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to check for record in Date table
        public SqlCommand checkDate(string username1, string username2)
        {
            SqlCommand command = new SqlCommand("checkDateRequest");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = username1;
            command.Parameters.Add("@username2", SqlDbType.VarChar).Value = username2;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to update Date Table when current user send date request
        public SqlCommand insertDate(string username1, string username2, string status)
        {
            SqlCommand command = new SqlCommand("insertDateRequest");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = username1;
            command.Parameters.Add("@username2", SqlDbType.VarChar).Value = username2;
            command.Parameters.Add("@viewStatus", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to retrieve info about the person who sent the date request
        public SqlCommand getDateRequest(string username)
        {
            SqlCommand command = new SqlCommand("getDateRequest");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = username;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to see how many date request the current user has
        public SqlCommand getDateRequest(string username, string status)
        {
            SqlCommand command = new SqlCommand("checkPersonalDateRequest");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = status;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to delete record from Date table
        public SqlCommand deleteDate(string username1, string username2)
        {
            SqlCommand command = new SqlCommand("deleteDate");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = username1;
            command.Parameters.Add("@username2", SqlDbType.VarChar).Value = username2;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to insert users to DatePlan table
        public SqlCommand insertDatePlan(string user1, string user2, string username1, string username2)
        {
            SqlCommand command = new SqlCommand("insertDatePlan");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = user1;
            command.Parameters.Add("@username2", SqlDbType.VarChar).Value = user2;
            command.Parameters.Add("@username1_Name", SqlDbType.VarChar).Value = username1;
            command.Parameters.Add("@username2_Name", SqlDbType.VarChar).Value = username2;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to check datePlan table for record
        public SqlCommand checkDatePlan(string user1)
        {
            SqlCommand command = new SqlCommand("checkDatePlanRecord");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = user1;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to retrive date plan
        public SqlCommand getDatePlan(string user1)
        {
            SqlCommand command = new SqlCommand("getDatePlan");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = user1;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to update the date plan table
        public SqlCommand updateDatePlan(string username, string time, string location, string description)
        {
            SqlCommand command = new SqlCommand("updateDatePlan");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.Parameters.Add("@time", SqlDbType.VarChar).Value = time;
            command.Parameters.Add("@location", SqlDbType.VarChar).Value = location;
            command.Parameters.Add("@description", SqlDbType.VarChar).Value = description;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        //Use this to delete date plan table record
        public SqlCommand deleteDatePlan(string username)
        {
            SqlCommand command = new SqlCommand("deleteDatePlan");
            command.Parameters.Add("@username", SqlDbType.VarChar).Value = username;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

        public SqlCommand checkMatch(string username1, string username2)
        {
            SqlCommand command = new SqlCommand("checkMatch");
            command.Parameters.Add("@username1", SqlDbType.VarChar).Value = username1;
            command.Parameters.Add("@username2", SqlDbType.VarChar).Value = username2;
            command.CommandType = CommandType.StoredProcedure;
            return command;
        }

    }
}
