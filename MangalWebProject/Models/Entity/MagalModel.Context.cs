﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class MangalDBEntities : DbContext
    {
        public MangalDBEntities()
            : base("name=MangalDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Menu> tbl_Menu { get; set; }
        public virtual DbSet<u_userauthorization> u_userauthorization { get; set; }
        public virtual DbSet<tbl_Payment> tbl_Payment { get; set; }
        public virtual DbSet<tbl_User> tbl_User { get; set; }
        public virtual DbSet<Mst_City> Mst_City { get; set; }
        public virtual DbSet<Mst_Country> Mst_Country { get; set; }
        public virtual DbSet<Mst_PinCode> Mst_PinCode { get; set; }
        public virtual DbSet<Mst_State> Mst_State { get; set; }
        public virtual DbSet<Mst_Zone> Mst_Zone { get; set; }
        public virtual DbSet<Mst_SourceofApplication> Mst_SourceofApplication { get; set; }
        public virtual DbSet<Mst_DocumentMaster> Mst_DocumentMaster { get; set; }
        public virtual DbSet<Mst_Ornament> Mst_Ornament { get; set; }
        public virtual DbSet<Mst_Reason> Mst_Reason { get; set; }
        public virtual DbSet<Mst_AuditCheckList> Mst_AuditCheckList { get; set; }
        public virtual DbSet<Mst_GstMaster> Mst_GstMaster { get; set; }
        public virtual DbSet<Mst_Charge> Mst_Charge { get; set; }
        public virtual DbSet<Mst_ChargeDetails> Mst_ChargeDetails { get; set; }
        public virtual DbSet<Mst_PenaltySlab> Mst_PenaltySlab { get; set; }
        public virtual DbSet<Mst_PurityMaster> Mst_PurityMaster { get; set; }
        public virtual DbSet<tblaccountmaster> tblaccountmasters { get; set; }
        public virtual DbSet<tblGroupMaster> tblGroupMasters { get; set; }
        public virtual DbSet<tblPrimaryGroup> tblPrimaryGroups { get; set; }
        public virtual DbSet<Mst_SchemePurity> Mst_SchemePurity { get; set; }
        public virtual DbSet<Mst_SchemeMaster> Mst_SchemeMaster { get; set; }
        public virtual DbSet<Mst_ProductRate> Mst_ProductRate { get; set; }
        public virtual DbSet<Mst_ProductRateDetails> Mst_ProductRateDetails { get; set; }
        public virtual DbSet<tblfinancialyear> tblfinancialyears { get; set; }
        public virtual DbSet<Mst_Branch> Mst_Branch { get; set; }
        public virtual DbSet<Mst_ChildDeviation> Mst_ChildDeviation { get; set; }
        public virtual DbSet<Mst_ParentDeviation> Mst_ParentDeviation { get; set; }
        public virtual DbSet<tbl_UserCategory> tbl_UserCategory { get; set; }
        public virtual DbSet<Mst_DocumentType> Mst_DocumentType { get; set; }
        public virtual DbSet<Trans_KYCDetails> Trans_KYCDetails { get; set; }
        public virtual DbSet<Trn_DocumentUpload> Trn_DocumentUpload { get; set; }
    }
}
