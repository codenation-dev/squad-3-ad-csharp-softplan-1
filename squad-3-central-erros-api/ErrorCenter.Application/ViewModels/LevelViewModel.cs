using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
    public class LevelViewModel
    {
        public int LevelId { get; set; }

        [Required]
        public string LevelName { get; set; }
    }
}
