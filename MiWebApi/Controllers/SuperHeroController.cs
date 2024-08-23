//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Storage.Internal;
//using MiWebApi.Data;
//using MiWebApi.Entities;

//namespace MiWebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SuperHeroController : ControllerBase
//    {

//        private readonly DataContext _dataContext;

//        public SuperHeroController(DataContext context)
//        {
//            _dataContext = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
//        {
//            //var heroes = new List<SuperHero>
//            //{
//            //    new SuperHero
//            //    {
//            //        Id = 1,
//            //        Name = "Spiderman",
//            //        FirstName = "Peter",
//            //        LastName = "Parker",
//            //        Place = "New York"
//            //    }
//            //};

//            var heroes = await _dataContext.SuperHeroes.ToListAsync();

//            return Ok(heroes);
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
//        {
//            var hero = await _dataContext.SuperHeroes.FindAsync(id);
//            if (hero == null)
//            {
//                return NotFound("Hero not found");
//            }
//            return Ok(hero);
//        }


//        [HttpPost]

//        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
//        {
//            _dataContext.SuperHeroes.Add(hero);
//            await _dataContext.SaveChangesAsync();
//            return Ok(await GetAllHeroes());
//        }

//        [HttpPut]
//        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero updatedHero)
//        {
//            var dbHero = await _dataContext.SuperHeroes.FindAsync(updatedHero.Id);
//            if (dbHero is null)
//            {
//                return NotFound("Hero not found");
//            }
//            dbHero.Name = updatedHero.Name;
//            dbHero.FirstName = updatedHero.FirstName;
//            dbHero.LastName = updatedHero.LastName;
//            dbHero.Place = updatedHero.Place;

//            await _dataContext.SaveChangesAsync();

//            return Ok(await _dataContext.SuperHeroes.ToListAsync());
//        }

//        [HttpDelete]

//        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
//        {
//            var dbHero = await _dataContext.SuperHeroes.FindAsync(id);
//            if (dbHero is null)
//            {
//                return NotFound("Hero not found");
//            }

//            _dataContext.SuperHeroes.Remove(dbHero);
//            await _dataContext.SaveChangesAsync();

//            //return Ok(await _dataContext.SuperHeroes.ToListAsync());
//            return Ok("Well done");

//        }
//    }
//}
