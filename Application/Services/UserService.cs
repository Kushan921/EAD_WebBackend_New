using Application.IServices;
using Domain.IRepos;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services 
{
    public class UserService:IUserService
    {
        private readonly IMongoCollection<Users> _users;

        public UserService(ITravelAgencyDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("travelDB");
            _users = database.GetCollection<Users>("users");
        }

        public Users Create(Users user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<Users> Get()
        {
            return _users.Find(user => true).ToList();
        }

        public Users Get(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }

        public void Remove(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public void Update(string id, Users user)
        {
            _users.ReplaceOne(users => users.Id == id, user);
        }
        public Users Login(string email,string password)
        {
            return _users.Find(user => user.Email == email && user.Password==password && user.Active==true).FirstOrDefault();
        }
        public Users GetByNIC(string nic)
        {
            return _users.Find(user => user.NIC == nic).FirstOrDefault();
        }
        public Users GetByEmail(string email)
        {
            return _users.Find(user => user.Email == email).FirstOrDefault();
        }
      


    }
}
