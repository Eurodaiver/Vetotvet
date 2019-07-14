using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vetotvet.Data;
using Vetotvet.Models;

namespace Vetotvet.Controllers
{
    public class KindOfAnimalsController : Controller
    {
        private readonly VetotvetDbContext _context;

        public KindOfAnimalsController(VetotvetDbContext context)
        {
            _context = context;
        }

        // GET: KindOfAnimals
        public async Task<IActionResult> Index()
        {
            return View(await _context.KindOfAnimals.ToListAsync());
        }

        // GET: KindOfAnimals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfAnimal = await _context.KindOfAnimals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kindOfAnimal == null)
            {
                return NotFound();
            }

            return View(kindOfAnimal);
        }

        // GET: KindOfAnimals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KindOfAnimals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Kind")] KindOfAnimal kindOfAnimal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kindOfAnimal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kindOfAnimal);
        }

        // GET: KindOfAnimals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfAnimal = await _context.KindOfAnimals.FindAsync(id);
            if (kindOfAnimal == null)
            {
                return NotFound();
            }
            return View(kindOfAnimal);
        }

        // POST: KindOfAnimals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Kind")] KindOfAnimal kindOfAnimal)
        {
            if (id != kindOfAnimal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kindOfAnimal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KindOfAnimalExists(kindOfAnimal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(kindOfAnimal);
        }

        // GET: KindOfAnimals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kindOfAnimal = await _context.KindOfAnimals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kindOfAnimal == null)
            {
                return NotFound();
            }

            return View(kindOfAnimal);
        }

        // POST: KindOfAnimals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kindOfAnimal = await _context.KindOfAnimals.FindAsync(id);
            _context.KindOfAnimals.Remove(kindOfAnimal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KindOfAnimalExists(int id)
        {
            return _context.KindOfAnimals.Any(e => e.Id == id);
        }
    }
}
