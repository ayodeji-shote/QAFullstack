using QaFullStack.EF;
using QaFullStack.Model;
namespace QaFullStack.Repositories
{
    public class SellerRepository : RepositoryBase<Seller>, ISellerRepository
    {
        public SellerRepository(EstateDBContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
   
}
