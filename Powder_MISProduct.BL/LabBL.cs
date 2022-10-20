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
  public  class LabBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region Lab Log Report
        /// <summary>

        /// </summary>
        public ApplicationResult LabReport(DateTime FromDatetime, DateTime ToDatetime)
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



                strStoredProcName = "usp_Lab_SelectAll_Details";

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

        #region Lab Log Report
        /// <summary>

        /// </summary>
        public ApplicationResult LabReportReportSelectAll()
        {
            try
            {

                strStoredProcName = "usp_Lab_SelectAll";

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

        #region Insert Lab Details

        public ApplicationResult Lab_Insert(LabBO objLabBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[35];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objLabBo.Id;

                pSqlParameter[1] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objLabBo.Date;

                pSqlParameter[2] = new SqlParameter("@TypeofPowder", SqlDbType.NVarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objLabBo.@TypeofPowder;

                pSqlParameter[3] = new SqlParameter("@Time", SqlDbType.Time);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objLabBo.Time;

                pSqlParameter[4] = new SqlParameter("@SampleId", SqlDbType.NVarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objLabBo.SampleId;

                pSqlParameter[5] = new SqlParameter("@BatchNo", SqlDbType.NVarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objLabBo.BatchNo;

                pSqlParameter[6] = new SqlParameter("@BagNo", SqlDbType.NVarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objLabBo.BagNo;

                pSqlParameter[7] = new SqlParameter("@Weight", SqlDbType.NVarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objLabBo.Weight;

                pSqlParameter[8] = new SqlParameter("@TempOC", SqlDbType.NVarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objLabBo.TempOC;

                pSqlParameter[9] = new SqlParameter("@Fat", SqlDbType.NVarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objLabBo.Fat;

                pSqlParameter[10] = new SqlParameter("@SNF", SqlDbType.NVarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objLabBo.SNF;

                pSqlParameter[11] = new SqlParameter("@Acidity", SqlDbType.NVarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objLabBo.Acidity;

                pSqlParameter[12] = new SqlParameter("@Moisture", SqlDbType.NVarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objLabBo.Moisture;

                pSqlParameter[13] = new SqlParameter("@Sugar", SqlDbType.NVarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objLabBo.Sugar;

                pSqlParameter[14] = new SqlParameter("@SolIndex", SqlDbType.NVarChar);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objLabBo.SolIndex;

                pSqlParameter[15] = new SqlParameter("@Coffetest", SqlDbType.NVarChar);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objLabBo.Coffetest;

                pSqlParameter[16] = new SqlParameter("@Particleontop", SqlDbType.NVarChar);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objLabBo.Particleontop;

                pSqlParameter[17] = new SqlParameter("@ParticleonBottom", SqlDbType.NVarChar);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objLabBo.ParticleonBottom;

                pSqlParameter[18] = new SqlParameter("@Sendiments", SqlDbType.NVarChar);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objLabBo.Sendiments;

                pSqlParameter[19] = new SqlParameter("@BulkDensity", SqlDbType.NVarChar);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objLabBo.BulkDensity;

                pSqlParameter[20] = new SqlParameter("@Scorchedparticle", SqlDbType.NVarChar);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objLabBo.Scorchedparticle;

                pSqlParameter[21] = new SqlParameter("@Wettability", SqlDbType.NVarChar);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objLabBo.Wettability;

                pSqlParameter[22] = new SqlParameter("@Dispersibility", SqlDbType.NVarChar);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objLabBo.Dispersibility;

                pSqlParameter[23] = new SqlParameter("@FreeFat", SqlDbType.NVarChar);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objLabBo.FreeFat;

                pSqlParameter[24] = new SqlParameter("@TotalPlatecount", SqlDbType.NVarChar);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objLabBo.TotalPlatecount;

                pSqlParameter[25] = new SqlParameter("@Coliform", SqlDbType.NVarChar);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objLabBo.Coliform;

                pSqlParameter[26] = new SqlParameter("@YestMould", SqlDbType.NVarChar);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objLabBo.YestMould;

                pSqlParameter[27] = new SqlParameter("@Ecoli", SqlDbType.NVarChar);
                pSqlParameter[27].Direction = ParameterDirection.Input;
                pSqlParameter[27].Value = objLabBo.Ecoli;

                pSqlParameter[28] = new SqlParameter("@Salmonella", SqlDbType.NVarChar);
                pSqlParameter[28].Direction = ParameterDirection.Input;
                pSqlParameter[28].Value = objLabBo.Salmonella;

                pSqlParameter[29] = new SqlParameter("@Saureus", SqlDbType.NVarChar);
                pSqlParameter[29].Direction = ParameterDirection.Input;
                pSqlParameter[29].Value = objLabBo.Saureus;

                pSqlParameter[30] = new SqlParameter("@Anerobicsporecount", SqlDbType.NVarChar);
                pSqlParameter[30].Direction = ParameterDirection.Input;
                pSqlParameter[30].Value = objLabBo.Anerobicsporecount;

                pSqlParameter[31] = new SqlParameter("@Listeriamonocytogen", SqlDbType.NVarChar);
                pSqlParameter[31].Direction = ParameterDirection.Input;
                pSqlParameter[31].Value = objLabBo.Listeriamonocytogen;

                pSqlParameter[32] = new SqlParameter("@Username", SqlDbType.NVarChar);
                pSqlParameter[32].Direction = ParameterDirection.Input;
                pSqlParameter[32].Value = objLabBo.Username;

                pSqlParameter[33] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
                pSqlParameter[33].Direction = ParameterDirection.Input;
                pSqlParameter[33].Value = objLabBo.Remarks;

                //pSqlParameter[33] = new SqlParameter("@Wettability", SqlDbType.NVarChar);
                //pSqlParameter[33].Direction = ParameterDirection.Input;
                //pSqlParameter[33].Value = objLabBo.Acidity;


                pSqlParameter[34] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                pSqlParameter[34].Direction = ParameterDirection.Input;
                pSqlParameter[34].Value = objLabBo.IsDeleted;


                sSql = "usp_Lab_Insert";
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
                objLabBo = null;
            }
        }
        #endregion

        #region Update Lab Details

        public ApplicationResult Lab_Update(LabBO objLabBo)
        {
            try
            {
                pSqlParameter = new SqlParameter[35];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = objLabBo.Id;

                pSqlParameter[1] = new SqlParameter("@Date", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = objLabBo.Date;

                pSqlParameter[2] = new SqlParameter("@TypeofPowder", SqlDbType.NVarChar);
                pSqlParameter[2].Direction = ParameterDirection.Input;
                pSqlParameter[2].Value = objLabBo.@TypeofPowder;

                pSqlParameter[3] = new SqlParameter("@Time", SqlDbType.Time);
                pSqlParameter[3].Direction = ParameterDirection.Input;
                pSqlParameter[3].Value = objLabBo.Time;

                pSqlParameter[4] = new SqlParameter("@SampleId", SqlDbType.NVarChar);
                pSqlParameter[4].Direction = ParameterDirection.Input;
                pSqlParameter[4].Value = objLabBo.SampleId;

                pSqlParameter[5] = new SqlParameter("@BatchNo", SqlDbType.NVarChar);
                pSqlParameter[5].Direction = ParameterDirection.Input;
                pSqlParameter[5].Value = objLabBo.BatchNo;

                pSqlParameter[6] = new SqlParameter("@BagNo", SqlDbType.NVarChar);
                pSqlParameter[6].Direction = ParameterDirection.Input;
                pSqlParameter[6].Value = objLabBo.BagNo;

                pSqlParameter[7] = new SqlParameter("@Weight", SqlDbType.NVarChar);
                pSqlParameter[7].Direction = ParameterDirection.Input;
                pSqlParameter[7].Value = objLabBo.Weight;

                pSqlParameter[8] = new SqlParameter("@TempOC", SqlDbType.NVarChar);
                pSqlParameter[8].Direction = ParameterDirection.Input;
                pSqlParameter[8].Value = objLabBo.TempOC;

                pSqlParameter[9] = new SqlParameter("@Fat", SqlDbType.NVarChar);
                pSqlParameter[9].Direction = ParameterDirection.Input;
                pSqlParameter[9].Value = objLabBo.Fat;

                pSqlParameter[10] = new SqlParameter("@SNF", SqlDbType.NVarChar);
                pSqlParameter[10].Direction = ParameterDirection.Input;
                pSqlParameter[10].Value = objLabBo.SNF;

                pSqlParameter[11] = new SqlParameter("@Acidity", SqlDbType.NVarChar);
                pSqlParameter[11].Direction = ParameterDirection.Input;
                pSqlParameter[11].Value = objLabBo.Acidity;

                pSqlParameter[12] = new SqlParameter("@Moisture", SqlDbType.NVarChar);
                pSqlParameter[12].Direction = ParameterDirection.Input;
                pSqlParameter[12].Value = objLabBo.Moisture;

                pSqlParameter[13] = new SqlParameter("@Sugar", SqlDbType.NVarChar);
                pSqlParameter[13].Direction = ParameterDirection.Input;
                pSqlParameter[13].Value = objLabBo.Sugar;

                pSqlParameter[14] = new SqlParameter("@SolIndex", SqlDbType.NVarChar);
                pSqlParameter[14].Direction = ParameterDirection.Input;
                pSqlParameter[14].Value = objLabBo.SolIndex;

                pSqlParameter[15] = new SqlParameter("@Coffetest", SqlDbType.NVarChar);
                pSqlParameter[15].Direction = ParameterDirection.Input;
                pSqlParameter[15].Value = objLabBo.Coffetest;

                pSqlParameter[16] = new SqlParameter("@Particleontop", SqlDbType.NVarChar);
                pSqlParameter[16].Direction = ParameterDirection.Input;
                pSqlParameter[16].Value = objLabBo.Particleontop;

                pSqlParameter[17] = new SqlParameter("@ParticleonBottom", SqlDbType.NVarChar);
                pSqlParameter[17].Direction = ParameterDirection.Input;
                pSqlParameter[17].Value = objLabBo.ParticleonBottom;

                pSqlParameter[18] = new SqlParameter("@Sendiments", SqlDbType.NVarChar);
                pSqlParameter[18].Direction = ParameterDirection.Input;
                pSqlParameter[18].Value = objLabBo.Sendiments;

                pSqlParameter[19] = new SqlParameter("@BulkDensity", SqlDbType.NVarChar);
                pSqlParameter[19].Direction = ParameterDirection.Input;
                pSqlParameter[19].Value = objLabBo.BulkDensity;

                pSqlParameter[20] = new SqlParameter("@Scorchedparticle", SqlDbType.NVarChar);
                pSqlParameter[20].Direction = ParameterDirection.Input;
                pSqlParameter[20].Value = objLabBo.Scorchedparticle;

                pSqlParameter[21] = new SqlParameter("@Wettability", SqlDbType.NVarChar);
                pSqlParameter[21].Direction = ParameterDirection.Input;
                pSqlParameter[21].Value = objLabBo.Wettability;

                pSqlParameter[22] = new SqlParameter("@Dispersibility", SqlDbType.NVarChar);
                pSqlParameter[22].Direction = ParameterDirection.Input;
                pSqlParameter[22].Value = objLabBo.Dispersibility;

                pSqlParameter[23] = new SqlParameter("@FreeFat", SqlDbType.NVarChar);
                pSqlParameter[23].Direction = ParameterDirection.Input;
                pSqlParameter[23].Value = objLabBo.FreeFat;

                pSqlParameter[24] = new SqlParameter("@TotalPlatecount", SqlDbType.NVarChar);
                pSqlParameter[24].Direction = ParameterDirection.Input;
                pSqlParameter[24].Value = objLabBo.TotalPlatecount;

                pSqlParameter[25] = new SqlParameter("@Coliform", SqlDbType.NVarChar);
                pSqlParameter[25].Direction = ParameterDirection.Input;
                pSqlParameter[25].Value = objLabBo.Coliform;

                pSqlParameter[26] = new SqlParameter("@YestMould", SqlDbType.NVarChar);
                pSqlParameter[26].Direction = ParameterDirection.Input;
                pSqlParameter[26].Value = objLabBo.YestMould;

                pSqlParameter[27] = new SqlParameter("@Ecoli", SqlDbType.NVarChar);
                pSqlParameter[27].Direction = ParameterDirection.Input;
                pSqlParameter[27].Value = objLabBo.Ecoli;

                pSqlParameter[28] = new SqlParameter("@Salmonella", SqlDbType.NVarChar);
                pSqlParameter[28].Direction = ParameterDirection.Input;
                pSqlParameter[28].Value = objLabBo.Salmonella;

                pSqlParameter[29] = new SqlParameter("@Saureus", SqlDbType.NVarChar);
                pSqlParameter[29].Direction = ParameterDirection.Input;
                pSqlParameter[29].Value = objLabBo.Saureus;

                pSqlParameter[30] = new SqlParameter("@Anerobicsporecount", SqlDbType.NVarChar);
                pSqlParameter[30].Direction = ParameterDirection.Input;
                pSqlParameter[30].Value = objLabBo.Anerobicsporecount;

                pSqlParameter[31] = new SqlParameter("@Listeriamonocytogen", SqlDbType.NVarChar);
                pSqlParameter[31].Direction = ParameterDirection.Input;
                pSqlParameter[31].Value = objLabBo.Listeriamonocytogen;

                pSqlParameter[32] = new SqlParameter("@Username", SqlDbType.NVarChar);
                pSqlParameter[32].Direction = ParameterDirection.Input;
                pSqlParameter[32].Value = objLabBo.Username;

                pSqlParameter[33] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
                pSqlParameter[33].Direction = ParameterDirection.Input;
                pSqlParameter[33].Value = objLabBo.Remarks;

                //pSqlParameter[33] = new SqlParameter("@Wettability", SqlDbType.NVarChar);
                //pSqlParameter[33].Direction = ParameterDirection.Input;
                //pSqlParameter[33].Value = objLabBo.Acidity;


                pSqlParameter[34] = new SqlParameter("@IsDeleted", SqlDbType.Bit);
                pSqlParameter[34].Direction = ParameterDirection.Input;
                pSqlParameter[34].Value = objLabBo.IsDeleted;



                sSql = "usp_Lab_Update";
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
                objLabBo = null;
            }
        }
        #endregion

        #region Select  Lab Details
        /// <summary>

        /// </summary>
        public ApplicationResult Lab_Select(int intId)
        {
            try
            {
                pSqlParameter = new SqlParameter[1];

                pSqlParameter[0] = new SqlParameter("@Id", SqlDbType.Int);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = intId;

                strStoredProcName = "usp_Lab_Select";

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

        #region Delete Lab Details by 
        /// <summary>
        /// To Delete details of Employee for selected  from Employee table
        /// Created By : Nirmal, 27-04-2015
        /// Modified By :
        /// </summary>
        public ApplicationResult Lab_Delete(int intId, int intLastModifiedBy, string strLastModifiedDate)
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

                strStoredProcName = "usp_Lab_Delete";

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
