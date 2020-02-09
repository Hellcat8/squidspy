using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace squidspy.Models
{
    public partial class Equipement
    {
        public Equipement()
        {
            CraftEquipement = new HashSet<CraftEquipement>();
            EquipementCondition = new HashSet<EquipementCondition>();
            EquipementEffect = new HashSet<EquipementEffect>();
        }

        public int IdEquipement { get; set; }
        public string Label { get; set; }
        public int Level { get; set; }
        public string Description { get; set; }
        public int? IdCraft { get; set; }
        public int? IdImage { get; set; }
        public int IdTypeEquipement { get; set; }

        [NotMapped]
        public string TypeEquipementName { get; set; }
        [NotMapped]
        public List<String> EffectsList { get; set; }
        [NotMapped]
        public List<String> ConditionsList { get; set; }

        public virtual Craft IdCraftNavigation { get; set; }
        public virtual Image IdImageNavigation { get; set; }
        public virtual TypeEquipement IdTypeEquipementNavigation { get; set; }
        public virtual ICollection<CraftEquipement> CraftEquipement { get; set; }
        public virtual ICollection<EquipementCondition> EquipementCondition { get; set; }
        public virtual ICollection<EquipementEffect> EquipementEffect { get; set; }
    }
}
