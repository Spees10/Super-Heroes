using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHero.Data;
using SuperHero.Models;
using SuperHero.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// عرض الكواترو
//فاير هاوس - عشاق الجبنة - كرانشي تشيكن داينمايت - كرانشي جمبري رانش
// فولكانو كبير - ثاوزاند ايلاند كبير - بافلو و تنيسي صغير - اجنحة دجاج 6 قطع - حلقات البصل
// تشيييييزي جارلك بيتزا - تشيز فرايز هالبينو
// 01026922003 - 01007705778 - 15018

namespace SuperHero.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly SuperHeroDbContext _Context;

        public SuperHeroController(SuperHeroDbContext context)
        {
            _Context = context;
        }

        //private readonly SuperHeroesService superHeroesService;

        //#############################################################

        [HttpGet]
        public async Task<ActionResult<List<Superheroo>>> GetAll()
        {
            //var heroes = await superHeroesService.GetAll();
            var heroes = await _Context.SuperHeroes.ToListAsync();

            return Ok(heroes);
        }

        //#############################################################

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hero = await _Context.SuperHeroes.FindAsync(id);
            //var hero = await _Context.SuperHeroes.SingleOrDefault(h => h.Id == id);
            //var hero = await superHeroesService.GetById(id);
            return Ok(hero);
        }

        //#############################################################

        [HttpPost]
        public async Task<IActionResult> Add(Superheroo hero)
        {
            await _Context.SuperHeroes.AddAsync(hero);
            _Context.SaveChanges();

            //var Hero = await superHeroesService.Add(hero);
            return Ok(hero);
        }

        //#############################################################

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var Hero = await _Context.SuperHeroes.FindAsync(id);
            if (Hero == null)
                return BadRequest("Hero not found!");

            _Context.Remove(Hero);
            _Context.SaveChanges();

            return Ok(Hero);
        }

        //#############################################################

        [HttpPut]
        public async Task<IActionResult> Update(Superheroo hero)
        {
            var newHero = await _Context.SuperHeroes.FindAsync(hero.Id);
            if (newHero == null)
                return BadRequest("Hero not found!");

            newHero.NickName = hero.NickName;
            newHero.FirstName = hero.FirstName;
            newHero.LastName = hero.LastName;
            newHero.Country = hero.Country;

            //superHeroesService.Update(newHero);

            //_Context.SuperHeroes.Update(newHero);

            _Context.SaveChanges();

            return Ok(hero);
        }
    }
}