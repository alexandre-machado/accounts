using System;
using System.ComponentModel.DataAnnotations;

namespace Models.ViewModel
{
    [Serializable]
    public class LoginViewModel
    {
        [Required]
        public string Login { get; internal set; }
        [Required]
        public string Password { get; internal set; }
        public bool RememberMe { get; internal set; }
    }
}