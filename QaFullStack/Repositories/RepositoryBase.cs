using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using QaFullStack.Model;
using QaFullStack.EF;

namespace QaFullStack.Repositories
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : EntityBase
    {
        // This is the RepositoryBase class
        // It is used to define the methods that will be used in the Repository classes
        // The Repository classes are used to define the methods that will be used in the Controllers
        // The Controllers are used to define the methods that will be used in the API
        // The API is used to define the methods that will be used in the Front End
        // The Front End is used to define the methods that will be used by the user
        // The methods in this class are not implemented

        // This class inherits the IRepositoryBase interface
        // The IRepositoryBase interface is used to define the methods that will be used in the RepositoryBase class
        // the EstateDBContext class is used to define the methods that will be used in the RepositoryBase class
        protected EstateDBContext _dBContext { get; set; }

        // This is the constructor for the RepositoryBase class
        // It is used to create an instance of the EstateDBContext class
        // The EstateDBContext class is used to define the methods that will be used in the RepositoryBase class
        public RepositoryBase(EstateDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IQueryable<T> FindAll() => _dBContext.Set<T>().AsNoTracking();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            // This method is used to find an entity by its condition
            var result = _dBContext.Set<T>().Where(expression).AsNoTracking();
            return result;
        }

        public T FindById(int id)
        {
            // This method is used to find an entity by its id

            return _dBContext.Set<T>().Find(id);
        }
        public  T Create(T entity)
        {
            _dBContext.Set<T>().Add(entity);
            _dBContext.SaveChanges();
            return entity;
        }

        void IRepositoryBase<T>.Delete(T entity)
        {
            _dBContext.ChangeTracker.Clear();
            _dBContext.Set<T>().Remove(entity);
            _dBContext.SaveChanges();
        }



        public T Update(T entity)
        {
            _dBContext.Set<T>().Update(entity);
            _dBContext.SaveChanges();
            //_repositoryContext.Dispose();
            return entity;
        }

        public void SaveChanges()
        {
            _dBContext.SaveChanges();
        }
    }
}
