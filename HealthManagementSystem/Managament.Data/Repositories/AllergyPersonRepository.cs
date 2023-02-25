using Management.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Data.Repositories
{
    public class AllergyPersonRepository
    {
        private readonly HealthManagementDbContext _context;
        public AllergyPersonRepository(HealthManagementDbContext context)
        {
            _context = context;
        }
    }
}
