using QaFullStack.EF;
using QaFullStack.Model;
namespace QaFullStack.Repositories
{
    public class BookingRepository : RepositoryBase<Booking>, IBookingRepository
    {
        public BookingRepository(EstateDBContext repositoryContext)
            : base(repositoryContext)
        {
        }
    }
   
}
