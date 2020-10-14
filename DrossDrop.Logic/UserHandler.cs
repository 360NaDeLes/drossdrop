using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using MySqlX.XDevAPI.CRUD;
using Org.BouncyCastle.Crypto.Tls;
using System.Threading.Tasks;
using System.Linq;
using DrossDrop.Interface;
using DrossDrop.DTOs;
using DrossDrop.Factory;

namespace DrossDrop.Logic
{
    public class UserHandler
    {
        private UserQuerystringFormatter formatter = new UserQuerystringFormatter();
        IData db = DBFactory.GetInstance();

        public void CreateAsync(User user)
        {
            string querystring = formatter.InsertFormatter(user);

            db.ExecuteNonResponsiveQuery(querystring);
        }

        public IEnumerable<User> SelectAllAsync()
        {
            List<User> list = db.ExecuteSelectUserQuery("SELECT * FROM users");

            return list;
        }

        public User SelectByIdAsync(int id)
        {
            User user = new User();

            string querystring = formatter.SelectByIdFormatter(id);

            db.ExecuteSelectUserQuery(querystring);

            return user;
        }

        public void UpdateAsync(User user, int id)
        {
            string querystring = formatter.UpdateFormatter(user, id);

            db.ExecuteNonResponsiveQuery(querystring);
        }

        public void DeleteAsync(int id)
        {
            string querystring = formatter.DeleteFormatter(id);

            db.ExecuteNonResponsiveQuery(querystring);
        }
    }
}
