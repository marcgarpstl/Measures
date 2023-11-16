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
        internal static ReadFemaleMeasuresDto ToReadFemaleDto(this ReadFemaleMeasuresDto rfd) =>
            new ReadFemaleMeasuresDto(rfd.Id, rfd.UserId, rfd.Bust, rfd.Waist, rfd.Hip, rfd.NapeWaist, rfd.FrontRise, rfd.UnderBust, rfd.MidShoulderBust, rfd.ShoulderLength, rfd.Wrist, rfd.Biceps, rfd.CrotchAnkle, rfd.Thigh, rfd.FootLength);

        internal static FemaleMeasures ToFemaleMeasures(this SetFemaleMeasuresDto sfd) =>
            new FemaleMeasures(sfd.UserId);

        internal static ReadMaleMeasuresDto ToReadMaleDto(this ReadMaleMeasuresDto rmd) =>
            new ReadMaleMeasuresDto(rmd.Id, rmd.UserId, rmd.Chest, rmd.Waist, rmd.Neck, rmd.ArmLenght, rmd.Calf, rmd.Inseam, rmd.FootLength);

        internal static MaleMeasures ToMaleMeasures(this SetMaleMeasuresDto smd) =>
            new MaleMeasures(smd.UserId);
    }
}
