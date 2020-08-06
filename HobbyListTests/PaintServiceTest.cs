using HobbyListForHobbyist.Models.DTOs;
using HobbyListForHobbyist.Models.Interfaces;
using HobbyListForHobbyist.Models.Services;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using Xunit;

namespace HobbyListTests
{
    public class PaintServiceTest : DatabaseTestBase
    {
        private IPaint BuildService()
        {
            return new PaintService(_db);
        }

        [Fact]
        public async void CanCreateANewPaint()
        {
            var testEmail = "admin@gmail.com";

            var paint = new PaintDTO
            {
                ColorName = "Nulin Oil",
                Manufacturer = "Games Workshop",
                ProductNumber = "123"
            };

            var service = BuildService();

            var saved = await service.Create(paint, testEmail);

            Assert.NotNull(saved);
            Assert.Equal(paint.ColorName, saved.ColorName);
            Assert.Equal(paint.Manufacturer, saved.Manufacturer);
            Assert.Equal(paint.ProductNumber, saved.ProductNumber);
        }

        [Fact]
        public async void CanGetAPaint()
        {
            var testEmail = "admin@gmail.com";

            var service = BuildService();

            var expected = "Gunmetal";
            var returnFromMethod = await service.GetPaint(1, testEmail);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnFromMethod.ColorName);
        }

        [Fact]
        public async void CanGetAllPaints()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            var expectedList = new List<string>()
            {
               "Gunmetal", "Patriot Green", "Alabaster"
            };

            var returnFromMethod = await service.GetPaints(testEmail);

            var returnList = new List<string>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.ColorName);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expectedList, returnList);
        }

        [Fact]
        public async void CanUpdateAPaint()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            var paint = new PaintDTO
            {
                Id = 1,
                ColorName = "Hot Orange",
                Manufacturer = "Citadel",
                ProductNumber = "72.063"
            };

            await service.Update(paint, testEmail);
            var returnFromMethod = await service.GetPaint(1, testEmail);

            Assert.NotNull(returnFromMethod);
            Assert.Equal(paint.Id, returnFromMethod.Id);
            Assert.Equal(paint.ColorName, returnFromMethod.ColorName);
            Assert.Equal(paint.Manufacturer, returnFromMethod.Manufacturer);
            Assert.Equal(paint.ProductNumber, returnFromMethod.ProductNumber);
        }

        [Fact]
        public async void CanDeleteAPaint()
        {
            var testEmail = "admin@gmail.com";
            var service = BuildService();

            await service.Delete(1);
            var returnFromMethod = await service.GetPaints(testEmail);

            var expected = new List<string>
            {
                "Patriot Green", "Alabaster"
            };

            var returnList = new List<string>();

            foreach (var item in returnFromMethod)
            {
                returnList.Add(item.ColorName);
            }

            Assert.NotNull(returnFromMethod);
            Assert.Equal(expected, returnList);
        }
    }
}
