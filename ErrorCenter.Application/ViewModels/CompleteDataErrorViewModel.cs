using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Application.ViewModels
{
	public class CompleteDataErrorViewModel
	{
		public int ErrorCode { get; set; }
		public string userToken { get; set; }

		public int EnvironmentId { get; set; }

		public int LevelId { get; set; }

		public int SituationId { get; set; }

		public string ErrorOrigin { get; set; }

		public string ErrorDetails { get; set; }

		public string DateTime { get; set; }

		public int UserId { get; set; }
		public string UserName { get; set; }
		public string UserEmail { get; set; }

		public string ErrorDescription { get; set; }
		public string ErrorTitle { get; set; }

		public int ErrorEventCount { get; set; }
	}
}
