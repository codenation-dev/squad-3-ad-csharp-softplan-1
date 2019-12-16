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
    /// Controller for the Errors service.
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        private readonly ErrorCenterContext _context;
        private readonly IErrorService _service;
        private readonly IMapper _mapper;

		/// <summary>
		/// Instantiates a new ErrorsController in a Context.
		/// </summary>
        public ErrorsController(IMapper mapper, IErrorService service, ErrorCenterContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }

		/// <summary>
		/// Returns all registered Errors.
		/// </summary>
        // GET: api/Errors
        [HttpGet]
        public ActionResult<IEnumerable<Error>> GetErrors()
        {
            var errors = _service.GetAllErros();

            if (errors == null)
            {
                return NotFound();
            }
            else
            {

                List<ErrorViewModel> usersViewModels = errors.
                        Select(x => _mapper.Map<ErrorViewModel>(x)).
                        ToList();

                return Ok(usersViewModels);
            }
        }

		/// <summary>
		/// Returns a registered Error by its ID.
		/// </summary>
        // GET: api/Errors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Error>> GetError(int id)
        {
            var error = await _context.Errors.FindAsync(id);

            if (error == null)
            {
                return NotFound();
            }

            return error;
        }

		/// <summary>
		/// Updates a registered Error.
		/// </summary>
        // PUT: api/Errors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutError(int id, Error error)
        {
            if (id != error.Id)
            {
                return BadRequest();
            }

            _context.Entry(error).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorExists(id))
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
        /// Shelve a registered Error.
        /// </summary>
        // PUT: api/Errors/Arquivar
        [HttpPut("{id}/shelve")]
        public async Task<IActionResult> PutShelveError(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var error = await _context.Errors.FindAsync(id);

            if (error == null)
            {
                return NotFound();
            }

            Situation situationShelve = _context.Situations.Where(p => p.Id == 2).FirstOrDefault();

            error.Situation = situationShelve;

            _context.Entry(error).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorExists(id))
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
        /// Creates an Error.
        /// </summary>
        // POST: api/Errors
        [HttpPost]
        public async Task<ActionResult<Error>> PostError(Error error)
        {
            _context.Errors.Add(error);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ErrorExists(error.SituationId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetError", new { id = error.SituationId }, error);
        }

		/// <summary>
		/// Deletes a registered Error.
		/// </summary>
        // DELETE: api/Errors/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Error>> DeleteError(int id)
        {
            var error = await _context.Errors.FindAsync(id);
            if (error == null)
            {
                return NotFound();
            }

            _context.Errors.Remove(error);
            await _context.SaveChangesAsync();

            return error;
        }

		/// <summary>
		/// Asserts the exitance of a Error.
		/// </summary>
        private bool ErrorExists(int id)
        {
            return _context.Errors.Any(e => e.SituationId == id);
        }
    }
}
