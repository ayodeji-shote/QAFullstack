using QaFullStack.EF;
using QaFullStack.Model;
namespace QaFullStack.Repositories
{
    public class PropertyRepository : RepositoryBase<Property>, IPropertyRepository
    {
        public PropertyRepository(EstateDBContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
   
}
