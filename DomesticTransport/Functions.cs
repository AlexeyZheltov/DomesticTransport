﻿using DomesticTransport.Model;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Config = DomesticTransport.Properties.Settings;
using Excel = Microsoft.Office.Interop.Excel;

namespace DomesticTransport
{
    class Functions
    {
        // private DomesticTransport.Properties.Settings 

        /// <summary>
        /// Вывести на рабочий лист доставки 
        /// </summary>
        public void SetDelivery()
        {

            SapFiles sapFiles = new SapFiles();
            sapFiles.ShowDialog();
            if (sapFiles.DialogResult == DialogResult.OK)
            {
                string sap = "";
                string orders = "";
                try
                {
                    sap = sapFiles.ExportFile;
                    orders = sapFiles.OrderFile;
                }
                catch (Exception ex)
                {
                    return;
                }
                finally
                {
                    sapFiles.Close();
                }

                List<Delivery> deliveries = GetDeliveries(sap, orders);

                Worksheet deliverySheet = Globals.ThisWorkbook.Sheets["Delivery"];
                ListObject carrierTable = deliverySheet.ListObjects["TableCarrier"];
                ListObject invoiciesTable = deliverySheet.ListObjects["TableInvoicies"];

                ClearListObj(carrierTable);
                if (invoiciesTable.DataBodyRange.Rows.Count > 0)
                { invoiciesTable.DataBodyRange.Rows.Delete();}

                if (deliveries != null)
                {
                    foreach (Delivery delivery in deliveries)
                    {
                        PrintDelivery(delivery, deliverySheet,carrierTable, invoiciesTable);
                        System.Windows.Forms.Application.DoEvents();
                    }

                }
            }
        }

        private void ClearListObj(ListObject listObject)
        {
          
            Worksheet worksheet = listObject.Parent;
            for (int i= listObject.ListRows.Count; i>0;i--)
            {
                    ListRow listRow = listObject.ListRows[i];
                worksheet.Rows[listRow.Range.Row].Delete();
            }
            
        }
        private void AddListRow(ListObject listObject)
        {
            Worksheet worksheet = listObject.Parent;
            if ( listObject.ListRows.Count > 0)
            {
            worksheet.Rows[listObject.ListRows[listObject.ListRows.Count].Range.Row + 1].Insert();
            }
            else
            {
                worksheet.Rows[listObject.HeaderRowRange.Row+2].Insert();
            }
            listObject.ListRows.Add();
        }

        private void PrintDelivery(Delivery delivery, Worksheet deliverySheet, ListObject CarrierTable, ListObject OrderTable)
        {
            //Worksheet deliverySheet = Globals.ThisWorkbook.Sheets["Delivery"];
            //ListObject CarrierTable = deliverySheet.ListObjects["TableCarrier"];
            //ListObject InvoiciesTable = deliverySheet.ListObjects["TableInvoicies"];
            if (CarrierTable == null || OrderTable == null)
            {
                MessageBox.Show("Отсутствует таблица");
                return;
            }
            ListRow rowCarrier = null;
            if (CarrierTable.ListRows.Count == 0)
            {
                AddListRow(CarrierTable);
                rowCarrier = CarrierTable.ListRows[1];//  }
            }
            else
            {
                AddListRow(CarrierTable);
                rowCarrier = CarrierTable.ListRows[CarrierTable.ListRows.Count-1];
            }                
                rowCarrier.Range[1, 1].Value = rowCarrier.Index;
                
                //  rowCarrier.Range[1, 1].Value = delivery.Carrier?.Id  ?? 0 ;
                // rowCarrier.Range[1, 2].Value = delivery.Carrier?.Name ?? "";
                // rowCarrier.Range[1, 3].Value = delivery.Carrier?.Truck?.Number ?? "";
                //  rowCarrier.Range[1, 4].Value = delivery.Carrier?.Truck?.Mark ?? "";
                rowCarrier.Range[1, 5].Value = delivery.Carrier?.Truck?.Tonnage ?? 0;
                rowCarrier.Range[1, 6].Value = delivery.Carrier?.Name ?? "";

                ListRow rowOrder;

                foreach (Order order in delivery.Invoices)
                {
                    // if (CarrierTable.ListRows.Count == 0) CarrierTable.ListRows.AddEx()

                    if (OrderTable.ListRows.Count == 0)
                    {
                        OrderTable.ListRows.Add();
                    rowOrder = OrderTable.ListRows[1];
                    }
                    else
                    {
                        OrderTable.ListRows.Add();
                        rowOrder = OrderTable.ListRows[OrderTable.ListRows.Count-1]; // InvoiciesTable.ListRows.AddEx(InvoiciesTable.ListRows.Count - 1);
                    }
                    int column = 0;
                        rowOrder.Range[1, ++column].Value = rowCarrier.Index; //delivery.Carrier?.Id ?? 0;
                        rowOrder.Range[1, ++column].Value = order.TransportationUnit;
                        rowOrder.Range[1, ++column].Value = order.Customer?.Id ?? 0;
                        rowOrder.Range[1, ++column].Value = "";
                        rowOrder.Range[1, ++column].Value = order.Route;
                        rowOrder.Range[1, ++column].Value = order.PalletsCount;
                        rowOrder.Range[1, ++column].Value = order.Weight;
                        rowOrder.Range[1, ++column].Value = order.Cost;

                }


                //int offset = number > 1 ? 20 : Config.Default.HeaderRow;
                //int tableRows = 10;
                //int tableColumns = 10;

                // Range range = deliverySheet.Range[deliverySheet.Cells[number + offset, 2],
                //                                         deliverySheet.Cells[number + offset + tableRows, 2 + tableColumns]];
                //range.Cells[1, 1].Value = "s11s";
                // range.Cells[2, 1].Value = delivery.DateCreate.ToString(); 
            

        }

