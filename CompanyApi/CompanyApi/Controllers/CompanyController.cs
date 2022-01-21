using CompanyApp.Core.DTOs;
using CompanyApp.Core.Entities;
using CompanyApp.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApi.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class CompanyController : ControllerBase
  {


    private readonly ICompanyService _companyService;

    public CompanyController(ICompanyService companyService)
    {
      _companyService = companyService;
    }

    [HttpGet]
    public IActionResult Get()
    {
      List<Company> companies = _companyService.GetAllAsync();
      return Ok(companies);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CompanyDTO companyDto)
    {
      Company company = await _companyService.CreateCompanyAsync(companyDto);
      return Ok(company);
    }

    [HttpPut("{companyId}")]
    public async Task<IActionResult> Put(Guid companyId,[FromBody] CompanyDTO companyDto)
    {
      Company company = await _companyService.UpdateCompanyAsync(companyId, companyDto);
      return Ok(company);
    }

    [HttpDelete("{companyId}")]
    public async Task<IActionResult> Delete(Guid companyId)
    {
      await _companyService.DeleteCompanyAsync(companyId);
      return Ok();
    }
  }
}
