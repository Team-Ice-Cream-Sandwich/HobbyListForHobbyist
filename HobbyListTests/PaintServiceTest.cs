using HobbyListForHobbyist.Models.Interfaces;
using HobbyListForHobbyist.Models.Services;
using System;
using System.Collections.Generic;
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
        public async void FirstTest()
        {

        }
    }
}
