
using AllinOneApiApplication.Model.UserModel;
using AllinOneApiApplication.Repository.User;
using MediatR;


namespace AllinOneApiApplication.CQRS.Queries
{
    public class GetAllUserQuery : IRequest<IEnumerable<user>>
    {
        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<user>>
        {
            private UserReposistory context;
            public GetAllUserQueryHandler(UserReposistory context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<user>> Handle(GetAllUserQuery query, CancellationToken cancellationToken)
            {
                var userList =  context.UserDetails();
                
                return userList;
            }
        }
    }
}
