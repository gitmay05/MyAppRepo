namespace AllinOneApiApplication.Model.Login
{
    public class UserInfoModel
    {
        public Int64 UserId { get; set; }
        public string UserName { get; set; }
        public string HomePage { get; set; }
        public string HomePage_Action { get; set; }
        public string HomePage_Controller { get; set; }
        public string HomePage_Area { get; set; }
        
        public string UserPassword { get; set; }
        public Int64 RoleId { get; set; }
        public string RoleName { get; set; }
        public Int64 AccountId { get; set; }
        
        
        //public static UserRoleAndRightsModel GetUserRoleAndRights
        //{
        //    get
        //    {
        //        return (UserRoleAndRightsModel)HttpContext.Current.Items["UserRoleAndRights"];
        //    }
        //}

    }
}
