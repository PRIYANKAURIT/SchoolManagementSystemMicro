using Dapper;
using StudentAttendanceManagement.Models;
using StudentAttendanceManagement.Repository.Interface;
using System.Data.Common;

namespace StudentAttendanceManagement.Repository
{
    public class Attendance : BaseAsyncRepository,IAttendace
    {
        public Attendance(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<List<StudentAttendanceManagementDetails>> GetAll()
        {
            List<StudentAttendanceManagementDetails> list = null;
            using (DbConnection dbconnection = sqlreaderConnection)
            {
                await dbconnection.OpenAsync();
                var admission = await dbconnection.QueryAsync<StudentAttendanceManagementDetails>(@"select * from StudAttendance");
                list = admission.ToList();
            }
            return list;


        }

        public async Task<StudentAttendanceManagementDetails> GetById(int id)
        {
            StudentAttendanceManagementDetails model = null;
            using (DbConnection dbconnection = sqlreaderConnection)
            {
                await dbconnection.OpenAsync();
                var stud = await dbconnection.QueryAsync<StudentAttendanceManagementDetails>(@"select * from StudAttendance where StudentID =@id", new { id });
                model = stud.FirstOrDefault();
            }
            return model;
        }

        public async Task<int> Add(AddStudentAttendanceManagementDetails studentAttendanceDetails)
        {
            int result = 0;
            int resultResult = 0;
            using (DbConnection dbConnection = sqlwriterConnection)
            {
                await dbConnection.OpenAsync();

                result = await dbConnection.ExecuteAsync(@" insert into StudAttendance(StudentName,AttendencePercentage)
                                                        values (@StudentName,@AttendencePercentage);", studentAttendanceDetails);
                if (result >= 1)
                {
                    resultResult = result;
                    int Id = result;
                }
                return resultResult;
            }
        }

        public async Task<int> Update(StudentAttendanceManagementDetails studentAttendanceDetails)
        {
            var resultResult = 0;
            using (DbConnection dbConnection = sqlreaderConnection)
            {
                await dbConnection.OpenAsync();
                var result = await dbConnection.ExecuteAsync(@"update StudAttendance set StudentName=@StudentName,
                                        AttendencePercentage=@AttendencePercentage where StudentID=@StudentID;", studentAttendanceDetails);
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
                    result = await dbConnection.ExecuteAsync(@"delete from StudAttendance where StudentID=@id", new { id });
                }

            }
            return result;
        }
    }
}

