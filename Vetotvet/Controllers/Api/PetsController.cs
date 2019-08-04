using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vetotvet.Data;
using Vetotvet.Models;

namespace Vetotvet.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly VetotvetDbContext _context;

        public PetsController(VetotvetDbContext context)
        {
            _context = context;
        }

        // GET: api/Pets/GetPets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return await _context.Pets.Include(x=>x.Breed).ToListAsync();
        }

        // GET: api/Pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        //получаем список животных по указанному id владельца
        // GET: api/Pets/GetPetsByOwner/1
        [HttpGet("{ownerid}")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPetsByOwner(int ownerid)
        {
            var pet = await _context.Pets.Include(x => x.Breed).ThenInclude(x=>x.KindOfAnimal).Where(x=>x.OwnerId == ownerid).ToListAsync();

            if (pet == null)
            {
                return null;
            }

            return pet;
        }

        // PUT: api/Pets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PetExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Pets
        [HttpPost]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPet", new { id = pet.Id }, pet);
        }

        // DELETE: api/Pets/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pet>> DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        private bool PetExists(int id)
        {
            return _context.Pets.Any(e => e.Id == id);
        }
    }
}
