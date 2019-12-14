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
	/// <summary>
	/// Controller for the ErrorOccurrences service.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class ErrorOccurrencesController : ControllerBase
	{
		private readonly ErrorCenterContext _context;
		private readonly IErrorOccurrenceService _service;
		private readonly IMapper _mapper;

		/// <summary>
		/// Instantiates a new ErrorOccurrencesController in a Context.
		/// </summary>
		public ErrorOccurrencesController(IMapper mapper, IErrorOccurrenceService service, ErrorCenterContext context)
		{
			_service = service;
			_mapper = mapper;
			_context = context;
		}

		/// <summary>
		/// Returns all registered ErrorOccurrences.
		/// </summary>
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

		/// <summary>
		/// Returns a registered ErrorOcurrence by its search and sort criteria.
		/// </summary>
		//[Route("api/erros/consulta")]
		[HttpGet("{environmentId}/{pageSize}/{page}/{sortType}/{filterType}/{filterValue}")]
		// https://localhost:5001/api/erros/1/10/1/T/teste
		public ActionResult GetErrorOccurrences(int environmentId,
			int pageSize, int page, string sortType, string filterType, string filterValue)
		{
			int tamPag = pageSize < 1 ? 10 : pageSize;
			int pag = page < 1 ? 1 : page;


			var errorOccurrencesResultPage = _service.GetErrorOccurrencesParams(environmentId,
			tamPag, pag, sortType, filterType, filterValue);

			if (errorOccurrencesResultPage == null)
			{
				return NotFound();
			}
			else
			{
				return Ok(errorOccurrencesResultPage);
			}

		}

		/// <summary>
		/// Returns a registered ErrorOccurrence by its ID.
		/// </summary>
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

		/// <summary>
		/// Updates a registered ErrorOccurrence.
		/// </summary>
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

		/// <summary>
		/// Creates a ErrorOccurrence.
		/// </summary>
		// POST: api/ErrorOccurrences
		[HttpPost]
		public async Task<ActionResult<ErrorOccurrence>> PostErrorOccurrence(ErrorOccurrence errorOccurrence)
		{
			_context.ErrorOccurrences.Add(errorOccurrence);
			await _context.SaveChangesAsync();

			return CreatedAtAction("GetErrorOccurrence", new { id = errorOccurrence.Id }, errorOccurrence);
		}

		/// <summary>
		/// Deletes an ErrorOccurence.
		/// </summary>
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

		/// <summary>
		/// Asserts the exitance of a ErrorOccurence.
		/// </summary>
		private bool ErrorOccurrenceExists(int id)
		{
			return _context.ErrorOccurrences.Any(e => e.Id == id);
		}
	}
}
