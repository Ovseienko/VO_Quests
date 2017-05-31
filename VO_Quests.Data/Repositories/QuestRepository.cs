using System.Collections.Generic;
using System.Linq;
using VO_Quests.Abstraction;
using VO_Quests.Models;

namespace VO_Quests.Repositories
{
    public class QuestRepository : BaseRepository, IQuestRepository
    {
        public QuestRepository(IUnitOfWork unitOfWork, IDatabaseContext dbContext)
            : base(unitOfWork, dbContext)
        { }

        public IEnumerable<Quest> GetAllQuests()
        {
            var quests = _dbContext.Quests.ToList();

            return quests;
        }

        public Quest GetById(int id)
        {
            var quest = _dbContext.Quests.FirstOrDefault(q => q.Id == id);

            return quest;
        }
    }
}
