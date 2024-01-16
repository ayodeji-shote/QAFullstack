using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QaFullStack.Model;
using System.Linq.Expressions;
namespace QaFullStack.Repositories
{
    // This is the interface for the RepositoryBase class
    // It is used to define the methods that will be used in the RepositoryBase class
    // The RepositoryBase class is used to define the methods that will be used in the Repository classes
    // The Repository classes are used to define the methods that will be used in the Controllers
    // The Controllers are used to define the methods that will be used in the API
    // The API is used to define the methods that will be used in the Front End
    // The Front End is used to define the methods that will be used by the user
    public interface IRepositoryBase<T> where T : EntityBase
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T FindById(int id);
        T Create(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
