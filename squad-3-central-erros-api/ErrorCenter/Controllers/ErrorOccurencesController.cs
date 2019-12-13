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
        public ActionResult<IEnumerable<ErrorOccurrenceViewModel>> GetErrorOccurrences()
        {
            var errorOccurrences = _service.GetAllErrorOccurrences();

            if (errorOccurrences == null)
            {
                return NotFound();
            }
            else
            {

                List<ErrorOccurrenceViewModel> errorOccurrencesViewModels = errorOccurrences.
                        Select(x => _mapper.Map<ErrorOccurrenceViewModel>(x)).
                        ToList();

                return Ok(errorOccurrencesViewModels);
            }
        }

        //[Route("api/erros/consulta")]
        [HttpGet("{idAmbiente}/{tamanhoPagina}/{pagina}/{tipoOrdenacao}/{tipoFiltro}/{valorFiltro}")]
        // https://localhost:5001/api/erros/1/10/1/T/teste
        public ActionResult GetErrorOccurrences(int idAmbiente,
            int tamanhoPagina, int pagina, string tipoOrdenacao, string tipoFiltro, string valorFiltro)
        {
            int tamPag = tamanhoPagina < 1 ? 10 : tamanhoPagina;
            int pag = pagina < 1 ? 1 : pagina;


            var errorOccurrencesResultPage = _service.GetErrorOccurrencesParams(idAmbiente,
            tamPag, pag, tipoOrdenacao, tipoFiltro, valorFiltro);

            if (errorOccurrencesResultPage == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(errorOccurrencesResultPage);
            }

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
            if (id != errorOccurrence.Id)
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

            return CreatedAtAction("GetErrorOccurrence", new { id = errorOccurrence.Id }, errorOccurrence);
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
            return _context.ErrorOccurrences.Any(e => e.Id == id);
        }
    }
}
