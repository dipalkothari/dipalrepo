using Sample.Domains;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    public interface IEmployeeRepository
    {
        Task<Employee> AddEmployee(Employee employee);
        Task<Employee> GetEmployeeById(Guid Id);
        Task<Employee> UpdateEmployee(Employee employee);
        void DeleteEmployee(Guid employeeId);

        Task<List<Employee>> GetAllEmployee(string value);
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly RepositoryContext appDbContext;

        public EmployeeRepository(RepositoryContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            var result = await appDbContext.Employees.AddAsync(employee);
            await appDbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employee.Id);

            if (result != null)
            {
                result.FirstName = employee.FirstName;
                result.LastName = employee.LastName;
                result.Gender = employee.Gender;
                result.Age = employee.Age;
                await appDbContext.SaveChangesAsync();

                return result;
            }

            return null;
        }

        public async void DeleteEmployee(Guid employeeId)
        {
            var result = await appDbContext.Employees
                .FirstOrDefaultAsync(e => e.Id == employeeId);
            if (result != null)
            {
                appDbContext.Employees.Remove(result);
                await appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Employee>> GetAllEmployee(string value)
        {
            // var result = appDbContext.Employees.wh.ToList();

            var rr = await appDbContext.Employees
        .AsQueryable()
        .Where(b => b.FirstName == value || b.LastName == value || b.Gender == Convert.ToChar(value))
        .ToListAsync();

            return rr;

        }

        public async Task<Employee> GetEmployeeById(Guid Id)
        {
            // var result = appDbContext.Employees.wh.ToList();

            var rr = await appDbContext.Employees.FirstOrDefaultAsync(x => x.Id == Guid);

            return rr;

        }
    }
}
