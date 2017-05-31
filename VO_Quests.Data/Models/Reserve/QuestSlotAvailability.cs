using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VO_Quests.Models
{
    public struct QuestSlotAvailability
    {
        public DateTimeOffset SlotDate { get; set; }
        public bool IsAllowed { get; set; }
    }
}
