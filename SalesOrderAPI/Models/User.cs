using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SalesOrderAPI.Models
{
    public class User
    {
        public string date
        {
            get;
            set;
        }

        public string order_id
        {
            get;
            set;
        }

        public string customer_po
        {
            get;
            set;
        }

        public string TYPE
        {
            get;
            set;
        }

        public string name
        {
            get;
            set;
        }
        public string note
        {
            get;
            set;
        }
        public string shipping_method 
        { 
            get;
            set; 
        }

        public string shipping_carrier 
        { 
            get; 
            set; 
        }


        public string street
        {
            get;
            set;
        }

        public string city
        {
            get;
            set;
        }

        public string state
        {
            get;
            set;
        }

       public string zip_code
        {
            get;
            set;
        }

   
        public string country
        {
            get;
            set;
        }

        public string phone
        {
            get;
            set;
        }

    }

    
}