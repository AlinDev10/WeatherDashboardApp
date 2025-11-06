using MediatR;
using WeatherDashboardAPI.Domain.Entities;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Commands
{
    public record UpdateUserCommand(UserEntity UserEntity) : IRequest<UserEntity>;
    public class UpdateUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<UpdateUserCommand, UserEntity>
    {
        public async Task<UserEntity> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.UpdateUserAsync(request.UserEntity);
        }
    }
}
