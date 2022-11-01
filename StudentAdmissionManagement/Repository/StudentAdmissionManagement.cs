using Dapper;
using StudentAdmissionManagementSystem.Models;
using StudentAdmissionManagementSystem.Repository.Interface;
using System.Data.Common;

namespace StudentAdmissionManagementSystem.Repository
{
    public class StudentAdmissionManagement : BaseAsyncRepository, IStudentAdmissionManagement
    {
        public StudentAdmissionManagement(IConfiguration configuration) : base(configuration)
        {
 
        }

        public async Task<List<StudentAdmissionDetailsModel>> GetAll()  
        {
            List<StudentAdmissionDetailsModel> list = null;
            using (DbConnection dbconnection = sqlreaderConnection)
            {
                await dbconnection.OpenAsync();
                var admission = await dbconnection.QueryAsync<StudentAdmissionDetailsModel>(@"select * from Admission");
                list = admission.ToList();
            }
            return list;


        }

        public async Task<StudentAdmissionDetailsModel> GetById(int id)
        {
            StudentAdmissionDetailsModel model = null;
            using (DbConnection dbconnection = sqlreaderConnection)
            {
                await dbconnection.OpenAsync();
                var stud = await dbconnection.QueryAsync<StudentAdmissionDetailsModel>(@"select * from Admission where StudentID =@id", new { id });
                model = stud.FirstOrDefault();
            }
            return model;
        }

        public async Task<int> Add(ADDStudentAdmissionDetailsModel studentAdmissionDetails)
        {
            int result = 0;
            int resultResult = 0;
            using (DbConnection dbConnection = sqlwriterConnection)
            {
                await dbConnection.OpenAsync();            
               
                result = await dbConnection.ExecuteAsync(@"insert into Admission(StudentName,StudentClass,DateofJoining)
                                                                    values (@StudentName,@StudentClass,@DateofJoining);", studentAdmissionDetails);
                if (result >= 1)
                {
                    resultResult = result;
                    int Id = result;
                }
                return resultResult;
            }
        }

        public async Task<int> Update(StudentAdmissionDetailsModel studentAdmissionDetails)
        {
            var resultResult = 0;
            using (DbConnection dbConnection= sqlreaderConnection )
            {
                await dbConnection.OpenAsync();
                var result = await dbConnection.ExecuteAsync(@"update Admission set StudentName=@StudentName,
                                        StudentClass=@StudentClass,DateofJoining=@DateofJoining where StudentID=@StudentID;", studentAdmissionDetails);
                if (result >= 1)
                {
                    resultResult = result;
                    int Id = result;
                }
                return resultResult;
            }
        }

        public async Task<int> DeleteById(int id)
        {
            int result = 0;
            if (id != 0)
            {
                using (DbConnection dbConnection = sqlwriterConnection)
                {
                    await dbConnection.OpenAsync();                  
                    result = await dbConnection.ExecuteAsync(@"delete from Admission where StudentID=@id", new {id});
                }

            }
            return result;
        }
    }
}
