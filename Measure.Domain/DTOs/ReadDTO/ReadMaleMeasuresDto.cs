using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.DTOs.ReadDTO
{
    public record ReadMaleMeasuresDto(Guid Id,
        Guid UserId,
        int Chest,
        int Waist,
        int Neck,
        int ArmLenght,
        int Calf,
        int Inseam,
        int FootLength);

}
