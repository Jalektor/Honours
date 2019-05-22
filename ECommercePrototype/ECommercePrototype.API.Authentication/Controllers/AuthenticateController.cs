using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommercePrototype.API.Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommercePrototype.API.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticateController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }
        // GET: api/Authenticate
        [HttpGet]
        public IEnumerable<IdentityUser> Get()
        {
            return _userManager.Users.ToList();
        }

        // GET: api/Authenticate/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Authenticate
        [HttpPost]
        public async void Post([FromBody] Identity identity)
        {
            var user = new IdentityUser { UserName = identity.Email, Email = identity.Email  };
            var result = await _userManager.CreateAsync(user, identity.Password);
        }

        // PUT: api/Authenticate/5
        [HttpPut("{id}")]
        public async void Put(int id)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
