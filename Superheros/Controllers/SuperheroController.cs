using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superheros.Data;
using Superheros.Models;

namespace Superheros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperheroController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }


        public IActionResult Delete(int id)
        {
            var editedSuperhero = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(editedSuperhero);
        }

        [HttpPost]
        public IActionResult Delete(Superhero editedSuperhero)
        {
            if (ModelState.IsValid)
            {
                _context.Superheroes.Remove(editedSuperhero);
                _context.SaveChanges();
            }
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            var editedSuperhero = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(editedSuperhero);
        }

        [HttpPost]
       public IActionResult Edit(Superhero editedSuperhero)
        {
            if (ModelState.IsValid)
            {
                _context.Superheroes.Update(editedSuperhero);
                _context.SaveChanges();
            }
            return RedirectToAction("index");

        }


        // GET: api/Superhero
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Superhero/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Superhero
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Superhero/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
