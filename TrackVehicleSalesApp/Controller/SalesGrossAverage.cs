using System;
using System.Collections.Generic;
using System.Text;
using TrackVehicleSalesApp.Model;
using TrackVehicleSalesApp.Util;

namespace TrackVehicleSalesApp.Controller
{
    public class SalesGrossAverage
    {
        private SalesExtension extension = new SalesExtension();
        private List<VehicleSales> vehicleSalesList = null;
        private HashSet<string> modelList = null;

        public SalesGrossAverage()
        {
            if (vehicleSalesList == null)
            {
                vehicleSalesList = extension.GetVehicleSales();
                modelList = extension.GetModel(vehicleSalesList);
            }
        }

        public int GrossAverage(int startYear, int endYear)
        {
            int total = 0;
            int count = 0;

            TotalSalesPerManufacturer salesPerManufacturer = new TotalSalesPerManufacturer();
            VehicleSales[] vehSoldArray = extension.RetrieveVehicleHistory(vehicleSalesList);
            extension.setYear(vehSoldArray);

            foreach (KeyValuePair<string, int> kvp in salesPerManufacturer.ManufacturerTotalSales(startYear, endYear))
            {
                count++;
                total = total + kvp.Value;
            }
            return total / extension.numberOfItems;
        }
    }
}
