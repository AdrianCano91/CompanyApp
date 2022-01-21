using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Core.Entities
{
  public interface IBaseEntity : IBaseEntity<Guid> { }

  public interface IBaseEntity<IdType>
  {
    IdType Id { get; }
  }
}
