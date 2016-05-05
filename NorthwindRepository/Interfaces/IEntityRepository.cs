using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindRepository.Interfaces
{
    interface IEntityRepository<T, P> where T:class where P:struct
    {
        IQueryable<T> GetAllData(); // Query Value

        T Search(P id); //Untuk melakukan search

        void Insert(T entity); //Untuk melakukan insert

        void Delete(P id);

        void Update(T entity);
    }
}
