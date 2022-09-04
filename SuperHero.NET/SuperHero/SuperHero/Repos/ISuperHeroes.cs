using SuperHero.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHero.Repos
{
    public interface ISuperHeroes
    {
        Task<IEnumerable<Superheroo>> GetAll();

        Task<Superheroo> GetById(int id);

        Task<Superheroo> Add(Superheroo hero);

        Superheroo Update(Superheroo hero);

        Superheroo Delete(Superheroo hero);
    }
}