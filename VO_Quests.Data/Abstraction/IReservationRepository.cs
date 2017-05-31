using System;
using System.Collections.Generic;
using System.Text;
using VO_Quests.Models;

namespace VO_Quests.Abstraction
{
    public interface IReservationRepository
    {
        bool AddNewReservation(Reservation newReserve);
        IEnumerable<QuestSlotAvailability> GetQuestSlots(int id);
    }
}
