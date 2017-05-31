using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VO_Quests.Models;

namespace VO_Quests.Abstraction
{
    public interface IDatabaseContext
    {
        DbSet<Quest> Quests { get; set; }
        DbSet<Reservation> Reservations { get; set; }
        DbSet<ApplicationUser> Users { get; set; }
        int SaveChanges();
    }
}
