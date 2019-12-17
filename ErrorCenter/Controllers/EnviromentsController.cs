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

namespace ErrorCenter.Api.Controllers
{
    /// <summary>
    /// Controller for the ErrorOccurrences service.
    /// </summary>
    /// 
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentsController : ControllerBase
    {
        private readonly ErrorCenterContext _context;
        private readonly IEnvironmentService _service;
        private readonly IMapper _mapper;

		/// <summary>
		/// Instantiates a new EnvironmentsController in a Context.
		/// </summary>
        public EnvironmentsController(IMapper mapper, IEnvironmentService service, ErrorCenterContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }

		/// <summary>
		/// Returns all registered Environments.
		/// </summary>
        // GET: api/Environments
        [HttpGet]
        public ActionResult<IEnumerable<EnvironmentViewModel>> GetEnvironments()
        {
            var environments = _service.ConsultAllEnvironments();

            if (environments == null)
            {
                return NotFound();
            }
            else
            {

                List<EnvironmentViewModel> teste = environments.
                        Select(x => _mapper.Map<EnvironmentViewModel>(x)).
                        ToList();

                return Ok(teste);
            }
        }

		/// <summary>
		/// Returns a registered Environment by its ID.
		/// </summary>
        // GET: api/Environments/5
        [HttpGet("{id}")]
        public ActionResult<EnvironmentViewModel> GetEnvironment(int id)
        {
            var environment = _service.ConsultEnvironment(id);

            if (environment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<EnvironmentViewModel>(environment));
        }

		/// <summary>
		/// Updates a registered Environment.
		/// </summary>
        // PUT: api/Environments/5
        [HttpPut("{id}")]
        public ActionResult<EnvironmentViewModel> PutEnvironment(int id, Environment environment)
        {
            if (id != environment.Id)
            {
                return BadRequest();
            }

            try
            {
                return Ok(_mapper.Map<EnvironmentViewModel>(_service.RegisterEnvironment(environment)));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnvironmentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

		/// <summary>
		/// Deletes a registered Environment.
		/// </summary>
        // POST: api/Environments
        [HttpPost]
        public ActionResult<EnvironmentViewModel> PostEnvironment([FromBody] EnvironmentViewModel value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(_mapper.Map<EnvironmentViewModel>(_service.RegisterEnvironment(_mapper.Map<Environment>(value))));

        }

		/// <summary>
		/// Asserts the exitance of an Environment.
		/// </summary>
        private bool EnvironmentExists(int id)
        {
            return _context.Environments.Any(e => e.Id == id);
        }
    }
}
