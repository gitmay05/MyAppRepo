
using AllinOneApiApplication.Repository.User;
using MediatR;

namespace AllinOneApiApplication.CQRS.Commands
{
    public class UpdateUserCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
        {
            private UserReposistory context;
            public UpdateUserCommandHandler(UserReposistory context)
            {
                this.context = context;
            }
            public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
            {
                //var updateuser = context.UpdateUser(command);
                //if (updateuser == null)
                //{
                //    return default;
                //}
                //else
                //{
                //    updateuser.Name = command.Name;
                //    updateuser.Price = command.Price;
                    //return user.Id;
                    return 1;
               // }
            }
        }
    }
}
