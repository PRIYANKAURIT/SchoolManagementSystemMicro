using StudentAdmissionManagementSystem.Models;

namespace StudentAdmissionManagementSystem.Repository.Interface
{
    public interface IStudentAdmissionManagement
    {
        public Task<List<StudentAdmissionDetailsModel>> GetAll();
        public Task<StudentAdmissionDetailsModel> GetById(int id);
        public Task<int> Add(ADDStudentAdmissionDetailsModel studentAdmissionDetails);
        public Task<int> Update(StudentAdmissionDetailsModel studentAdmissionDetails);
        public Task<int> DeleteById(int id);
    }
}
