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

        //[Fact]
        //public async void CanCreateANewMiniModel()
        //{
        //    var testEmail = "admin@gmail.com";

        //    var miniModel = new MiniModelDTO
        //    {
        //        Name = "Stromwall",
        //        Manufacturer = "Privateer Press",
        //        PartNumber = "PP1234",
        //        Faction = "Cygnar",
        //        PointCost = 38,
        //        BuildState = "Built"
        //    };

        //    var service = BuildService();

        //    var saved = await service.Create(miniModel, testEmail);

        //    Assert.NotNull(saved);
        //    Assert.Equal(miniModel.Name, saved.Name);
        //    Assert.Equal(miniModel.BuildState, saved.BuildState);
        //}

        //[Fact]
        //public async void CanGetAMiniModel()
        //{
        //    var testEmail = "admin@gmail.com";

        //    var service = BuildService();

        //    var expected = "Platoon Leader";
        //    var returnFromMethod = await service.GetMiniModel(1, testEmail);

        //    Assert.NotNull(returnFromMethod);
        //    Assert.Equal(expected, returnFromMethod.Name);
        //}

        //[Fact]
        //public async void CanGetAllMiniModelsOfBuildState()
        //{
        //    var testEmail = "admin@gmail.com";
        //    var service = BuildService();

        //    var expectedList = new List<string>()
        //    {
        //        "Heavy Support Squad"
        //    };

        //    var returnFromMethod = await service.GetAMiniModelOfState(BuildState.painted, testEmail);

        //    var returnList = new List<string>();

        //    foreach (var item in returnFromMethod)
        //    {
        //        returnList.Add(item.Name);
        //    }

        //    Assert.NotNull(returnFromMethod);
        //    Assert.Equal(expectedList, returnList);
        //}

        //[Fact]
        //public async void CanGetAllMiniModels()
        //{
        //    var testEmail = "admin@gmail.com";
        //    var service = BuildService();

        //    var expectedList = new List<string>()
        //    {
        //        "Platoon Leader", "Heavy Support Squad", "Chariot Armored Personnel Carrier"
        //    };

        //    var returnFromMethod = await service.GetAllMiniModels(testEmail);

        //    var returnList = new List<string>();

        //    foreach (var item in returnFromMethod)
        //    {
        //        returnList.Add(item.Name);
        //    }

        //    Assert.NotNull(returnFromMethod);
        //    Assert.Equal(expectedList, returnList);
        //}

        //[Fact]
        //public async void CanUpdateAMiniModel()
        //{
        //    var testEmail = "admin@gmail.com";
        //    var service = BuildService();

        //    var miniModel = new MiniModelDTO
        //    {
        //        Id = 1,
        //        Name = "IronClad",
        //        Manufacturer = "Privateer Press",
        //        PartNumber = "PP0987",
        //        PointCost = 40,
        //        BuildState = "Painted"
        //    };

        //    await service.Update(miniModel, 1, testEmail);
        //    var returnFromMethod = await service.GetMiniModel(1, testEmail);

        //    Assert.NotNull(returnFromMethod);
        //    Assert.Equal(miniModel.Name, returnFromMethod.Name);
        //}

        //[Fact]
        //public async void CanDeleteAMiniModel()
        //{
        //    var testEmail = "admin@gmail.com";
        //    var service = BuildService();

        //    await service.Delete(1);
        //    var returnFromMethod = await service.GetAllMiniModels(testEmail);

        //    var expected = new List<string>
        //    {
        //        "Heavy Support Squad", "Chariot Armored Personnel Carrier"
        //    };

        //    var returnList = new List<string>();

        //    foreach (var item in returnFromMethod)
        //    {
        //        returnList.Add(item.Name);
        //    }

        //    Assert.NotNull(returnFromMethod);
        //    Assert.Equal(expected, returnList);
        //}
    }
}
