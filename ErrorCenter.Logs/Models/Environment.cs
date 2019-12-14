using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ErrorCenter.Domain.Models
{
	/// <summary>
	/// Basic parameters for a Environment.
	/// </summary>
    public class Environment
    {
		/// <summary>
		/// Unique identifier of a Environment.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Name of the Environment.
		/// </summary>
        public string Name { get; set; }

        public virtual ICollection<Error> Errors { get; set; }


    }
}