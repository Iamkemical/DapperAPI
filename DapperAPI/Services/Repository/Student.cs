using Dapper;
using DapperAPI.Services.CRUDCommands;
using DapperAPI.Services.SQLBaseRepository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Services
{
    public class Student : BaseRepository, IStudent
    {
        private readonly ICommand command;
        public Student(IConfiguration config, ICommand command)
            :base(config)
        {
            this.command = command;
        }
        public async Task CreateStudent(Model model)
        {
            await WithConnection(async connection =>
            {
                await connection.ExecuteAsync(command.CreateStudent,
                    new { Name = model.Name, Age = model.Age });
            });
        }

        public async Task DeleteStudent(int id)
        {
            await WithConnection(async connection =>
            {
                await connection.ExecuteAsync(command.DeleteStudent, new { Id = id });
            });
        }

        public async Task<IEnumerable<Model>> GetAllStudent()
        {
            return await WithConnection(async connection =>
            {
                var query = await connection.QueryAsync<Model>(command.GetStudent);
                return query;
            });
        }

        public async ValueTask<Model> GetStudentById(int id)
        {
            return await WithConnection(async connection =>
            {
                var query = await connection.QueryFirstOrDefaultAsync<Model>(command.GetStudentById, new { Id = id });
                return query;
            });
        }

        public async Task UpdateStudent(Model model, int id)
        {
            await WithConnection(async connection =>
            {
                await connection.ExecuteAsync(command.UpdateStudent,
                    new { Name = model.Name, Age = model.Age, Id = id });
            });
        }
    }
}
