using System;
using System.Collections.Generic;
using System.Text;

namespace VO_Quests.Abstraction
{
    public interface IUnitOfWork
    {
        IReservationRepository Reservations { get; }
        IQuestRepository Quests { get; }
    }
}
