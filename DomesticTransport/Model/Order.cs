﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomesticTransport.Model
{

    class Order
    {
        public string Id { get; set; }


        public Customer Customer { get;set;}
        public int PalletsCount { get; set; }
        public double WeightNetto { get; set; }

        public double WeightBrutto { get; set; }
        
        public string TransportationUnit { get; set; }
        public double Cost { get; set; }
        public string Route { get; set; }

        public int Prioriy {
            get{
            if (_prioriy == 0 && Customer !=null)//!string.IsNullOrWhiteSpace(Route))
                {
                    using (FunctionsSheffler functions = new FunctionsSheffler())
                    {
                        _prioriy = functions.GetPriority(Customer.Id);
                    }                     
                }
                return _prioriy; }          
            }
        int _prioriy = 0;
    }
}
