using API.Controllers;
using API.Data;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using Xunit;

namespace events.Tests
{
    public class UsersControllerTests
    {
        public UsersControllerTests()
        {
            
        }

        [Fact]
        public void GetUsersTest()
        {
            Assert.Equal(2, 2);
        }

        [Fact]
        public void DeleteUser()
        {
            Assert.Equal(2, 2);
        }
    }

    public class EventsControllerTests
    {
        UsersController _controller;
        IUserRepository userRepository;
        public EventsControllerTests()
        {

        }

        [Fact]
        public void GetFirstEventTest()
        {
            Assert.Equal(2, 2);
        }
    }
}
