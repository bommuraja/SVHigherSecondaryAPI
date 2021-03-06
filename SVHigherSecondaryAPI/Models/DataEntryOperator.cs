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
    
    public partial class DataEntryOperator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DataEntryOperator()
        {
            this.ClassMasters = new HashSet<ClassMaster>();
            this.SectionMasters = new HashSet<SectionMaster>();
            this.StudentFees = new HashSet<StudentFee>();
            this.StudentRolls = new HashSet<StudentRoll>();
            this.YearMasters = new HashSet<YearMaster>();
            this.StudentAdmissions = new HashSet<StudentAdmission>();
        }
    
        public int DataEntryOperatorID { get; set; }
        public string DataEntryOperatorName { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClassMaster> ClassMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SectionMaster> SectionMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentFee> StudentFees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentRoll> StudentRolls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<YearMaster> YearMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentAdmission> StudentAdmissions { get; set; }
    }
}
