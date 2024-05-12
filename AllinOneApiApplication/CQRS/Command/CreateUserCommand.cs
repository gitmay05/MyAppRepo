
using AllinOneApiApplication.Model.UserModel;
using AllinOneApiApplication.Repository.User;
using MediatR;

namespace AllinOneApiApplication.CQRS.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateUserCommand, int>
        {
            private UserReposistory context;
            public CreateProductCommandHandler(UserReposistory context)
            {
                this.context = context;
            }
            public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
            {
                var userobj = new user();
                userobj.UserName = command.Name;
                userobj.UserPwd = command.Name;
               // context.User.Add(userobj);
             
                return 1;
            }
        }
    }
}
