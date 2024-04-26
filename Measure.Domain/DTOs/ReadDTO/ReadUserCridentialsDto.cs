using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.DTOs.ReadDTO
{
    public record ReadUserCridentialsDto(Guid id,
        string FirstName,
        string LastName,
        string Username,
        string Email,
        string Password)
    { }
}
