using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TrackVehicleSalesApp.Controller;
using TrackVehicleSalesApp.Model;
using Xunit.Sdk;


namespace TrackVehicleSalesAppTests.Controller
{
    [TestClass]
    public class TotalSalesPerManufacturerTest
    {
        [DataRow(2011, 2020)]
        [TestMethod]
        //[Ignore]
        public void SalesPerManufacturer_WithExpectedStartYear_ReturnsFirstElementData(int startYear, int endYear)
        {
            TotalSalesPerManufacturer salesInstance = new TotalSalesPerManufacturer();

            Dictionary<string, int> salesByManufacturer = salesInstance.ManufacturerTotalSales(startYear, endYear);
            VehicleSales manufacturer = new VehicleSales().WithManufacturer(salesByManufacturer.ElementAt(0).Key).Build();
            SalesHistory salesHistoryIncome = new SalesHistory().WithVehiclesSold(salesByManufacturer.ElementAt(0).Value).Build();

            Console.WriteLine(startYear + "-" + endYear +  " Manufacturer: " + manufacturer.manufacturer + " Income "
                                                        + salesHistoryIncome.vehiclesSold);
            Assert.IsTrue(manufacturer.manufacturer.Equals("BMW"));
            Assert.AreEqual(178844, salesHistoryIncome.vehiclesSold);
        }

        [DataRow(2014, 2020)]
        [TestMethod]
        //[Ignore]
        public void SalesPerManufacturer_StartYearIncremented_ReturnsFirstElementData(int startYear, int endYear)
        {
            TotalSalesPerManufacturer salesInstance = new TotalSalesPerManufacturer();

            Dictionary<string, int> salesByManufacturer = salesInstance.ManufacturerTotalSales(startYear, endYear);
            VehicleSales manufacturer = new VehicleSales().WithManufacturer(salesByManufacturer.ElementAt(0).Key).Build();
            SalesHistory salesHistoryIncome = new SalesHistory().WithVehiclesSold(salesByManufacturer.ElementAt(0).Value).Build();

            Console.WriteLine(startYear + "-" + endYear + " Manufacturer: " + manufacturer.manufacturer +
                                                " Income " + salesHistoryIncome.vehiclesSold);
            Assert.IsTrue(manufacturer.manufacturer.Equals("BMW"));
            Assert.IsFalse(salesHistoryIncome.vehiclesSold == 178844);
        }
    }
}
