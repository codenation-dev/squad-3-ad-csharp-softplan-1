using ErrorCenter.Domain.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
    public class ErrorOccurrenceViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Origin { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public int UserId { get; set; }

        public virtual UserViewModel User { get; set; }

        [Required]
        public int ErrorId { get; set; }

        public virtual ErrorViewModel Error { get; set; }

        [Required]
        public int EventCount { get; set; }

    }
}
