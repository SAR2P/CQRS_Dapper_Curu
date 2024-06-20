using Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.User.Queries
{/// <summary>
/// for query we send these classes
/// </summary>
    public class GetAllUsersQuery : IRequest<IEnumerable<UserClass>>
    {

    }

    public class GetUserByIdQuery : IRequest<UserClass> 
    {
        public int Id { get; set; }
    }
}
