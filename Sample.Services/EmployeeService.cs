using Sample.Domains;
using Sample.Repositories;
using System;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class EmployeeService
    {
        public readonly EmployeeRepository _repository;
        public EmployeeService(EmployeeRepository repository)
        {
            _repository = repository;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    throw new ArgumentNullException(nameof(employee));
                }
                else
                {
                    return await _repository.AddEmployee(employee);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                {
                    throw new ArgumentNullException(nameof(employee));
                }
                else
                {
                    return await _repository.UpdateEmployee(employee);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteEmployee(int Id)
        {
            try
            {
                if (Id != 0)
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
