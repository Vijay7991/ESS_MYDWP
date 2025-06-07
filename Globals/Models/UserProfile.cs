using System;

namespace Globals.Models
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; } // Foreign key
        public User User { get; set; }  // Navigation property

        // Profile Header
        public string FullName { get; set; }
        public string Designation { get; set; }
        public string EmployeeId { get; set; }

        // Personal Details
        public string Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string MaritalStatus { get; set; }
        public string Nationality { get; set; }

        // Employment Details
        public string Department { get; set; }
        public string EmploymentType { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string ReportingManager { get; set; }
        public string EmploymentStatus { get; set; }

        // Contact Information
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string PresentAddress { get; set; }
        public string PermanentAddress { get; set; }
        public string EmergencyContact { get; set; }
    }
}