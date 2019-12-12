using AutoMapper;
using ErrorCenter.Application.Interfaces;
using ErrorCenter.Application.ViewModels;
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
    public class ErrorsController : ControllerBase
    {
        private readonly ErrorCenterContext _context;
        private readonly IErrorService _service;
        private readonly IMapper _mapper;


        public ErrorsController(IMapper mapper, IErrorService service, ErrorCenterContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }


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

        // PUT: api/Errors/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutError(int id, Error error)
        {
            if (id != error.SituationId)
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

        private bool ErrorExists(int id)
        {
            return _context.Errors.Any(e => e.SituationId == id);
        }
    }
}
