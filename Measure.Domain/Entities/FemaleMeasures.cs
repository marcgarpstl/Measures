using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Measure.Domain.Entities
{
    public class FemaleMeasures
    {
        [Key]
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
        public FemaleMeasures()
        {
            
        }
        public FemaleMeasures(Guid userId, int bust, int waist, int hip, int armLenght, int legLenght, int underBust, int breastVolume, int footLength, int footWidth, int calf, int handCircumference, int headCircumference, int fingerCircumference)
        {
            FemaleMeasureId = new Guid();
            UserId = userId;
            Bust = bust;
            Waist = waist;
            Hip = hip;
            ArmLenght = armLenght;
            LegLenght = legLenght;
            UnderBust = underBust;
            BreastVolume = breastVolume;
            FootLength = footLength;
            FootWidth = footWidth;
            Calf = calf;
            HandCircumference = handCircumference;
            HeadCircumference = headCircumference;
            FingerCircumference = fingerCircumference;
        }
    }
}
