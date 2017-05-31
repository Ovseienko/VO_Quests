using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VO_Quests.UI.ViewModels.Reserve
{
    public class NewReservationVM
    {
        public DateTimeOffset SlotDate { get; set; }
        public int QuestId { get; set; }
    }
}
