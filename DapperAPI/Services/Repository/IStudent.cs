using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Services
{
    public interface IStudent
    {
        Task<IEnumerable<Model>> GetAllStudent();
        ValueTask<Model> GetStudentById(int id);
        Task CreateStudent(Model model);
        Task UpdateStudent(Model model, int id);
        Task DeleteStudent(int id);
    }
}
