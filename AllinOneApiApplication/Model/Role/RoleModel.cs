using System.ComponentModel.DataAnnotations;

namespace AllinOneApiApplication.Model.Role
{
    public class NewRoleModel
    {
        public string? RoleName { get; set; }

    }
    public class RoleModel
	{
		public Int64 PK_RoleId { get; set; }
		public string? RoleName { get; set; }
		public Int64 HomePageId { get; set; }
		public Int64 CategoryId { get; set; }
		public Int64 FK_AccountId { get; set; }
        public Int64 FK_HomePageFormId { get; set; }
        public bool IsActive { get; set; }
		public string? CreatedBy { get; set; }
		public string? CreatedDate { get; set; }	
		public string? Status { get; set; }
		public Int64 SessionAccountId { get; set; }

        public List<RoleRightsMappingModel> Item { get; set; }

    }
}
