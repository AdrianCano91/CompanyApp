using CompanyApp.Core.Entities;
using CompanyApp.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Infrastructure.DataAccess.Repositories
{
  public class CompanyRepository: BaseRepository<Company>, ICompanyRepository
  {
    public CompanyRepository(ApplicationDbContext dbContext) : base(dbContext)
    { }
  }
}
