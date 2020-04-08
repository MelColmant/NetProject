using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IParentChildRepository<TKey, T> : IRepository<TKey, T> where T: class
    {
        IEnumerable<T> GetParentChildFromTree(TKey id);
    }
}
