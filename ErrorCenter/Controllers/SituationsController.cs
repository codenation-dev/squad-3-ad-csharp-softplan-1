using AutoMapper;
using ErrorCenter.Application.Interfaces;
using ErrorCenter.Application.ViewModels;
using ErrorCenter.Data.Context;
using ErrorCenter.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorCenter.Api.Controllers
{
    /// <summary>
    /// Controller for the Situations service.
    /// </summary> 
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SituationsController : ControllerBase
    {
        private readonly ErrorCenterContext _context;
        private readonly ISituationService _service;
        private readonly IMapper _mapper;

		/// <summary>
		/// Instantiates a new SituationsController in a Context.
		/// </summary>
        public SituationsController(IMapper mapper, ISituationService service, ErrorCenterContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }

		/// <summary>
		/// Returns all registered Situations.
		/// </summary>
        // GET: api/Situations
        [HttpGet]
        public ActionResult<IEnumerable<Situation>> GetSituations()
        {
            var situations = _service.ConsultAllSituations();

            if (situations == null)
            {
                return NotFound();
            }
            else
            {

                List<SituationViewModel> situationsViewModels = situations.
                        Select(x => _mapper.Map<SituationViewModel>(x)).
                        ToList();

                return Ok(situationsViewModels);
            }
        }

		/// <summary>
		/// Returns a registered Situation by its ID.
		/// </summary>
        // GET: api/Situations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Situation>> GetSituation(int id)
        {
            var situation = await _context.Situations.FindAsync(id);

            if (situation == null)
            {
                return NotFound();
            }

            return situation;
        }

		/// <summary>
		/// Returns a registered Situation by its ID and Situation.
		/// </summary>
        // PUT: api/Situations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSituation(int id, Situation situation)
        {
            if (id != situation.Id)
            {
                return BadRequest();
            }

            _context.Entry(situation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SituationExists(id))
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

		/// <summary>
		/// Updates a registered Situation.
		/// </summary>
        // POST: api/Situations
        [HttpPost]
        public async Task<ActionResult<Situation>> PostSituation(Situation situation)
        {
            _context.Situations.Add(situation);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSituation", new { id = situation.Id }, situation);
        }

		/// <summary>
		/// Deletes a Situation.
		/// </summary>
        // DELETE: api/Situations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Situation>> DeleteSituation(int id)
        {
            var situation = await _context.Situations.FindAsync(id);
            if (situation == null)
            {
                return NotFound();
            }

            _context.Situations.Remove(situation);
            await _context.SaveChangesAsync();

            return situation;
        }

		/// <summary>
		/// Asserts the exitance of a Situation.
		/// </summary>
        private bool SituationExists(int id)
        {
            return _context.Situations.Any(e => e.Id == id);
        }
    }
}
