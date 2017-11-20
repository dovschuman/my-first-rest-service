using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UsersManager.Models;
using UsersManager.Services;

namespace UsersManager.Controllers
{
    public class UsersController : ApiController
    {
        private UsersRepository usersRepository;

        public UsersController()
        {
            this.usersRepository = new UsersRepository();
        }

        public User[] Get()
        {
            return this.usersRepository.GetAllUsers();

            //return new User[]
            //{
            //    new User
            //    {
            //        username="dubys",
            //        email = "schuman.dov@gmail.com"
                    
            //    },
            //    new User
            //    {
            //        username="galitb",
            //        email = "galitt0409@gmail.com"
            //    }
            //};
        }

        public string Put([FromBody]string value)
        {
            return "Put returning: " + value;
        }
    }
}
