using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.DTO;
using WebApplication3.Entities;

namespace WebApplication3.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly DBContext _DBContext;
		public UserController (DBContext DBContext)
		{
			_DBContext = DBContext;
		}

		// get all users API.
		[HttpGet("GetUsers")]
		public async Task<ActionResult<List<UserDTO>>> GetAllUsers()
		{
			var users = await _DBContext.Users.ToListAsync();
			if (users.Count == null)
			{
				return NotFound();
			} else
			{
				return Ok(users);
			}
		}

		// get user by id API.
		[HttpGet("{id}")]
		public async Task<ActionResult<UserDTO>> GetUserById(int id)
		{
			var user = await _DBContext.Users.FindAsync(id);
			if (user is null)
			{
				return NotFound("User not found");
			} else
			{
				return Ok(user);
			}
		}

		// create new user API.
		[HttpPost]
		public async Task<ActionResult<UserDTO>> PostUser(UserDTO User)
		{
			var user = new User()
			{
				Firstname = User.Firstname,
				Lastname = User.Lastname,
				Username = User.Username,
				Password = User.Password,
				CreatedAt = User.CreatedAt
			};
			_DBContext.Users.Add(user);
			await _DBContext.SaveChangesAsync();
			return Ok(user);
		}

		// update user by id API.
		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateUser(int id,  UserDTO User)
		{
			var entity = await _DBContext.Users.FirstOrDefaultAsync(userId => userId.Id == User.Id);
			entity.Firstname = User.Firstname;
			entity.Lastname = User.Lastname;
			entity.Username = User.Username;
			entity.Password = User.Password;
			entity.CreatedAt = User.CreatedAt;

			await _DBContext.SaveChangesAsync();
			return Ok(entity);
		}


		// delete user API.
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteUser(int id)
		{
			var entity = new User()
			{
				Id = id
			};
			_DBContext.Users.Attach(entity);
			_DBContext.Users.Remove(entity);
			await _DBContext.SaveChangesAsync();
			return Ok();
		}
	}
}