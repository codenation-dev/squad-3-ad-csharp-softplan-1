using AceleraDev.CrossCutting.Utils;
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
    /// Controller for the UsersController service.
    /// </summary>
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ErrorCenterContext _context;
        private readonly IUserService _service;
        private readonly IMapper _mapper;

		/// <summary>
		/// Instantiates a new UsersController in a Context.
		/// </summary>
        public UsersController(IMapper mapper, IUserService service, ErrorCenterContext context)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
        }

		/// <summary>
		/// Returns all registered Users.
		/// </summary>
        // GET: api/Users
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            var users = _service.ConsultAllUsers();

            if (users == null)
            {
                return NotFound();
            }
            else
            {

                List<UserViewModel> usersViewModels = users.
                        Select(x => _mapper.Map<UserViewModel>(x)).
                        ToList();

                return Ok(usersViewModels);
            }

        }

		/// <summary>
		/// Returns a registered User by its ID.
		/// </summary>
        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

		/// <summary>
		/// Updates a registered User by its ID.
		/// </summary>
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            //max: colcoa a senha que vem em md5
            user.Password = user.Password.ToHashMD5();

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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
		/// Creates a registered User.
		/// </summary>
        // POST: api/Users
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            //max: passa apra md5
            user.Password = user.Password.ToHashMD5();

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

		/// <summary>
		/// Deletes a registered User.
		/// </summary>
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

		/// <summary>
		/// Asserts the exitance of a User.
		/// </summary>
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
