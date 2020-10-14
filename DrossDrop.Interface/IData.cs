using DrossDrop.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrossDrop.Interface
{
    public interface IData
    {
        public void ExecuteNonResponsiveQuery(string querystring);

        public IEnumerable<User> ExecuteSelectUserQuery(string querysstring);
    }
}
