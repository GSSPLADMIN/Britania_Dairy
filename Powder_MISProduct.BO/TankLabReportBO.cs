using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powder_MISProduct.BO
{
    public class TankLabReportBO
    {

        #region TankerLab Class Properties

        public const string TankLab_TABLE = "TankerLab_report";
        public const string TankLab_ID = "Id";
        public const string TankLab_DateTime = "DateTime";
        public const string TankLab_SampleTime = "SampleTime";
        public const string TankLab_SampleID = "SampleID";
        public const string TankLab_SiloTagNo = "SiloTagNo";
        public const string TankLab_TankName = "TankName";
        public const string TankLab_Temp = "Temp";
        public const string TankLab_Fat = "Fat";
        public const string TankLab_SNF = "SNF";
        public const string TankLab_TS = "TS";
        public const string TankLab_pH = "pH";
        public const string TankLab_Acidity = "Acidity";
        public const string TankLab_Protein = "Protein";
        public const string TankLab_TankStatus = "TankStatus";
        public const string TankLab_TDS = "TDS";
        public const string TankLab_Remarks = "Remarks";
        public const string TankLab_ISDELETED = "IsDeleted";
        public const string TankLab_CREATEDBY = "CreatedBy";
        public const string TankLab_CREATEDDATE = "CreatedDate";
        public const string TankLab_LASTMODIFIEDBY = "LastModifiedBy";
        public const string TankLab_LASTMODIFIEDDATE = "LastModifiedDate";



        private int intId = 0;
        private string strDate = string.Empty;
        private string strTime = string.Empty;
        private string strSampleDate = string.Empty;
        private string strDateTime = string.Empty;
        private string strSampleTime = string.Empty;
        private string strSampleID = string.Empty;
        private string strSiloTagNo = string.Empty;
        private string strTankName = string.Empty;
        private string strTemp = string.Empty;
        private string strFAT = string.Empty;
        private string strSNF = string.Empty;
        private string strTS = string.Empty;
        private string strpH = string.Empty;
        private string strAcidity = string.Empty;
        private string strProtein = string.Empty;
        private string strtankStatus = string.Empty;
        private string strTDS = string.Empty;
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
        public string DateTime
        {
            get { return strDateTime; }
            set { strDateTime = value; }
        }
        public string SampleID
        {
            get { return strSampleID; }
            set { strSampleID = value; }
        }
        public string SiloTagNo
        {
            get { return strSiloTagNo; }
            set { strSiloTagNo = value; }
        }
        public string TankName
        {
            get { return strTankName; }
            set { strTankName = value; }
        }
        public string Temp
        {
            get { return strTemp; }
            set { strTemp = value; }
        }
        public string FAT
        {
            get { return strFAT; }
            set { strFAT = value; }
        }
        public string SNF
        {
            get { return strSNF; }
            set { strSNF = value; }
        }
        public string TS
        {
            get { return strTS; }
            set { strTS = value; }
        }
        public string pH
        {
            get { return strpH; }
            set { strpH = value; }
        }
        public string Acidity
        {
            get { return strAcidity; }
            set { strAcidity = value; }
        }
        public string Protein
        {
            get { return strProtein; }
            set { strProtein = value; }
        }
        public string tankStatus
        {
            get { return strtankStatus; }
            set { strtankStatus = value; }
        }
        public string TDS
        {
            get { return strTDS; }
            set { strTDS = value; }
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
