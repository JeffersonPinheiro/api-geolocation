using ApiGeolocation.Entities;
using MongoDB.Driver;

namespace ApiGeolocation.Data
{
    public interface IGeolocationContext
    {
        IMongoCollection<Address> Address { get; }

    }
}
