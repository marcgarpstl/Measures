﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Entities
{
    public class MaleMeasures
    {
        public MaleMeasures(Guid userId)
        {
            MaleMeasureId = new Guid();
            UserId = userId;
        }
        [Key]
        public Guid MaleMeasureId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Chest { get; set; } // Bröst
        public int Waist { get; set; } // Midja
        public int Neck { get; set; } // Nacke
        public int ArmLength { get; set; } // Armlängd
        public int Calf { get; set; } // Vad
        public int Inseam { get; set; } // Fot till skrev
        public int FootLength { get; set; } // Fotlängd


    }
}
