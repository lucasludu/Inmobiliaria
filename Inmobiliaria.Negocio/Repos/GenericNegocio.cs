using Inmobiliaria.Negocio.Connection;
using Inmobiliaria.Negocio.Repos.Interfaces;
using System.Linq.Expressions;
using System.Security.AccessControl;

namespace Inmobiliaria.Negocio.Repos
{
    public class GenericNegocio<T> : BLLContext, IGenericNegocio<T> where T : class
    {

        public GenericNegocio()
        {

        }

        public bool Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return Save();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public List<T> GetAllByCondition(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition).ToList();
        }

        public T GetByCondition(Expression<Func<T, bool>> condition)
        {
            return _context.Set<T>().Where(condition).FirstOrDefault()!;
        }

        public T GetById(int id)
        {
            var model = _context.Set<T>().Find(id)!;
            if (model == null)
                throw new Exception("No se encuentra en la BD");
            return model;
        }

        public bool Insert(T entity)
        {
            _context.Set<T>().Add(entity);
            return Save();
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public bool Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return Save();
        }
    }
}
