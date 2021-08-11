using System;
using System.Collections.Generic;
using System.Text;

namespace TrackVehicleSalesApp.Model
{
    public class SalesHistory
    {
        public string year { get; set; }
        public int vehiclesSold { get; set; }

        public SalesHistory WithYear(string year)
        {
            this.year = year;
            return this;
        }

        public SalesHistory WithVehiclesSold(int vehiclesSold)
        {
            this.vehiclesSold = vehiclesSold;
            return this;
        }

        public SalesHistory Build()
        {
            return this;
        }
    }
}
