using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DrossDrop.Data.Formatters;
using DrossDrop.DTOs;
using DrossDrop.Interface;

namespace DrossDrop.Data.DALs
{
    public class UserData : IUserData
    {
        private UserQuerystringFormatter formatter = new UserQuerystringFormatter();
        private DBConnection db = new DBConnection();

        public void CreateUser(User user)
        {
            string querystring = formatter.InsertFormatter(user);

            db.ExecuteNonResponsiveQuery(querystring);
        }

        public IEnumerable<User> SelectAllUsers()
        {
            List<User> list = db.ExecuteSelectUserQuery("SELECT * FROM users").ToList();

            return list;
        }

        public User SelectUserById(int id)
        {
            string querystring = formatter.SelectByIdFormatter(id);

            User user = db.ExecuteSelectUserQuery(querystring).FirstOrDefault();

            return user;
        }

        public void UpdateUser(User user, int id)
        {
            string querystring = formatter.UpdateFormatter(user, id);

            db.ExecuteNonResponsiveQuery(querystring);
        }

        public void DeleteUser(int id)
        {
            string querystring = formatter.DeleteFormatter(id);

            db.ExecuteNonResponsiveQuery(querystring);
        }
    }
}
