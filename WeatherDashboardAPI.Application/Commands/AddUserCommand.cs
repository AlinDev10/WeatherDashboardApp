using MediatR;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Commands
{
    public record AddUserCommand(UserEntity User) :  IRequest<UserEntity>;

    public class AddUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<AddUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(AddUserCommand request, CancellationToken cancellationToken) 
        {
            return await userRepository.AddUserAsync(request.User);
        }
    }
}
