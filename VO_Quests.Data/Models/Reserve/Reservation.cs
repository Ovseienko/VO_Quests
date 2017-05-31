using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VO_Quests.Models
{
    public class Reservation
    {
        public int Id { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        [ForeignKey("Quest")]
        public int QuestId { get; set; }

        [ForeignKey("User")]
        [Required]
        public string UserId { get; set; }

        [Required]
        public DateTimeOffset SlotDate { get; set; }

        public Quest Quest { get; set; }
        public ApplicationUser User { get; set; }

    }
}
