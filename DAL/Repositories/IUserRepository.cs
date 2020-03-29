using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository<TKey, T> where T : class
    {
        void AddUser(T entity);
        void RemoveUser(TKey id);

        TKey CheckUser(string username, string password);

    }
}
