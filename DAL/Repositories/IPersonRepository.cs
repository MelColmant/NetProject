using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IPersonRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        IEnumerable<T> GetChildren(TKey id);
        IEnumerable<T> GetParents(TKey id);
        IEnumerable<T> GetSiblings(TKey id);
        IEnumerable<T> GetAllFromTree(TKey id);
        IEnumerable<T> GetChildrenRel(TKey id1, TKey id2);
    }
}
