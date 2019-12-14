using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
	/// <summary>
	/// Basic parameters for a Level of severity.
	/// </summary>
    public class LevelViewModel
    {
		/// <summary>
		/// Unique identifier for a Level.
		/// </summary>
        public int Id { get; set; }

		/// <summary>
		/// Name of the Level of severity.
		/// </summary>
        [Required]
        public string Name { get; set; }
    }
}
