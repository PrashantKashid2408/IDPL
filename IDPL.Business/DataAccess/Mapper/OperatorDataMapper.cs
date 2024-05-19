using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.DataAccess.Constants;
using System.Data.SqlClient;
using System.Data;
using Core.Entity;
using Core.Entity.Common;
using Core.Utility.Common;

namespace Core.Business.DataAccess.Mapper
{
    public class OperatorDataMapper
    {
        private static readonly string _module = "Core.Business.DataAccess.Mapper.OperatorDataMapper";
        private Operator objOperator = null;

        public Operator GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objOperator = new Operator();

                if (sqlDataReader.HasColumn(OperatorDBFields.ID))
                    objOperator.ID = (sqlDataReader[OperatorDBFields.ID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[OperatorDBFields.ID]) : 0);
                if (sqlDataReader.HasColumn(OperatorDBFields.UserId))
                    objOperator.UserId = (sqlDataReader[OperatorDBFields.UserId] != DBNull.Value ? Convert.ToInt32(sqlDataReader[OperatorDBFields.UserId]) : 0);
                if (sqlDataReader.HasColumn(OperatorDBFields.OperatorName))
                    objOperator.OperatorName = (sqlDataReader[OperatorDBFields.OperatorName] != DBNull.Value ? Convert.ToString(sqlDataReader[OperatorDBFields.OperatorName]) : string.Empty);
                if (sqlDataReader.HasColumn(OperatorDBFields.UserName))
                    objOperator.UserName = (sqlDataReader[OperatorDBFields.UserName] != DBNull.Value ? Convert.ToString(sqlDataReader[OperatorDBFields.UserName]) : string.Empty);
                if (sqlDataReader.HasColumn(OperatorDBFields.Password))
                    objOperator.Password = (sqlDataReader[OperatorDBFields.Password] != DBNull.Value ? Convert.ToString(sqlDataReader[OperatorDBFields.Password]) : string.Empty);
                if (sqlDataReader.HasColumn(OperatorDBFields.StatusId))
                    objOperator.StatusId = (sqlDataReader[OperatorDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[OperatorDBFields.StatusId]) : (byte)0);
                if (sqlDataReader.HasColumn(OperatorDBFields.CreatedDate))
                    objOperator.CreatedDate = (sqlDataReader[OperatorDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[OperatorDBFields.CreatedDate]) : DateTime.Now);
                if (sqlDataReader.HasColumn(OperatorDBFields.UpdatedDate))
                    objOperator.UpdatedDate = (sqlDataReader[OperatorDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[OperatorDBFields.UpdatedDate]) : DateTime.Now);
                if (sqlDataReader.HasColumn(OperatorDBFields.RowNumber))
                    objOperator.RowNumber = (sqlDataReader[OperatorDBFields.RowNumber] != DBNull.Value ? Convert.ToInt32(sqlDataReader[OperatorDBFields.RowNumber]) : 0);

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objOperator;
        }

