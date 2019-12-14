using ErrorCenter.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
	/// <summary>
	/// Basic parameters for an Error.
	/// </summary>
    public class ErrorViewModel
    {
		/// <summary>
		/// Unique identifier for the Error.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// ID of the Environment.
		/// </summary>
        [Required]
        public int EnvironmentId { get; set; }

		/// <summary>
		/// Environment of the Error.
		/// </summary>
        public virtual EnvironmentViewModel Environment { get; set; }

		/// <summary>
		/// ID of the Level of severity.
		/// </summary>
        [Required]
        public int LevelId { get; set; }
		
		/// <summary>
		/// Severity of the Error.
		/// </summary>
		public virtual LevelViewModel Level { get; set; }
		
		/// <summary>
		/// ID of the Situation.
		/// </summary>
        [Required]
        public int SituationId { get; set; }

		/// <summary>
		/// Situation of the Error.
		/// </summary>
        public virtual SituationViewModel Situation { get; set; }

		/// <summary>
		/// Title of the Error.
		/// </summary>
        [Required]
        public string Title { get; set; }

        //public virtual List<ErrorOccurrenceViewModel> ErrorOccurrences { get; set; }
    }
}
