using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInvoiceGeneretor
{
    public class InvoiceGenerator
    {
        RideType rideType;
        private RideRepository rideRepository;
        private double MINIMUM_COST_PER_KM;
        private int COST_PER_TIME;
        private double MINIMUM_FARE;
        public InvoiceGenerator(RideType rideType)
        {
            this.rideType = rideType;
            this.rideRepository = new RideRepository();
            try
            {
                if (rideType.Equals(RideType.PREMIUM))
                {
                    this.MINIMUM_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MINIMUM_FARE = 20;
                }
                else if (rideType.Equals(RideType.NORMAL))
                {
                    this.MINIMUM_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MINIMUM_FARE = 5;
                }
            }catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALIDE_RIDE_TYPE, "Inavald ride type");
            }
        }
        public double CalculateFare(double distance,int time)
        {
            double totalfare = 0;
            try
            {
                totalfare = distance * MINIMUM_COST_PER_KM + time * COST_PER_TIME;
            }
            catch (CabInvoiceException)
            {
                if (rideType.Equals(null))
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDE, "Ride is null");
                }  
                else if (distance <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INAVALIDE_DISTANCE, "INavalid distance");
                }
                if (time <= 0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALIDE_TIEME, "Inavalid time");
                }
            }
            return Math.Max(totalfare, MINIMUM_FARE);
        }
        public InvoiceSummary Calculatefare(Ride[] rides)
        {
            double totalfare = 0;
            try
            {
                //calculating total fare for all rides
                foreach(Ride ride in rides)
                {
                    totalfare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch (CabInvoiceException)
            {
                if (rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDE, "Null rides");
                }
            }
            return new InvoiceSummary(rides.Length, totalfare);
        }
        //method to add userid
        public void AddRides(string userID, Ride[] rides)
        {
            try
            {
                //adding rides to user
                rideRepository.AddRide(userID, rides);
            }
            catch (CabInvoiceException)
            {
                if(rides == null)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDE, "Rides are null");
                }
            }
        }
        //method to get summary by userID
      public InvoiceSummary GetInvoiceSummary(string userID)
        {
            try
            {
                return this.Calculatefare(rideRepository.GetRides(userID));
            }
            catch (CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALIDE_USERID, "invalid user id");
            }
        }
    }
}
