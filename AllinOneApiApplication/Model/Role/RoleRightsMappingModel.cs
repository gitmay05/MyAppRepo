namespace AllinOneApiApplication.Model.Role
{
	public class RoleRightsMappingModel
	{
		public Int64? PK_FormId { get; set; }
		public Int64 FK_ParentId { get; set; }
		public string ? FormName { get; set; }
		public bool All { get; set; }
		public bool CanAdd { get; set; }
		public bool CanEdit { get; set; }
		public bool CanView { get; set; }
		public bool CanDelete { get; set; }
		public Int64 CreatedBy { get; set; }
		public Int64 FK_Sort_Id { get; set; }
		public bool CanAll { get; set; }
	}
}
