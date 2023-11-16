using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.DTOs.WriteDTO
{
    public record SetMaleMeasuresDto(int Chest, int Waist, int Neck, int ArmLength, int Calf, int Inseam, int FootLength);
}
