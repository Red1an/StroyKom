using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логин")]
        public string? UserName { set; get; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string? Password { set; get; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { set; get; }
    }
}
