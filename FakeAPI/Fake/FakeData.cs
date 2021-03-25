using Bogus;
using FakeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FakeAPI.Fake
{
    /// <summary>
    /// Fake Data Method
    /// </summary>
    public class FakeData
    {
        private static List<User> _users;

        public static List<User> GetUsers(int number) {
            if(_users==null)
            { 
                _users = new Faker<User>().RuleFor(u => u.ID, f => f.IndexFaker+1)
                    .RuleFor(u => u.Name, f => f.Company.CompanyName())
                    .RuleFor(u => u.Address, f => f.Address.FullAddress())
                    .RuleFor(u => u.CreateDate, f => f.Date.Recent(0))
                    .Generate(number);
            }
            return _users;

        }
    }
}
