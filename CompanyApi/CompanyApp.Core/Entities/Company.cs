using CompanyApp.Core.DTOs;
using CompanyApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Core.Entities
{
  public class Company : BaseEntity
  {
    public string Name { get; private set; }
    public ESize Size { get; private set; }

    private Company() { }

    public static Company Create(CompanyDTO companyDto)
    {
      Company company = new Company();
      company.Name = companyDto.Name;
      company.Size = companyDto.Size;
      return company;
    }

    public void Update(CompanyDTO companyDto)
    {
      Name = companyDto.Name;
      Size = companyDto.Size;
    }
  }

  
}
