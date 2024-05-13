
using AllinOneApiApplication.Model.User;
using AllinOneApiApplication.Model.UserModel;
using AllinOneApiApplication.Repository.User;
using MediatR;


namespace AllinOneApiApplication.CQRS.Queries
{
    public class GetUserByIdQuery : IRequest<List<UserModel>>
    {
        public int Id { get; set; }
        public class GetProductByIdQueryHandler : IRequestHandler<GetUserByIdQuery, List<UserModel>>
        {
            private UserReposistory context; 
            public GetProductByIdQueryHandler(UserReposistory context)
            {
                this.context = context;
            }
            public async Task<List<UserModel>> Handle(GetUserByIdQuery query, CancellationToken cancellationToken)
            {
                List<UserModel> user = new List<UserModel>();
                user = context.GetUserDetails(query.Id);
                
                    return user;
               
               
            }

            
        }
    }
}
