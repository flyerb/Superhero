using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superheros.Data;
using Superheros.Data.Migrations;
using Superheros.Models;

namespace Superheros.Controllers
{
    public class SuperheroesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuperheroesController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: Superheroes
        public ActionResult Index()
        {
           var super = _context.Superheroes.ToList();
            return View(super);
        }

        // GET: Superheroes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Superheroes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Superheroes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
                if (ModelState.IsValid)
                {
                    _context.Superheroes.Add(superhero);
                    _context.SaveChanges();
                }
                return RedirectToAction("Index");
            
        }

        // GET: Superheroes/Edit/5
        public ActionResult Edit(int id)
        {
            var editedSuperhero = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(editedSuperhero);
            
        }

        // POST: Superheroes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Superhero editedSuperhero)
        {
            {
                if (ModelState.IsValid)
                {
                    _context.Entry(editedSuperhero).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _context.SaveChanges();
                }
                return RedirectToAction("index");

            }

        }

        // GET: Superheroes/Delete/5
        public ActionResult Delete(int id)
        {
            var editedSuperhero = _context.Superheroes.Where(s => s.Id == id).FirstOrDefault();
            return View(editedSuperhero);
        }

        // POST: Superheroes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Superhero editedSuperhero)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Superheroes.Remove;
                    _context.SaveChanges();
                }
                return RedirectToAction("index");

            }
            catch
            {
                return View();
            }
        }
    }
}