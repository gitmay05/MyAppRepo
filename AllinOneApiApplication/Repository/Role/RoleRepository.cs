using AllinOneApiApplication.CommonDataAccess;
using AllinOneApiApplication.Interface.Role;
using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Role;
using System.Data.SqlClient;
using System.Data;
using AllinOneApiApplication.Model.Form;
using AllinOneApiApplication.Model.UserModel;
using Microsoft.SqlServer.Server;

namespace AllinOneApiApplication.Repository.Role
{
	public class RoleRepository : IRole
	{
		#region
		static DataFunctions objDataFunctions = null;
		System.Data.DataSet objDataSet = null;
		List<RoleModel> _List = null;
		static string _commandText = string.Empty;
		#endregion
		public RoleRepository()
		{
			objDataFunctions = new DataFunctions();
		}

      
        public List<RoleRightsMappingModel> BindMenuFormsForRole(Int64 RoleId)
		{
			List<RoleRightsMappingModel>  _FormRoleMappinglist = new List<RoleRightsMappingModel>();
			try
			{
				_commandText = "[dbo].[usp.BindFormForRole]";
				List<SqlParameter> parms = new List<SqlParameter>()
			{
				new SqlParameter("@FK_RoleId", RoleId)

			};
				CheckParameters.ConvertNullToDBNull(parms);
				objDataSet = (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);

				if (objDataSet.Tables[0].Rows.Count > 0)
				{
					_FormRoleMappinglist = objDataSet.Tables[0].AsEnumerable().Select(dr => new RoleRightsMappingModel()
					{

						FK_ParentId = dr.Field<Int64>("FK_ParentId"),
						PK_FormId = dr.Field<Int64>("FK_FormId"),
						FormName = dr.Field<string>("FormName"),
						CanAdd = dr.Field<bool>("CanAdd"),
						CanEdit = dr.Field<bool>("CanEdit"),
						CanView = dr.Field<bool>("CanView"),
						CanDelete = dr.Field<bool>("CanDelete"),
						CanAll = dr.Field<bool>("CanAll"),
						FK_Sort_Id = dr.Field<Int64>("SortId")
				
					}).ToList();
				}
			}
			catch (Exception ex)
			{

				var objBase = System.Reflection.MethodBase.GetCurrentMethod();
				//ErrorLogDAL.SetError("AllInOne", objBase.DeclaringType.Assembly.GetName().Name, objBase.DeclaringType.FullName, "", objBase.Name, ex.Message, "ADDITIONAL REMARKS");
			}

			return _FormRoleMappinglist;
		}

		public List<RoleModel> GetRoleDetails(Int64 RoleId)
		{
			_List = new List<RoleModel>();
			var result = _List;
			

			System.Data.DataSet ? objDataSet = null;
			try
			{
				List<SqlParameter> parms = new List<SqlParameter>()
				{

					new SqlParameter("@iPK_RoleId",RoleId),

				};

				_commandText = "[dbo].[USP_GetRoleDetails]";
				objDataSet = (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
				if (objDataSet.Tables[0].Rows.Count > 0)
				{

					if (objDataSet.Tables[0].Rows[0].Field<int>("Message_Id") == 1)
					{
						_List = objDataSet.Tables[1].AsEnumerable().Select(dr => new RoleModel()
						{

							PK_RoleId = dr.Field<Int64>("PK_RoleId"),
							RoleName = dr.Field<string>("RoleName"),
							CreatedBy = dr.Field<string>("CreatedBy"),
							CreatedDate = dr.Field<string>("CreatedDate"),
							Status = dr.Field<string>("Status"),	
						}).ToList();
						objDataSet.Dispose();
						result = _List;
					}
					//else
					//{
					//	result = null;
					//}
				}

			}
			catch (Exception e)
			{
				//result = null;
			}
			return result;

		}

		public Message AddEditRoleDetails(string JsonData,string RoleName, Int64 RoleId, Int64 HomePageId, Int64 SessionUserId)
		{
			Message objMessages = new Message();
			try
			{
				_commandText = "[dbo].[USP_AddEditFormRole]";
				List<SqlParameter> parms = new List<SqlParameter>
				{
					new SqlParameter("@JsonData",JsonData),
					new SqlParameter("@iPK_RoleId",RoleId),
					new SqlParameter("@cRoleName",RoleName),
					new SqlParameter("@iHomePageId",HomePageId),
					new SqlParameter("@iUserId",SessionUserId),
				
				};
				CheckParameters.ConvertNullToDBNull(parms);
				objDataSet = (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
				if (objDataSet.Tables[0].Rows.Count > 0)
				{
					objMessages.MsgId = objDataSet.Tables[0].Rows[0].Field<int>("Message_Id");
					objMessages.Msg = objDataSet.Tables[0].Rows[0].Field<string>("Message");
				}
				else
				{
					objMessages.MsgId = 0;
					objMessages.Msg = "ProcessFailed";
				}
			}
			catch (Exception ex)
			{
				var objBase = System.Reflection.MethodBase.GetCurrentMethod();
			}
			return objMessages;
		}

		public Message DeleteRoleDetails(Int64 RoleId, Int64 SessionUserId)
		{
			Message objMessages = new Message();
			_commandText = "[dbo].[USP_DeleteRole]";
			try
			{
				List<SqlParameter> parms = new List<SqlParameter>()
				{
					new SqlParameter("@iPK_RoleId",RoleId),
					new SqlParameter ("@iUserId",SessionUserId),

				};
				CheckParameters.ConvertNullToDBNull(parms);
				objDataSet = (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
				if (objDataSet.Tables[0].Rows.Count > 0)
				{
					objMessages.MsgId = objDataSet.Tables[0].Rows[0].Field<int>("Message_Id");
					objMessages.Msg = objDataSet.Tables[0].Rows[0].Field<string>("Message");
				}
				else
				{
					objMessages.MsgId = 0;
					objMessages.Msg = "Process Failed";
				}
			}
			catch (Exception ex)
			{
				var objBase = System.Reflection.MethodBase.GetCurrentMethod();
				// ErrorLogDAL.SetError("AllInOne", objBase.DeclaringType.Assembly.GetName().Name, objBase.DeclaringType.FullName, "", objBase.Name, ex.Message, "ADDITIONAL REMARKS");
			}

			return objMessages;
		}

		
	

	}
}
