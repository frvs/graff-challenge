using Graff.Api.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Graff.Api.Repositories
{
    public interface IGenericRepository<T> where T: Entity
    {
        string Create(T obj);

        void Update(T obj);

        void Delete(string id);
    }
}
