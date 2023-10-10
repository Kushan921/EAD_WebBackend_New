using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Bookings
    {
        [BsonId(IdGenerator = typeof(StringObjectIdGenerator))]
        public string? Id { get; set; }
        [BsonElement("from")]
        public string? From { get; set; }
        [BsonElement("status")]
        public int? Status { get; set; }
        [BsonElement("to")]
        public string? To { get; set; }
        [BsonElement("date")]
        public string? Date { get; set; }
        [BsonElement("count")]
        public int Count { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("trainschedule")]
        public string? Train_Schedule { get; set; }

        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("user")]
        public string? User { get; set; }
    }
}
