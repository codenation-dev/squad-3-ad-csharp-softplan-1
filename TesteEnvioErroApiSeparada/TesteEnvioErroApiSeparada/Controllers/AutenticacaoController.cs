using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TesteEnvioErroApiSeparada.Controllers
{
	public class LoginViewModel
	{
		public string Login { get; set; }

		public string Password { get; set; }
	}



	[Route("api/auth")]
	[ApiController]
	public class AutenticacaoController : ControllerBase
	{
		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "enviar no post app/json com login e passwd", "no body" };
		}


		/*
		 * o delphi enviando post, par´[0] login como plain text e requestbody e o c# com:
		 * pos, e assiantura public ActionResult Post(string login) funcionou.
		 * 
		 */
		//[FromBody]
		// POST api/auth
		[HttpPost]
		public ActionResult Post(LoginViewModel login)
		{
			return Ok(new { access_token = "token-auth", user = new { id = 1, nome = "teste teste", token = "token-usario"}, solicitacao = login });
		}

	}
}
