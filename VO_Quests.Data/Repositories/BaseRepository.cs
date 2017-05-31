using VO_Quests.Abstraction;

namespace VO_Quests.Repositories
{
    public class BaseRepository
    {
        protected IDatabaseContext _dbContext;
        protected IUnitOfWork _unitOfWork;
        
        public BaseRepository(IUnitOfWork unitOfWork, IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
            _unitOfWork = unitOfWork;
        }

    }
}
