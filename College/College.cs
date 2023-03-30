using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CollegeManagement
{
    public class College
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
        public string FacultyQualification { get; set; }
        public double FacultyPhoneNumber { get; set; }
        public string FacultyEmail { get; set; }
        public string FacultyDepartment { get; set; }
        public string FacultySubject { get; set; }
        public string FacultyClass { get; set; }
        public int StudentsCount { get; set; }
    }
    public class PageInfo
    {
        
        public int PageNum { get; set; }       
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public int NestPages { get; set; }
    }
}
