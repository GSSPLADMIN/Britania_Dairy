using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powder_MISProduct.BO
{
  public  class LabBO
    {
        #region Lab Class Properties

        public const string Lab_TABLE = "Lab";
        public const string Lab_ID = "Id";
        public const string Lab_Date = "Date";
        public const string Lab_TypeofPowder = "TypeofPowder";
        public const string Lab_Time = "Time";
        public const string Lab_SampleId = "SampleId";
        public const string Lab_BatchNo = "BatchNo";
        public const string Lab_BagNo = "BagNo";
        public const string Lab_Weight = "Weight";
        public const string Lab_TempOC = "TempOC";
        public const string Lab_Fat = "Fat";
        public const string Lab_SNF = "SNF";
        public const string Lab_Acidity = "Acidity";
        public const string Lab_Moisture = "Moisture";
        public const string Lab_Sugar = "Sugar";
        public const string Lab_SolIndex = "SolIndex";
        public const string Lab_Coffetest = "Coffetest";
        public const string Lab_Particleontop = "Particleontop";
        public const string Lab_ParticleonBottom = "ParticleonBottom";
        public const string Lab_Sendiments = "Sendiments";
        public const string Lab_BulkDensity = "BulkDensity";
        public const string Lab_Scorchedparticle = "Scorchedparticle";
        public const string Lab_Wettability = "Wettability";
        public const string Lab_Dispersibility = "Dispersibility";
        public const string Lab_FreeFat = "FreeFat";
        public const string Lab_TotalPlatecount = "TotalPlatecount";
        public const string Lab_Coliform = "Coliform";
        public const string Lab_YestMould = "YestMould";
        public const string Lab_Ecoli = "Ecoli";
        public const string Lab_Salmonella = "Salmonella";
        public const string Lab_Saureus = "Saureus";
        public const string Lab_Anerobicsporecount = "Anerobicsporecount";
        public const string Lab_Listeriamonocytogen = "Listeriamonocytogen";
        public const string Lab_Username = "Username";
        public const string Lab_Remarks = "Remarks";
        public const string Lab_ISDELETED = "IsDeleted";
        public const string Lab_CREATEDBY = "CreatedBy";
        public const string Lab_CREATEDDATE = "CreatedDate";
        public const string Lab_LASTMODIFIEDBY = "LastModifiedBy";
        public const string Lab_LASTMODIFIEDDATE = "LastModifiedDate";



        private int intId = 0;
        private DateTime strDate;
        private string strTypeofPowder = string.Empty;
        private string strTime = string.Empty;
        private string strSampleId = string.Empty;
        private string strBatchNo = string.Empty;
        private string strBagNo = string.Empty;
        private string strWeight = string.Empty;
        private string strTempOC = string.Empty;
        private string strFat = string.Empty;
        private string strSNF = string.Empty;
        private string strAcidity = string.Empty;
        private string strMoisture = string.Empty;
        private string strSugar = string.Empty;
        private string strSolIndex = string.Empty;
        private string strCoffetest = string.Empty;
        private string strParticleontop = string.Empty;
        private string strParticleonBottom = string.Empty;
        private string strSendiments = string.Empty;
        private string strBulkDensity = string.Empty;
        private string strScorchedparticle = string.Empty;
        private string strWettability = string.Empty;
        private string strDispersibility = string.Empty;
        private string strFreeFat = string.Empty;
        private string strTotalPlatecount = string.Empty;
        private string strColiform = string.Empty;
        private string strYestMould = string.Empty;
        private string strEcoli = string.Empty;
        private string strSalmonella = string.Empty;
        private string strSaureus = string.Empty;
        private string strAnerobicsporecount = string.Empty;
        private string strListeriamonocytogen = string.Empty;
        private string strUsername = string.Empty;
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
        public DateTime Date
        {
            get { return strDate; }
            set { strDate = value; }
        }

        public string TypeofPowder
        {
            get { return strTypeofPowder; }
            set { strTypeofPowder = value; }
        }
        public string Time
        {
            get { return strTime; }
            set { strTime = value; }
        }
        public string SampleId
        {
            get { return strSampleId; }
            set { strSampleId = value; }
        }
        public string BatchNo
        {
            get { return strBatchNo; }
            set { strBatchNo = value; }
        }
        public string BagNo
        {
            get { return strBagNo; }
            set { strBagNo = value; }
        }
        public string Weight
        {
            get { return strWeight; }
            set { strWeight = value; }
        }
        public string TempOC
        {
            get { return strTempOC; }
            set { strTempOC = value; }
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
        public string Moisture
        {
            get { return strMoisture; }
            set { strMoisture = value; }
        }
        public string Sugar
        {
            get { return strSugar; }
            set { strSugar = value; }
        }
        public string SolIndex
        {
            get { return strSolIndex; }
            set { strSolIndex = value; }
        }
        public string Coffetest
        {
            get { return strCoffetest; }
            set { strCoffetest = value; }
        }
        public string Particleontop
        {
            get { return strParticleontop; }
            set { strParticleontop = value; }
        }
        public string ParticleonBottom
        {
            get { return strParticleonBottom; }
            set { strParticleonBottom = value; }
        }
        public string Sendiments
        {
            get { return strSendiments; }
            set { strSendiments = value; }
        }
        public string BulkDensity
        {
            get { return strBulkDensity; }
            set { strBulkDensity = value; }
        }
        public string Scorchedparticle
        {
            get { return strScorchedparticle; }
            set { strScorchedparticle = value; }
        }
        public string Wettability
        {
            get { return strWettability; }
            set { strWettability = value; }
        }
        public string Dispersibility
        {
            get { return strDispersibility; }
            set { strDispersibility = value; }
        }
        public string FreeFat
        {
            get { return strFreeFat; }
            set { strFreeFat = value; }
        }
        public string TotalPlatecount
        {
            get { return strTotalPlatecount; }
            set { strTotalPlatecount = value; }
        }
        public string Coliform
        {
            get { return strColiform; }
            set { strColiform = value; }
        }
        public string YestMould
        {
            get { return strYestMould; }
            set { strYestMould = value; }
        }
        public string Ecoli
        {
            get { return strEcoli; }
            set { strEcoli = value; }
        }
        public string Salmonella
        {
            get { return strSalmonella; }
            set { strSalmonella = value; }
        }
        public string Saureus
        {
            get { return strSaureus; }
            set { strSaureus = value; }
        }
        public string Anerobicsporecount
        {
            get { return strAnerobicsporecount; }
            set { strAnerobicsporecount = value; }
        }
        public string Listeriamonocytogen
        {
            get { return strListeriamonocytogen; }
            set { strListeriamonocytogen = value; }
        }
        public string Username
        {
            get { return strUsername; }
            set { strUsername = value; }
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
