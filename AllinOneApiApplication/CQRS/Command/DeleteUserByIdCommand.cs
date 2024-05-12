
using AllinOneApiApplication.Repository.User;
using MediatR;


namespace AllinOneApiApplication.CQRS.Commands
{
    public class DeleteUserByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteUserByIdCommand, int>
        {
            private UserReposistory context;
            public DeleteProductByIdCommandHandler(UserReposistory context)
            {
                this.context = context;
            }
            public async Task<int> Handle(DeleteUserByIdCommand command, CancellationToken cancellationToken)
            {
                // var user = DeleteProductById(command.Id);
                // return user.Id;
                return 1;
            }
        }
    }
}
