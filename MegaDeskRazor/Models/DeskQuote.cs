﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MegaDeskRazor.Models;
using System.ComponentModel.DataAnnotations;

namespace MegaDeskRazor.Models
{
    public class DeskQuote
    {
        Dictionary<String, int> materials =new Dictionary<string, int> 
        {
            { "Oak", 200 },
            { "Laminate", 100 },
            { "Pine", 50 },
            { "Rosewood", 300 },
            { "Veneer", 125 },
        };

        public int DeskQuoteId { get; set; }

        //[ForeignKey("DeskId")]
        public int DeskId { get; set; }
        public string CustomerName { get; set ; }
        public DateTime Date { get; set; }
        public int TotalCost { get; set; }
        public int SurfaceAreaPrice { get; set; }
        public int ShippingPrice { get; set; }
        public int DrawerPrice { get; set; }
        public int MaterialPrice { get; set; }

        public int ProductionTime { get; set; }
        public Desk Desk { get; set; }

        //public DeskQuote(Desk desk, int prodTime, String name)
        //{
        //    this.desk = desk;
        //    materials.TryGetValue(desk.SurfaceMaterial, out materialPrice);
        //    productionTime = prodTime;
        //    customerName = name;
        //    date = DateTime.Now;
        //}

        //public DeskQuote(int totalCost, int surfaceAreaPrice, int shippingPrice, int drawerPrice, int materialPrice, DateTime datetime, string name, int productionTime, Desk desk)
        //{
        //    this.totalCost = totalCost;
        //    this.surfaceAreaPrice = surfaceAreaPrice;
        //    this.shippingPrice = shippingPrice;
        //    this.drawerPrice = drawerPrice;
        //    this.materialPrice = materialPrice;
        //    this.date = datetime;
        //    customerName = name;
        //    this.productionTime = productionTime;
        //    this.desk = desk;

        //}

        private int calcShippingPrice()
        {
            string[] pricesString = File.ReadAllLines(@"rushOrder.txt", Encoding.UTF8);
            int[] shippingPricesList = new int[pricesString.Length];
            for (int i = 0; i < pricesString.Length; i++)
                shippingPricesList[i] = Convert.ToInt32(pricesString[i]);

            switch (ProductionTime)
            {
                case 3:
                    if(Desk.SurfaceArea < 1000)
                    {
                        return shippingPricesList[0];
                    }
                    else if (Desk.SurfaceArea < 2000)
                    {
                        return shippingPricesList[1];
                    }
                    else
                    {
                        return shippingPricesList[2];
                    }
                case 5:
                    if (Desk.SurfaceArea < 1000)
                    {
                        return shippingPricesList[3];
                    }
                    else if (Desk.SurfaceArea < 2000)
                    {
                        return shippingPricesList[4];
                    }
                    else
                    {
                        return shippingPricesList[5];
                    }

                case 7:
                    if (Desk.SurfaceArea < 1000)
                    {
                        return shippingPricesList[6];
                    }
                    else if (Desk.SurfaceArea < 2000)
                    {
                        return shippingPricesList[7];
                    }
                    else
                    {
                        return shippingPricesList[8];
                    }
                default:
                    return 0;

            }
        }
        public void calcPrice()
        {
             ShippingPrice= calcShippingPrice();
            DrawerPrice = (50* Desk.DrawerNum);
            if(Desk.SurfaceArea > 1000)
            {
                SurfaceAreaPrice = (1 * Desk.SurfaceArea);

            }
            else
            {
                SurfaceAreaPrice = 0;
            }
            TotalCost= 200 + ShippingPrice + DrawerPrice + SurfaceAreaPrice + MaterialPrice;
        }

    }
    //public enum ShippingTimes
    //{
    //    14,
    //    3,
    //    5,
    //    7
    //}
}