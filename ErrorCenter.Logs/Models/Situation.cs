using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for a Situation.
	/// </summary>
    public class Situation
    {
		/// <summary>
		/// Unique identifier for the Situation.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Name of the Situation.
		/// </summary>
        public string Name { get; set; }

        public virtual ICollection<Error> Errors { get; set; }
    }
}
