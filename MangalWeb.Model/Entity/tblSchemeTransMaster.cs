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
    
    public partial class tblSchemeTransMaster
    {
        public int SchemesID { get; set; }
        public int SchemeID { get; set; }
        public decimal LoanAmount { get; set; }
        public int Tenure { get; set; }
        public int AdvanceEMI { get; set; }
        public int EMI { get; set; }
        public double RateofInterest { get; set; }
        public string ServiceChrgType { get; set; }
        public double ServiceChrgPercentage { get; set; }
        public int ServiceChrgAmount { get; set; }
        public double ServiceTaxPercentage { get; set; }
        public int ServiceTaxAmount { get; set; }
        public string EMIType { get; set; }
    }
}
