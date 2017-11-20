using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UsersManager.Models;

namespace UsersManager.Services
{
    public class UsersRepository
    {
        private const string CacheKey = "UsersStore";

        public UsersRepository()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                if (ctx.Cache[CacheKey] == null)
                {
                    var users = new User[]
                    {
                        new User
                        {
                            username="user1", email="user1@gmail.com"
                        },
                        new User
                        {
                            username="user2", email="user2@gmail.com"
                        }
                    };

                    ctx.Cache[CacheKey] = users;
                }
            }
        }

        public User[] GetAllUsers()
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                return (User[])ctx.Cache[CacheKey];
            }

            return new User[]
            {
                new User
                {
                    username="ph", email="ph@gmail.com"
                }
            };

            //return new User[]
            //{
            //    new User
            //    {
            //        username="duby2",
            //        email="duby2@gmail.com"
            //    },
            //    new User
            //    {
            //        username="galit2",
            //        email="galit2@gmail.com"
            //    }
            //};
        }

        public bool SaveUser(User user)
        {
            var ctx = HttpContext.Current;

            if (ctx != null)
            {
                try
                {
                    var currentData = ((User[])ctx.Cache[CacheKey]).ToList();
                    currentData.Add(user);

                    ctx.Cache[CacheKey] = currentData.ToArray();

                    return true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            return false;
        }

    }
}