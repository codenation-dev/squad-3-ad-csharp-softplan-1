using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
    public class SituationViewModel
    {
        public int SituationId { get; set; }

        [Required]
        public string SituationName { get; set; }
    }
}
