﻿using AutoMapper;
using ErrorCenter.Application.Interfaces;
using ErrorCenter.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorCenter.Api.Controllers
{
	/// <summary>
	/// Classe d ocontrolador que implementa a as operação sobre as tabelas de erro
	/// </summary>
	[Route("api/errorlog")]
	public class ErrorLogController : ControllerBase
	{
		private readonly IUserService _Userservice;
		private readonly IErrorOccurrenceService _erroOcuService;
		IMapper _mapper;



		/// <summary>
		/// Instantiates a new UsersController in a Context.
		/// </summary>
		public ErrorLogController(IMapper mapper, IErrorOccurrenceService erroOcuService, IUserService service, IErrorOccurrenceService erroOcur)
		{
			_Userservice = service;
			_erroOcuService = erroOcuService;
			_mapper = mapper;
		}

		/// <summary>
		/// Sava o erro com base em registro com todos os dados esperados
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		[HttpPost()]
		public ActionResult Post([FromBody]CompleteDataErrorViewModel item)
		{
			if( string.IsNullOrEmpty(item.userToken) && string.IsNullOrEmpty(item.UserEmail) )
			{
				return BadRequest("Deve passar o usertoken no objeto item (corpo da requisição)");
			}

			var user = _Userservice.ValidateUserToken(item.userToken);
			if (user == null)
			{
				return BadRequest("O usertoken no objeto item (corpo da requisição) não corresponde a nenhum usuário");
			}

			var userViewModel = _mapper.Map<UserViewModel>(user);

			item.UserId = user.Id;
			item.UserName = user.Name;
			item.UserEmail = user.Email;


			_erroOcuService.RegisterError(item);


			return Ok(new { token = item.userToken, dados = item });
		}

	}
}
