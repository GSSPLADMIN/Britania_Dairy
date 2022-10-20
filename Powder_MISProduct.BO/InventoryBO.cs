using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Powder_MISProduct.BO
{
   public class InventoryBO
    {
        #region Inventory Class Properties

        public const string Inventory_TABLE = "Inventory";
        public const string Inventory_ID = "Id";
        public const string Inventory_Date = "Date";
        public const string Inventory_Itemdesc = "Itemdesc";
        public const string Inventory_MakeType = "MakeType";
        public const string Inventory_BatchNumber = "BatchNumber";
        public const string Inventory_Quantity = "Quantity";
        public const string Inventory_Remarks = "Remarks";
        public const string EMPLOYEE_ISDELETED = "IsDeleted";
        public const string EMPLOYEE_CREATEDBY = "CreatedBy";
        public const string EMPLOYEE_CREATEDDATE = "CreatedDate";
        public const string EMPLOYEE_LASTMODIFIEDBY = "LastModifiedBy";
        public const string EMPLOYEE_LASTMODIFIEDDATE = "LastModifiedDate";



        private int intId = 0;
        private DateTime strDate;
        private string  strItemdesc= string.Empty;
        private string strMakeType = string.Empty;
        private string strBatchNumber = string.Empty;
        private int intQuantity = 0;
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

        public string Itemdesc
        {
            get { return strItemdesc; }
            set { strItemdesc = value; }
        }
        public string MakeType
        {
            get { return strMakeType; }
            set { strMakeType = value; }
        }
        public string BatchNumber
        {
            get { return strBatchNumber; }
            set { strBatchNumber = value; }
        }
        public int Quantity
        {
            get { return intQuantity; }
            set { intQuantity = value; }
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
