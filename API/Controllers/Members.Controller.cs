using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API.Data;
using API.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace API.Controllers
{
    [Route("api/[controller]")] // localhost:5001/api/members
    [ApiController]
    public class MembersController(DataContext context) : ControllerBase
    {
        [HttpGet]
        public async Task< ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();
            return Ok(members); // Wrap in Ok() for proper ActionResult
        }

        [HttpGet("{id}")] // localhost:5001/api/members/bob-id
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var user = context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}