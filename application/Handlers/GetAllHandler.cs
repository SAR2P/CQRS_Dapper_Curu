using application.User.Commands;
using application.User.Queries;
using Domain.Models;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace application.Handlers
{
    public class GetAllUSersHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserClass>>
    {
        private readonly IUserRepositories _UserRepository;

        public GetAllUSersHandler(IUserRepositories UserRepository)
        {
            _UserRepository = UserRepository;
        }

        public async Task<IEnumerable<UserClass>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _UserRepository.GetAllUSersAsync();
        }
    }


    public class GetUserByIdHandler : IRequestHandler<GetUserByIdQuery, UserClass>
    {

        private readonly IUserRepositories _UserRepository;

        public GetUserByIdHandler(IUserRepositories userRepositories)
        {
            _UserRepository= userRepositories;
        }
        public async Task<UserClass> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _UserRepository.GetUserByIdAsync(request.Id);
        }
    }


    public class CreateUserHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly IUserRepositories _UserRepository;
        public CreateUserHandler(IUserRepositories userRepositories)
        {
            _UserRepository = userRepositories;
        }
        public async Task<Unit> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserClass()
            {
                FullName = request.FullName,
                Age = request.Age
            };

            await _UserRepository.AddUserAsync(user);

            return Unit.Value;

        }
    }

    
    public class UpdateUserHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly IUserRepositories _UserRepository;

        public UpdateUserHandler(IUserRepositories userRepositories)
        {
            _UserRepository =(userRepositories);
        }

        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new UserClass()
            {
                Id = request.Id,
                FullName = request.FullName,
                Age = request.Age
            };

            await _UserRepository.UpdateUserAsync(user);

            return Unit.Value;
        }

        public class DeleteUserHandler : IRequestHandler<DeleteUserCommand>
        {
            private readonly IUserRepositories _UserRepository;

            public DeleteUserHandler(IUserRepositories userRepository)
            {
                _UserRepository = userRepository;
            }

            public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
            {
                await _UserRepository.DeleteUserAsync(request.Id);
                return Unit.Value;
            }
        }

    }


}
