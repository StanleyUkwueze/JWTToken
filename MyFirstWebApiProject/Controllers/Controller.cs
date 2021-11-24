using Microsoft.AspNetCore.Mvc;
using MyFirstWebApiProject.Models;
using MyFirstWebApiProject.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApiProject.Controllers
{
    [ApiController]
    [Route("Controller")]
   
    public class UserController : ControllerBase
    {
        private static readonly  List<string> _listOfUsers;
       

       static UserController()
        {
            _listOfUsers = new List<string>
          {
                "Suleman S", "Stanley U", "Edore U", "Isreal I", "Blessing E"
          };
        }
        [HttpGet]
        [Route("GetUser/{name}")]
        public IActionResult GetUser(string name)
        {
            var counter = 0;
            var usermodelDto = new UserModelDto();
            foreach
                (var user in _listOfUsers)
            {
                var SplittedName = user.Split(" ");
                if (SplittedName[0].Equals(name))
                {
                    usermodelDto.FullName = name;
                    usermodelDto.Position = "None";
                    usermodelDto.Title = "Decadev";
                }
                counter++;
            }

            return Ok(usermodelDto);
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            var users = new List<UserModelDto>();
            foreach (var user in _listOfUsers)
            {
                users.Add(new UserModelDto { FullName = user, Position = "None", Title = "Decadev" });
            }
            return Ok(users);
        }
        [HttpPost]
        [Route("GetAdd/{id}")]
        public IActionResult AddUser(UserDetailsDto model)
        {
            if (model.Equals(null))
            {
                return BadRequest("Empty Object");
            }
            //var user = new UserModel();
            //user.FirstName = model.FirstName;
            //user.Lastname = model.Lastname;
            //user.Position = model.Position;
            //user.Title = model.Title;

            _listOfUsers.Add($"{model.FirstName} {model.Lastname}");
            return Ok("New user added");
        }
    
    }
}
