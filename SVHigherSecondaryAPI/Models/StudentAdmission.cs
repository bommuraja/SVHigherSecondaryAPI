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
    
    public partial class StudentAdmission
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentAdmission()
        {
            this.StudentRolls = new HashSet<StudentRoll>();
        }
    
        public int StudentAdmissionID { get; set; }
        public string AdmissionNumber { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string ContactNumber { get; set; }
        public string EMISNumber { get; set; }
        public string AadhaarNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string BloodGroup { get; set; }
        public string CreatedDate { get; set; }
        public Nullable<int> DataEntryOperatorID { get; set; }
        public Nullable<bool> Gender { get; set; }
        public string Community { get; set; }
        public string MotherName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string AdmissionYear { get; set; }
        public string AdmissionClass { get; set; }
    
        public virtual DataEntryOperator DataEntryOperator { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StudentRoll> StudentRolls { get; set; }
    }
}