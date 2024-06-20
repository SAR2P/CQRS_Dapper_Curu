using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUserRepositories
    {
        Task<IEnumerable<UserClass>> GetAllUSersAsync();

        Task<UserClass> GetUserByIdAsync(int id);

        Task AddUserAsync(UserClass user);

        Task UpdateUserAsync(UserClass user);

        Task DeleteUserAsync(int id);

    }
}
