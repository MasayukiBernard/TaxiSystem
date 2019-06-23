using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBirdSystem.model
{
    class Payment
    {
        public string ID { set; get; }
        public string customerID { set; get; }
        public string paymentMethod { set; get; }
        public int price { set; get; }
        public int payment { set; get; }
        public int change { set; get; }
        public DateTime date { set; get; }
    }
}
