

using ApiGeolocation.Entities;

namespace ApiGeolocation.Repositories
{
    public interface IAddressRepository
    {
        Task<IEnumerable<Address>> GetAddresses();

        Task<Address> GetAddress(string id);

        public string GetGeolocation(Address address);

        Task<bool> UpdateAddress(Address address);

        Task CreateAddress(Address address);

        public double DistanceBetween(List<Address> address);
    }
}
