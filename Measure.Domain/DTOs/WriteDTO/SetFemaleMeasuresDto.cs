using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.DTOs.WriteDTO
{
    public record SetFemaleMeasuresDto(Guid UserId,
        int Bust,
        int Waist,
        int Hip,
        int NapeWaist,
        int FrontRise,
        int UnderBust,
        int MidShoulderBust,
        int ShoulderLength,
        int Wrist,
        int Biceps,
        int CrotchAnkle,
        int Thigh,
        int FootLength);

}
