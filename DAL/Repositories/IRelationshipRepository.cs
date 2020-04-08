using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IRelationshipRepository<TKey, T> : IRepository<TKey, T> where T : class
    {
        IEnumerable<T> GetRelationships(TKey id);

        IEnumerable<T> GetRelationshipsFromTree(TKey id);

    }
}
