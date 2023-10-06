using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManager.Models
{
    public class Room
    {
        public int IdRoom { get; set; }
        public int RoomNumber { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

    }
}