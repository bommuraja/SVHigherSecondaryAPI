//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class StudentRoll
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentRoll()
        {
            this.StudentFees = new HashSet<StudentFee>();
        }
    
        public int StudentRollID { get; set; }
        public string RollNumber { get; set; }
        public Nullable<int> StudentAdmissionID { get; set; }
        public Nullable<int> ClassMasterID { get; set; }
        public Nullable<int> SectionMasterID { get; set; }
        public Nullable<int> YearMasterID { get; set; }
        public string CreatedDate { get; set; }
        public Nullable<int> DataEntryOperatorID { get; set; }
    
        public virtual ClassMaster ClassMaster { get; set; }
        public virtual DataEntryOperator DataEntryOperator { get; set; }
        public virtual SectionMaster SectionMaster { get; set; }
        public virtual StudentAdmission StudentAdmission { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentFee> StudentFees { get; set; }
        public virtual YearMaster YearMaster { get; set; }
    }
}