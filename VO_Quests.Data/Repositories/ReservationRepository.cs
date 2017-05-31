
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using VO_Quests.Abstraction;
using VO_Quests.Data;
using VO_Quests.Models;
using VO_Quests.Repositories;

namespace VO_Quests.Repositories
{
    public class ReservationRepository : BaseRepository, IReservationRepository
    {
        public ReservationRepository(IUnitOfWork unitOfWork, IDatabaseContext dbContext)
            : base(unitOfWork, dbContext)
        {

        }

        public bool AddNewReservation(Reservation newReservation)
        {
            var isSlotAllowed = IsSlotAllowed(newReservation.QuestId, newReservation.SlotDate);

            if (isSlotAllowed)
            {
                _dbContext.Reservations.Add(newReservation);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<QuestSlotAvailability> GetQuestSlots(int id)
        {
            var currentTime = DateTimeOffset.Now;

            var questSlots = new List<QuestSlotAvailability>();
            var reservatedSlots = GetQuestReservatedSlots(id, currentTime);


            var firstScheduleDayDate = new DateTimeOffset(currentTime.Year, currentTime.Month, currentTime.Day, Constants.QuestsStartHour, 0, 0, 0, currentTime.Offset);
            var lastScheduleDayDate = firstScheduleDayDate.AddDays(Constants.QuestsScheduleDays - 1).AddHours(Constants.QuestsEndHour - Constants.QuestsStartHour);


            var currentScheduleDate = firstScheduleDayDate;

            for (int scheduleDayNumber = 0; scheduleDayNumber < Constants.QuestsScheduleDays; scheduleDayNumber++)
            {
                for (int nextScheduleSlotMinutesOffseet = 0; nextScheduleSlotMinutesOffseet <= (Constants.QuestsEndHour - Constants.QuestsStartHour) * 60 - Constants.IntervalBetweenSlots; nextScheduleSlotMinutesOffseet += Constants.IntervalBetweenSlots)
                {
                    var slotDate = firstScheduleDayDate.AddDays(scheduleDayNumber).AddMinutes(nextScheduleSlotMinutesOffseet);

                    var slotAvailability = new QuestSlotAvailability()
                    {
                        SlotDate = slotDate,
                        IsAllowed = true
                    };

                    if (reservatedSlots.Contains(slotDate) || slotDate < currentTime)
                    {
                        slotAvailability.IsAllowed = false;
                    }

                    questSlots.Add(slotAvailability);

                }

            }

            return questSlots;
        }

        private IEnumerable<DateTimeOffset> GetQuestReservatedSlots(int questId, DateTimeOffset fromDate)
        {
            var reservatedDates = _dbContext
                .Reservations
                .Where(r => r.QuestId == questId && r.SlotDate >= fromDate)
                .Select(r => r.SlotDate)
                .ToList();

            return reservatedDates;
        }


        private bool IsSlotAllowed(int questId, DateTimeOffset slotDate)
        {
            var isSlotAllowed = GetQuestSlots(questId).Where(f => f.SlotDate == slotDate && f.IsAllowed).Count() == 1;

            return isSlotAllowed;
        }
    }
}
