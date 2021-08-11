using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TrackVehicleSalesApp.Model;
using TrackVehicleSalesApp.Util;

namespace TrackVehicleSalesApp.Controller
{
    public class MostCommonCarColor
    {
        private SalesExtension extension = new SalesExtension();
        private List<VehicleSales> vehicleSalesList = null;
        private HashSet<string> modelList = null;

        public MostCommonCarColor()
        {
            if (vehicleSalesList == null)
            {
                vehicleSalesList = extension.GetVehicleSales();
                modelList = extension.GetModel(vehicleSalesList);
            }
        }

        public Dictionary<string, int> MostCommonColor(int startYear, int endYear)
        {
            List<SalesHistory> salesHistories = extension.GetSalesHistory();
            Dictionary<string, int> valuePairs = new Dictionary<string, int>();

            for (int x = 0; x < salesHistories.Count(); x++)
            {
                int year = Int32.Parse(salesHistories.ElementAt(x).year);

                if (year >= startYear && year <= endYear)
                {
                    foreach (string value in extension.colorList)
                    {
                        if (valuePairs.TryGetValue(value, out int count))
                        {
                            valuePairs[value] = count + 1;
                        }
                        else
                        {
                            valuePairs.Add(value, 1);
                        }
                    }
                }

            }

            return valuePairs;
        }

    }
}
