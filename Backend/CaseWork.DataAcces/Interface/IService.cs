using System.Linq.Expressions;

namespace CaseWork.DataAcces.Interface
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        IEnumerable<T> Where(Expression<Func<T, bool>> where);
    }
}
