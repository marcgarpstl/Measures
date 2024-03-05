using Measure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.DTOs.WriteDTO
{
    public record SetUserDto(Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Password,
        string UserName);
}
