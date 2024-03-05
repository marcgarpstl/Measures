using Measure.Domain.DTOs.ReadDTO;
using Measure.Domain.DTOs.WriteDTO;
using Measure.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Extensions
{
    internal static class MeasuresMapper
    {
        internal static ReadFemaleMeasuresDto ToFemaleDto(this FemaleMeasures rfd) =>
            new ReadFemaleMeasuresDto(
                rfd.UserId,
                rfd.Bust,
                rfd.Waist,
                rfd.Hip,
                rfd.ArmLenght, 
                rfd.LegLenght, 
                rfd.UnderBust, 
                rfd.BreastVolume, 
                rfd.FootLength, 
                rfd.FootWidth, 
                rfd.Calf, 
                rfd.HandCircumference, 
                rfd.HeadCircumference, 
                rfd.FingerCircumference);

        internal static FemaleMeasures ToFemaleMeasures(this SetFemaleMeasuresDto sfd) =>
            new FemaleMeasures(
                sfd.Bust,
                sfd.Waist,
                sfd.Hip,
                sfd.ArmLenght,
                sfd.LegLenght,
                sfd.UnderBust,
                sfd.BreastVolume,
                sfd.FootLenght,
                sfd.FootWitdh,
                sfd.Calf,
                sfd.HandCircumference,
                sfd.HeadCircumference,
                sfd.FingerCircumference);

        internal static ReadMaleMeasuresDto ToMaleDto(this ReadMaleMeasuresDto rmd) =>
            new ReadMaleMeasuresDto(
                rmd.Id,
                rmd.UserId, 
                rmd.Chest, 
                rmd.Waist,
                rmd.Neck,
                rmd.ArmLenght,
                rmd.Calf,
                rmd.Inseam,
                rmd.FootLength);

        internal static MaleMeasures ToMaleMeasures(this SetMaleMeasuresDto smd) =>
            new MaleMeasures(smd.UserId);
    }
}
