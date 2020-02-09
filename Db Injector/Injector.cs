using System;
using System.Collections.Generic;
using squidspy.Models;
using System.Linq;

namespace squidspy.DbInjector
{
    public class Injector
    {
        private squidofusContext _context;

        public Injector()
        {
            _context = new squidofusContext();
        }

        public void InjectRessources(List<Ressource> ressources, List<string> ressourceTypes)
        {
            if (ressourceTypes.Any())
            {
                foreach (string cat in ressourceTypes.Distinct())
                {
                    TypeRessource tr = new TypeRessource();
                    tr.Label = cat;

                    if (!_context.TypeRessource.Where(x => x.Label.Equals(cat)).Any())
                    {
                        _context.TypeRessource.Add(tr);
                    }
                }
                _context.SaveChanges();
            }

            if (ressources.Any())
            {
                foreach (Ressource r in ressources)
                {
                    r.IdTypeRessource = _context.TypeRessource.Where(x => x.Label.Equals(r.TypeRessourceName)).Select(x => x.IdTypeRessource).FirstOrDefault();

                    _context.Ressource.Add(r);
                }
                _context.SaveChanges();
            }
        }

        public void InjectEquipements(List<Equipement> equipements, List<string> equipementTypes)
        {
            if (equipementTypes.Any())
            {
                foreach (string cat in equipementTypes.Distinct())
                {
                    TypeEquipement te = new TypeEquipement();
                    te.Label = cat;

                    if (!_context.TypeEquipement.Where(x => x.Label.ToLower().Equals(cat.ToLower())).Any())
                    {
                        _context.TypeEquipement.Add(te);
                    }
                }
                _context.SaveChanges();
            }

            if (equipements.Any())
            {
                foreach (Equipement e in equipements)
                {
                    e.IdTypeEquipement = _context.TypeEquipement.Where(x => x.Label.Equals(e.TypeEquipementName)).Select(x => x.IdTypeEquipement).FirstOrDefault();
                    e.EquipementCondition = GetEquipementConditions(e);
                    e.EquipementEffect = GetEquipementEffects(e);

                    _context.Equipement.Add(e);
                }
                _context.SaveChanges();
            }
        }

        private ICollection<EquipementCondition> GetEquipementConditions(Equipement equip)
        {
            List<EquipementCondition> ecList = new List<EquipementCondition>();

            int count = 1;
            foreach (string c in equip.ConditionsList)
            {
                EquipementCondition ec = new EquipementCondition();
                ec.Order = count;
                ec.Condition = c;

                ecList.Add(ec);
                count++;
            }

            return ecList;
        }

        private ICollection<EquipementEffect> GetEquipementEffects(Equipement equip)
        {
            List<EquipementEffect> efList = new List<EquipementEffect>();

            int count = 1;
            foreach (string eff in equip.EffectsList)
            {
                EquipementEffect ee = new EquipementEffect();
                ee.Order = count;
                ee.Effect = eff;
                ee.IdTypeEffect = GetTypeEffect(eff, false);
                ee.IdTypeCaracteristique = GetTypeCaracteristique(eff);

                efList.Add(ee);
                count++;

                if (ee.Effect.Length > 254)
                {
                    Console.WriteLine($"{equip.Label} : {ee.Effect}");
                    Console.ReadLine();
                }
            }

            return efList;
        }

        private int GetTypeEffect(string effect, bool isArme)
        {
            effect = effect.ToLower();

            if (effect.StartsWith("+")||
                (effect.Contains("résistance") && !effect.StartsWith("résistance")) ||
                effect.Contains("res.") ||
                effect.StartsWith("réduction") ||
                effect.StartsWith("augmente") ||
                effect.StartsWith("désactive") ||
                effect.StartsWith("rend ") ||
                effect.StartsWith("réduit") ||
                effect.StartsWith("renvoi"))
            {
                return 2; // BONUS
            }
            else if (effect.StartsWith("-") ||
                    effect.StartsWith("PM perdus") ||
                    (effect.StartsWith("PA perdus") && isArme == false) ||
                    effect.Contains("faiblesse"))
            {
                return 3; // MALUS
            }
            else if (effect.StartsWith("dommages :"))
            {
                return 4; // DOMMAGES
            }
            else
            {
                return 1; // NEUTRE
            }
        }

        private int? GetTypeCaracteristique(string effect)
        {
            effect = effect.ToLower();

            if (effect.Contains("force"))
            {
                return 2; //terre
            }
            else if (effect.Contains("intelligence"))
            {
                return 4; //feu
            }
            else if (effect.Contains("agilité"))
            {
                return 5; //air
            }
            else if (effect.Contains("chance"))
            {
                return 3; //eau
            }
            else if (effect.Contains("vitalité"))
            {
                return 1; //vita
            }
            else if (effect.Contains("sagesse"))
            {
                return 6; //sagesse
            }
            else if (effect.Contains("neutre"))
            {
                return 14; //neutre
            }
            else if (effect.Contains("invoc") && !effect.Contains("sort"))
            {
                return 10; //invoc
            }
            else if (effect.Contains("prospection"))
            {
                return 12; //pp
            }
            else if (effect.Contains("initiative"))
            {
                return 11; //ini
            }
            else if (effect.Contains("portée") && !effect.Contains("sort"))
            {
                return 9; //po
            }
            else if (effect.Contains("vie"))
            {
                return 13; //pv
            }
            else if (effect.Contains("pm") && !effect.Contains("sort"))
            {
                return 8; //PM
            }
            else if (effect.Contains("pa") && !effect.Contains("sort"))
            {
                return 7; //PA
            }
            return null;
        }
    }
}
