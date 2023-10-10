using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IUserService
    {
        List<Users> Get();
        Users Get(string id);
        Users Create(Users student);
        void Update(string id, Users student);
        void Remove(string id);
        Users Login(string email, string password);
        Users GetByNIC(string nic);
        Users GetByEmail(string email);
    }
}
