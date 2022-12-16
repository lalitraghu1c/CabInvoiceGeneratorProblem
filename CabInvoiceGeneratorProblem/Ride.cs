using System;
namespace CabInvoiceGenerator
{
    public class Ride
    {
        public double rideDistance;
        public double rideTime;

        public Ride(double rideDistance, double rideTime)
        {
            this.rideDistance = rideDistance;
            this.rideTime = rideTime;
        }
    }
}