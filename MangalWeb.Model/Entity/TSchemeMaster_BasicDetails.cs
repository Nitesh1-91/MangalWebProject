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
    
    public partial class TSchemeMaster_BasicDetails
    {
        public int SID { get; set; }
        public string SchemeName { get; set; }
        public string SchemeType { get; set; }
        public Nullable<decimal> MinLoanAmt { get; set; }
        public Nullable<int> Tenure { get; set; }
        public Nullable<decimal> MaxLoanAmt { get; set; }
        public Nullable<decimal> Ltv { get; set; }
        public string CalMethod { get; set; }
        public Nullable<decimal> ROI { get; set; }
        public string ProChargeType { get; set; }
        public Nullable<decimal> EMI { get; set; }
        public Nullable<decimal> ProCharge { get; set; }
        public Nullable<decimal> PenalInterest { get; set; }
        public Nullable<int> CMPId { get; set; }
        public Nullable<int> BranchId { get; set; }
        public Nullable<int> FYId { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> DeletedBy { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string isActive { get; set; }
        public Nullable<decimal> AmtLmtTo { get; set; }
        public Nullable<decimal> ServiceTax { get; set; }
    }
}
