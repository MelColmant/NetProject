using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUserRepository<TKey, T> where T : class
    {
        IEnumerable<T> Get();
        T Get(TKey id);
        bool AddUser(T entity);
        void Update(TKey id, T entity);
        void RemoveUser(TKey id);
        T CheckUser(string username, string password);
    }
}
