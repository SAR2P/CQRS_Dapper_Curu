using application.User.Commands;
using application.User.Queries;
using Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IMediator _mediatR;

        public UserController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserClass>>> GetUsers()
        {
            var users = await _mediatR.Send(new GetAllUsersQuery());
            return Ok(users);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<UserClass>> GetUserById(int id)
        {
            var user = await _mediatR.Send(new GetUserByIdQuery { Id = id });
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser(CreateUserCommand command)
        {
            await _mediatR.Send(command);
            return CreatedAtAction(nameof(GetUsers), command);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("Id should be same number");
            }
            await _mediatR.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> deleteUser(int id)
        {
            await _mediatR.Send(new DeleteUserCommand { Id = id });
            return NoContent();
        }



    }
}
