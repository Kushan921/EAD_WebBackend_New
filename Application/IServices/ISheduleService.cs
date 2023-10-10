using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ISheduleService
    {

        Shedules Create(Shedules booking);
         List<Shedules> Get();
        Shedules Get(string id);
        void Remove(string id);
        void Update(string id, Shedules booking);
        Bookings GetByShedule(string sheduleId);


    }
}
