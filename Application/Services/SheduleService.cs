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
    public class SheduleService:ISheduleService
    {
     
        private readonly IMongoCollection<Shedules> _shedules;
        private readonly IMongoCollection<Bookings> _bookings;

        public SheduleService(ITravelAgencyDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("travelDB");
       
            _shedules = database.GetCollection<Shedules>("shedules");
            _bookings = database.GetCollection<Bookings>("bookings");
        }

        public Shedules Create(Shedules shedule)
        {
            _shedules.InsertOne(shedule);
            return shedule;
        }

        public List<Shedules> Get()
        {
            return _shedules.Find(shedule => true).ToList();
        }

        public Shedules Get(string id)
        {
            return _shedules.Find(shedule => shedule.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _shedules.DeleteOne(shedule => shedule.Id == id);
        }

        public void Update(string id, Shedules shedule)
        {
            _shedules.ReplaceOne(shedule => shedule.Id == id, shedule);
        }

        public Bookings GetByShedule(string sheduleId)
        {
            return _bookings.Find(booking => booking.Train_Schedule == sheduleId).FirstOrDefault();
        }

    }
}
