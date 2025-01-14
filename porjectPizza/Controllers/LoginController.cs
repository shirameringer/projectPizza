using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using pizzaProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Login.Interface;
using System.Security.Claims;
using myModels;
using Login.service;
using porjectPizza.Controllers;
using Login.tokenService;
using Login.tokenService;

namespace pizzaProject.Controllers
{
    public class LoginController : Basecontrollers
    {
        Ilogin _ilogin;

        public LoginController(Ilogin l)
        {
            _ilogin = l;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<String> Login(string name, string password)
        {

            var dt = DateTime.Now;

            if (_ilogin.IsWorkerValid(name, password)==null)
            {
                return Unauthorized();
            }
            Worker worker;
            worker=_ilogin.IsWorkerValid(name, password);
            var claims = new List<Claim>
            {
                new Claim("role",worker.role),
                new Claim("role",worker.firstName)
            };

            var token = TokenService.GetToken(claims);

            return new OkObjectResult(TokenService.WriteToken(token));
        }

    }
}