using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DatingAppLibrary
{
    public class updateProfileDB
    {
        public SqlCommand insertProfile(string uname, string name, string age, string occupation, string address, string email, string phone, string height, string like, string dislike, string goal, string commitment, string description, string photo, string birthday)
        {
            SqlCommand insertCommand = new SqlCommand("INSERT INTO datingProfile (username, name, age, occupation, address, email, phone, height, like, dislike, goal, commitment, description, photo, birthday" +
                "VALUES (@username, @name, @age, @occupation, @address, @email, @phone, @height, @like, @dislike, @goal, @commitment, @description, @photo, @birthday");
            insertCommand.Parameters.AddWithValue("username", uname);
            insertCommand.Parameters.AddWithValue("name", name);
            insertCommand.Parameters.AddWithValue("age", age);
            insertCommand.Parameters.AddWithValue("occupation", occupation);
            insertCommand.Parameters.AddWithValue("address", address);
            insertCommand.Parameters.AddWithValue("email", email);
            insertCommand.Parameters.AddWithValue("phone", phone);
            insertCommand.Parameters.AddWithValue("height", height);
            insertCommand.Parameters.AddWithValue("like", like);
            insertCommand.Parameters.AddWithValue("dislike", dislike);
            insertCommand.Parameters.AddWithValue("goal", goal);
            insertCommand.Parameters.AddWithValue("commitment", commitment);
            insertCommand.Parameters.AddWithValue("description", description);
            insertCommand.Parameters.AddWithValue("photo", photo);
            insertCommand.Parameters.AddWithValue("birthday", birthday);

            return insertCommand;

        }
    }
}
