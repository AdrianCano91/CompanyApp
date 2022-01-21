using CompanyApp.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Core.DTOs
{
  public class CompanyDTO
  {
    public string Name { get; set; }
    public ESize Size { get; set; }
  }
}
