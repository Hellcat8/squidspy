using System;
using System.Collections.Generic;

namespace squidspy.Models
{
    public partial class SpellDetail
    {
        public SpellDetail()
        {
            SpellEffect = new HashSet<SpellEffect>();
        }

        public int IdSpellDetail { get; set; }
        public sbyte SpellLvl { get; set; }
        public int RequiredLvl { get; set; }
        public string Range { get; set; }
        public string ApCost { get; set; }
        public string CriticalHitProbability { get; set; }
        public string FailureProbability { get; set; }
        public string NbCastPerTurn { get; set; }
        public string NbCastPerTurnPerPlayer { get; set; }
        public string NbTurnsBetweenTwoCasts { get; set; }
        public bool AdjustableRange { get; set; }
        public bool LineOfSight { get; set; }
        public bool Linear { get; set; }
        public bool FreeCells { get; set; }
        public bool FailureEndsTurn { get; set; }
        public bool HasCriticalEffect { get; set; }
        public bool HasSummonInfo { get; set; }
        public bool HasGlyphInfo { get; set; }
        public bool HasTrapInfo { get; set; }
        public int IdSpell { get; set; }

        public virtual Spell IdSpellNavigation { get; set; }
        public virtual ICollection<SpellEffect> SpellEffect { get; set; }
    }
}
