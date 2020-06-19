using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class Address
    {

        public int deleted { get; set; }
        public string dni { get; set; }
        public string phone_mobile { get; set; }
        public string phone { get; set; }
        public string other { get; set; }
        public string city { get; set; }
        public string postcode { get; set; }
        public string address2 { get; set; }
        public string address1 { get; set; }
        public string vat_number { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string company { get; set; }
        public string alias { get; set; }
        public long? id_state { get; set; }
        public long? id_country { get; set; }
        public long? id_warehouse { get; set; }
        public long? id_supplier { get; set; }
        public long? id_manufacturer { get; set; }
        public long? id_customer { get; set; }
        public long? id { get; set; }
        public string date_add { get; set; }
        public string date_upd { get; set; }

    }
}
