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

        [HttpGet("{ID}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _orderItemService.GetUserAsync(id);
            if (item == null)
            {
                return NotFound("Order not found");
            }
            return Ok(item);
        }
  
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserItem item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            await _orderItemService.CreateUser(item);

            return CreatedAtAction(nameof(GetById), new { id = item.ID }, item);
        }
    }
}
