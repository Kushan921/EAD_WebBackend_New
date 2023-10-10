using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IBookingService
    {
         Bookings Create(Bookings booking);
         List<Bookings> Get();
         Bookings Get(string id);
         void Remove(string id);
         void Update(string id, Bookings booking);

        bool IsBookingExists(string date,string from,string to,string trainschedule,string user);
        public List<Bookings> GetUserBookings(string id);



    }
}
