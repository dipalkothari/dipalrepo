using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sample.Domains;
using Sample.Infrastructure.UnitTest;
using Sample.Repositories;
using Sample.Services;
using System;
using System.Threading.Tasks;

namespace Tests.Unit.Sample.Services
{
    [TestClass]
    public class EmployeeServiceTest
    {
        private readonly EmployeeService _employeeService;
        private readonly Mock<EmployeeRepository> _employeeRepository;
        private readonly IMapper _mapper;


        private readonly EmployeeDTO _employeeDtoEntity;
        private readonly Employee _employeeEntity;

        public EmployeeServiceTest()
        {
            _employeeDtoEntity = new EmployeeDTO()
            {
                FirstName = "FirstNameDTO",
                LastName = "LastNameDTO",
                Age = 12,
                Gender = 'F'
            };
            _employeeEntity = new Employee()
            {
                FirstName = "FirstName",
                LastName = "LastName",
                Age = 12,
                Gender = 'F'
            };


            var myProfile = new AutoMapperProfiles.AutoMapperProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            _mapper = new Mapper(configuration);

            _employeeService = new EmployeeService(_employeeRepository.Object, _mapper);


        }

        [Fact]
        public async Task GetAll()
        {
            string value = "FirstName";
            //Act
            var result = await _employeeService.GetAll(value);

            //Assert
            Assert.IsNotNull(result);
        }


        [Fact]
        public async Task GetEmployeeByIdAsync_WhenSuccess_ReturnsEmployeeDTOList()
        {
            Guid value = Guid.Parse("11223344-5566-7788-99AA-BBCCDDEEFF00");

            //Act
            var result = await _employeeService.GetEmployeeById(value);

            //Assert
            Assert.IsNotNull(result);
        }

        [Fact]
        public async Task Save()
        {
            //Arrange
            _employeeRepository
                .Setup(repo => repo.AddEmployee(It.IsAny<Employee>()))
                .ReturnsAsync(_employeeEntity);
            //Arrange
            _employeeRepository
                .Setup(repo => repo.UpdateEmployee(It.IsAny<Employee>()))
                .ReturnsAsync(_employeeEntity);


            //Act
            var result = await _employeeService.Save(_employeeDtoEntity);

            //Assert
            Assert.IsNotNull(result);
        }

    }
}
