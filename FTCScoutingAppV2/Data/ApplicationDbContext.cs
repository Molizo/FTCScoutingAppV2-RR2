﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FTCScoutingAppV2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<FTCScoutingAppV2.Models.Event> Event { get; set; }
        public DbSet<FTCScoutingAppV2.Models.Match> Match { get; set; }
        public DbSet<FTCScoutingAppV2.Models.Team> Team { get; set; }
    }
}