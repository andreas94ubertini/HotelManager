using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class QueryCf
    {
        public int IdReservation {  get; set; }
        public DateTime ResDate { get; set; }
        public double Deposit {  get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Cf {  get; set; }
    }
}