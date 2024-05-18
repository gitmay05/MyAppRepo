using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Form;
using AllinOneApiApplication.Model.Role;

namespace AllinOneApiApplication.Interface.Role
{
	public interface IRole
	{
		List<RoleRightsMappingModel> BindMenuFormsForRole(Int64 RoleId);
		List<RoleModel> GetRoleDetails(Int64 RoleId);
		Message AddEditRoleDetails(string JsonData, string ?RoleName, Int64 RoleId, Int64 HomePageId, Int64 SessionUserId);
		Message DeleteRoleDetails(Int64 RoleId, Int64 SessionUserId);
	}
}
