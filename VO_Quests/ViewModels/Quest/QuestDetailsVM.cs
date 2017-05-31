using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VO_Quests.Models;

namespace VO_Quests.UI.ViewModels
{
    public class QuestDetailsVM
    {
        public string QuestName { get; set; }
        public string PosterPath { get; set; }
        public IEnumerable<QuestSlotAvailability> Slots { get; set; }
        public int QuestId { get; internal set; }
    }
}
