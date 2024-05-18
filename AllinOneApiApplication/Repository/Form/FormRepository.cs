using AllinOneApiApplication.CommonDataAccess;
using AllinOneApiApplication.Interface.Form;
using AllinOneApiApplication.Model.Common;
using AllinOneApiApplication.Model.Form;
using System.Data.SqlClient;
using System.Data;

namespace AllinOneApiApplication.Repository.Form
{
    public class FormRepository : IForm
    {
        #region
        static DataFunctions objDataFunctions = null;
        System.Data.DataSet objDataSet = null;
        List<FormModel> _List = null;
        static string _commandText = string.Empty;
        #endregion
        public FormRepository()
        {
            objDataFunctions = new DataFunctions();
        }
        public List<FormModel> GetFormDetails(Int64 FormId)
        {

            var result = _List;
            _List = new List<FormModel>();

            System.Data.DataSet objDataSet = null;
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>()
                {

                    new SqlParameter("@iPK_FormId",FormId),

                };

                _commandText = "[dbo].[USP_GetFormDetails]";
                objDataSet = (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
                if (objDataSet.Tables[0].Rows.Count > 0)
                {

                    if (objDataSet.Tables[0].Rows[0].Field<int>("Message_Id") == 1)
                    {
                        _List = objDataSet.Tables[1].AsEnumerable().Select(dr => new FormModel()
                        {

                            PK_FormId = dr.Field<Int64>("PK_FormId"),
                            FK_ParentId = dr.Field<Int64>("FK_ParentId"),
                            FormName = dr.Field<string>("FormName"),
                            ControllerName = dr.Field<string>("FormName"),
                            ActionName = dr.Field<string>("ActionName"),
                            // ClassName = dr.Field<string>("ClassName"),
                            //  Area = dr.Field<string>("FormName"),
                            Status = dr.Field<string>("Status"),
                            CreatedDate = dr.Field<string>("CreatedDate"),
                            //UserName = dr.Field<string>("UserName"),
                            ParentForm = dr.Field<string>("ParentForm")

                        }).ToList();
                        objDataSet.Dispose();
                        result = _List;
                    }
                    else
                    {
                        result = null;
                    }
                }

            }
            catch (Exception e)
            {
                result = null;
            }
            return result;

        }

        public Message AddEditFormDetails(FormModel formDetails)
        {
            Message objMessages = new Message();
            try
            {
                _commandText = "[dbo].[USP_AddEditForm]";
                List<SqlParameter> parms = new List<SqlParameter>
                {
                    new SqlParameter("@iPK_FormId",formDetails.PK_FormId),
                    new SqlParameter("@cFormName",formDetails.FormName),
                    new SqlParameter("@cControllerName",formDetails.ControllerName==null?"":formDetails.ControllerName.Trim()),
                    new SqlParameter("@cActionName",formDetails.ActionName==null?"":formDetails.ActionName.Trim()),
                    new SqlParameter("@iFK_ParentId",formDetails.FK_ParentId),
                    new SqlParameter("@cClassName", formDetails.ClassName==null?"":formDetails.ClassName.Trim()),
                    new SqlParameter("@cArea",formDetails.Area==null?"":formDetails.Area.Trim()),
                    new SqlParameter("@bIsActive",formDetails.IsActive),
                    new SqlParameter("@iUserId",formDetails.CreatedBy),

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
        public Message DeleteFormsDetails(Int64 formID, Int64 userId)
        {
            Message objMessages = new Message();
            _commandText = "[dbo].[USP_DeleteForm]";
            try
            {
                List<SqlParameter> parms = new List<SqlParameter>()
                {
                    new SqlParameter("@iPK_FormId",formID),
                    new SqlParameter ("@iUserId",userId),

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

        //public IEnumerable<Dropdown> GetParentForms(Int64 FormId)
        //{
        //    List<Dropdown> _List = new List<Dropdown>();
        //    var result = _List;


        //    System.Data.DataSet objDataSet = null;
        //    try
        //    {
        //        List<SqlParameter> parms = new List<SqlParameter>()
        //        {

        //            new SqlParameter("@id","1"),

        //        };

        //        _commandText = "[dbo].[USP_GetFormDetails]";
        //        objDataSet = (DataSet)objDataFunctions.getQueryResult(_commandText, DataReturnType.DataSet, parms);
        //        if (objDataSet.Tables[0].Rows.Count > 0)
        //        {

        //            if (objDataSet.Tables[0].Rows[0].Field<int>("Message_Id") == 1)
        //            {
        //                _List = objDataSet.Tables[1].AsEnumerable().Select(dr => new Dropdown()
        //                {

        //                    Id = dr.Field<Int64>("Id"),
        //                    Value = dr.Field<string>("Value")
        //                }).ToList();
        //                objDataSet.Dispose();
        //                result = _List;
        //            }
        //            else
        //            {
        //                result = null;
        //            }
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        result = null;
        //    }
        //    return result;
        //}


    }
}
