using MediatR;
using WeatherDashboardAPI.Domain.Interfaces;

namespace WeatherDashboardAPI.Application.Commands
{
    public record DeleteUserCommand(string UserId) : IRequest<bool>;
    public class DeleteUserCommandHandler(IUserRepository userRepository)
        : IRequestHandler<DeleteUserCommand, bool>
    {
        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await userRepository.DeleteUserByIdAsync(request.UserId);
        }
    }
}
