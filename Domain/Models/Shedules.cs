using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Shedules
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string? Id { get; set; }

        [BsonElement("departure")]
        public string? Departure { get; set; }

        [BsonElement("destination")]
        public string? Designation { get; set; }

        [BsonElement("stations")]
        public string? Stations { get; set; }
        [BsonElement("days")]
        public string? Days { get; set; }
        [BsonElement("starting_times")]
        public string? StartingTimes { get; set; }


    }
}
