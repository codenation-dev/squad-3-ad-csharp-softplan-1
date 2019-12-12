using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
    public class ErrorViewModel
    {
        public int Id { get; set; }

        [Required]
        public int EnvironmentId { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Required]
        public int SituationId { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
