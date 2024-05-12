
using AllinOneApiApplication.Model.UserModel;
using AllinOneApiApplication.Repository.User;
using MediatR;


namespace AllinOneApiApplication.CQRS.Queries
{
    public class GetUserByIdQuery : IRequest<user>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetUserByIdQuery, user>
        {
            private UserReposistory context; 
            public GetProductByIdQueryHandler(UserReposistory context)
            {
                this.context = context;
            }
            public async Task<user> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                var user = context.UserDetailsById(query.Id);
                return user;
            }
        }
    }
}
