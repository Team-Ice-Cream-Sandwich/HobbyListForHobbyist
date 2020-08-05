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
        public async void FirstTest()
        {

        }
    }
}
