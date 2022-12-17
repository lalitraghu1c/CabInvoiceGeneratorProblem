using CabInvoiceGenerator;
using System;
using static CabInvoiceGeneratorProblem.RideOption;

namespace CabInvoiceGeneratorProblem
{
    public class CabInvoiceGenerator
    {
        RideType rideType;
        private readonly double COST_PER_KILOMETER = 10.0;
        private readonly double COST_PER_MINUTE = 1.0;
        private readonly double MINIMUM_FARE = 5.0;
        private double CAB_FARE = 0.0;
        public CabInvoiceGenerator()
        {

        }
        public CabInvoiceGenerator(RideType rideType)
        {
            {
                this.rideType = rideType;
                this.rideRepository = new RideRepository();
                try
                {
                    if (rideType.Equals(RideType.PREMIUM))
                    {
                        this.COST_PER_KILOMETER = 15;
                        this.COST_PER_MINUTE = 2;
                        this.MINIMUM_FARE = 20;
                    }
                    else if (rideType.Equals(RideType.NORMAL))
                    {
                        this.COST_PER_KILOMETER = 10;
                        this.COST_PER_MINUTE = 1;
                        this.MINIMUM_FARE = 5;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid Ride Type");
                }
            }
        }
        private RideRepository rideRepository = new RideRepository();

        public double CalculateFare(double distance, double time)
        {
            this.CAB_FARE = (distance * COST_PER_KILOMETER) + (time * COST_PER_MINUTE);
            return Math.Max(this.CAB_FARE, MINIMUM_FARE);
        }
        public InvoiceSummary GetMultipleRidersFare(Ride[] rides)
        {
            double totalRideFare = 0.0;
            foreach (Ride ride in rides)
            {
                totalRideFare += this.CalculateFare(ride.rideDistance, ride.rideTime);
            }
            return new InvoiceSummary(totalRideFare, rides.Length);
        }
        public void MapRidesToUser(string userID, Ride[] rides)
        {
            this.rideRepository.AddCabRides(userID, rides);
        }
        public InvoiceSummary GetInvoiceSummary(string userID)
        {
            return this.GetMultipleRidersFare(this.rideRepository.GetCabRides(userID));
        }
    }
}