using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for an Error.
	/// </summary>
    public class Error
    {
		/// <summary>
		/// Unique identifier for the Error.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Code of the Error.
		/// </summary>
        public int Code { get; set; }
		
		/// <summary>
		/// Title of the Error.
		/// </summary>
        public string Title { get; set; }

		/// <summary>
		/// Description of the Error.
		/// </summary>
        public string Description { get; set; }

		/// <summary>
		/// ID of the Environment.
		/// </summary>
        public int EnvironmentId { get; set; }

		/// <summary>
		/// ID of the Environment.
		/// </summary>
        public virtual Environment Environment { get; set; }// referencia 

		/// <summary>
		/// ID of the Level of severity.
		/// </summary>
        public int LevelId { get; set; }

		/// <summary>
		/// ID of the Level of severity.
		/// </summary>
        public virtual Level Level { get; set; }// referencia 

		/// <summary>
		/// ID of the Situation.
		/// </summary>
        public int SituationId { get; set; }

		/// <summary>
		/// ID of the Situation.
		/// </summary>
        public virtual Situation Situation { get; set; }// referencia 
        //public object ErrorOccurrences { get; set; }
        public virtual ICollection<ErrorOccurrence> ErrorOccurrences { get; set; }
    }
}
