//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MangalWebProject.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class Mst_ChargeDetails
    {
        public int Chgd_Id { get; set; }
        public int Chgd_ChgRefId { get; set; }
        public decimal Chgd_LoanAmountGreater { get; set; }
        public decimal Chgd_LoanAmountLess { get; set; }
        public decimal Chgd_ChargesAmt { get; set; }
        public Nullable<short> Chgd_ChargeType { get; set; }
        public Nullable<System.DateTime> Chg_RecordCreated { get; set; }
        public Nullable<System.DateTime> Chg_RecordUpdated { get; set; }
        public Nullable<int> Chg_RecordCreatedBy { get; set; }
        public Nullable<int> Chg_RecordUpdatedBy { get; set; }
    
        public virtual Mst_Charge Mst_Charge { get; set; }
    }
}
