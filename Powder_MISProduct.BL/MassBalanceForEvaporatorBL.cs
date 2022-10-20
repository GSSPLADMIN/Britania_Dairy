using Powder_MISProduct.Common;
using Powder_MISProduct.DataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powder_MISProduct.BL
{
    public class MassBalanceForEvaporatorBL
    {
        #region user defined variables
        public string sSql;
        public string strStoredProcName;
        public SqlParameter[] pSqlParameter = null;
        #endregion

        #region For mass balance report
        public ApplicationResult MassBalanceReportForEvaporator(DateTime FromDate, DateTime EndDate)
        {
            try
            {
                pSqlParameter = new SqlParameter[2];


                pSqlParameter[0] = new SqlParameter("@FromDate", SqlDbType.DateTime);
                pSqlParameter[0].Direction = ParameterDirection.Input;
                pSqlParameter[0].Value = FromDate;

                pSqlParameter[1] = new SqlParameter("@EndDate", SqlDbType.DateTime);
                pSqlParameter[1].Direction = ParameterDirection.Input;
                pSqlParameter[1].Value = EndDate;

                sSql = "usp_rpt_MassBalanceForEvaporator_Report";
                DataSet dtResult = new DataSet();
                dtResult = Database.ExecuteDataSet(CommandType.StoredProcedure, sSql, pSqlParameter);
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
    }
}
