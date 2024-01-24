using System;
using System.Collections.Generic;
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

        public Guid FemaleMeasureId { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        /// <summary>
        /// Shirts, Blouses, Dresses, Skirts, Pants etc
        /// </summary>
        public int Bust { get; set; } // Byst
        public int Waist { get; set; } // Midja
        public int Hip { get; set; } // Höft/Stuss
        public int ArmLenght { get; set; } // Armlängd
        public int LegLenght { get; set; } // Innerbenslängd (Skrev till golv)
        /// <summary>
        /// BH
        /// </summary>
        public int UnderBust { get; set; } // Byst under bröst 
        public int BreastVolume { get; set; } // Bröstomgång
        /// <summary>
        /// Socks and Shoes
        /// </summary>
        public int FootLength { get; set; } // Fotlängd
        public int FootWidth { get; set; } // Fotensbredd
        public int Calf {  get; set; } // Vaden
        /// <summary>
        /// Gloves
        /// </summary>
        public int HandCircumference {  get; set; } // Handomkrets
        /// <summary>
        /// Hats
        /// </summary>
        public int HeadCircumference { get; set; } // Huvudomkrets
        /// <summary>
        /// Rings
        /// </summary>
        public int FingerCircumference { get; set; } // Fingeromkrets
    }
}
