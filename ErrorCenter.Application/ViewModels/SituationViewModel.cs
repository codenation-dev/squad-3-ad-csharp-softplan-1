using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
	/// <summary>
	/// Basic parameters for a Situation.
	/// </summary>
    public class SituationViewModel
    {
		/// <summary>
		/// Unique identifier for the Situation.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Name of the Situation.
		/// </summary>
        [Required]
        public string Name { get; set; }
    }
}
