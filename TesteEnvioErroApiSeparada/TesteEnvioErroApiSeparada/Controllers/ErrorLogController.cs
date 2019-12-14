using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TesteEnvioErroApiSeparada.Controllers
{
	public class CompleteDataErrorViewModel
	{
		public string userToken { get; set; }

		public int ErrorId { get; set; }

		public int EnvironmentId { get; set; }

		public string EnvironmentName { get; set; }

		public int LevelId { get; set; }

		public string LevelName { get; set; }

		public int SituationId { get; set; }

		public string SituationName { get; set; }

		public string Title { get; set; }

		public int ErrorOccurrenceId { get; set; }

		public string Origin { get; set; }

		public string Details { get; set; }

		public string DateTime { get; set; }

		public int UserId { get; set; }

		public string UserName { get; set; }

		public string UserEmail { get; set; }

	}


	public class CompleteDataErrorRequestInfo
	{
		[FromQuery] public string userToken { get; set; }

		[FromBody] public CompleteDataErrorViewModel completeDataError { get; set; }
	}

[Route("api/errorlog")]
	public class ErrorLogController : ControllerBase
	{

		// GET api/values
		[HttpGet]
		public ActionResult<IEnumerable<string>> Get()
		{
			return new string[] { "enviar no post app/json com as propriedades do CompleteDataErrorViewModel e usertoken=<token> na requisição", "CompleteDataErrorViewModel no body, na linha usertoken" };
		}

		/*
		[HttpPost()]
		public ActionResult Post(CompleteDataErrorRequestInfo reqInfo)
		{
			if (string.IsNullOrEmpty(reqInfo.userToken))
			{
				return BadRequest("Deve passar o usertoken na requisição");
			}


			return Ok(new { token = reqInfo.userToken, dados = reqInfo.completeDataError });
		}
		*/

		
		[HttpPost()]
		public ActionResult Post([FromBody]CompleteDataErrorViewModel item)
		{
			if(string.IsNullOrEmpty(item.userToken))
			{
				return BadRequest("Deve passar o usertoken na requisição");
			}


			return Ok(new { token = item.userToken, dados = item });
		}
		
	}
}
