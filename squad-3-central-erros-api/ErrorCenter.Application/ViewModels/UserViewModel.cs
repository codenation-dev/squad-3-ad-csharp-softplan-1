﻿using System.ComponentModel.DataAnnotations;

namespace ErrorCenter.Application.ViewModels
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Token { get; set; }
    }
}