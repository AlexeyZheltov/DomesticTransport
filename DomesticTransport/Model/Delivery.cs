﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomesticTransport.Model
{
    class Delivery
    {
        /// <summary>
        /// Найден маршрут доставки в таблице
        /// </summary>
        public bool hasRoute { get; set; } = true;
        /// <summary>
        /// Номер Авто
        /// </summary>
        public int Number { get; set; } = 0;


        ///// <summary>
        ///// 
        ///// </summary>
        //public DateTime DateCreate { get { return DateTime.Now; } }
        public Carrier Carrier
        {
            get
            {
                if (_carrier == null)
                {
                    _carrier = new Carrier();
                }
                return _carrier;
            }
            private set { _carrier = value; }
        }
        Carrier _carrier;

        /// <summary>
        /// Стоимость доставки
        /// </summary>
        public double CostDelivery
        {
            get
            {
                return Truck?.Cost ?? 0;
            }
        }

        /// <summary>
        /// Общий вес
        /// </summary>
        public double TotalWeight
        {
            get
            {
                double sum = 0;
                Orders.ForEach(x => sum += x.WeightNetto);
                return sum;
            }
        }
        ///// <summary>
        ///// Стоимость товаров
        ///// </summary>
        public double CostProducts
        {
            get
            {
                double sum = 0;
                Orders.ForEach(x => sum += x.Cost);
                return sum;
            }
        }


        public List<Order> Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new List<Order>();
                }
                return _orders;
            }
            set
            {

                _orders = value;
            }
        }
        List<Order> _orders;



        /// <summary>
        /// Точки доставки
        /// </summary>
        public List<DeliveryPoint> MapDelivery
        {
            get
            {
                List<DeliveryPoint> dp = (from r in Orders
                                          select r.DeliveryPoint
                                          ).Distinct().ToList();
                dp.OrderBy(x => x.PriorityRoute).ThenBy(y => y.PriorityPoint);
                return dp;
            }
        }


        public Truck Truck
        {
            get
            {
                if (_truck == null)
                {

                    ShefflerWorkBook workBook = new ShefflerWorkBook();
                    _truck = workBook.GetTruck(TotalWeight, MapDelivery);
                }
                return _truck;
            }
            set { _truck = value; }//private
        }
        Truck _truck;

        public Delivery() { }
        public Delivery(Order order)
        {
            Orders.Add(order);
        }

         /// <summary>
         /// Проверка на превышение веса
         /// </summary>
         /// <param name="order"></param>
         /// <returns></returns>
        internal bool CheckDeliveryWeght(Order order)
        {
            double sum = TotalWeight + order.WeightNetto;
            return sum < 20200;

        }
    }
}
