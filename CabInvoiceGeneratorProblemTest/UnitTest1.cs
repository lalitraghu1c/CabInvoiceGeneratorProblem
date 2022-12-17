using CabInvoiceGenerator;
using System;
using static CabInvoiceGeneratorProblem.RideOption;

namespace CabInvoiceGeneratorProblem
{
    public class CabInvoiceGeneratorProblemTest
    {
        private CabInvoiceGenerator cabInvoiceGenerator;
        [SetUp]
        public void Setup() //For creating instance of class
        {
            this.cabInvoiceGenerator = new CabInvoiceGenerator();
        }

        [Test]
        //Test to get total fare using given time and distance
        public void GivenProperDistanceAndTimeForSingleRide_ShouldReturnTotalFare()
        {
            double totalFare = cabInvoiceGenerator.CalculateFare(3.0, 5.0);
            Assert.AreEqual(35.0, totalFare);
        }
        [Test]
        //Test to get Mininum Fare when given less than minimum fare
        public void GivenProperDistanceAndTimeForSingleRide_LessThanMinFare_ShouldReturnMinimumFare()
        {
            double CabFare = cabInvoiceGenerator.CalculateFare(0.1, 0.5);
            Assert.AreEqual(5, CabFare);
        }
        [Test]
        //Test to get aggregate fare for multiple rides
        public void GivenProperDistanceAndTimeForMultipleRide_ShouldReturnAggregateFare()
        {
            Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0), new Ride(0.1, 0.5) };
            InvoiceSummary invoiceSummary = this.cabInvoiceGenerator.GetMultipleRidersFare(ride);
            Assert.AreEqual(65, invoiceSummary.totalFare);
        }
        [Test]
        //Test to get invoice summary for userID
        public void GivenProperDistanceAndTimeForRide_ShouldReturnFare()
        {
            CabInvoiceGenerator generator = new CabInvoiceGenerator();
            Ride[] ride = { new Ride(3.0, 5.0), new Ride(2.0, 5.0) };
            generator.MapRidesToUser("lalit", ride);
            InvoiceSummary summary = generator.GetInvoiceSummary("lalit");
            Assert.AreEqual(summary.totalFare, 60.0);
        }
        [Test]
        //Test to get fare for premium rides
        public void GivenProperDistanceAndTimeForPremiumeRide_ShouldReturnPremiumFare()
        {
            try
            {
                double distance = -5; //in km
                int time = 20;   //in minute
                CabInvoiceGenerator summary = new CabInvoiceGenerator(RideType.NORMAL);
                double fare = summary.CalculateFare(distance, time);
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message,"Invalid Ride Type");
            }
        }
    }
}