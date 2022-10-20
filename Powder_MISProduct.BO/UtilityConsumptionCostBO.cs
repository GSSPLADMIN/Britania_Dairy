using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powder_MISProduct.BO
{
    public class UtilityConsumptionCostBO
    {
        #region UtilityConsumptionCost Class Properties

        public const string UtilityCost_TankLab_TABLE = "UtilityConsumptionCost";
        public const string UtilityCost_Id = "Id";
        public const string UtilityCost_ChilledWaterCost= "ChilledWaterCost";
        public const string UtilityCost_RawWaterCost = "RawWaterCost";
        public const string UtilityCost_ROWaterCost = "ROWaterCost";
        public const string UtilityCost_SoftWaterCost = "SoftWaterCost";
        public const string UtilityCost_SteamCost = "SteamCost";
        public const string UtilityCost_AirCost = "AirCost";
        public const string UtilityCost_ElectricityCost = "ElectricityCost";
        public const string UtilityCost_SCM_ElectricityCost = "SCM_ElectricityCost";
        public const string UtilityCost_SCM_Steam = "SCM_Steam";
        public const string UtilityCost_SCM_Air = "SCM_Air";
        public const string UtilityCost_SCM_SoftWater = "SCM_SoftWater";
        public const string UtilityCost_SCM_ChilledWater = "SCM_ChilledWater";
        public const string UtilityCost_SCM_ROWaterCost = "SCM_ROWaterCost";
        public const string UtilityCost_SCM_RawWaterCost = "SCM_RawWaterCost";
        public const string UtilityCost_PowerCost = "PowerCost";
        public const string UtilityCost_AcidCost = "AcidCost";
        public const string UtilityCost_LyeCost = "LyeCost";
        public const string UtilityCost_ISDELETED = "IsDeleted";
        public const string UtilityCost_CREATEDBY = "CreatedBy";
        public const string UtilityCost_CREATEDDATE = "CreatedDate";
        public const string UtilityCost_LASTMODIFIEDBY = "LastModifiedBy";
        public const string UtilityCost_LASTMODIFIEDDATE = "LastModifiedDate";

        private int intId = 0;
        private float flt_ChilledWaterCost = 0;
        private float flt_RawWaterCost = 0;
        private float flt_ROWaterCost = 0;
        private float flt_SoftWaterCost = 0;
        private float flt_SteamCost;
        private float flt_AirCost = 0;
        private float flt_ElectricityCost = 0;
        private float flt_SCM_ElectricityCost = 0;
        private float flt_SCM_Steam = 0;
        private float flt_SCM_Air = 0;
        private float flt_SCM_SoftWater = 0;
        private float flt_SCM_ChilledWater = 0;
        private float flt_SCM_ROWaterCost = 0;
        private float flt_SCM_RawWaterCost = 0;
        private float flt_PowerCost = 0;
        private float flt_AcidCost = 0;
        private float flt_LyeCost = 0;
        private int intIsDeleted = 0;
        private int intCreatedBy = 0;
        private DateTime dtCreatedDate;
        private int intLastModifiedBy = 0;
        private DateTime dtLastModifiedDate;

        #endregion

        #region ---Properties---
        public int Id
        {
            get { return intId; }
            set { intId = value; }
        }

        public float ChilledWaterCost
        {
            get { return flt_ChilledWaterCost; }
            set { flt_ChilledWaterCost = value; }
        }

        public float RawWaterCost
        {
            get { return flt_RawWaterCost; }
            set { flt_RawWaterCost = value; }
        }
        
        public float ROWaterCost
        {
            get { return flt_ROWaterCost; }
            set { flt_ROWaterCost = value; }
        }

        public float SoftWaterCost
        {
            get { return flt_SoftWaterCost; }
            set { flt_SoftWaterCost = value; }
        }

        public float SteamCost
        {
            get { return flt_SteamCost; }
            set { flt_SteamCost = value; }
        }
        public float AirCost
        {
            get { return flt_AirCost; }
            set { flt_AirCost = value; }
        }
        public float ElectricityCost
        {
            get { return flt_ElectricityCost; }
            set { flt_ElectricityCost = value; }
        }
        public float SCM_ElectricityCost
        {
            get { return flt_SCM_ElectricityCost; }
            set { flt_SCM_ElectricityCost = value; }
        }
        public float SCM_Steam
        {
            get { return flt_SCM_Steam; }
            set { flt_SCM_Steam = value; }
        }
        public float SCM_Air
        {
            get { return flt_SCM_Air; }
            set { flt_SCM_Air = value; }
        }
        public float SCM_SoftWater
        {
            get { return flt_SCM_SoftWater; }
            set { flt_SCM_SoftWater = value; }
        }
        public float SCM_ChilledWater
        {
            get { return flt_SCM_ChilledWater; }
            set { flt_SCM_ChilledWater = value; }
        }
        public float SCM_ROWaterCost
        {
            get { return flt_SCM_ROWaterCost; }
            set { flt_SCM_ROWaterCost = value; }
        }
        public float SCM_RawWaterCost
        {
            get { return flt_SCM_RawWaterCost; }
            set { flt_SCM_RawWaterCost = value; }
        }
        public float PowerCost
        {
            get { return flt_PowerCost; }
            set { flt_PowerCost = value; }
        }
        public float AcidCost
        {
            get { return flt_AcidCost; }
            set { flt_AcidCost = value; }
        }
        public float LyeCost
        {
            get { return flt_LyeCost; }
            set { flt_LyeCost = value; }
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
        public DateTime CreatedDate
        {
            get { return dtCreatedDate; }
            set { dtCreatedDate = value; }
        }
        public int LastModifiedBy
        {
            get { return intLastModifiedBy; }
            set { intLastModifiedBy = value; }
        }
        public DateTime LastModifiedDate
        {
            get { return dtLastModifiedDate; }
            set { dtLastModifiedDate = value; }
        }

        #endregion
    }
}
