using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;


namespace EMTestTask.Models
{
    public class Customer
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("FirstName")]
        public string FirstName { get; set; }

        [BsonElement("SecondName")]
        public string SecondName { get; set; }

        [BsonElement("Email")]
        public string Email { get; set; }

        [BsonElement("PhoneNumber")]
        public string PhoneNumber { get; set; }

        [BsonElement("Address")]
        public string Address { get; set; }
    }
}
