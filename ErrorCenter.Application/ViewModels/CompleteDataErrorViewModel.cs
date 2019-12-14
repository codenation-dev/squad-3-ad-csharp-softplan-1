using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorCenter.Application.ViewModels
{
	public class CompleteDataErrorViewModel
	{
		public int ErrorCode { get; set; }
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
		public string ErrorDescription { get; internal set; }
		public string ErrorTitle { get; internal set; }
	}
}
