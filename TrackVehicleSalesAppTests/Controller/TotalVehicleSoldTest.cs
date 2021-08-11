using Microsoft.VisualStudio.TestTools.UnitTesting;
using TrackVehicleSalesApp.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Xunit.Sdk;
using TrackVehicleSalesApp.Model;
using TrackVehicleSalesApp.Controller;

namespace TrackVehicleSalesApp.Tests
{
    [TestClass]
    public class TotalVehicleSoldTest
    {
        [DataRow(2011, 2020)]
        [TestMethod]
        //[Ignore]
        public void TotalVehiclesSold_WithValidData_ReturnsLastElement(int startYear, int endYear)
        {
            TotalVehicleSold salesInstance = new TotalVehicleSold();

            Dictionary<string, int> salesByModel = salesInstance.TotalVehiclesSold(startYear, endYear);
            VehicleSales modelSales = new VehicleSales().WithModel(salesByModel.ElementAt(0).Key).Build();
            SalesHistory salesHistoryIncome = new SalesHistory().WithVehiclesSold(salesByModel.ElementAt(0).Value).Build();

            Console.WriteLine(startYear + "-" + endYear + " Model: " + modelSales.model + " Income "
                                                                        + salesHistoryIncome.vehiclesSold);
            Assert.AreEqual(55323, salesHistoryIncome.vehiclesSold);
            Assert.AreEqual("1 Series", modelSales.model);
        }

        [DataRow(2017, 2020)]
        [TestMethod]
        //[Ignore]
        public void TotalVehiclesSold_StartYearChanged_ReturnFilteredPrice(int startYear, int endYear)
        {
            TotalVehicleSold salesInstance = new TotalVehicleSold();

            Dictionary<string, int> salesByModel = salesInstance.TotalVehiclesSold(startYear, endYear);
            VehicleSales modelSales = new VehicleSales().WithModel(salesByModel.ElementAt(0).Key).Build();
            SalesHistory salesHistoryIncome = new SalesHistory().WithVehiclesSold(salesByModel.ElementAt(0).Value).Build();

            Console.WriteLine(startYear + "-" + endYear + " Model: " + modelSales.model + " Income " + salesHistoryIncome.vehiclesSold);
            Assert.AreNotEqual(55323, salesHistoryIncome.vehiclesSold);
        }
    }
}