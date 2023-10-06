using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class Customer
    {
        public int IdCustomer { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Nome")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Cognome")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "CodiceFiscale")]
        [StringLength(16,ErrorMessage ="Max 16 caratteri")]
        public string Cf { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Città")]
        public string City { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Provincia")]
        public string Pr { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Telefono Fisso")]
        public string Tel { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Cellulare")]
        public string Cell { get; set; }
    }
}