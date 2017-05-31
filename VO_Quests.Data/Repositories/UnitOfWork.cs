using VO_Quests.Abstraction;

namespace VO_Quests.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDatabaseContext _dbContext;
        private IQuestRepository _quests;
        private IReservationRepository _reserveations;
        public UnitOfWork(IDatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal IDatabaseContext DbContext
        {
            get
            {
                return _dbContext;
            }
        }

        public IQuestRepository Quests
        {
            get
            {
                if (_quests == null)
                    _quests = new QuestRepository(this, DbContext);
                return _quests;
            }
        }

        public IReservationRepository Reservations
        {
            get
            {
                if (_reserveations == null)
                    _reserveations = new ReservationRepository(this, DbContext);
                return _reserveations;
            }
        }
    }
}
