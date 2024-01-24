﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.DTOs.ReadDTO
{
    public record ReadFemaleMeasuresDto(Guid Id,
        Guid UserId,
        int Bust,
        int Waist,
        int Hip,
        int ArmLenght,
        int LegLenght,
        int UnderBust,
        int BreastVolume,
        int FootLenght,
        int FootWitdh,
        int Calf,
        int HandCircumference,
        int HeadCircumference,
        int FingerCircumference);
}
