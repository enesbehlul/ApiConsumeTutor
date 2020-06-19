using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIConsume.Models
{
    public class Customer
    {

        public string date_add { get; set; }
        public string last_passwd_gen { get; set; }
        public string newsletter_date_add { get; set; }
        public int active { get; set; }
        public int show_public_prices { get; set; }
        public int is_guest { get; set; }
        public int newsletter { get; set; }
        public int optin { get; set; }
        public int deleted { get; set; }
        public string note { get; set; }
        public long max_payment_days { get; set; }
        public decimal outstanding_allow_amount { get; set; }
        public string secure_key { get; set; }
        public string ip_registration_newsletter { get; set; }
        public string date_upd { get; set; }
        public string ape { get; set; }
        public string company { get; set; }
        public string website { get; set; }
        public string birthday { get; set; }
        public string email { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string passwd { get; set; }
        public long? id_gender { get; set; }
        public long? id_risk { get; set; }
        public long? id_shop_group { get; set; }
        public long? id_shop { get; set; }
        public long? id_lang { get; set; }
        public long? id_default_group { get; set; }
        public long? id { get; set; }
        public string siret { get; set; }
    }
}
