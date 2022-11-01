namespace StudentAttendanceManagement.Models
{
    public class StudentAttendanceManagementDetails
    {
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public double AttendencePercentage { get; set; }
    }

    public class AddStudentAttendanceManagementDetails
    {  
        public string? StudentName { get; set; }
        public double AttendencePercentage { get; set; }
    }
}
