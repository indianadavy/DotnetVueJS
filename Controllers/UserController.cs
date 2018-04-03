using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shipbob.Services;
using shipbob.Models;

namespace shipbob.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        private readonly IOrderItemService _orderItemService;

        public UserController(IOrderItemService orderItemService)
        {
            _orderItemService = orderItemService;
        }
        [HttpGet]
        public async Task<IEnumerable<UserItem>> GetAll()
        {
            var users = await _orderItemService.GetAllUsersAsync();

            return users;
        }  

        [HttpPost]
        public IActionResult Create([FromBody] UserItem item)
        {
           if (item == null)
           {
               return BadRequest();
           }

           _orderItemService.CreateUser(item);
           
           return Ok();
        }
    }
}
