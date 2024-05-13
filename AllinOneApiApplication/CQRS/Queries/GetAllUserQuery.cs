
using AllinOneApiApplication.Model.User;
using AllinOneApiApplication.Model.UserModel;
using AllinOneApiApplication.Repository.User;
using MediatR;


namespace AllinOneApiApplication.CQRS.Queries
{
    public class GetAllUserQuery : IRequest<IEnumerable<UserModel>>
    {
        public class GetAllUserQueryHandler : IRequestHandler<GetAllUserQuery, IEnumerable<UserModel>>
        {
            private UserReposistory context;
            public GetAllUserQueryHandler(UserReposistory context)
            {
                this.context = context;
            }
            public async Task<IEnumerable<UserModel>> Handle(GetAllUserQuery query, CancellationToken cancellationToken)
            {
                var userList =  context.GetUserDetails(0);
                
                return userList;
            }
        }
    }
}
