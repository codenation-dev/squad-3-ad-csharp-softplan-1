using ErrorCenter.Domain.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
    public class ErrorViewModel
    {
        public int Id { get; set; }

        [Required]
        public int EnvironmentId { get; set; }

        public virtual EnvironmentViewModel Environment { get; set; }

        [Required]
        public int LevelId { get; set; }

        public virtual LevelViewModel Level { get; set; }

        [Required]
        public int SituationId { get; set; }

        public virtual SituationViewModel Situation { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<ErrorOccurrenceViewModel> ErrorOccurrences { get; set; }
    }
}
