using QaFullStack.EF;
using QaFullStack.Model;
namespace QaFullStack.Repositories
{
    public class BuyerRepository : RepositoryBase<Buyer>, IBuyerRepository
    {
        public BuyerRepository(EstateDBContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
   
}
