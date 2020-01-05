using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TobaccoStore.Models;

namespace TobaccoStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TobaccoController : ControllerBase
    {
        private readonly TobaccoContext _context;

        public TobaccoController(TobaccoContext context)
        {
            _context = context;
        }

        // GET: api/Tobacco
        [HttpGet]
        [EnableQuery()]
        public async Task<ActionResult<List<TobaccoModel>>> GetTobacco()
        {
            return await _context.Tobacco.ToListAsync();
        }

        // GET: api/Tobacco/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TobaccoModel>> GetTobaccoModel(int id)
        {
            var tobaccoModel = await _context.Tobacco.FindAsync(id);

            if (tobaccoModel == null)
            {
                return NotFound();
            }

            return tobaccoModel;
        }

        // PUT: api/Tobacco/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTobaccoModel(int id, TobaccoModel tobaccoModel)
        {
            if (id != tobaccoModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(tobaccoModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TobaccoModelExists(id))
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

        // POST: api/Tobacco
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<TobaccoModel>> PostTobaccoModel(TobaccoModel tobaccoModel)
        {
            _context.Tobacco.Add(tobaccoModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTobaccoModel", new { id = tobaccoModel.Id }, tobaccoModel);
        }

        // DELETE: api/Tobacco/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TobaccoModel>> DeleteTobaccoModel(int id)
        {
            var tobaccoModel = await _context.Tobacco.FindAsync(id);
            if (tobaccoModel == null)
            {
                return NotFound();
            }

            _context.Tobacco.Remove(tobaccoModel);
            await _context.SaveChangesAsync();

            return tobaccoModel;
        }

        private bool TobaccoModelExists(int id)
        {
            return _context.Tobacco.Any(e => e.Id == id);
        }
    }
}
