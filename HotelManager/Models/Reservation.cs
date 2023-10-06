using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class Reservation
    {
        public int IdReservation {  get; set; }
        public DateTime ResDate { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Data check in")]
        public DateTime Start {  get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Data check out")]
        public DateTime EndRes { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Caparra")]
        public double Deposit { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Prezzo")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Trattamento")]
        public string Details { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Cliente")]
        public int IdCustomer {  get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Stanza")]
        public int IdRooms {  get; set; }

    }
}