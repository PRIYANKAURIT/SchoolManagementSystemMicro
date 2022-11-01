using StudentAttendanceManagement.Models;

namespace StudentAttendanceManagement.Repository.Interface
{
    public interface IAttendace
    {
        public Task<List<StudentAttendanceManagementDetails>> GetAll();
        public Task<StudentAttendanceManagementDetails> GetById(int id);
        public Task<int> Add(AddStudentAttendanceManagementDetails studentAttendanceDetails);
        public Task<int> Update(StudentAttendanceManagementDetails studentAttendanceDetails);
        public Task<int> DeleteById(int id);
    }
}
