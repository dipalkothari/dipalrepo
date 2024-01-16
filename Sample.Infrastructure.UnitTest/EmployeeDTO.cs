using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Infrastructure.UnitTest
{
    public class EmployeeDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public char Gender { get; set; }

        public string FullName { get; set; }
    }
}
