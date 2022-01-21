using CompanyApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Core.Interfaces.Repositories
{
  public interface ICompanyRepository
  {
    Task<Company> AddAsync(Company company);
    Task<Company> UpdateAsync(Company company);
    Task DeleteAsync(Company company);
    IQueryable<Company> GetById(Guid id);
    IQueryable<Company> GetAll();

  }
}
