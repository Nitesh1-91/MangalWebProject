//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MangalWeb.Model.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TGLCashInOutDetail
    {
        public int InOutID { get; set; }
        public string RefType { get; set; }
        public Nullable<int> RefNo { get; set; }
        public string ReferenceType { get; set; }
        public string FName { get; set; }
        public Nullable<System.DateTime> Date_time { get; set; }
        public string InOutMode { get; set; }
        public string InOutTo { get; set; }
        public Nullable<int> InOutToID { get; set; }
        public string InOutFrom { get; set; }
        public Nullable<int> InOutFromID { get; set; }
        public Nullable<int> InOutBy { get; set; }
        public Nullable<int> FYID { get; set; }
        public Nullable<int> CmpID { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string isActive { get; set; }
        public Nullable<decimal> TotalCash { get; set; }
    }
}
