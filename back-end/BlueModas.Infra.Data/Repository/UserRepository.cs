using BlueModas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlueModas.Infra.Data.Repository
{
    public static class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, UserName = "batman", Password = "batman", Role = "manager" });
            users.Add(new User { Id = 2, UserName = "robin", Password = "robin", Role = "employee" });
            return users.Where(x => x.UserName.ToLower() == username.ToLower() && x.Password.ToLower() == password.ToLower()).FirstOrDefault();
        }
    }
}
