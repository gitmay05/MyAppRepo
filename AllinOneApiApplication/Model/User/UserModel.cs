namespace AllinOneApiApplication.Model.User
{
    public class UserModel
    {
        public Int64 UserId { get; set; }
        public Int64 SessionUserId { get; set; }
        public Int64 FK_AccountId { get; set; }
        public Int64 FK_RoleId { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? RoleName { get; set; }
        public string ?Status { get; set; }
        public string? Email { get; set; }
        public string? CreatedBy { get; set; }
        public string? CreatedDate { get; set; }
        public bool IsActive { get; set; }
        


    }
}
