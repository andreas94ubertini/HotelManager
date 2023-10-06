using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class Services
    {
        
        
        public int IdOpts { get; set; }
        [Display(Name = "Colazione In camera")]
        public bool RoomBr {  get; set; }
        [Display(Name = "Servizio MiniBar")]
        public bool MiniBar {  get; set; }
        [Display(Name = "Connessione Internet veloce")]
        public bool Internet {  get; set; }
        [Display(Name = "Letto Aggiuntivo")]
        public bool AddBed {  get; set; }
        [Display(Name = "Culla")]
        public bool Cradle {  get; set; }
        public bool IdReservation {  get; set; }
    }
}