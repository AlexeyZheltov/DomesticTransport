﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomesticTransport.Model
{
    /// <summary>
    ///  Класс заказа 
    /// </summary>
    class Order
    {
        public string Id
        {
            get
            {                         
                return _id;
            }

            set {              
                    _id = value.Length <10 ? new string('0', 10 - value.Length) + value : value ;                  
            }
        }
        private string _id;
        

        public int NumberDelivery { get; set; } = 0;
        public int PointNumber { get; set; }
        
        public Customer Customer 
        {
            get 
            {
                if (_customer == null) _customer = new Customer();
                return _customer;
            }

            set { _customer = value; }
        }
        private Customer _customer;


        public int PalletsCount { get; set; }
        public double WeightNetto { get; set; }

        public double WeightBrutto { get; set; }

        public string TransportationUnit
        {
            get { return _transportationUnit; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _transportationUnit = new string('0', 18 - value.Length) + value;
                }
            }
        }
        private string _transportationUnit;
        public double Cost { get; set; }
        public string Route { get; set; }

        public DeliveryPoint DeliveryPoint { get; set; }
        //    get {
        //        if (_deliveryPoint.IdRoute == 0) 
        //        {
        //           // _deliveryPoint = 

        //        }
        //        return _deliveryPoint;
        //    } 
        //    set {
        //        _deliveryPoint = value;
        //    } }

        //DeliveryPoint _deliveryPoint;


    }
}
