using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.DTOs.WriteDTO
{
    public record SetUserDto(string FirstName, string LastName, string Email, string Password, string UserName);
}
