using Fantasy.Backend.Data;
using Fantasy.Shared.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fantasy.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CountriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var country = await _context.Countries.AsNoTracking().ToListAsync();

            return Ok(country);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null) 
            { 
                return NotFound();
            }
            return Ok(country);
        }



        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country)
        {
            _context.Add(country);
            await _context.SaveChangesAsync();
            return Ok(country);
        }



        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country)
        {
            var currentCountry = await _context.Countries.FindAsync(country.Id);
            if (currentCountry == null)
            {
                return NotFound();
            }

            currentCountry.Name = country.Name;
            _context.Update(currentCountry);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var country = await _context.Countries.FindAsync(id);
            if (country == null)
            {
                return NotFound();
            }
          
            _context.Remove(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}