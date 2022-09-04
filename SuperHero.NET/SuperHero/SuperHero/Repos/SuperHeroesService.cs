using Microsoft.EntityFrameworkCore;
using SuperHero.Data;
using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Repos
{
    public class SuperHeroesService : ISuperHeroes
    {
        private readonly SuperHeroDbContext _Context;

        public SuperHeroesService(SuperHeroDbContext context)
        {
            _Context = context;
        }

        public async Task<IEnumerable<Superheroo>> GetAll()
        {
            return await _Context.SuperHeroes.ToListAsync();
        }

        public async Task<Superheroo> GetById(int id)
        {
            var hero = await _Context.SuperHeroes.FindAsync(id);
            return hero;
        }

        public async Task<Superheroo> Add(Superheroo hero)
        {
            await _Context.SuperHeroes.AddAsync(hero);
            _Context.SaveChanges();

            return hero;
        }

        public Superheroo Delete(Superheroo hero)
        {
            _Context.Remove(hero);
            _Context.SaveChanges();

            return hero;
        }

        public Superheroo Update(Superheroo hero)
        {
            _Context.SuperHeroes.Update(hero);

            _Context.SaveChanges();

            return hero;
        }
    }
}