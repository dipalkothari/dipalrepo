using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sample.Repositories;
using System;
using Xunit;

namespace Tests.Unit.Sample.Repositories
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        private readonly Mock<EmployeeRepository> _employeeRepository;

        private  Guid Id = Guid.Parse("11223344-5566-7788-99AA-BBCCDDEEFF00");

        public EmployeeRepositoryTest()
        {
            _employeeRepository = new Mock<EmployeeRepository>();

        }
        [Fact]
        public void DeleteEmployee()
        {
            //Assert
            _employeeRepository.Verify(x => x.DeleteEmployee(Id), Times.Once());
        }

    }
}
