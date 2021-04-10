using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Services.CRUDCommands
{
    public interface ICommand
    {
        string GetStudent { get; }
        string GetStudentById { get; }
        string CreateStudent { get; }
        string UpdateStudent { get; }
        string DeleteStudent { get; }
    }
}
