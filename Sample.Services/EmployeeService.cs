using AutoMapper;
using Sample.Domains;
using Sample.Infrastructure.UnitTest;
using Sample.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class EmployeeService
    {
        public readonly EmployeeRepository _repository;
        private readonly IMapper _mapper;

        public EmployeeService(EmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> Save(EmployeeDTO employeeDto)
        {
            try
            {
                var result = _repository.GetEmployeeById(employeeDto.Id);
                if (result == null)
                {
                    var addedUser = await _repository.AddEmployee(_mapper.Map<Employee>(employeeDto));

                    return _mapper.Map<EmployeeDTO>(addedUser);
                }
                else
                {
                    var updateUser = await _repository.UpdateEmployee(_mapper.Map<Employee>(employeeDto));

                    return _mapper.Map<EmployeeDTO>(updateUser);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        public async Task<List<EmployeeDTO>> GetAll(string empValue)
        {
            try
            {
                if (empValue == null)
                {
                    throw new ArgumentNullException(nameof(empValue));
                }
                else
                {
                    var result = await _repository.GetAllEmployee(empValue);
                    List<EmployeeDTO> employeeDTOs = new List<EmployeeDTO>();
                    foreach (var em in result)
                    {
                        EmployeeDTO dTO = new EmployeeDTO();
                        dTO.FullName = string.Concat(em.FirstName, " ", em.LastName);
                        dTO.FirstName = em.FirstName;
                        dTO.LastName = em.LastName;
                        dTO.Age = em.Age;
                        dTO.Gender = em.Gender;
                        employeeDTOs.Add(dTO);
                    }
                    return _mapper.Map<List<EmployeeDTO>>(employeeDTOs);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<EmployeeDTO> GetEmployeeById(Guid Id)
        {
            try
            {
                var employee = await _repository.GetEmployeeById(Id);
                EmployeeDTO employeeDTO = new EmployeeDTO();
                employeeDTO.FullName = employee.FirstName + employee.LastName;
                employeeDTO.FirstName = employee.FirstName;
                employeeDTO.LastName = employee.LastName;
                employeeDTO.Age = employee.Age;
                employeeDTO.Gender = employee.Gender;
                return employeeDTO;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public void DeleteEmployee(Guid Id)
        {
            try
            {
                if (Id != null)
                {
                    _repository.DeleteEmployee(Id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
