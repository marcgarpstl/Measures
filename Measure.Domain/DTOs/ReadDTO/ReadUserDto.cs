using Measure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.DTOs.ReadDTO
{
    public record ReadUserDto(Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string UserName,
        MaleMeasures male,
        FemaleMeasures female
        );
}
