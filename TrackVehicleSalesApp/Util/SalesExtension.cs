using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using TrackVehicleSalesApp.Model;

namespace TrackVehicleSalesApp.Util
{
    public class SalesExtension
    {
        public List<string> manufacturerList = new List<string>();
        public List<string> colorList = new List<string>();
        public int numberOfItems = 0;

        public string RetrieveJson()
        {
            WebClient client = new WebClient();
            return client.DownloadString("https://raw.githubusercontent.com/stormsimmons/mock-data/main/mock-data.json");
        }

        public List<VehicleSales> GetVehicleSales()
        {
            string json = RetrieveJson();
            List<VehicleSales> salesList = JsonConvert.DeserializeObject<List<VehicleSales>>(json);
            return salesList;
        }

        public List<SalesHistory> GetSalesHistory()
        {
            List<SalesHistory> sales = GetVehicleSales().ElementAt(0).salesHistory.ToList();
            return sales;
        }


        public VehicleSales[] RetrieveVehicleHistory(List<VehicleSales> vehicleSales)
        {
            VehicleSales[] vehSoldArray = vehicleSales.GroupBy(x => new { x.salesHistory, x.colour })
                                        .Select(y => new VehicleSales()
                                        {
                                            salesHistory = y.Key.salesHistory
                                        }).ToArray();

            return vehSoldArray;
        }

        public List<int> setYear(VehicleSales[] vehSoldArray)
        {
            List<int> yearList = new List<int>();
            int year = 0;
            for (int x = 0; x < vehSoldArray.Length; x++)
            {
                for (int y = 0; y < vehSoldArray[x].salesHistory.Length; y++)
                {
                    numberOfItems++;
                    year = Int32.Parse(vehSoldArray[x].salesHistory[y].year);
                    yearList.Add(year);

                }
            }
            return yearList;
        }

        public HashSet<int> GetVehiclesSold(List<VehicleSales> vehicleSales, int startYear, int endYear)
        {
            int total = 0;
            int year = 0;

            HashSet<int> vehiclesSoldSet = new HashSet<int>();
            VehicleSales[] vehSoldArray = RetrieveVehicleHistory(vehicleSales);

            for (int x = 0; x < vehSoldArray.Length; x++)
            {
                for (int y = 0; y < vehSoldArray[x].salesHistory.Length; y++)
                {
                    year = Int32.Parse(vehSoldArray[x].salesHistory[y].year);

                    if (year >= startYear && year <= endYear)
                    {
                        total += vehSoldArray[x].salesHistory[y].vehiclesSold;
                    }
                }
                vehiclesSoldSet.Add(total);
                total = 0;
            }
            return vehiclesSoldSet;
        }

        public HashSet<string> GetModel(List<VehicleSales> vehicleSales)
        {
            HashSet<string> modelSet = new HashSet<string>();

            var modelsArray = vehicleSales.GroupBy(x => new { x.model, x.manufacturer, x.colour })
                                                .Where(x => x.Skip(0).Any()).ToArray();

            for (int y = 0; y < modelsArray.Length; y++)
            {
                foreach (var dupeList in modelsArray)
                {

                    manufacturerList.Add(dupeList.Key.manufacturer);
                    colorList.Add(dupeList.Key.colour);
                    modelSet.Add(dupeList.Key.model);
                }
            }
            return modelSet;
        }
    }
}
