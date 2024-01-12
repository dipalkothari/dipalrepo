using Sample.Domains;
using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RepositoryContext repositoryContext;

        public EmployeeRepository(RepositoryContext appDbContext)
        {
            this.repositoryContext = appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await repositoryContext.Employees.AddAsync(employee);
            await repositoryContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await repositoryContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Gender = employee.Gender;
                result.Age = employee.Age;
                await repositoryContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async void DeleteEmployee(int employeeId)
        {
            var result = await repositoryContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            if (result != null)
            {
                repositoryContext.Employees.Remove(result);
                await repositoryContext.SaveChangesAsync();
            }
        }


    }
}
