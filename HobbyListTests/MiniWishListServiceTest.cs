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
        public async void FirstTest()
        {

        }
    }
}
