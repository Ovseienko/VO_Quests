using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VO_Quests.Models;
using VO_Quests.Abstraction;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace VO_Quests.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDatabaseContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
          
        }

        public DbSet<Quest> Quests { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            


        }
    }

}
