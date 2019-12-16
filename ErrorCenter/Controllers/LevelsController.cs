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
    /// Controller for the Levels service.
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LevelsController : ControllerBase
    {
        private readonly ErrorCenterContext _context;
        private readonly ILevelService _service;
        private readonly IMapper _mapper;

		/// <summary>
		/// Instantiates a new LevelsController in a Context.
		/// </summary>
        public LevelsController(IMapper mapper, ILevelService service, ErrorCenterContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }

		/// <summary>
		/// Returns all registered Levels.
		/// </summary>
        // GET: api/Levels
        [HttpGet]
        public ActionResult<IEnumerable<LevelViewModel>> GetLevels()
        {
            var levels = _service.ConsultAllLevels();

            if (levels == null)
            {
                return NotFound();
            }
            else
            {

                List<LevelViewModel> levelsViewModels = levels.
                        Select(x => _mapper.Map<LevelViewModel>(x)).
                        ToList();

                return Ok(levelsViewModels);
            }

        }

		/// <summary>
		/// Returns a specified Level by its ID.
		/// </summary>
        // GET: api/Levels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Level>> GetLevel(int id)
        {
            var level = await _context.Levels.FindAsync(id);

            if (level == null)
            {
                return NotFound();
            }

            return level;
        }

		/// <summary>
		/// Updates a registered Level.
		/// </summary>
        // PUT: api/Levels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLevel(int id, Level level)
        {
            if (id != level.Id)
            {
                return BadRequest();
            }

            _context.Entry(level).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LevelExists(id))
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
		/// Creates a new Level.
		/// </summary>
        // POST: api/Levels
        [HttpPost]
        public async Task<ActionResult<Level>> PostLevel(Level level)
        {
            _context.Levels.Add(level);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLevel", new { id = level.Id }, level);
        }

		/// <summary>
		/// Deletes a registered Level.
		/// </summary>
        // DELETE: api/Levels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Level>> DeleteLevel(int id)
        {
            var level = await _context.Levels.FindAsync(id);
            if (level == null)
            {
                return NotFound();
            }

            _context.Levels.Remove(level);
            await _context.SaveChangesAsync();

            return level;
        }

		/// <summary>
		/// Asserts the exitance of a Level.
		/// </summary>
        private bool LevelExists(int id)
        {
            return _context.Levels.Any(e => e.Id == id);
        }
    }
}
