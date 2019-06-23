using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdSystem.model
{
    class Order
    {
        public string ID { set; get; }
        public DateTime orderDate { set; get; }
        public string customerID { set; get; }
        public string driverID { set; get; }
        public string vehicleID { set; get; }
        public string paymentID { set; get; }
        public string pickupLocation { set; get; }
        public string pickupNotes { set; get; }
        public string destinationLocation { set; get; }
        public string destinationNotes { set; get; }
        public DateTime pickupDate { set; get; }
        public int passengers { set; get; }
        public TimeSpan travelDuration { set; get; }
        public int distanceTravelled { set; get; }
        public int price { set; get; }
        public bool completed { set; get; }
    }
}
