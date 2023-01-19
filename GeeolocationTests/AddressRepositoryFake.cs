using ApiGeolocation.Entities;
using ApiGeolocation.Repositories;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeeolocationTests
{
    public class AddressRepositoryFake : IAddressRepository
    {
        private readonly List<Address> _addresses;

        public AddressRepositoryFake()
        {
            _addresses = new List<Address>() 
            {
                new Address() {Id = "1",
                    Bairro = "Centro",
                    Estado = "Rio de Janeiro",
                    CEP = "20090003",
                    Pais = "Brasil",
                    Rua = "AV. Rio Branco"},
                new Address() {Id = "2",
                    Bairro = "Centro",
                    Estado = "Rio de Janeiro",
                    CEP = "20021200",
                    Pais = "Brasil",
                    Rua = "Praça Mal. Âncora"}
            };
        }

        public Task CreateAddress(Address address)
        {
            throw new NotImplementedException();
        }

        public double DistanceBetween(List<Address> address)
        {
            throw new NotImplementedException();
        }

        public Task<Address> GetAddress(string id)
        {
            throw new NotImplementedException();
        }

        public  Task<IEnumerable<Address>> GetAddresses()
        {
            throw new NotImplementedException();
        }

        public string GetGeolocation(Address address)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAddress(Address address)
        {
            throw new NotImplementedException();
        }
    }
}
