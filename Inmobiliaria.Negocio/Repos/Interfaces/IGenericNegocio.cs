using System.Linq.Expressions;

namespace Inmobiliaria.Negocio.Repos.Interfaces
{
    public interface IGenericNegocio<T> where T : class
    {
        bool Save();
        bool Insert(T entity);
        bool Update(T entity);
        bool Delete(T entity);

        T GetById(int id);
        List<T> GetAll();
        T GetByCondition(Expression<Func<T, bool>> condition);
        List<T> GetAllByCondition(Expression<Func<T, bool>> condition);
    }
}
