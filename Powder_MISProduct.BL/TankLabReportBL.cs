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
    public class TankLabReportBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region TankerLabReport selectAll
        /// <summary>

        /// </summary>
        public ApplicationResult TankerLabReport(DateTime FromDatetime, DateTime ToDatetime)
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



                strStoredProcName = "usp_tankLab_Report_SelectAll_Details";

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

        #region TankerLabReport select
        /// <summary>

        /// </summary>
        public ApplicationResult TankerLabReportSelect()
        {
            try
            {

                strStoredProcName = "usp_tbl_TankLab_Report_SelectAll";

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

        #region Insert TankerLabReport Details

        public ApplicationResult TankerLabReportInsert(TankLabReportBO TankerLabReportBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[18];
                
                pSqlParameter[0] = new SqlParameter("@DateTime", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = TankerLabReportBO.DateTime;

                pSqlParameter[1] = new SqlParameter("@SampleTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = TankerLabReportBO.SampleTime;

                pSqlParameter[2] = new SqlParameter("@SampleID", SqlDbType.NVarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = TankerLabReportBO.SampleID;

                pSqlParameter[3] = new SqlParameter("@SiloTagNo", SqlDbType.NVarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = TankerLabReportBO.SiloTagNo;

                pSqlParameter[4] = new SqlParameter("@TankName", SqlDbType.NVarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = TankerLabReportBO.TankName;

                pSqlParameter[5] = new SqlParameter("@Temp", SqlDbType.NVarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = TankerLabReportBO.Temp;

                pSqlParameter[6] = new SqlParameter("@SNF", SqlDbType.NVarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = TankerLabReportBO.SNF;

                pSqlParameter[7] = new SqlParameter("@FAT", SqlDbType.NVarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = TankerLabReportBO.FAT;

                pSqlParameter[8] = new SqlParameter("@TS", SqlDbType.NVarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = TankerLabReportBO.TS;

                pSqlParameter[9] = new SqlParameter("@pH", SqlDbType.NVarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = TankerLabReportBO.pH;

                pSqlParameter[10] = new SqlParameter("@Acidity", SqlDbType.NVarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = TankerLabReportBO.Acidity;

                pSqlParameter[11] = new SqlParameter("@Protein", SqlDbType.NVarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = TankerLabReportBO.Protein;

                pSqlParameter[12] = new SqlParameter("@tankStatus", SqlDbType.NVarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = TankerLabReportBO.tankStatus;

                pSqlParameter[13] = new SqlParameter("@TDS", SqlDbType.NVarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = TankerLabReportBO.TDS;

                pSqlParameter[14] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = TankerLabReportBO.Remarks;

                pSqlParameter[15] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = TankerLabReportBO.IsDeleted;

                pSqlParameter[16] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = TankerLabReportBO.CreatedDate;

                pSqlParameter[17] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = TankerLabReportBO.CreatedBy;


                sSql = "usp_tbl_TankLab_Report_Insert";
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
                TankerLabReportBO = null;
            }
        }
        #endregion

        #region Update Tank lab report Details

        public ApplicationResult TankerLabReportUpdate(TankLabReportBO TankerLabReportBO)
        {
            try
            {
                pSqlParameter = new SqlParameter[19];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = TankerLabReportBO.Id;

                pSqlParameter[1] = new SqlParameter("@DateTime", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = TankerLabReportBO.DateTime;

                pSqlParameter[2] = new SqlParameter("@SampleTime", SqlDbType.DateTime);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = TankerLabReportBO.SampleTime;

                pSqlParameter[3] = new SqlParameter("@SampleID", SqlDbType.NVarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = TankerLabReportBO.SampleID;

                pSqlParameter[4] = new SqlParameter("@SiloTagNo", SqlDbType.NVarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = TankerLabReportBO.SiloTagNo;

                pSqlParameter[5] = new SqlParameter("@TankName", SqlDbType.NVarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = TankerLabReportBO.TankName;

                pSqlParameter[6] = new SqlParameter("@Temp", SqlDbType.NVarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = TankerLabReportBO.Temp;

                pSqlParameter[7] = new SqlParameter("@SNF", SqlDbType.NVarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = TankerLabReportBO.SNF;

                pSqlParameter[8] = new SqlParameter("@FAT", SqlDbType.NVarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = TankerLabReportBO.FAT;

                pSqlParameter[9] = new SqlParameter("@TS", SqlDbType.NVarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = TankerLabReportBO.TS;

                pSqlParameter[10] = new SqlParameter("@pH", SqlDbType.NVarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = TankerLabReportBO.pH;

                pSqlParameter[11] = new SqlParameter("@Acidity", SqlDbType.NVarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = TankerLabReportBO.Acidity;

                pSqlParameter[12] = new SqlParameter("@Protein", SqlDbType.NVarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = TankerLabReportBO.Protein;

                pSqlParameter[13] = new SqlParameter("@tankStatus", SqlDbType.NVarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = TankerLabReportBO.tankStatus;

                pSqlParameter[14] = new SqlParameter("@TDS", SqlDbType.NVarChar);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = TankerLabReportBO.TDS;

                pSqlParameter[15] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = TankerLabReportBO.Remarks;

                pSqlParameter[16] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = TankerLabReportBO.LastModifiedBy;

                pSqlParameter[17] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = TankerLabReportBO.LastModifiedDate;


                sSql = "usp_tbl_TankLab_Report_Update";
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
                TankerLabReportBO = null;
            }
        }
        #endregion

        #region Select  tank lab report Details
        /// <summary>

        /// </summary>
        public ApplicationResult TankerLabReportSelect(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_tbl_TankLab_Report_Select";

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

        #region Delete tank lab report Details by 
        /// <summary>
        /// To Delete details of Employee for selected  from Employee table
        /// Created By : Nirmal, 27-04-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult TankerLabReportDelete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_tbl_TankLab_Report_Delete";

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
