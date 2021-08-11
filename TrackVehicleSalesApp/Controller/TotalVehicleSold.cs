using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackVehicleSalesApp.Model;
using TrackVehicleSalesApp.Util;

namespace TrackVehicleSalesApp.Controller
{
    public class TotalVehicleSold
    {
        private SalesExtension extension = new SalesExtension();
        private List<VehicleSales> vehicleSalesList = null;
        //private HashSet<string> modelList = null;

        public TotalVehicleSold()
        {
            if (vehicleSalesList == null)
            {
                vehicleSalesList = extension.GetVehicleSales();
                //modelList = helper.GetModel(vehicleSalesList);
            }
        }

        public Dictionary<string, int> TotalVehiclesSold(int startYear, int endYear)
        {

            Dictionary<string, int> valuePairs = new Dictionary<string, int>();

            HashSet<int> vehiclesSoldSet = extension.GetVehiclesSold(vehicleSalesList, startYear, endYear);
            HashSet<string> modelSet = extension.GetModel(vehicleSalesList);

            for (int x = 0; x < vehiclesSoldSet.Count; x++)
            {
                valuePairs.Add(modelSet.ElementAt(x), vehiclesSoldSet.ElementAt(x));
            }
            return valuePairs;
        }
    }
}
