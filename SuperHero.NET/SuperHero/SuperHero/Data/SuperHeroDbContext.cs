using Microsoft.EntityFrameworkCore;
using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Data
{
    public class SuperHeroDbContext : DbContext
    {
        public SuperHeroDbContext(DbContextOptions<SuperHeroDbContext> option) : base(option)
        {
        }

        public DbSet<Superheroo> SuperHeroes { get; set; }
    }
}