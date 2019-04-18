using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SVHigherSecondaryAPI.Models
{
    public class StudentAdmissionData
    {
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
    }
}