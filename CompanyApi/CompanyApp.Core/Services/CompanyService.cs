using CompanyApp.Core.DTOs;
using CompanyApp.Core.Entities;
using CompanyApp.Core.Interfaces.Repositories;
using CompanyApp.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Core.Services
{
  public class CompanyService: ICompanyService
  {
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(ICompanyRepository companyRepository)
    {
      _companyRepository = companyRepository;
    }

    public async Task<Company> CreateCompanyAsync(CompanyDTO companyDto)
    {
      Company company = Company.Create(companyDto);
      return await _companyRepository.AddAsync(company);
      
    }

    public async Task<Company> UpdateCompanyAsync(Guid companyId,CompanyDTO companyDto)
    {
      Company company = _companyRepository.GetById(companyId).FirstOrDefault();
      company.Update(companyDto);
      return await _companyRepository.UpdateAsync(company);

    }

    public async Task DeleteCompanyAsync(Guid companyId)
    {
      Company company = _companyRepository.GetById(companyId).FirstOrDefault();
      await _companyRepository.DeleteAsync(company);

    }

    public List<Company> GetAllAsync()
    {
      return _companyRepository.GetAll().ToList();
    }
  }
}
