using AutoMapper;
using ErrorCenter.Application.Interfaces;
using ErrorCenter.Data.Context;
using ErrorCenter.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorCenter.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorOccurrencesController : ControllerBase
    {
        private readonly ErrorCenterContext _context;
        private readonly IErrorOccurrenceService _service;
        private readonly IMapper _mapper;


        public ErrorOccurrencesController(IMapper mapper, IErrorOccurrenceService service, ErrorCenterContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }

        // GET: api/ErrorOccurrences
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ErrorOccurrence>>> GetErrorOccurrences()
        {
            return await _context.ErrorOccurrences.ToListAsync();
        }

        // GET: api/ErrorOccurrences/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ErrorOccurrence>> GetErrorOccurrence(int id)
        {
            var errorOccurrence = await _context.ErrorOccurrences.FindAsync(id);

            if (errorOccurrence == null)
            {
                return NotFound();
            }

            return errorOccurrence;
        }

        // PUT: api/ErrorOccurrences/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutErrorOccurrence(int id, ErrorOccurrence errorOccurrence)
        {
            if (id != errorOccurrence.ErrorOccurrenceId)
            {
                return BadRequest();
            }

            _context.Entry(errorOccurrence).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorOccurrenceExists(id))
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

        // POST: api/ErrorOccurrences
        [HttpPost]
        public async Task<ActionResult<ErrorOccurrence>> PostErrorOccurrence(ErrorOccurrence errorOccurrence)
        {
            _context.ErrorOccurrences.Add(errorOccurrence);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetErrorOccurrence", new { id = errorOccurrence.ErrorOccurrenceId }, errorOccurrence);
        }

        // DELETE: api/ErrorOccurrences/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ErrorOccurrence>> DeleteErrorOccurrence(int id)
        {
            var errorOccurrence = await _context.ErrorOccurrences.FindAsync(id);
            if (errorOccurrence == null)
            {
                return NotFound();
            }

            _context.ErrorOccurrences.Remove(errorOccurrence);
            await _context.SaveChangesAsync();

            return errorOccurrence;
        }

        private bool ErrorOccurrenceExists(int id)
        {
            return _context.ErrorOccurrences.Any(e => e.ErrorOccurrenceId == id);
        }
    }
}
