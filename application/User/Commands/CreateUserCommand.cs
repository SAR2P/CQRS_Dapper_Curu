using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.User.Commands
{
    public class CreateUserCommand : IRequest
    {
        public string FullName { get; set; }
        public int Age { get; set; }
    }

    public class UpdateUserCommand : IRequest
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        public int Age { get; set; }
    }

    public class DeleteUserCommand : IRequest 
    {
        public int Id { get; set; }
    }
}
