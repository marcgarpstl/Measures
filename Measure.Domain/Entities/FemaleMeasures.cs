using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Entities
{
    public class FemaleMeasures
    {

        public FemaleMeasures(Guid userId)
        {
            FemaleMeasureId = new Guid();
            UserId = userId;
        }

        [Key]
        public Guid FemaleMeasureId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public int Bust { get; set; } // Byst
        public int Waist { get; set; } // Midja
        public int Hip { get; set; } // Höft
        public int NapeWaist { get; set; } // Navel till halsgrop
        public int FrontRise { get; set; } // Navel till skrev
        public int UnderBust { get; set; } // Byst under bröst
        public int MidShoulderBust { get; set; } // Centrum byst till axel
        public int ShoulderLength {  get; set; } // Hals till axel
        public int Wrist { get; set; } // Handled
        public int Biceps { get; set; } // Biceps
        public int CrotchAnkle { get; set; } // Skrev till ankel
        public int Thigh { get; set; } // Lår
        public int FootLength { get; set; } // Fotlängd

    }
}
