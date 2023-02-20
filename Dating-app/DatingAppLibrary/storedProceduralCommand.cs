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
    }
}
