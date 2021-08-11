using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackVehicleSalesApp.Model;
using TrackVehicleSalesApp.Util;

namespace TrackVehicleSalesApp.Controller
{
    public class TotalSalesPerManufacturer
    {
        private SalesExtension extension = new SalesExtension();
        private List<VehicleSales> vehicleSalesList = null;
        private HashSet<string> modelList = null;
        private List<string> manufacturerList = null;

        public TotalSalesPerManufacturer()
        {
            if (vehicleSalesList == null)
            {
                vehicleSalesList = extension.GetVehicleSales();
                modelList = extension.GetModel(vehicleSalesList);
            }
        }

        public Dictionary<string, int> ManufacturerTotalSales(int startYear, int endYear)
        {
            Dictionary<string, int> valuePairs = new Dictionary<string, int>();
            manufacturerList = extension.manufacturerList;

            int total = 0;
            HashSet<int> vehiclesSoldSet = extension.GetVehiclesSold(vehicleSalesList, startYear, endYear);

            for (int x = 0; x < vehiclesSoldSet.Count; x++)
            {
                if (manufacturerList.ElementAt(x) == manufacturerList.ElementAt(x + 1))
                {

                    if (x > 0 && manufacturerList.ElementAt(x - 1) == manufacturerList.ElementAt(x))
                    {
                        total = total + vehiclesSoldSet.ElementAt(x);
                    }
                    else
                    {
                        total = total + vehiclesSoldSet.ElementAt(x);
                    }
                }
                else
                {
                    total = total + vehiclesSoldSet.ElementAt(x);
                    valuePairs.Add(manufacturerList.ElementAt(x), total);
                    total = 0;
                }

            }
            return valuePairs;
        }
    }
}
