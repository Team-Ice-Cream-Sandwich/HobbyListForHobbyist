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
            var testEmail = "admin@gmail.com";

            var supply = new SupplyDTO
            {
                Name = "Thin Stuff",
                Category = "Glue"
            };

            var service = BuildService();

            var saved = await service.Create(supply, testEmail);

            Assert.NotNull(saved);
            Assert.Equal(supply.Name, saved.Name);
            Assert.Equal(supply.Category, saved.Category);
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

        [Fact]
        public async void CanUpdateASupply()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            var supply = new SupplyDTO
            {
                Id = 1,
                Name = "Exacto",
                Category = "Cutting"
            };

            await service.Update(supply, testEmail);
            var returnFromMethod = await service.GetSupply(1, testEmail);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(supply.Id, returnFromMethod.Id);
            Assert.Equal(supply.Name, returnFromMethod.Name);
            Assert.Equal(supply.Category, returnFromMethod.Category);
        }

        [Fact]
        public async void CanDeleteASupply()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            await service.Delete(1);
            var returnFromMethod = await service.GetSupplies(testEmail);

            var expected = new List<string>
            {
                "Plastiweld"
            };

            var returnList = new List<string>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.Name);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnList);
        }
    }
}
