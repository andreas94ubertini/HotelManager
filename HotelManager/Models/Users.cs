using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class Users
    {
        public int IdUser { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "PassWord")]
        public string Psw { get; set; }
        public string Role { get; set; }
    }
}