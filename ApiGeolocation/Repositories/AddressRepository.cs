using ApiGeolocation.Entities;
using ApiGeolocation.Data;
using MongoDB.Driver;
using System.Net;
using System.Xml.Linq;
using MongoDB.Bson;

namespace ApiGeolocation.Repositories
{
    public class AddressRepository : IAddressRepository
    {

        private readonly IGeolocationContext _context;

        public AddressRepository(IGeolocationContext context)
        {
            _context = context;
        }

        public async Task<Address> GetAddress(string id)
        {
            return await _context.Address.Find(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Address>> GetAddresses()
        {
            return await _context.Address.Find(p => true).ToListAsync();
        }

        public async Task CreateAddress(Address address)
        {
            GetGeolocation(address);
            await _context.Address.InsertOneAsync(address);
        }

        public async Task<bool> UpdateAddress(Address address)
        {
            var updateResult = await _context.Address.ReplaceOneAsync(filter: g => g.Id == address.Id,
                replacement: address);

            return updateResult.IsAcknowledged
                && updateResult.ModifiedCount > 0;
        }

        public string GetGeolocation(Address address)
        {
            try
            {
                string formattedAddress = address.Numero + address.Rua + ", " + address.Bairro + ", " + address.Cidade + ", " + address.Estado;
                string requestUri = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?address={0}&key=AIzaSyAenjpfi-_Bqqa_I8BkkohbCumymYg7R10", formattedAddress);

                WebRequest request = WebRequest.Create(requestUri);
                WebResponse response = request.GetResponse();
                XDocument xdoc = XDocument.Load(response.GetResponseStream());

                XElement result = xdoc.Element("GeocodeResponse").Element("result");
                XElement locationElement = result.Element("geometry").Element("location");
                XElement lat = locationElement.Element("lat");
                XElement lng = locationElement.Element("lng");

                address.Latitude = Convert.ToDouble(lat.Value);
                address.Longitude = Convert.ToDouble(lng.Value);

                List<Address> addresses = new List<Address>();

                addresses.Add(address);

                if (addresses.Count == 2)
                {
                    DistanceBetween(addresses);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return address.ToString();
        }

        public double DistanceBetween(List<Address> address)
        {
            List<double> distanceList = new List<double>();
            double maxDistance;
            double minDistance;
            double x1, y1, x2, y2;
            double distance;

            x1 = address[0].Latitude;
            y1 = address[0].Longitude;
            x2 = address[1].Latitude;
            y2 = address[1].Longitude;

            double ex1 = x1 - x2;
            double ex2 = y1 - y2;
            double firstPoint = Math.Sqrt(Math.Pow(ex1, 2));
            double secondPoint = Math.Sqrt(Math.Pow(ex2, 2));

            distance = firstPoint + secondPoint;

            distanceList.Add(distance);

            maxDistance = distanceList.Max();
            minDistance = distanceList.Min();

            GetDistanceLists(distanceList);
            GetDistanceRanges(maxDistance, minDistance);

            return distance;

        }

        public string GetDistanceLists(List<double> distance)
        {
            return distance.ToJson();
        }

        public string GetDistanceRanges(double maxDistance, double minDistance)
        {
            List<double> ranges = new List<double>();
            ranges.Add(maxDistance);
            ranges.Add(minDistance);

            return ranges.ToJson();
        }
    }
}
