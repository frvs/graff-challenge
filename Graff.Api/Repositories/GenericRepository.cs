using Graff.Api.Entities.ValueObjects;
using Graff.Api.Repositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Graff.Api.Repositories
{
    public class GenericRepository<T> where T: Entity
    {
        private DataContext _context;
        private DbSet<T> entities;

        public GenericRepository(DataContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public string Create(T obj)
        {
            if (obj == null) throw new ArgumentNullException("entity");
            entities.Add(obj);
            var rowsAffected = _context.SaveChanges();

            return rowsAffected == 1 ? obj.Id : string.Empty;
        }
       
        public void Update(T obj)
        {
            entities.Update(obj);
            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = GetById(id);
            entities.Remove(entity);
            _context.SaveChanges();
        }

        public T GetById(string id)
        {
            return entities.Find(id);
        }

        public List<T> GetAll()
        {
            return entities.AsNoTracking().ToList();
        }
    }
}
