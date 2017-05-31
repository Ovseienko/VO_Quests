using System;
using System.Collections.Generic;
using System.Text;
using VO_Quests.Models;

namespace VO_Quests.Abstraction
{
    public interface IQuestRepository
    {
        IEnumerable<Quest> GetAllQuests();
        Quest GetById(int id);
    }
}
