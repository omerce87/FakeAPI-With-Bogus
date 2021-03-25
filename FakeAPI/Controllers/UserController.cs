using FakeAPI.Fake;
using FakeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private List<User> _users = FakeData.GetUsers(100);

        /// <summary>
        /// Classic Get Method
        /// </summary>
        /// <returns>User List</returns>
        [HttpGet]
        public List<User> get() {
            return _users;
        }

        /// <summary>
        /// Get Detail By ID Method
        /// </summary>
        /// <param name="id">User ID</param>
        /// <returns>User Class</returns>
        [HttpGet("{id}")]
        public User Get(int id) {
            var user = _users.FirstOrDefault(x => x.ID == id);
            return user;
        }

        /// <summary>
        /// Post Method for a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public User Post([FromBody]User user)
        {
            _users.Add(user);
            return user;
        }

        /// <summary>
        /// put method for a user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public User Put([FromBody]User user)
        {
            var edituser = _users.FirstOrDefault(x => x.ID == user.ID);
            edituser.Name = user.Name;
            edituser.Address = user.Address;
            return user;
        }

        /// <summary>
        /// delete user from user list
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var deleted = _users.FirstOrDefault(x => x.ID == id);
            _users.Remove(deleted);
        }
    }
}
