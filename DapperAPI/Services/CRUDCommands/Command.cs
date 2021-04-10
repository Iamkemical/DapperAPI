using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperAPI.Services.CRUDCommands
{
    public class Command : ICommand
    {
        public string GetStudent => "Select * from Student";

        public string GetStudentById => "Select * from Student Where Id = @Id";

        public string CreateStudent => "Insert into Student (Name, Age) Values (@Name, @Age)";

        public string UpdateStudent => "Update Student set Name = @Name, Age = @Age Where Id = @Id";

        public string DeleteStudent => "Delete from Student Where Id = @Id";
    }
}
