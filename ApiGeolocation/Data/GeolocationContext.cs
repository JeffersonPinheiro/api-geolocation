using ApiGeolocation.Entities;
using MongoDB.Driver;

namespace ApiGeolocation.Data
{
    public class GeolocationContext : IGeolocationContext
    {
        
        public GeolocationContext(IConfiguration configuration) 
        {
            var client = new MongoClient(configuration.GetValue<string>
                ("DatabaseSettings:ConnectionString"));

            var database = client.GetDatabase(configuration.GetValue<string>
                ("DatabaseSettings:DatabaseName"));

            Address = database.GetCollection<Address>(configuration.GetValue<string>
                ("DatabaseSettings:CollectionName"));

            //GeolocationContextSeed.SeedData(Address);

        } 
        
        public IMongoCollection<Address> Address { get; }
    }
}
