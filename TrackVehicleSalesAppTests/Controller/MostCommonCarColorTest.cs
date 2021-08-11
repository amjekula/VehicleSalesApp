using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TrackVehicleSalesApp.Controller;
using TrackVehicleSalesApp.Model;

namespace TrackVehicleSalesAppTests.Controller
{
    [TestClass]
    public class MostCommonCarColorTest
    {
        [DataRow(2011, 2020)]
        [TestMethod]
        //[Ignore]
        public void MostCommonCarColor_WithExpectedStartYear_ReturnsFirstElementData(int startYear, int endYear)
        {
            MostCommonCarColor colorInstance = new MostCommonCarColor();

            Dictionary<string, int> salesByManufacturer = colorInstance.MostCommonColor(startYear, endYear);
            VehicleSales getColor = new VehicleSales().WithColor(salesByManufacturer.ElementAt(0).Key).Build();

            Console.WriteLine(startYear + "-" + endYear + " Colour: " + getColor.colour);
            Assert.IsTrue(getColor.colour.Equals("white"));
        }
    }
}
