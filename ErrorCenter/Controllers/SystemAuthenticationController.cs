﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ErrorCenter.Application.ViewModels;
using AutoMapper;
using ErrorCenter.Data.Context;
using ErrorCenter.Application.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using ErrorCenter.CrossCutting.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace ErrorCenter.Api.Controllers
{
	/// <summary>
	/// Controller for the SystemAuthentication service.
	/// </summary> 
    [Route("api/auth")]
    public class SystemAuthenticationController : ControllerBase
    {
        private readonly ErrorCenterContext _context;
        private readonly ISystemAuthenticationService _service;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

		/// <summary>
		/// Instantiates a new SystemAuthenticationController in a Context.
		/// </summary>
        public SystemAuthenticationController(IMapper mapper, ISystemAuthenticationService service,
            ErrorCenterContext context, IOptions<AppSettings> appSettings)
        {
            _service = service;
            _mapper = mapper;
            _context = context;
            _appSettings = appSettings.Value;
        }

		/// <summary>
		/// Communicates with LoginViewModel to authenticate a Login request.
		/// </summary> 
        [AllowAnonymous]
        [HttpPost()]
        public ActionResult Post([FromBody]LoginViewModel login)
        {
            var user = _service.Authenticate(login);

            if (user == null)
            {
                return BadRequest("Usuário ou senha não conferem.");
            }

            UserViewModel userViewModel = _mapper.Map<UserViewModel>(user);

            string token = GenarateJWT(userViewModel);

            return Ok(new { access_token = token, user = userViewModel });

        }

		/// <summary>
		/// Generates a JWT from the UserViewModel.
		/// </summary> 
        private string GenarateJWT(UserViewModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secretKeyJWT = _appSettings.SecretKeyJWT;
            var key = Encoding.ASCII.GetBytes(secretKeyJWT);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name),
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
