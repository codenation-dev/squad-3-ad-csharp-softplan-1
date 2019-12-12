using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
    public class LevelViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
