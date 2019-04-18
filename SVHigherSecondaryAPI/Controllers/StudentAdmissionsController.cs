using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SVHigherSecondaryAPI.Models;

namespace SVHigherSecondaryAPI.Controllers
{
    public class StudentAdmissionsController : ApiController
    {
        private SVEntitiesDataModel db = new SVEntitiesDataModel();

        // Method : 1
        //1 GET: api/DataEntryOperators
        public List<StudentAdmissionData> GetStudentAdmissions()
        {
            List<StudentAdmissionData> objList = new List<StudentAdmissionData>();
            foreach (var item in db.StudentAdmissions)
            {
                objList.Add(
                    new StudentAdmissionData
                    {
                        StudentAdmissionID = item.StudentAdmissionID,
                        AdmissionNumber = item.AdmissionNumber,
                        StudentName = item.StudentName,
                        FatherName = item.FatherName,
                        ContactNumber = item.ContactNumber,
                        EMISNumber = item.EMISNumber,
                        AadhaarNumber = item.AadhaarNumber,
                        DateOfBirth = item.DateOfBirth,
                        BloodGroup = item.BloodGroup,
                        CreatedDate = item.CreatedDate,
                        DataEntryOperatorID = item.DataEntryOperatorID,
                        Gender = item.Gender,
                        Community = item.Community,
                        MotherName = item.MotherName,
                        PlaceOfBirth = item.PlaceOfBirth,
                        AdmissionYear = item.AdmissionYear,
                        AdmissionClass = item.AdmissionClass
                    }
                );
            }
            return objList;
        }

        // Method : 2
        [Route("api/DropStudentAdmission/{id}")]
        public bool GetRemoveStudentAdmissionDetails(int id)
        {
            StudentAdmission studentAdmission = db.StudentAdmissions.Find(id);
            if (studentAdmission == null)
            {
                return false;
            }
            try
            {
                db.StudentAdmissions.Remove(studentAdmission);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

     
        // Method : 3
        //4 GET: api/DataEntryOperators/5
        [ResponseType(typeof(StudentAdmission))]
        public StudentAdmissionData GetStudentAdmission(int id)
        {
            StudentAdmission studentAdmission = db.StudentAdmissions.Find(id);
            StudentAdmissionData objData = new StudentAdmissionData();
            if (studentAdmission != null)
            {
                objData = new StudentAdmissionData
                {
                    StudentAdmissionID = studentAdmission.StudentAdmissionID,
                    AdmissionNumber = studentAdmission.AdmissionNumber,
                    StudentName = studentAdmission.StudentName,
                    FatherName = studentAdmission.FatherName,
                    ContactNumber = studentAdmission.ContactNumber,
                    EMISNumber = studentAdmission.EMISNumber,
                    AadhaarNumber = studentAdmission.AadhaarNumber,
                    DateOfBirth = studentAdmission.DateOfBirth,
                    BloodGroup = studentAdmission.BloodGroup,
                    CreatedDate = studentAdmission.CreatedDate,
                    DataEntryOperatorID = studentAdmission.DataEntryOperatorID,
                    Gender = studentAdmission.Gender,
                    Community = studentAdmission.Community,
                    MotherName = studentAdmission.MotherName,
                    PlaceOfBirth = studentAdmission.PlaceOfBirth,
                    AdmissionYear = studentAdmission.AdmissionYear,
                    AdmissionClass = studentAdmission.AdmissionClass
                };
            }
            return objData;
        }

        // Method : 4
        //5 POST: api/DataEntryOperators
        [ResponseType(typeof(StudentAdmissionData))]
        public IHttpActionResult PostStudentAdmission(StudentAdmissionData studentAdmissionData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                if (studentAdmissionData.StudentAdmissionID > 0)
                {
                    StudentAdmission objDE = db.StudentAdmissions.Find(studentAdmissionData.StudentAdmissionID);

                    objDE.StudentAdmissionID = studentAdmissionData.StudentAdmissionID;
                    objDE.AdmissionNumber = studentAdmissionData.AdmissionNumber;
                    objDE.StudentName = studentAdmissionData.StudentName;
                    objDE.FatherName = studentAdmissionData.FatherName;
                    objDE.ContactNumber = studentAdmissionData.ContactNumber;
                    objDE.EMISNumber = studentAdmissionData.EMISNumber;
                    objDE.AadhaarNumber = studentAdmissionData.AadhaarNumber;
                    objDE.DateOfBirth = studentAdmissionData.DateOfBirth;
                    objDE.BloodGroup = studentAdmissionData.BloodGroup;
                    objDE.CreatedDate = studentAdmissionData.CreatedDate;
                    objDE.DataEntryOperatorID = studentAdmissionData.DataEntryOperatorID;
                    objDE.Gender = studentAdmissionData.Gender;
                    objDE.Community = studentAdmissionData.Community;
                    objDE.MotherName = studentAdmissionData.MotherName;
                    objDE.PlaceOfBirth = studentAdmissionData.PlaceOfBirth;
                    objDE.AdmissionYear = studentAdmissionData.AdmissionYear;
                    objDE.AdmissionClass = studentAdmissionData.AdmissionClass;
                    db.SaveChanges();

                }
                else
                {
                    studentAdmissionData.DataEntryOperatorID = 7;
                    StudentAdmission objDE = new StudentAdmission
                    {
                        StudentAdmissionID = studentAdmissionData.StudentAdmissionID,
                        AdmissionNumber = studentAdmissionData.AdmissionNumber,
                        StudentName = studentAdmissionData.StudentName,
                        FatherName = studentAdmissionData.FatherName,
                        ContactNumber = studentAdmissionData.ContactNumber,
                        EMISNumber = studentAdmissionData.EMISNumber,
                        AadhaarNumber = studentAdmissionData.AadhaarNumber,
                        DateOfBirth = studentAdmissionData.DateOfBirth,
                        BloodGroup = studentAdmissionData.BloodGroup,
                        CreatedDate = studentAdmissionData.CreatedDate,
                        DataEntryOperatorID = studentAdmissionData.DataEntryOperatorID,
                        Gender = studentAdmissionData.Gender,
                        Community = studentAdmissionData.Community,
                        MotherName = studentAdmissionData.MotherName,
                        PlaceOfBirth = studentAdmissionData.PlaceOfBirth,
                        AdmissionYear = studentAdmissionData.AdmissionYear,
                        AdmissionClass = studentAdmissionData.AdmissionClass
                    };
                    db.StudentAdmissions.Add(objDE);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           

            return CreatedAtRoute("DefaultApi", new { id = studentAdmissionData.StudentAdmissionID }, studentAdmissionData);
        }
    }
}