using Curotec.Application.Repositories;
using Curotec.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Curotec.Persistence.Context;

namespace Curotec.Persistence.Repositories
{
    public class UserRepository(CurotecContext context) : GenericRepository<User>(context), IUserRepository
    {
    
    }
}
