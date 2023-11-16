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
        string Password,
        string UserName,
        ICollection<ReadFemaleMeasuresDto> FemaleMeasures,
        ICollection<ReadMaleMeasuresDto> MaleMeasures)
    {
        ICollection<ReadFemaleMeasuresDto> Female = new List<ReadFemaleMeasuresDto>();
        ICollection<ReadMaleMeasuresDto> Male = new List<ReadMaleMeasuresDto>();
    }
}
