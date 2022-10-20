using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powder_MISProduct.BO
{
    public class WheyAnalysisBO
    {
        #region WheyAnalysis Class Properties

        public const string WheyAnalysis_TABLE = "WheyAnalysis";
        public const string WheyAnalysis_ID = "Id";
        public const string WheyAnalysis_DateTime = "DateTime";
        public const string WheyAnalysis_Time = "Time";
        public const string WheyAnalysis_SampleDateTime = "SampleDateTime";
        public const string WheyAnalysis_SampleTime = "SampleTime";
        public const string WheyAnalysis_SampleName = "SampleName";
        public const string WheyAnalysis_SampleNo = "SampleNo";
        public const string WheyAnalysis_ProductName = "ProductName";
        public const string WheyAnalysis_OT = "OT";
        public const string WheyAnalysis_Temp = "Temp";
        public const string WheyAnalysis_Fat = "Fat";
        public const string WheyAnalysis_SNF = "SNF";
        public const string WheyAnalysis_Acidity = "Acidity";
        public const string WheyAnalysis_COB = "COB";
        public const string WheyAnalysis_AlcholTest65 = "AlcholTest65";
        public const string WheyAnalysis_AlcholTest = "AlcholTest";
        public const string WheyAnalysis_Blactumantibiotictest = "Blactumantibiotictest";
        public const string WheyAnalysis_MineralOilTest = "MineralOilTest";
        public const string WheyAnalysis_AnyOtherTest01 = "AnyOtherTest01";
        public const string WheyAnalysis_AnyOtherTest02 = "AnyOtherTest02";
        public const string WheyAnalysis_AnyOtherTest03 = "AnyOtherTest03";
        public const string WheyAnalysis_AnyOtherTest04 = "AnyOtherTest04";
        public const string WheyAnalysis_Neutrilize = "Neutrilize";
        public const string WheyAnalysis_Urea = "Urea";
        public const string WheyAnalysis_Salt = "Salt";
        public const string WheyAnalysis_Startch = "Startch";
        public const string WheyAnalysis_FPD = "FPD";
        public const string WheyAnalysis_Status = "Status";
        public const string WheyAnalysis_Remarks = "Remarks";
        public const string WheyAnalysis_ISDELETED = "IsDeleted";
        public const string WheyAnalysis_CREATEDBY = "CreatedBy";
        public const string WheyAnalysis_CREATEDDATE = "CreatedDate";
        public const string WheyAnalysis_LASTMODIFIEDBY = "LastModifiedBy";
        public const string WheyAnalysis_LASTMODIFIEDDATE = "LastModifiedDate";



        private int intId = 0;
        private string strDate = string.Empty;
        private string strTime = string.Empty;
        private string strSampleDate = string.Empty;
        private string strSampleTime = string.Empty;
        private string strSampleName = string.Empty;
        private string strSampleNo = string.Empty;
        private string strProductName = string.Empty;
        private string strOT = string.Empty;
        private string strTemp = string.Empty;
        private string strFat = string.Empty;
        private string strSNF = string.Empty;
        private string strAcidity = string.Empty;
        private string strCOB = string.Empty;
        private string strAlcholTest65 = string.Empty;
        private string strAlcholTest = string.Empty;
        private string strBlactumantibiotictest = string.Empty;
        private string strMineralOilTest = string.Empty;
        private string strAnyOtherTest01 = string.Empty;
        private string strAnyOtherTest02 = string.Empty;
        private string strAnyOtherTest03 = string.Empty;
        private string strAnyOtherTest04 = string.Empty;
        private string strNeutrilize = string.Empty;
        private string strUrea = string.Empty;
        private string strSalt = string.Empty;
        private string strStartch = string.Empty;
        private string strFPD = string.Empty;
        private string strStatus = string.Empty;
        private string strRemarks = string.Empty;
        private int intIsDeleted = 0;
        private int intCreatedBy = 0;
        private string strCreatedDate = string.Empty;
        private int intLastModifiedBy = 0;
        private string strLastModifiedDate = string.Empty;

        #endregion

        #region ---Properties---
        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }
        public string Date
        {
            get { return strDate; }
            set { strDate = value; }
        }

        public string Time
        {
            get { return strTime; }
            set { strTime = value; }
        }
        
        public string SampleDate
        {
            get { return strSampleDate; }
            set { strSampleDate = value; }
        }

        public string SampleTime
        {
            get { return strSampleTime; }
            set { strSampleTime = value; }
        }

        public string SampleName
        {
            get { return strSampleName; }
            set { strSampleName = value; }
        }
        public string SampleNo
        {
            get { return strSampleNo; }
            set { strSampleNo = value; }
        }
        public string ProductName
        {
            get { return strProductName; }
            set { strProductName = value; }
        }
        public string OT
        {
            get { return strOT; }
            set { strOT = value; }
        }
        public string Temp
        {
            get { return strTemp; }
            set { strTemp = value; }
        }
        public string Fat
        {
            get { return strFat; }
            set { strFat = value; }
        }
        public string SNF
        {
            get { return strSNF; }
            set { strSNF = value; }
        }
        public string Acidity
        {
            get { return strAcidity; }
            set { strAcidity = value; }
        }
        public string COB
        {
            get { return strCOB; }
            set { strCOB = value; }
        }
        public string AlcholTest65
        {
            get { return strAlcholTest65; }
            set { strAlcholTest65 = value; }
        }
        public string AlcholTest
        {
            get { return strAlcholTest; }
            set { strAlcholTest = value; }
        }
        public string Blactumantibiotictest
        {
            get { return strBlactumantibiotictest; }
            set { strBlactumantibiotictest = value; }
        }
        public string MineralOilTest
        {
            get { return strMineralOilTest; }
            set { strMineralOilTest = value; }
        }
        public string AnyOtherTest01
        {
            get { return strAnyOtherTest01; }
            set { strAnyOtherTest01 = value; }
        }
        public string AnyOtherTest02
        {
            get { return strAnyOtherTest02; }
            set { strAnyOtherTest02 = value; }
        }
        public string AnyOtherTest03
        {
            get { return strAnyOtherTest03; }
            set { strAnyOtherTest03 = value; }
        }
        public string AnyOtherTest04
        {
            get { return strAnyOtherTest04; }
            set { strAnyOtherTest04 = value; }
        }
        public string Neutrilize
        {
            get { return strNeutrilize; }
            set { strNeutrilize = value; }
        }
        public string Urea
        {
            get { return strUrea; }
            set { strUrea = value; }
        }
        public string Salt
        {
            get { return strSalt; }
            set { strSalt = value; }
        }

        public string Startch
        {
            get { return strStartch; }
            set { strStartch = value; }
        }
        public string FPD
        {
            get { return strFPD; }
            set { strFPD = value; }
        }
        public string Status
        {
            get { return strStatus; }
            set { strStatus = value; }
        }
        public string Remarks
        {
            get { return strRemarks; }
            set { strRemarks = value; }
        }
        public int IsDeleted
        {
            get { return intIsDeleted; }
            set { intIsDeleted = value; }
        }
        public int CreatedBy
        {
            get { return intCreatedBy; }
            set { intCreatedBy = value; }
        }
        public string CreatedDate
        {
            get { return strCreatedDate; }
            set { strCreatedDate = value; }
        }
        public int LastModifiedBy
        {
            get { return intLastModifiedBy; }
            set { intLastModifiedBy = value; }
        }
        public string LastModifiedDate
        {
            get { return strLastModifiedDate; }
            set { strLastModifiedDate = value; }
        }

        #endregion
    }
}
