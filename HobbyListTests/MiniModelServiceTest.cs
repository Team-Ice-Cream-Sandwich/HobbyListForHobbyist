using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using HobbyListForHobbyist.Models.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace HobbyListTests
{
    public class MiniModelServiceTest : DatabaseTestBase
    {
        private IMiniModel BuildService()
        {
            return new MiniModelService(_db, _paint, _supply);
        }

        [Fact]
        public async void CanCreateANewMiniModel()
        {
            var testEmail = "admin@gmail.com";

            var miniModel = new MiniModelDTO
            {
                Name = "Stromwall",
                Manufacturer = "Privateer Press",
                PartNumber = "PP1234",
                Faction = "Cygnar",
                PointCost = 38,
                BuildState = BuildState.built
            };

            var service = BuildService();

            var saved = await service.Create(miniModel, testEmail);

            Assert.NotNull(saved);
            Assert.Equal(miniModel.Name, saved.Name);
            Assert.Equal(miniModel.Manufacturer, saved.Manufacturer);
            Assert.Equal(miniModel.PartNumber, saved.PartNumber);
            Assert.Equal(miniModel.Faction, saved.Faction);
            Assert.Equal(miniModel.PointCost, saved.PointCost);
            Assert.Equal(miniModel.BuildState, saved.BuildState);
        }

        [Fact]
        public async void CanGetAMiniModel()
        {
            var testEmail = "admin@gmail.com";

            var service = BuildService();

            var expected = "Platoon Leader";
            var returnFromMethod = await service.GetMiniModel(1, testEmail);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod.Name);
        }

        [Fact]
        public async void CanGetAllMiniModelsOfBuildState()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            var expectedList = new List<string>()
            {
                "Heavy Support Squad"
            };

            var returnFromMethod = await service.GetAMiniModelOfState(BuildState.painted, testEmail);

            var returnList = new List<string>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.Name);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expectedList, returnList);
        }

        [Fact]
        public async void CanGetAllMiniModels()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            var expectedList = new List<string>()
            {
                "Platoon Leader", "Heavy Support Squad", "Chariot Armored Personnel Carrier"
            };

            var returnFromMethod = await service.GetAllMiniModels(testEmail);

            var returnList = new List<string>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.Name);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expectedList, returnList);
        }

        [Fact]
        public async void CanUpdateAMiniModel()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            var miniModel = new MiniModelDTO
            {
                Id = 1,
                Name = "IronClad",
                Manufacturer = "Privateer Press",
                PartNumber = "PP0987",
                Faction = "Cygnar",
                PointCost = 40,
                BuildState = BuildState.painted
            };

            await service.Update(miniModel, 1, testEmail);
            var returnFromMethod = await service.GetMiniModel(1, testEmail);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(miniModel.Id, returnFromMethod.Id);
            Assert.Equal(miniModel.Name, returnFromMethod.Name);
            Assert.Equal(miniModel.PartNumber, returnFromMethod.PartNumber);
            Assert.Equal(miniModel.PointCost, returnFromMethod.PointCost);
            Assert.Equal(miniModel.BuildState, returnFromMethod.BuildState);
        }

        [Fact]
        public async void CanDeleteAMiniModel()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            await service.Delete(1);
            var returnFromMethod = await service.GetAllMiniModels(testEmail);

            var expected = new List<string>
            {
                "Heavy Support Squad", "Chariot Armored Personnel Carrier"
            };

            var returnList = new List<string>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.Name);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnList);
        }

        [Fact]
        public async void CanAddAPaintToAModel()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            await service.AddAPaintToAModel(1, 1);

            var paintList = new List<string>
            {
                "Gunmetal"
            };

            var returnFromMethod = await service.GetMiniModel(1, testEmail);

            var returnList = new List<string>();

            foreach (var item in returnFromMethod.Paints)
            {
                returnList.Add(item.ColorName);
            }

            Assert.NotNull(returnFromMethod.Paints);
            Assert.Equal(paintList, returnList);            
        }

        [Fact]
        public async void CanDeleteAPaintFromAModel()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            await service.AddAPaintToAModel(1, 1);
            await service.RemoveAPaintToAModel(1, 1);

            var paintList = new List<string>
            {
                // Intentionally Left blank
            };

            var returnFromMethod = await service.GetMiniModel(1, testEmail);

            var returnList = new List<string>();

            foreach (var item in returnFromMethod.Paints)
            {
                returnList.Add(item.ColorName);
            }

            Assert.NotNull(returnFromMethod.Paints);
            Assert.Equal(paintList, returnList);
        }

        [Fact]
        public async void CanAddASupplyToAModel()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            await service.AddASupplytToAModel(1, 1);

            var supplyList = new List<string>
            {
                "Snipps"
            };

            var returnFromMethod = await service.GetMiniModel(1, testEmail);

            var returnList = new List<string>();

            foreach (var item in returnFromMethod.Supplies)
            {
                returnList.Add(item.Name);
            }

            Assert.NotNull(returnFromMethod.Supplies);
            Assert.Equal(supplyList, returnList);
        }

        [Fact]
        public async void CanDeleteASupplyFromAModel()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            await service.AddASupplytToAModel(1, 1);
            await service.RemoveASupplyToAModel(1, 1);

            var paintList = new List<string>
            {
                // Intentionally Left blank
            };

            var returnFromMethod = await service.GetMiniModel(1, testEmail);

            var returnList = new List<string>();

            foreach (var item in returnFromMethod.Supplies)
            {
                returnList.Add(item.Name);
            }

            Assert.NotNull(returnFromMethod.Supplies);
            Assert.Equal(paintList, returnList);
        }
    }
}
