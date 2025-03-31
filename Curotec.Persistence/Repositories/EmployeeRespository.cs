using Curotec.Application.Repositories;
using Curotec.Domain.Entities;
using Curotec.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Curotec.Persistence.Repositories
{
    public class EmployeeRepository(CurotecContext context) : GenericRepository<Employee>(context), IEmployeeRepository
    {
        public Task<Employee?> GetByEmail(string email, CancellationToken cancellationToken)
        {
            return Context.Employees.FirstOrDefaultAsync(x => x.Email == email, cancellationToken);
        }
    }
}
