using Graff.Api.Entities.ValueObjects;
using Graff.Api.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Graff.Api.Repositories
{
    public class GenericRepository<T> where T: Entity
    {
        private DataContext _context;

        public GenericRepository(DataContext context)
        {
            _context = context;
        }

        public string Create(T obj)
        {
            _context.Set<T>().Add(obj);
            var rowsAffected = _context.SaveChanges();

            return rowsAffected == 1 ? obj.Id : string.Empty;
        }
       
        public void Update(T obj)
        {
            _context.Set<T>().Update(obj);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = GetById(id);
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().AsNoTracking().ToList();
        }
    }
}
