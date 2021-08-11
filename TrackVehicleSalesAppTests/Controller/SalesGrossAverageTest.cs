using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TrackVehicleSalesApp.Controller;
using TrackVehicleSalesApp.Model;

namespace TrackVehicleSalesAppTests.Controller
{
    [TestClass]
    public class SalesGrossAverageTest
    {
        [DataRow(2011, 2020)]
        [TestMethod]
        //[Ignore]
        public void SalesGrossAverage_WithExpectedYearRange_ReturnsAverage(int startYear, int endYear)
        {
            SalesGrossAverage averageInstance = new SalesGrossAverage();

            int average = averageInstance.GrossAverage(startYear, endYear);

            Console.WriteLine(startYear + "-" + endYear + " Average: " + average);
            Assert.AreEqual(5837, average);
        }

        [DataRow(2020, 2020)]
        [TestMethod]
        //[Ignore]
        public void SalesGrossAverage_WithUpdatedYearRange_ReturnsAverage(int startYear, int endYear)
        {
            SalesGrossAverage averageInstance = new SalesGrossAverage();

            int average = averageInstance.GrossAverage(startYear, endYear);

            Console.WriteLine(startYear + "-" + endYear + " Average: " + average);
            Assert.AreNotEqual(5837, average);
        }
    }
}
