using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyApp.Core.Entities
{
  public class BaseEntity : IBaseEntity
  {
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; protected set; }

    protected BaseEntity()
    {
      Id = Guid.NewGuid();
    }

  }
}
