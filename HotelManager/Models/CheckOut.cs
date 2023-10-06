using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class CheckOut
    {
        public int IdReservation { get; set; }

        [Display(Name = "Data Prenotazione")]
        public DateTime ResDate { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Data check in")]
        public DateTime Start { get; set; }
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
        public int IdRoom { get; set; }
        
        [Display(Name = "Numero Stanza")]
        public int RoomNumber { get; set; }
        [Required(ErrorMessage = "Campo obbligatorio")]
        [Display(Name = "Tipo stanza")]
        public string Type { get; set; }
        public int IdOpts { get; set; }
        [Display(Name = "Colazione In camera")]
        public bool RoomBr { get; set; }
        [Display(Name = "Servizio MiniBar")]
        public bool MiniBar { get; set; }
        [Display(Name = "Connessione Internet veloce")]
        public bool Internet { get; set; }
        [Display(Name = "Letto Aggiuntivo")]
        public bool AddBed { get; set; }
        [Display(Name = "Culla")]
        public bool Cradle { get; set; }

        public int GetTotalServices()
        {
            List<bool> services = new List<bool>();
            services.Add(RoomBr);
            services.Add(MiniBar);
            services.Add(Internet);
            services.Add(AddBed);
            services.Add(Cradle);
            int total = 0;
            foreach(bool service in services)
            {
                if (service)
                {
                    total+= 5;
                }
            }
            return total;
        }
        public double GetTotalToPay()
        {
            double RoomPrice = 0;
            if (Type == "Singola")
            {
                RoomPrice = 30; 
            }else if(Type == "Doppia")
            {
                RoomPrice = 40;
            }
            double Days = (EndRes - Start).TotalDays;
            return (RoomPrice * Days);
        }

    }
}