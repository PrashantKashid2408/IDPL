using CommonUtilities;
using System;
using System.Collections.Generic;
namespace Core.Business.DataAccess.DataAccessLayer
{
    public class TransactionHandler
    {
        public TransactionHandler()
        {

        }

        public bool ExecuteUserTransactions(Dictionary<string, Command> commandList)
        {
            bool retValue = false;

            try
            {
                Core.Business.DataAccess.DataAccessLayer.DataAccess objDataAccess = new Core.Business.DataAccess.DataAccessLayer.DataAccess();
                Transaction objTransaction = new Transaction(objDataAccess);
                objTransaction.ConnectionString = dbClass.SqlConnectString();
                objTransaction.AddCommandList(commandList);

                if (objTransaction.ExecuteTransaction())
                    retValue = true;
            }
            catch (Exception ex)
            {
                Log.Write("", "", ex.Source, ex.Message);
            }

            return retValue;
        }


    }
}
