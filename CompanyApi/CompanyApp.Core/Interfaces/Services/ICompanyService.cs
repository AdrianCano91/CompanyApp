using CompanyApp.Core.DTOs;
using CompanyApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Core.Interfaces.Services
{
  public interface ICompanyService
  {
    Task<Company> CreateCompanyAsync(CompanyDTO companyDto);
    Task<Company> UpdateCompanyAsync(Guid companyId, CompanyDTO companyDto);
    Task DeleteCompanyAsync(Guid companyId);
    List<Company> GetAllAsync();
  }
}
