using System;
using System.Collections.Generic;
using System.Text;

namespace App446MasterDetail.Models
{
    public class TransportationTrips
    {
        public DateTime CreatedTime { get; set; }
        public string CreatedUser { get; set; }
        public string Vehicle { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Tolerance { get; set; }
        public decimal StartLocation { get; set; }
        public decimal DestinationLocation { get; set; }
        public Int32 SeatCount { get; set; }


    }
}