        /// <summary>
        /// Поиск 
        /// </summary>
        /// <param name="sap"></param>
        /// <returns></returns>
        public List<Delivery> GetDeliveries(string sap, string orders)
        {
           List<Delivery> deliveries = null;
            Delivery delivery = null;
            Workbook sapBook = null;
            Workbook orderBook = null;
            try
            {
                orderBook = Globals.ThisWorkbook.Application.Workbooks.Open(Filename: orders);
                sapBook = Globals.ThisWorkbook.Application.Workbooks.Open(Filename: sap);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось открыть книгу Excel");
            }
            Worksheet sheet = sapBook.Sheets[1];
            if (sheet != null)
            {
                int lastRow = sheet.Cells[sheet.Rows.Count, 1].End(XlDirection.xlUp).Row;
                int lastColumn = sheet.UsedRange.Column + sheet.UsedRange.Columns.Count - 1;
                Range range = sheet.Range[sheet.Cells[2, 1], sheet.Cells[lastRow, lastColumn]];         

                foreach (Range row in range.Rows)
                {
                    Order order = ReadSapRow(row);
                    if (order != null)
                    {
                        Debug.WriteLine(row.Row+ " "+ order.TransportationUnit );
                        if (!string.IsNullOrWhiteSpace(order.TransportationUnit))
                        {
                            List<string>  orderInfo = GetOrderInfo(orderBook.Sheets[1], order.TransportationUnit);
                            if (orderInfo != null)
                            {
                                string costStr = orderInfo[1];
                                costStr= costStr.Replace("Стоимость товаров без НДС:","");
                                costStr = costStr.Replace("RUB", "");
                                costStr = costStr.Replace(".", "");                                
                                costStr = costStr.Trim();
                                order.Cost = double.TryParse(costStr, out double cost) ? cost : 0;

                               // order.Customer.   //Улица , Город
                            }
                        }



                        delivery = deliveries?.Find(d => d.Invoices.Find(i => i.Route == order.Route) != null);
                        if (delivery != null)
                        {
                            delivery.Invoices.Add(order);
                        }
                        else
                        {
                            delivery = new Delivery();
                            delivery.Invoices = new List<Order>();
                            delivery.Invoices.Add(order);
                            if (deliveries == null) deliveries = new List<Delivery>();
                            deliveries.Add(delivery);
                        }
                    }

                    //Комплектовать авто


                }

            }
            return deliveries;
        }

        /// <summary>
        /// Собираем из строки выгруза данные для формирования доставки
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private Order ReadSapRow(Range row)
        {
            /// ТТН
            Order order = new Order();
            Debug.WriteLine(row.Row);
          order.TransportationUnit = row.Cells[1, 4].Text ;
          string idCusomer = row.Cells[1, 5].Text;
          order.Id = row.Cells[1, 7].Text;
            if (string.IsNullOrWhiteSpace(idCusomer) || string.IsNullOrWhiteSpace(order.Id))
            {
                return null;
            }            
                order.Customer = new Customer(idCusomer);                       

            string weight = row.Cells[1, 8].Text;
            order.Weight = double.TryParse(weight, out double wgt) ? wgt : 0;

            string palletsCount = row.Cells[1, 9].Text;
            order.PalletsCount = int.TryParse(palletsCount, out int count) ? count : 0;
           
            order.Route = row.Cells[1, 11].Text;


                //order.Customer = string.IsNullOrWhiteSpace(idCusomer) ? null : new Customer(idCusomer);
            //string idDocInvoice = row.Cells[1, 3].Value;
          //  if (string.IsNullOrWhiteSpace(idDocInvoice)) return null;
          //  order.Id = int.TryParse(idDocInvoice, out int id) ? id : 0;
            return order;
        }

        private List<string>  GetOrderInfo(Worksheet sheet, string transportationUnit)
        {
            Range findRange = sheet.Columns[1];
            //string search = "№ ТТН:" + new string('0', 18 - transportationUnit.Length) + transportationUnit;
            string search = new string('0', 18 - transportationUnit.Length) + transportationUnit;
            Range fcell = findRange.Find(What: search, LookIn: XlFindLookIn.xlValues);
          
            if (fcell == null && fcell.Value.Trim().Contains("ТТН:")) return null;

            int rowStart = fcell.Row;
            int lastRow = sheet.Cells[sheet.Rows.Count, 1].End(XlDirection.xlUp).Row;

            int rowEnd = rowStart;
            List<string> info = new List<string>();
            do
            {
                fcell = findRange.Cells[rowEnd++, 1];
                string cellText = fcell.Value;
                cellText.Trim();
                cellText = cellText.Replace("\t","");
                cellText = cellText.Replace(";;;", "");
                if (string.IsNullOrEmpty(cellText.Replace(";", ""))) break;
                info.Add(cellText);                
            }
            while (rowEnd <= lastRow);
            return info; //findRange[findRange.Cells[rowStart, 1], findRange.Cells[rowEnd, 1]];
        }


        /// <summary>
        /// Ищет в строке или на листе ячейку с заголовком и возвращает столбец
        /// </summary>
        /// <param name="sh"></param>
        /// <param name="header"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private int GetColumn(Worksheet sh, string header, int row = 0)
        {
            Range findRange = row == 0 ? sh.UsedRange : sh.Rows[row];
            Range fcell = findRange.Find(What: header, LookIn: XlFindLookIn.xlValues);
            return fcell == null ? 0 : fcell.Column;
        }


    }
}
