using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using Powder_MISProduct.Common;
using Powder_MISProduct.DataAccess;
using Powder_MISProduct.BO;

namespace Powder_MISProduct.BL
{
   public class InventoryBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Inventory Log Report
        /// <summary>

        /// </summary>
        public ApplicationResult InventoryReport(DateTime FromDatetime, DateTime ToDatetime)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];

                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDatetime;

                pSqlParameter[1] = new SqlParameter("@ToDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = ToDatetime;



                strStoredProcName = "usp_Inventory_SelectAll_Details";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Inventory Log Report
        /// <summary>

        /// </summary>
        public ApplicationResult InventoryReportSelect()
        {
            try
            {
              
                strStoredProcName = "usp_Inventory_SelectAll";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Insert Inventory Details

        public ApplicationResult Inventory_Insert(InventoryBO objInventoryBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[10];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objInventoryBo.Id;

                pSqlParameter[1] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objInventoryBo.Date;

                pSqlParameter[2] = new SqlParameter("@Itemdesc", SqlDbType.NVarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objInventoryBo.Itemdesc;

                pSqlParameter[3] = new SqlParameter("@MakeType", SqlDbType.NVarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objInventoryBo.MakeType;

                pSqlParameter[4] = new SqlParameter("@BatchNumber", SqlDbType.NVarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objInventoryBo.BatchNumber;

                pSqlParameter[5] = new SqlParameter("@Quantity", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objInventoryBo.Quantity;

                pSqlParameter[6] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objInventoryBo.Remarks;

                pSqlParameter[7] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objInventoryBo.CreatedBy;

                pSqlParameter[8] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objInventoryBo.CreatedDate;

                pSqlParameter[9] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objInventoryBo.IsDeleted;


                sSql = "usp_Inventory_Insert";
                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objInventoryBo = null;
            }
        }
        #endregion

        #region Update Inventory Details

        public ApplicationResult Inventory_Update(InventoryBO objInventoryBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[9];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objInventoryBo.Id;

                pSqlParameter[1] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objInventoryBo.Date;

                pSqlParameter[2] = new SqlParameter("@Itemdesc", SqlDbType.NVarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objInventoryBo.Itemdesc;

                pSqlParameter[3] = new SqlParameter("@MakeType", SqlDbType.NVarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objInventoryBo.MakeType;

                pSqlParameter[4] = new SqlParameter("@BatchNumber", SqlDbType.NVarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objInventoryBo.BatchNumber;

                pSqlParameter[5] = new SqlParameter("@Quantity", SqlDbType.Int);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objInventoryBo.Quantity;

                pSqlParameter[6] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objInventoryBo.Remarks;

                pSqlParameter[7] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objInventoryBo.LastModifiedBy;

                pSqlParameter[8] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objInventoryBo.LastModifiedDate;


                sSql = "usp_Inventory_Update";
                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, sSql, pSqlParameter);

                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                objInventoryBo = null;
            }
        }
        #endregion

        #region Select  Inventory Details
        /// <summary>
       
        /// </summary>
        public ApplicationResult Inventory_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_Inventory_Select";

                DataTable dtResult = new DataTable();
                dtResult = Database.ExecuteDataTable(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);
                ApplicationResult objResults = new ApplicationResult(dtResult);
                objResults.Status = ApplicationResult.CommonStatusType.Success;
                return objResults;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion

        #region Delete Inventory Details by 
        /// <summary>
        /// To Delete details of Employee for selected  from Employee table
        /// Created By : Nirmal, 27-04-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Inventory_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[3];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                pSqlParameter[1] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = intLastModifiedBy;

                pSqlParameter[2] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strLastModifiedDate;

                strStoredProcName = "usp_Inventory_Delete";

                int iResult = Database.ExecuteNonQuery(CommandType.StoredProcedure, strStoredProcName, pSqlParameter);

                if (iResult > 0)
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Success;
                    return objResults;
                }
                else
                {
                    ApplicationResult objResults = new ApplicationResult();
                    objResults.Status = ApplicationResult.CommonStatusType.Failure;
                    return objResults;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
