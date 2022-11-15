using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarInvoiceGeneretor
{
    public class RideRepository
    {
        //dictonary to store  userid and rides list
        Dictionary<string ,List<Ride>> userRides = null;
        //constortor to create dictonary
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }
        //method to add list to specified userid
        public void AddRide(string userID, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userID);
            try
            {
                if(!rideList)
                {
                    List<Ride> list = new List<Ride>();
                    list.AddRange(rides);
                    this.userRides.Add(userID ,list);
                }
            }catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDE, "Rides are null");
            }
        }
        //to get rides list as an array for specified userid
        public Ride[] GetRides(string userID)
        {
            try
            {
                return this.userRides[userID].ToArray();
            }
            catch (Exception)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALIDE_USERID, "Invalid user id");
            }
        }
    }
}
