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
    
    public partial class ClassMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ClassMaster()
        {
            this.SectionMasters = new HashSet<SectionMaster>();
            this.StudentRolls = new HashSet<StudentRoll>();
        }
    
        public int ClassMasterID { get; set; }
        public string ClassName { get; set; }
        public string CreatedDate { get; set; }
        public Nullable<int> DataEntryOperatorID { get; set; }
    
        public virtual DataEntryOperator DataEntryOperator { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SectionMaster> SectionMasters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentRoll> StudentRolls { get; set; }
    }
}
