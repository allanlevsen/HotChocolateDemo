using Data;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace HotChocolateAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ApiDataContext context;

        public UserController(IDbContextFactory<ApiDataContext> contextFactory)
        {
            this.context = contextFactory.CreateDbContext();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var result = await context.Users.ToListAsync();
                if (result == null)
                {
                    return BadRequest("No user data available");
                }

                if (result.Count == 0)
                {
                    return BadRequest("No users in the database");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            try
            {
                User? result = await context.Users.FindAsync(id);
                if (result == null)
                {
                    return NotFound("User not found");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateAsync(int userId, [FromBody] User user)
        {
            if (user == null || userId != user.UserId)
            {
                return BadRequest("Invalid User");
            }

            context.Entry(user).State = EntityState.Modified;

            try
            {
                int result = await context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost()]
        public async Task<ActionResult<int>> Add([FromBody] User user)
        {
            if (user == null)
            {
                return BadRequest("User is null");
            }

            context.Entry(user).State = EntityState.Added;

            try
            {
                int result = await context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> RemoveAsync(int userId)
        {
            User? user = await context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            context.Entry(user).State = EntityState.Deleted;
            try
            {
                int result = await context.SaveChangesAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
