using ApiGeolocation.Controllers;
using ApiGeolocation.Data;
using ApiGeolocation.Entities;
using ApiGeolocation.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GeeolocationTests
{
    public class ApiGeolocationTests
    {
        GeolocationController _controller;
        IAddressRepository _repository;

        public ApiGeolocationTests()
        {
            _repository = new AddressRepositoryFake();
            _controller = new GeolocationController(_repository);
        }

        [Fact]
        public void GetAddresses()
        {
            var okResult = _controller.GetAddresses();

            Assert.IsType<OkObjectResult>(okResult.Result);
        }

    }
}