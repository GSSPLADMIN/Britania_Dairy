using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Powder_MISProduct.BO
{
  public  class MaintenanceBO
    {
        #region Maintenance Class Properties

        public const string Maintainance_TABLE = "Maintainance";
        public const string Maintainance_ID = "Id";
        public const string Maintainance_Date = "Date";
        public const string Maintainance_StartTime = "StartTime";
        public const string Maintainance_EndTime = "EndTime";
        public const string Maintainance_EquipmentTagNo = "EquipmentTagNo";
        public const string Maintainance_EquipmentName = "EquipmentName";
        public const string Maintainance_PartNo = "PartNo";
        public const string Maintainance_Area = "Area";
        public const string Maintainance_ProblemDetails = "ProblemDetails";
        public const string Maintainance_ActionTaken = "ActionTaken";
        public const string Maintainance_RectifiedBy = "RectifiedBy";
        public const string Maintainance_Remark = "Remark";
        public const string Maintainance_ISDELETED = "IsDeleted";
        public const string Maintainance_CREATEDBY = "CreatedBy";
        public const string Maintainance_CREATEDDATE = "CreatedDate";
        public const string Maintainance_LASTMODIFIEDBY = "LastModifiedBy";
        public const string Maintainance_LASTMODIFIEDDATE = "LastModifiedDate";



        private int intId = 0;
        private DateTime strDate;
        private string strStartTime = string.Empty;
        private string strEndTime = string.Empty;
        private string strEquipmentTagNo = string.Empty;
        private string strEquipmentName = string.Empty;
        private string strPartNo = string.Empty;
        private string strArea = string.Empty;
        private string strProblemDetails = string.Empty;
        private string strActionTaken = string.Empty;
        private string strRectifiedBy = string.Empty;
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

        public string StartTime
        {
            get { return strStartTime; }
            set { strStartTime = value; }
        }
        public string EndTime
        {
            get { return strEndTime; }
            set { strEndTime = value; }
        }
        public string EquipmentTagNo
        {
            get { return strEquipmentTagNo; }
            set { strEquipmentTagNo = value; }
        }
        public string EquipmentName
        {
            get { return strEquipmentName; }
            set { strEquipmentName = value; }
        }
        public string PartNo
        {
            get { return strPartNo; }
            set { strPartNo = value; }
        }
        public string Area
        {
            get { return strArea; }
            set { strArea = value; }
        }
        public string ProblemDetails
        {
            get { return strProblemDetails; }
            set { strProblemDetails = value; }
        }
        public string ActionTaken
        {
            get { return strActionTaken; }
            set { strActionTaken = value; }
        }
        public string RectifiedBy
        {
            get { return strRectifiedBy; }
            set { strRectifiedBy = value; }
        }
        public string Remark
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
