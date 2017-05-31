using System;
using System.Collections.Generic;
using System.Text;

namespace VO_Quests.Models
{
    public class Quest
    {
        public int Id { get; set; }
        public string QuestName { get; set; }
        public string PosterPath { get; set; }
        public virtual ICollection<Reservation> Reserves { get; set; }

    }
}
