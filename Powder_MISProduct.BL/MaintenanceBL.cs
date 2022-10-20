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
   public class MaintenanceBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Maintenance Log Report
        /// <summary>

        /// </summary>
        public ApplicationResult MaintenanceReport(DateTime FromDatetime, DateTime ToDatetime)
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



                strStoredProcName = "usp_Maintenance_SelectAll_Details";

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

        #region Maintenance Log Report
        /// <summary>

        /// </summary>
        public ApplicationResult MaintenanceReportSelect()
        {
            try
            {

                strStoredProcName = "usp_Maintainance_SelectAll";

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

        #region Insert Maintenance Details

        public ApplicationResult Maintenance_Insert(MaintenanceBO objMaintenanceBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[13];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMaintenanceBo.Id;

                pSqlParameter[1] = new SqlParameter("@Date", SqlDbType.Date);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMaintenanceBo.Date;

                pSqlParameter[2] = new SqlParameter("@EquipmentTagNo", SqlDbType.NVarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMaintenanceBo.EquipmentTagNo;

                pSqlParameter[3] = new SqlParameter("@EquipmentName", SqlDbType.NVarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMaintenanceBo.EquipmentName;

                pSqlParameter[4] = new SqlParameter("@StartTime", SqlDbType.Time);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMaintenanceBo.StartTime;

                pSqlParameter[5] = new SqlParameter("@EndTime", SqlDbType.Time);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMaintenanceBo.EndTime;

                pSqlParameter[6] = new SqlParameter("@PartNo", SqlDbType.NVarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMaintenanceBo.PartNo;

                pSqlParameter[7] = new SqlParameter("@Area", SqlDbType.NVarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMaintenanceBo.Area;

                pSqlParameter[8] = new SqlParameter("@ProblemDetails", SqlDbType.NVarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMaintenanceBo.ProblemDetails;

                pSqlParameter[9] = new SqlParameter("@ActionTaken", SqlDbType.NVarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMaintenanceBo.ActionTaken;

                pSqlParameter[10] = new SqlParameter("@RectifiedBy", SqlDbType.NVarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMaintenanceBo.RectifiedBy;

                pSqlParameter[11] = new SqlParameter("@Remark", SqlDbType.NVarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMaintenanceBo.Remark;

                pSqlParameter[12] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMaintenanceBo.IsDeleted;


                sSql = "usp_Maintainance_Insert";
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
                objMaintenanceBo = null;
            }
        }
        #endregion

        #region Update Maintenance Details

        public ApplicationResult Maintenance_Update(MaintenanceBO objMaintenanceBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[14];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objMaintenanceBo.Id;

                pSqlParameter[1] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objMaintenanceBo.Date;

                pSqlParameter[2] = new SqlParameter("@EquipmentTagNo", SqlDbType.NVarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objMaintenanceBo.EquipmentTagNo;

                pSqlParameter[3] = new SqlParameter("@EquipmentName", SqlDbType.NVarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objMaintenanceBo.EquipmentName;

                pSqlParameter[4] = new SqlParameter("@StartTime", SqlDbType.Time);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objMaintenanceBo.StartTime;

                pSqlParameter[5] = new SqlParameter("@EndTime", SqlDbType.Time);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objMaintenanceBo.EndTime;

                pSqlParameter[6] = new SqlParameter("@PartNo", SqlDbType.NVarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objMaintenanceBo.PartNo;

                pSqlParameter[7] = new SqlParameter("@Area", SqlDbType.NVarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objMaintenanceBo.Area;

                pSqlParameter[8] = new SqlParameter("@ProblemDetails", SqlDbType.NVarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objMaintenanceBo.ProblemDetails;

                pSqlParameter[9] = new SqlParameter("@ActionTaken", SqlDbType.NVarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objMaintenanceBo.ActionTaken;

                pSqlParameter[10] = new SqlParameter("@RectifiedBy", SqlDbType.NVarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objMaintenanceBo.RectifiedBy;

                pSqlParameter[11] = new SqlParameter("@Remark", SqlDbType.NVarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objMaintenanceBo.Remark;

                pSqlParameter[12] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objMaintenanceBo.LastModifiedBy;

                pSqlParameter[13] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objMaintenanceBo.LastModifiedDate;


                sSql = "usp_Maintainance_Update";
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
                objMaintenanceBo = null;
            }
        }
        #endregion

        #region Select  Maintenance Details
        /// <summary>

        /// </summary>
        public ApplicationResult Maintenance_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_Maintainance_Select";

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

        #region Delete Maintenance Details by 
        /// <summary>
        /// To Delete details of Employee for selected  from Employee table
        /// Created By : Nirmal, 27-04-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Maintenance_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                pSqlParameter[2] = new SqlParameter("@LastModifiedDate", SqlDbType.VarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = strLastModifiedDate;

                strStoredProcName = "usp_Maintainance_Delete";

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
