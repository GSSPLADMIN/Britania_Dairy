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
  public  class WheyAnalysisBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region WheyAnalysis Log Report
        /// <summary>

        /// </summary>
        public ApplicationResult WheyAnalysisReport(DateTime FromDatetime, DateTime ToDatetime)
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



                strStoredProcName = "usp_WheyAnalysis_SelectAll_Details";

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
        public ApplicationResult WheyAnalysisReportSelect()
        {
            try
            {

                strStoredProcName = "usp_WheyAnalysis_SelectAll";

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

        #region Insert WheyAnalysis Details

        public ApplicationResult WheyAnalysis_Insert(WheyAnalysisBO objWheyAnalysisBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[24];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objWheyAnalysisBo.Id;

                pSqlParameter[1] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objWheyAnalysisBo.Date;
                                
                pSqlParameter[2] = new SqlParameter("@SampleName", SqlDbType.NVarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objWheyAnalysisBo.SampleName;

                pSqlParameter[3] = new SqlParameter("@SampleNo", SqlDbType.NVarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objWheyAnalysisBo.SampleNo;

                pSqlParameter[4] = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objWheyAnalysisBo.ProductName;

                pSqlParameter[5] = new SqlParameter("@OT", SqlDbType.NVarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objWheyAnalysisBo.OT;

                pSqlParameter[6] = new SqlParameter("@Temp", SqlDbType.NVarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objWheyAnalysisBo.Temp;

                pSqlParameter[7] = new SqlParameter("@Fat", SqlDbType.NVarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objWheyAnalysisBo.Fat;

                pSqlParameter[8] = new SqlParameter("@SNF", SqlDbType.NVarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objWheyAnalysisBo.SNF;

                pSqlParameter[9] = new SqlParameter("@Acidity", SqlDbType.NVarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objWheyAnalysisBo.Acidity;

                //pSqlParameter[10] = new SqlParameter("@COB", SqlDbType.NVarChar);
                //pSqlParameter[10].Direction = ParameterDirection.Input;
                //pSqlParameter[10].Value = objWheyAnalysisBo.COB;

                //pSqlParameter[11] = new SqlParameter("@AlcholTest65", SqlDbType.NVarChar);
                //pSqlParameter[11].Direction = ParameterDirection.Input;
                //pSqlParameter[11].Value = objWheyAnalysisBo.AlcholTest65;


                //pSqlParameter[12] = new SqlParameter("@AlcholTest", SqlDbType.NVarChar);
                //pSqlParameter[12].Direction = ParameterDirection.Input;
                //pSqlParameter[12].Value = objWheyAnalysisBo.AlcholTest;

                //pSqlParameter[13] = new SqlParameter("@Blactumantibiotictest", SqlDbType.NVarChar);
                //pSqlParameter[13].Direction = ParameterDirection.Input;
                //pSqlParameter[13].Value = objWheyAnalysisBo.Blactumantibiotictest;

                //pSqlParameter[14] = new SqlParameter("@MineralOilTest", SqlDbType.NVarChar);
                //pSqlParameter[14].Direction = ParameterDirection.Input;
                //pSqlParameter[14].Value = objWheyAnalysisBo.MineralOilTest;

                pSqlParameter[10] = new SqlParameter("@AnyOtherTest01", SqlDbType.NVarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objWheyAnalysisBo.AnyOtherTest01;

                pSqlParameter[11] = new SqlParameter("@AnyOtherTest02", SqlDbType.NVarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objWheyAnalysisBo.AnyOtherTest02;

                pSqlParameter[12] = new SqlParameter("@AnyOtherTest03", SqlDbType.NVarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objWheyAnalysisBo.AnyOtherTest03;

                pSqlParameter[13] = new SqlParameter("@AnyOtherTest04", SqlDbType.NVarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objWheyAnalysisBo.AnyOtherTest04;

                //pSqlParameter[19] = new SqlParameter("@Neutrilize", SqlDbType.NVarChar);
                //pSqlParameter[19].Direction = ParameterDirection.Input;
                //pSqlParameter[19].Value = objWheyAnalysisBo.Neutrilize;

                pSqlParameter[14] = new SqlParameter("@Urea", SqlDbType.NVarChar);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objWheyAnalysisBo.Urea;

                pSqlParameter[15] = new SqlParameter("@Salt", SqlDbType.NVarChar);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objWheyAnalysisBo.Salt;

                pSqlParameter[16] = new SqlParameter("@Startch", SqlDbType.NVarChar);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objWheyAnalysisBo.Startch;

                pSqlParameter[17] = new SqlParameter("@FPD", SqlDbType.NVarChar);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objWheyAnalysisBo.FPD;

                pSqlParameter[18] = new SqlParameter("@Status", SqlDbType.NVarChar);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objWheyAnalysisBo.Status;

                pSqlParameter[19] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objWheyAnalysisBo.Remarks;

                pSqlParameter[20] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objWheyAnalysisBo.IsDeleted;


                //pSqlParameter[27] = new SqlParameter("@Time", SqlDbType.VarChar);
                //pSqlParameter[27].Direction = ParameterDirection.Input;
                //pSqlParameter[27].Value = objWheyAnalysisBo.Time;

                pSqlParameter[21] = new SqlParameter("@SampleDateTime", SqlDbType.DateTime);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objWheyAnalysisBo.SampleDate;
                
                pSqlParameter[22] = new SqlParameter("@CreatedDate", SqlDbType.DateTime);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objWheyAnalysisBo.CreatedDate;
                
                pSqlParameter[23] = new SqlParameter("@CreatedBy", SqlDbType.Int);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objWheyAnalysisBo.CreatedBy;


                sSql = "usp_WheyAnalysis_Insert";
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
                objWheyAnalysisBo = null;
            }
        }
        #endregion

        #region Update WheyAnalysis Details

        public ApplicationResult WheyAnalysis_Update(WheyAnalysisBO objWheyAnalysisBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[29];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objWheyAnalysisBo.Id;

                pSqlParameter[1] = new SqlParameter("@Date", SqlDbType.NVarChar);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objWheyAnalysisBo.Date;

                pSqlParameter[2] = new SqlParameter("@SampleName", SqlDbType.NVarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objWheyAnalysisBo.SampleName;

                pSqlParameter[3] = new SqlParameter("@SampleNo", SqlDbType.NVarChar);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objWheyAnalysisBo.SampleNo;

                pSqlParameter[4] = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                pSqlParameter[4] = new SqlParameter("@ProductName", SqlDbType.NVarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objWheyAnalysisBo.ProductName;

                pSqlParameter[5] = new SqlParameter("@OT", SqlDbType.NVarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objWheyAnalysisBo.OT;

                pSqlParameter[6] = new SqlParameter("@Temp", SqlDbType.NVarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objWheyAnalysisBo.Temp;

                pSqlParameter[7] = new SqlParameter("@Fat", SqlDbType.NVarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objWheyAnalysisBo.Fat;

                pSqlParameter[8] = new SqlParameter("@SNF", SqlDbType.NVarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objWheyAnalysisBo.SNF;

                pSqlParameter[9] = new SqlParameter("@Acidity", SqlDbType.NVarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objWheyAnalysisBo.Acidity;

                pSqlParameter[10] = new SqlParameter("@COB", SqlDbType.NVarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objWheyAnalysisBo.COB;

                pSqlParameter[11] = new SqlParameter("@AlcholTest65", SqlDbType.NVarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objWheyAnalysisBo.AlcholTest65;


                pSqlParameter[12] = new SqlParameter("@AlcholTest", SqlDbType.NVarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objWheyAnalysisBo.AlcholTest;

                pSqlParameter[13] = new SqlParameter("@Blactumantibiotictest", SqlDbType.NVarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objWheyAnalysisBo.Blactumantibiotictest;

                pSqlParameter[14] = new SqlParameter("@MineralOilTest", SqlDbType.NVarChar);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objWheyAnalysisBo.MineralOilTest;

                pSqlParameter[15] = new SqlParameter("@AnyOtherTest01", SqlDbType.NVarChar);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objWheyAnalysisBo.AnyOtherTest01;

                pSqlParameter[16] = new SqlParameter("@AnyOtherTest02", SqlDbType.NVarChar);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objWheyAnalysisBo.AnyOtherTest02;

                pSqlParameter[17] = new SqlParameter("@AnyOtherTest03", SqlDbType.NVarChar);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objWheyAnalysisBo.AnyOtherTest03;

                pSqlParameter[18] = new SqlParameter("@AnyOtherTest04", SqlDbType.NVarChar);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objWheyAnalysisBo.AnyOtherTest04;

                pSqlParameter[19] = new SqlParameter("@Neutrilize", SqlDbType.NVarChar);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objWheyAnalysisBo.Neutrilize;

                pSqlParameter[20] = new SqlParameter("@Urea", SqlDbType.NVarChar);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objWheyAnalysisBo.Urea;

                pSqlParameter[21] = new SqlParameter("@Salt", SqlDbType.NVarChar);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objWheyAnalysisBo.Salt;

                pSqlParameter[22] = new SqlParameter("@Startch", SqlDbType.NVarChar);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objWheyAnalysisBo.Startch;

                pSqlParameter[23] = new SqlParameter("@FPD", SqlDbType.NVarChar);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objWheyAnalysisBo.FPD;

                pSqlParameter[24] = new SqlParameter("@Status", SqlDbType.NVarChar);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objWheyAnalysisBo.Status;

                pSqlParameter[25] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objWheyAnalysisBo.Remarks;

                pSqlParameter[26] = new SqlParameter("@LastModifiedBy", SqlDbType.Int);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objWheyAnalysisBo.LastModifiedBy;

                pSqlParameter[27] = new SqlParameter("@LastModifiedDate", SqlDbType.DateTime);
                pSqlParameter[27].Direction = ParameterDirection.Input;
                pSqlParameter[27].Value = objWheyAnalysisBo.LastModifiedDate;

                //pSqlParameter[28] = new SqlParameter("@Time", SqlDbType.Time);
                //pSqlParameter[28].Direction = ParameterDirection.Input;
                //pSqlParameter[28].Value = objWheyAnalysisBo.Time;
                
                pSqlParameter[28] = new SqlParameter("@SampleDateTime", SqlDbType.VarChar);
                pSqlParameter[28].Direction = ParameterDirection.Input;
                pSqlParameter[28].Value = objWheyAnalysisBo.SampleDate;


                sSql = "usp_WheyAnalysis_Update";
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
                objWheyAnalysisBo = null;
            }
        }
        #endregion

        #region Select  WheyAnalysis Details
        /// <summary>

        /// </summary>
        public ApplicationResult WheyAnalysis_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_WheyAnalysis_Select";

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

        #region Delete WheyAnalysis Details by 
        /// <summary>
        /// To Delete details of Employee for selected  from Employee table
        /// Created By : Nirmal, 27-04-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult WheyAnalysis_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_WheyAnalysis_Delete";

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
