using Common.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Common.Models
{
    public class Flight
    {
        public Guid Id { get; set; }
        public string To { get; set; }
        public string From { get; set; }
        public FlightDirection Direction { get; set; }
        public virtual int AirplaneId { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual ICollection<FlightHistory> History { get; set; }
    }
}
