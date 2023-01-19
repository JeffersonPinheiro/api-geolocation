using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiGeolocation.Entities
{
    public class Address
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]

        public string Rua { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }  
        public string Estado { get; set; }  
        public string CEP { get; set; }
        public string Pais { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

    }
}
