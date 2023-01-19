using ApiGeolocation.Entities;
using MongoDB.Driver;

namespace ApiGeolocation.Data
{
    public class GeolocationContextSeed
    {
        public static void SeedData(IMongoCollection<Address> AddressCollection)
        {
            bool existAddres = AddressCollection.Find(p => true).Any();
            if (existAddres)
            {
                AddressCollection.InsertManyAsync(GetMyAddress());
            }
        }

        private static IEnumerable<Address> GetMyAddress() 
        {
            return new List<Address>()
            {
                new Address()
                {
                    Id = "1",
                    Bairro = "Centro",
                    Estado = "Rio de Janeiro",
                    CEP = "20090003",
                    Pais = "Brasil",
                    Rua = "AV. Rio Branco"
                },
                new Address() 
                {
                    Id = "2",
                    Bairro = "Centro",
                    Estado = "Rio de Janeiro",
                    CEP = "20021200",
                    Pais = "Brasil",
                    Rua = "Praça Mal. Âncora"
                }
            };
        }
    }
}
