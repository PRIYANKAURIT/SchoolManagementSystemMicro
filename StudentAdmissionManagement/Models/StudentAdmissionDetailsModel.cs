﻿namespace StudentAdmissionManagementSystem.Models
{
    public class StudentAdmissionDetailsModel
    {
        public int StudentID { get; set; }
        public string? StudentName { get; set; }
        public string? StudentClass { get; set; }
        public DateTime DateofJoining { get; set; }
    }

    public class ADDStudentAdmissionDetailsModel
    {
        public string? StudentName { get; set; }
        public string? StudentClass { get; set; }
        public DateTime DateofJoining { get; set; }
    }
}
