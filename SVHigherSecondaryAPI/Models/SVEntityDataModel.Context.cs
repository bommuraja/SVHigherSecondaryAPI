﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SVHigherSecondaryAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SVEntitiesDataModel : DbContext
    {
        public SVEntitiesDataModel()
            : base("name=SVEntitiesDataModel")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ClassMaster> ClassMasters { get; set; }
        public virtual DbSet<DataEntryOperator> DataEntryOperators { get; set; }
        public virtual DbSet<SectionMaster> SectionMasters { get; set; }
        public virtual DbSet<StudentFee> StudentFees { get; set; }
        public virtual DbSet<StudentRoll> StudentRolls { get; set; }
        public virtual DbSet<YearMaster> YearMasters { get; set; }
        public virtual DbSet<StudentAdmission> StudentAdmissions { get; set; }
    }
}
