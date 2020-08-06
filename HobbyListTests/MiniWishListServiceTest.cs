using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using HobbyListForHobbyist.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HobbyListTests
{
    public class MiniWishListServiceTest : DatabaseTestBase
    {
        private IMiniWishList BuildService()
        {
            return new MiniWishListService(_db);
        }

        [Fact]
        public async void CanCreateANewMiniModelWishList()
        {
            var testEmail = "admin@gmail.com";

            var miniWish = new MiniWishListDTO
            {
                Name = "Stromwall",
                Manufacturer = "Privateer Press",
                PartNumber = "PP1234",
                Faction = "Cygnar",
                PointCost = 38,
                Price = "120"
            };

            var service = BuildService();

            var saved = await service.Create(miniWish, testEmail);

            Assert.NotNull(saved);
            Assert.Equal(miniWish.Name, saved.Name);
            Assert.Equal(miniWish.Manufacturer, saved.Manufacturer);
            Assert.Equal(miniWish.PartNumber, saved.PartNumber);
            Assert.Equal(miniWish.Faction, saved.Faction);
            Assert.Equal(miniWish.PointCost, saved.PointCost);
            Assert.Equal(miniWish.Price, saved.Price);
        }

        [Fact]
        public async void CanGetAMiniModelFromTheWishlist()
        {
            var testEmail = "admin@gmail.com";

            var service = BuildService();

            var expected = "Chariot Personnel Carrier";
            var returnFromMethod = await service.GetMiniModelInWishList(1, testEmail);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod.Name);
        }

        [Fact]
        public async void CanGetAllMiniModelWishListItems()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            var expectedList = new List<string>()
            {
                "Chariot Personnel Carrier", "Heavy support Squad", "Chariot Armed Personnel Carrier"
            };

            var returnFromMethod = await service.GetAllMiniModelsInWishList(testEmail);

            var returnList = new List<string>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.Name);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expectedList, returnList);
        }

        [Fact]
        public async void CanUpdateAMiniModelWishlist()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            var miniWish = new MiniWishListDTO
            {
                Id = 1,
                Name = "IronClad",
                Manufacturer = "Privateer Press",
                PartNumber = "PP0987",
                PointCost = 40,
                Price = "23"
            };

            await service.Update(miniWish, 1, testEmail);
            var returnFromMethod = await service.GetMiniModelInWishList(1, testEmail);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(miniWish.Id, returnFromMethod.Id);
            Assert.Equal(miniWish.Name, returnFromMethod.Name);
            Assert.Equal(miniWish.Manufacturer, returnFromMethod.Manufacturer);
            Assert.Equal(miniWish.PartNumber, returnFromMethod.PartNumber);
            Assert.Equal(miniWish.PointCost, returnFromMethod.PointCost);
            Assert.Equal(miniWish.Price, returnFromMethod.Price);
        }

        [Fact]
        public async void CanDeleteAMiniWishlist()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            await service.Delete(1);
            var returnFromMethod = await service.GetAllMiniModelsInWishList(testEmail);

            var expected = new List<string>
            {
                "Heavy support Squad", "Chariot Armed Personnel Carrier"
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
