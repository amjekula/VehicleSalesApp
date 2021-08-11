using System;
using System.Collections.Generic;
using System.Text;

namespace TrackVehicleSalesApp.Model
{ 
    public class VehicleSales
    {
        public int id { get; set; }
        public string model { get; set; }
        public string colour { get; set; }
        public string manufacturer { get; set; }
        public SalesHistory[] salesHistory { get; set; }

        public VehicleSales()
        {
            this.salesHistory = new SalesHistory[20];
        }

        public VehicleSales WithId(int id)
        {
            this.id = id;
            return this;
        }
        public VehicleSales WithModel(string model)
        {
            this.model = model;
            return this;
        }
        public VehicleSales WithColor(string colour)
        {
            this.colour = colour;
            return this;
        }
        public VehicleSales WithManufacturer(string manufacturer)
        {
            this.manufacturer = manufacturer;
            return this;
        }
        public VehicleSales WithSalesHistory(SalesHistory[] salesHistory)
        {
            this.salesHistory = salesHistory;
            return this;
        }

        public VehicleSales Build()
        {
            return this;
        }
        public int CompareManufacturer(VehicleSales sales1, VehicleSales sales2)
        {
            return String.Compare(sales1.manufacturer, sales2.manufacturer);
        }
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
