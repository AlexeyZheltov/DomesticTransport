﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DomesticTransport.Model
{
    public struct TruckRate
    {
        public string PlaceShipment { get; set; }
        public string PlaceDelivery { get; set; }
        public string City { get; set; }
        public string Company { get; set; }
        public decimal PriceFirstPoint { get; set; }
        public decimal PriceAddPoint { get; set; }
        public double Tonnage { get; set; }
        public decimal TotalDeliveryCost { get; set; }


        /// <summary>
        /// Города   ( проверять наличие города при поиске стоимости перевозки) 
        /// </summary>
        public string[] CityList
        {
            get
            {
                if (_cityList == null)
                {
                    _cityList = (from LR in ShefflerWB.RateList
                                 select LR.City
                                 ).Distinct().ToArray();
                }
                return _cityList;
            }
        }
        private string[] _cityList;

        /// <summary>
        /// Региональные перевозки
        /// </summary>
        /// <param name="rateVariants"></param>
        /// <returns></returns>
        public static List<TruckRate> GetTruckRate(double tonnageNeed, List<DeliveryPoint> mapDelivery)
        {
            List<TruckRate> rateVariants = new List<TruckRate>();
            int ix = 0;
            decimal MaxCost = 0;
            string city = "";

            /// подходящие варианты перевозчиков

            for (int i = 0; i < mapDelivery.Count; i++)
            {      //выбор дальней точки
                DeliveryPoint point = mapDelivery[i];
                if (ShefflerWB.RateList.FindAll(x => x.City == point.City).Count == 0)
                {
                    throw new Exception("В \"Rate\" отсутствует город " + point.City);
                }
                try
                {
                    decimal? MaxCostPoint = 0;
                    MaxCostPoint = (from rv in ShefflerWB.RateList
                                    where rv.City == point.City &&
                                            rv.Tonnage >= tonnageNeed
                                    select rv.PriceFirstPoint
                                )?.Max();
                    if (MaxCostPoint != null)
                    {
                        if (MaxCost < MaxCostPoint)
                        {
                            MaxCost = (decimal)MaxCostPoint;
                            ix = i;
                            city = point.City;
                        }
                    }
                }
                catch
                {
                    throw new Exception("Не удалось найти точку.  Проверьте наличие в Id клиента {mapDelivery[i].IdCustomer} на Листе \"Route\"");
                }
            }
            rateVariants = ShefflerWB.RateList.FindAll(r =>
                                        r.City == mapDelivery[ix].City &&
                                        r.Tonnage >= tonnageNeed
                                        ).ToList();

            if (rateVariants.Count > 0)
            {
                //По каждому варианту фирмы с дальним городом
                for (int rateIx = 0; rateIx < rateVariants.Count; rateIx++)
                {
                    bool hasFirstpoint = false;
                    TruckRate variantRate = rateVariants[rateIx];
                    variantRate.TotalDeliveryCost = 0;
                    city = GetCity(tonnageNeed, mapDelivery, variantRate.Company);
                    // считаем общую стоимость
                    for (int pointNumber = 0; pointNumber < mapDelivery.Count; pointNumber++)
                    {
                        if (mapDelivery[pointNumber].City == city && !hasFirstpoint)
                        {
                            TruckRate addPointRate =
                                 ShefflerWB.RateList.Where(x => x.Company == variantRate.Company &&
                                                    x.Tonnage == variantRate.Tonnage &&
                                                    x.City == mapDelivery[pointNumber].City).First();

                            variantRate.TotalDeliveryCost += addPointRate.PriceFirstPoint; // rateVariants[rateIx].PriceFirstPoint;
                            hasFirstpoint = true;
                        }
                        else
                        {
                            //Ищем стоимость доп точки в другом городе для той же машины 
                            TruckRate addPointRate =
                                 ShefflerWB.RateList.Where(x => x.Company == variantRate.Company &&
                                                    x.Tonnage == variantRate.Tonnage &&
                                                    x.City == mapDelivery[pointNumber].City).First();
                            variantRate.TotalDeliveryCost += addPointRate.PriceAddPoint;
                        }
                    }
                    rateVariants[rateIx] = variantRate;
                }
                rateVariants = rateVariants.OrderBy(r => r.TotalDeliveryCost).ToList();
            }
            return rateVariants;
        }

        private static string GetCity(double tonnageNeed, List<DeliveryPoint> mapDelivery, string provider)
        {
            int ix = 0;
            decimal MaxCost = 0;
            string city = "";

            /// подходящие варианты перевозчиков

            for (int i = 0; i < mapDelivery.Count; i++)
            {      //выбор дальней точки
                DeliveryPoint point = mapDelivery[i];
                if (ShefflerWB.RateList.FindAll(x => x.City == point.City).Count == 0)
                {
                    throw new Exception("В \"Rate\" отсутствует город " + point.City);
                }
                try
                {
                    decimal? MaxCostPoint = 0;
                    MaxCostPoint = (from rv in ShefflerWB.RateList
                                    where rv.City == point.City &&
                                     rv.Company ==  provider &&
                                            rv.Tonnage >= tonnageNeed
                                    select rv.PriceFirstPoint
                                )?.Max();
                    if (MaxCostPoint != null)
                    {
                        if (MaxCost < MaxCostPoint)
                        {
                            MaxCost = (decimal)MaxCostPoint;
                            ix = i;
                            city = point.City;
                        }
                    }
                }
                catch
                {
                    throw new Exception("Не удалось найти точку.  Проверьте наличие в Id клиента {mapDelivery[i].IdCustomer} на Листе \"Route\"");
                }
            }
            return city;
        }

        /// <summary>
        /// варианты Провайдеров для авто
        /// </summary>
        /// <param name="totalWeight"></param>
        /// <param name="mapDelivery"></param>
        /// <returns></returns>
        public static List<TruckRate> GetTruckRateInternational(double totalWeight, List<DeliveryPoint> mapDelivery)
        {
            List<TruckRate> rateVariants = new List<TruckRate>();
            int centner = (int)Math.Round(totalWeight / 100); //центнеры огругление до близжайшего целого
            if (centner < 1) centner = 1;
            double tonnageNeed = (double)centner / 10;   //тонн 

            for (int j = 0; j < ShefflerWB.RateInternationalList.Count; j++)
            {
                TruckRate rate = ShefflerWB.RateInternationalList[j];
                if (mapDelivery[0].City.Contains(rate.City) && rate.Tonnage == tonnageNeed)
                {
                    rateVariants.Add(rate);
                }
            }

            // Расчет стоимости доставки LTL
            for (int i = 0; i < rateVariants.Count; i++)
            {
                TruckRate rate = rateVariants[i];
                decimal addpointCost = (mapDelivery.Count - 1) * rateVariants[i].PriceAddPoint;
                rate.TotalDeliveryCost =
                    (int)Math.Round(rateVariants[i].PriceFirstPoint * (decimal)totalWeight / 100 + addpointCost, 0);
                rateVariants[i] = rate;
            }
            rateVariants = rateVariants.OrderBy(r => r.TotalDeliveryCost).ToList();
            return rateVariants;
        }

        /// <summary>
        /// По МСК и МО
        /// </summary>
        /// <param name="tonnageNeed"></param>
        /// <param name="rateVariants"></param>
        /// <param name="mapDelivery"></param>
        /// <returns></returns>
        public static List<TruckRate> GetCostMskRoutes(double tonnageNeed,
                  List<DeliveryPoint> mapDelivery)
        {
            List<TruckRate> rateVariants = new List<TruckRate>();
            rateVariants = ShefflerWB.RateList.FindAll(r =>
                                        r.City == mapDelivery[0].City &&
                                      r.Tonnage >= tonnageNeed
                                        ).ToList();

            if (rateVariants.Count > 0)
            {
                for (int rateIx = 0; rateIx < rateVariants.Count; rateIx++)
                {
                    TruckRate variantRate = rateVariants[rateIx];
                    variantRate.TotalDeliveryCost = rateVariants[rateIx].PriceFirstPoint;
                    for (int pointNumber = 1; pointNumber < mapDelivery.Count; pointNumber++)
                    {
                        TruckRate addPointRate =
                            ShefflerWB.RateList.Where(x => x.Company == variantRate.Company &&
                                                x.Tonnage == variantRate.Tonnage &&
                                                x.City == mapDelivery[pointNumber].City).First();
                        if (addPointRate.PriceAddPoint > 0)
                            variantRate.TotalDeliveryCost += addPointRate.PriceAddPoint;
                    }
                    rateVariants[rateIx] = variantRate;
                }
                rateVariants = rateVariants.OrderBy(r => r.TotalDeliveryCost).ToList();
            }
            return rateVariants;
        }

    }
}
