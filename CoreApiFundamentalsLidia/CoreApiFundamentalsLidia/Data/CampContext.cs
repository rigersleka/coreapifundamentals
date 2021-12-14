using CoreApiFundamentalsLidia.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApiFundamentalsLidia.Data
{
    public class CampContext : DbContext
    {
        private readonly IConfiguration _config;
        public CampContext(DbContextOptions options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public DbSet<Camp> Camps { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_config.GetConnectionString("CodeCamp"));
        }

        protected override void OnModelCreating(ModelBuilder bldr)
        {
            bldr.Entity<Camp>()
          .HasData(new
          {
              Id = 1,
              Moniker = "ATL2018",
              Name = "Atlanta Code Camp",
              EventDate = new DateTime(2018, 10, 18),
              //LocationId = 1,
              Length = 1
          });


        }

    }
}