        public List<Operator> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<Operator> list = new List<Operator>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objOperator = GetDetails(sqlDataReader);
                    list.Add(objOperator);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<Operator> GetDetails(DataSet dataSet)
        {
            List<Operator> Operators = new List<Operator>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objOperator = new Operator();

                        if (drow.Table.Columns.Contains(OperatorDBFields.ID))
                            objOperator.ID = (drow[OperatorDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[OperatorDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(OperatorDBFields.UserId))
                            objOperator.UserId = (drow[OperatorDBFields.UserId] != DBNull.Value ? Convert.ToInt32(drow[OperatorDBFields.UserId]) : 0);
                        if (drow.Table.Columns.Contains(OperatorDBFields.OperatorName))
                            objOperator.OperatorName = (drow[OperatorDBFields.OperatorName] != DBNull.Value ? Convert.ToString(drow[OperatorDBFields.OperatorName]) : string.Empty);
                        if (drow.Table.Columns.Contains(OperatorDBFields.UserName))
                            objOperator.UserName = (drow[OperatorDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[OperatorDBFields.UserName]) : string.Empty);
                        if (drow.Table.Columns.Contains(OperatorDBFields.Password))
                            objOperator.Password = (drow[OperatorDBFields.Password] != DBNull.Value ? Convert.ToString(drow[OperatorDBFields.Password]) : string.Empty);
                        if (drow.Table.Columns.Contains(OperatorDBFields.StatusId))
                            objOperator.StatusId = (drow[OperatorDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[OperatorDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(OperatorDBFields.CreatedDate))
                            objOperator.CreatedDate = (drow[OperatorDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[OperatorDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(OperatorDBFields.UpdatedDate))
                            objOperator.UpdatedDate = (drow[OperatorDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[OperatorDBFields.UpdatedDate]) : DateTime.Now);


                        Operators.Add(objOperator);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return Operators;
        }

        public Operator GetDetailsobj(DataSet dataSet)
        {
            Operator objOperator = new Operator();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objOperator = new Operator();

                        if (drow.Table.Columns.Contains(OperatorDBFields.ID))
                            objOperator.ID = (drow[OperatorDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[OperatorDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(OperatorDBFields.UserId))
                            objOperator.UserId = (drow[OperatorDBFields.UserId] != DBNull.Value ? Convert.ToInt32(drow[OperatorDBFields.UserId]) : 0);
                        if (drow.Table.Columns.Contains(OperatorDBFields.OperatorName))
                            objOperator.OperatorName = (drow[OperatorDBFields.OperatorName] != DBNull.Value ? Convert.ToString(drow[OperatorDBFields.OperatorName]) : string.Empty);
                        if (drow.Table.Columns.Contains(OperatorDBFields.UserName))
                            objOperator.UserName = (drow[OperatorDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[OperatorDBFields.UserName]) : string.Empty);
                        if (drow.Table.Columns.Contains(OperatorDBFields.Password))
                            objOperator.Password = (drow[OperatorDBFields.Password] != DBNull.Value ? Convert.ToString(drow[OperatorDBFields.Password]) : string.Empty);
                        if (drow.Table.Columns.Contains(OperatorDBFields.StatusId))
                            objOperator.StatusId = (drow[OperatorDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[OperatorDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(OperatorDBFields.CreatedDate))
                            objOperator.CreatedDate = (drow[OperatorDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[OperatorDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(OperatorDBFields.UpdatedDate))
                            objOperator.UpdatedDate = (drow[OperatorDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[OperatorDBFields.UpdatedDate]) : DateTime.Now);


                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objOperator;
        }

        public Operator GetDetails(DataTable dataTable)
        {
            Operator objOperator = new Operator();

            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objOperator = new Operator();

                        if (drow.Table.Columns.Contains(OperatorDBFields.ID))
                            objOperator.ID = (drow[OperatorDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[OperatorDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(OperatorDBFields.UserId))
                            objOperator.UserId = (drow[OperatorDBFields.UserId] != DBNull.Value ? Convert.ToInt32(drow[OperatorDBFields.UserId]) : 0);
                        if (drow.Table.Columns.Contains(OperatorDBFields.OperatorName))
                            objOperator.OperatorName = (drow[OperatorDBFields.OperatorName] != DBNull.Value ? Convert.ToString(drow[OperatorDBFields.OperatorName]) : string.Empty);
                        if (drow.Table.Columns.Contains(OperatorDBFields.UserName))
                            objOperator.UserName = (drow[OperatorDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[OperatorDBFields.UserName]) : string.Empty);
                        if (drow.Table.Columns.Contains(OperatorDBFields.Password))
                            objOperator.Password = (drow[OperatorDBFields.Password] != DBNull.Value ? Convert.ToString(drow[OperatorDBFields.Password]) : string.Empty);
                        if (drow.Table.Columns.Contains(OperatorDBFields.StatusId))
                            objOperator.StatusId = (drow[OperatorDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[OperatorDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(OperatorDBFields.CreatedDate))
                            objOperator.CreatedDate = (drow[OperatorDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[OperatorDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(OperatorDBFields.UpdatedDate))
                            objOperator.UpdatedDate = (drow[OperatorDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[OperatorDBFields.UpdatedDate]) : DateTime.Now);


                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objOperator;
        }

    }
}
