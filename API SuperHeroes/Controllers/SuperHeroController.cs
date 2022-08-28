using API_SuperHeroes.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_SuperHeroes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        //instanciação da lista do model superhero
        private static List<SuperHero> heroes = new List<SuperHero>
            {
                new SuperHero {Id=1, Name="Spider Man", FirstName="Peter", LastName="Parker", Place="New York"},
                new SuperHero {Id=2, Name="IronMan", FirstName="Tony", LastName="Stark", Place="New York"}
            };


        //constructor
        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context = context;
        }

        //método 1 get, retorna todos os heroes
        //ActionResult<List<SuperHero>> -- retorna o model dentro da UI uma lista de superhero
        [HttpGet] // método 2, retorna apenas 1 pelo id
        public async Task<ActionResult<List<SuperHero>>> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
            {
                BadRequest("Hero Not Found");
            }
            return Ok(hero);
        }

        //edit hero
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero request)
            {
            var hero = heroes.Find(h => h.Id == request.Id);
            if (hero == null)
            {
                BadRequest("Hero Not Found");
            }
            hero.Name = request.Name;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;
            hero.Place = request.Place;
            
            return Ok(hero);
            }
    


        //método 3 post
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero([FromBody]SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = heroes.Find(h => h.Id == id);
            if (hero == null)
            {
                BadRequest("Hero Not Found");
            }
            heroes.Remove(hero);
            return Ok(heroes);
        }

    }





}

