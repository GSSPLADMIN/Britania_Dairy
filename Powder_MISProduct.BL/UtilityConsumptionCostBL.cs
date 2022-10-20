using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Powder_MISProduct.Common;
using Powder_MISProduct.DataAccess;
using Powder_MISProduct.BO;

namespace Powder_MISProduct.BL
{
    public class UtilityConsumptionCostBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Utility consumption cost grid binding
        public ApplicationResult UtilityConsumpCostBindGrid()
        {
            try
            {
                strStoredProcName = "usp_tbl_UtilityCost_SelectAll";

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

        #region Select  utility cost report Details
        public ApplicationResult UtilityCostSelect(int intId=0)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_tbl_UtilityCost_Select";

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

        #region Insert Utility cost Details

        public ApplicationResult UtilityCostInsert(UtilityConsumptionCostBO objBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[16];

                pSqlParameter[0] = new SqlParameter("@SteamCost", SqlDbType.Float);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objBO.SteamCost;

                pSqlParameter[1] = new SqlParameter("@ElectricityCost", SqlDbType.Float);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objBO.ElectricityCost;

                pSqlParameter[2] = new SqlParameter("@AirCost", SqlDbType.Float);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objBO.AirCost;

                pSqlParameter[3] = new SqlParameter("@SoftWaterCost", SqlDbType.Float);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objBO.SoftWaterCost;

                pSqlParameter[4] = new SqlParameter("@ChilledWaterCost", SqlDbType.Float);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objBO.ChilledWaterCost;
                
                pSqlParameter[5] = new SqlParameter("@ROWaterCost", SqlDbType.Float);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objBO.ROWaterCost;
                
                pSqlParameter[6] = new SqlParameter("@RawWaterCost", SqlDbType.Float);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objBO.RawWaterCost;

                pSqlParameter[7] = new SqlParameter("@SCM_Steam", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objBO.SCM_Steam;

                pSqlParameter[8] = new SqlParameter("@SCM_ElectricityCost", SqlDbType.Float);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objBO.SCM_ElectricityCost;

                pSqlParameter[9] = new SqlParameter("@SCM_Air", SqlDbType.Float);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objBO.SCM_Air;

                pSqlParameter[10] = new SqlParameter("@SCM_SoftWater", SqlDbType.Float);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objBO.SCM_SoftWater;

                pSqlParameter[11] = new SqlParameter("@SCM_ChilledWater", SqlDbType.Float);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objBO.SCM_ChilledWater;

                pSqlParameter[12] = new SqlParameter("@SCM_ROWaterCost", SqlDbType.Float);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objBO.SCM_ROWaterCost;

                pSqlParameter[13] = new SqlParameter("@SCM_RawWaterCost", SqlDbType.Float);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objBO.SCM_RawWaterCost;

                pSqlParameter[14] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objBO.CreatedBy;

                pSqlParameter[15] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objBO.CreatedDate;

                sSql = "usp_tbl_UtilityCost_Insert";
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
                objBO = null;
            }
        }
        #endregion

        #region Update Utility Cost Details

        public ApplicationResult UtilityCostUpdate(UtilityConsumptionCostBO objBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[10];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objBO.Id;

                pSqlParameter[1] = new SqlParameter("@SteamCost", SqlDbType.Float);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objBO.SteamCost;

                pSqlParameter[2] = new SqlParameter("@ElectricityCost", SqlDbType.Float);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objBO.ElectricityCost;

                pSqlParameter[3] = new SqlParameter("@AirCost", SqlDbType.Float);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objBO.AirCost;

                pSqlParameter[4] = new SqlParameter("@SoftWaterCost", SqlDbType.Float);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objBO.SoftWaterCost;

                pSqlParameter[5] = new SqlParameter("@ChilledWaterCost", SqlDbType.Float);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objBO.ChilledWaterCost;

                pSqlParameter[6] = new SqlParameter("@ROWaterCost", SqlDbType.Float);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objBO.ROWaterCost;

                pSqlParameter[7] = new SqlParameter("@RawWaterCost", SqlDbType.Float);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objBO.RawWaterCost;

                pSqlParameter[8] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objBO.LastModifiedBy;

                pSqlParameter[9] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objBO.LastModifiedDate;


                sSql = "usp_tbl_UtilityCost_Update";
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
                objBO = null;
            }
        }
        #endregion

    }
}
