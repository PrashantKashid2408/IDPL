using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Business.DataAccess.Wrapper;
using Core.Business.DataAccess.Mapper;
using Core.Business.DataAccess.DataAccessLayer.General;
using Core.Business.DataAccess.DataAccessLayer;
using Core.Entity;
using Core.Business.DataAccess.Constants;
using Core.Utility;
using Core.Entity.Common;
using Core.Utility.Common;
using Core.Entity.Enums;
using IDPL.Resources;

namespace Core.Business.BusinessFacade
{
    public class OperatorBusinessFacade//:UniversalObject
    {
        private dynamic objdynamicWrapper;
        private OperatorWrapperColletion objOperatorWrapperColletion = new OperatorWrapperColletion();
        private OperatorWrapper objOperatorWrapper = new OperatorWrapper();
        private static readonly string _module = "Core.Business.BusinessFacade.OperatorBusinessFacade";

        public OperatorBusinessFacade()
        {
        }

        public List<Operator> GetRecordsBy_ID(string id)
        {
            List<Operator> _temp = new List<Operator>();

            try
            {
                objOperatorWrapperColletion.GetDataBy_ID(id);
                _temp = objOperatorWrapperColletion.Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecords(ID:" + id + ")", ex.Source, ex.Message, ex);
            }

            return _temp;
        }

        public List<Operator> GetListRecords()
        {
            List<Operator> _data = new List<Operator>();
            try
            {
                _data = objOperatorWrapperColletion.GetListRecords();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetListRecords()", ex.Source, ex.Message, ex);
            }

            return _data;
        }

        public JsonMessage ChangeStatus(long ID, string StatusID)
        {
            JsonMessage _jsonMessage = null;
            try
            {
                OperatorWrapper objWrapper = new OperatorWrapper();
                objWrapper.ChangeStatus(ID, StatusID);
                string strMessage = "";
                if (StatusID == "0")
                    strMessage = "Academic Year Disabled";
                else if (StatusID == "1")
                    strMessage = "Academic Year Enabled";
                else if (StatusID == "2")
                    strMessage = Resource.lbl_accountDeleted;
                _jsonMessage = new JsonMessage(true, Resource.lbl_success, strMessage, KeyEnums.JsonMessageType.SUCCESS, "", "");
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "0", null);
                Log.WriteLog(_module, "ChangeStatus(ID=" + ID + ",StatusID=" + StatusID + ")", ex.Source, ex.Message, ex);
            }

            return _jsonMessage;
        }

        public bool Save(dynamic objEntity)
        {
            try
            {
                objOperatorWrapper.objWrapperClass = objEntity;
                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objOperatorWrapper.Save(ref CommandsObj, ref commandCounter);
                TransObj.AddCommandList(CommandsObj);
                if (TransObj.ExecuteTransaction())
                {
                    long ID = 0;
                    if (long.TryParse(TransObj.ReturnID, out ID) && ID > 0)
                    {
                        objEntity.ID = ID;
                    }
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally { }
        }
    }
}