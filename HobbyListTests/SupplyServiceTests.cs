using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using HobbyListForHobbyist.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HobbyListTests
{
    public class SupplyServiceTests : DatabaseTestBase
    {
        private ISupply BuildService()
        {
            return new SupplyService(_db);
        }

        [Fact]
        public async void CanCreateANewSupply()
        {
            var supply = new SupplyDTO
            {
                Name = "Thin Stuff",
                Category = "Glue"
            };

            var service = BuildService();

            var saved = await service.Create(supply);

            Assert.NotNull(saved);
            Assert.Equal(supply.Name, saved.Name);
        }

        [Fact]
        public async void CanGetASupply()
        {
            var testEmail = "admin@gmail.com";

            var service = BuildService();

            var expected = "Snipps";
            var returnFromMethod = await service.GetSupply(1, testEmail);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod.Name);
        }

        [Fact]
        public async void CanGetAllSupplies()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            var expectedList = new List<string>()
            {
                "Snipps", "Plastiweld"
            };

            var returnFromMethod = await service.GetSupplies(testEmail);

            var returnList = new List<string>();

            foreach(var item in returnFromMethod)
            {
                returnList.Add(item.Name);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expectedList, returnList);
        }
    }
}
