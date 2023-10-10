using Application.IServices;
using Domain.IRepos;
using Domain.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BookingService:IBookingService
    {
        private readonly IMongoCollection<Bookings> _bookings;
        private readonly IMongoCollection<Shedules> _shedules;

        public BookingService(ITravelAgencyDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("travelDB");
            _bookings = database.GetCollection<Bookings>("bookings");
            _shedules = database.GetCollection<Shedules>("shedules");
        }

        public Bookings Create(Bookings booking)
        {
            _bookings.InsertOne(booking);
            return booking;
        }

        public List<Bookings> Get()
        {
            return _bookings.Find(booking => true).ToList();
        }

        public Bookings Get(string id)
        {
            return _bookings.Find(booking => booking.Id == id).FirstOrDefault();
        }
        public List<Bookings>  GetUserBookings(string id)
        {
            return _bookings.Find(booking => booking.User == id).ToList();
        }
        public void Remove(string id)
        {
            _bookings.DeleteOne(booking => booking.Id == id);
        }

        public void Update(string id, Bookings booking)
        {
            _bookings.ReplaceOne(booking => booking.Id == id, booking);
        }
   
     
        public bool IsBookingExists(string date, string from, string to, string trainschedule, string user)
        {
      var temp=  _bookings.Find(booking=>booking.Date==date && booking.From==from &&booking.To== to&& booking.Train_Schedule==trainschedule && booking.User==user).FirstOrDefault();

            if(temp!=null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
