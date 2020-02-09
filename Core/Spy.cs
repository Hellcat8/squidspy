using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;
using System.Net;
using squidspy.Models;
using System.Collections;
using System.Linq;
using squidspy.DbInjector;

namespace squidspy.Core
{
    public class Spy
    {
        public enum ItemTypes {
            ressource,
            equipement,
            arme,
            familier,
            panoplie,
            consommable
        };

        public Spy() {}

        private HtmlDocument OpenHtmlFromFile(string path)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(path);

            return doc;
        }

        public void ImportItems(string path, string item_type)
        {
            Logger logger = new Logger();
            logger.StartLogging(item_type);
            int success_count = 0;
            int total_count = 0;
            List<string> categories = new List<string>();
            List<Ressource> ressources = new List<Ressource>();
            List<Equipement> equipements = new List<Equipement>();
            List<Arme> armes = new List<Arme>();

            foreach (string dir in Directory.GetDirectories(path))
            {
                string cat = new DirectoryInfo(dir).Name;
                categories.Add(cat);
                foreach (string file in Directory.GetFiles(dir, "*.html"))
                {
                    HtmlDocument doc = this.OpenHtmlFromFile(file);
                    HtmlNodeCollection DataNodes = this.SelectItemDataNodes(doc);

                    foreach (HtmlNode node in DataNodes)
                    {
                        DofusItem.DofusItem dofus_item = new DofusItem.DofusItem()
                        {
                            Label = GetItemLabel(node),
                            Description = GetItemDescription(node),
                            Level = GetItemLevel(node),
                            Effects = GetItemEffects(node)
                        };

                        if (item_type == ItemTypes.equipement.ToString() || item_type == ItemTypes.arme.ToString())
                        {
                            dofus_item.Conditions = GetItemConditions(node);

                            if (item_type == ItemTypes.arme.ToString())
                            {
                                // Assigner Caractéristique
                            }
                        }
                        logger.LogItem(dofus_item, file, node.Line);

                        if (!dofus_item.HasError)
                        {
                            if (item_type == ItemTypes.ressource.ToString())
                            {
                                Ressource res = new Ressource();
                                res.Description = dofus_item.Description;
                                res.Label = dofus_item.Label;
                                res.Level = dofus_item.Level;
                                res.RessourceEffect = GetRessourceEffects(dofus_item.Effects);
                                res.TypeRessourceName = cat;

                                ressources.Add(res);
                            }
                            else if (item_type == ItemTypes.equipement.ToString())
                            {
                                Equipement eq = new Equipement();
                                // Equipement
                                eq.Label = dofus_item.Label;
                                eq.Description = dofus_item.Description;
                                eq.Level = dofus_item.Level;
                                eq.TypeEquipementName = cat;

                                // Equipement Effects
                                eq.EffectsList = dofus_item.Effects;

                                // Equipement Condition
                                eq.ConditionsList = dofus_item.Conditions;

                                equipements.Add(eq);
                            }
                            DisplayItem(dofus_item);
                            success_count++;
                        }
                        total_count++;
                    }
                }
            }

            Injector i = new Injector();

            if (item_type == ItemTypes.ressource.ToString())
            {
                i.InjectRessources(ressources, categories);
            }
            else if (item_type == ItemTypes.equipement.ToString())
            {
                i.InjectEquipements(equipements, categories);
            }

            Console.WriteLine($"{success_count} elements imported.");
            Console.WriteLine($"{(total_count - success_count)} elements NOT imported due to errors. (see '/Downloads/squidspy_log.txt')");
            Console.WriteLine();

            logger.LogCategories(categories);

            logger.EndLogging();
        }

        private HtmlNodeCollection SelectItemDataNodes(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectNodes("/html/body/div[@id=\"body\"]/div[@id=\"table\"]/div[@id=\"main\"]/div[position()>1]");
        }

        private string GetItemLabel(HtmlNode node)
        {
            string label = node.SelectSingleNode("div/table/tr/td/table/tr/td/div[1]")?.InnerText;

            if (String.IsNullOrWhiteSpace(label))
            {
                label = node.SelectSingleNode(".//div/tr/td/table/tr/td/div[1]")?.InnerText;
            }

            return WebUtility.HtmlDecode(label.Trim());
        }

        private int GetItemLevel(HtmlNode node)
        {
            string level = node.SelectSingleNode("div/table/tr/td/table/tr/td/div[3]")?.InnerText;

            if (String.IsNullOrWhiteSpace(level))
            {
                level = node.SelectSingleNode(".//div/tr/td/table/tr/td/div[3]")?.InnerText;
            }

            if (String.IsNullOrEmpty(level))
            {
                level = node.SelectSingleNode(".//div/tr/td/table/tr/td/div[last()]")?.InnerText;
            }

            int returnValue;
            Int32.TryParse(StringHelper.CleanLevelString(WebUtility.HtmlDecode(level.Trim())), out returnValue);

            return returnValue;
        }

        private string GetItemDescription(HtmlNode node)
        {
            string desc = node.SelectSingleNode("div/table/tr/td/table/tr[5]")?.InnerText;

            if (String.IsNullOrWhiteSpace(desc))
            {
                desc = node.SelectSingleNode(".//div/tr/td/table/tr[5]")?.InnerText;
            }

            return WebUtility.HtmlDecode(desc.Trim());
        }

        private List<string> GetItemEffects(HtmlNode node)
        {
            HtmlNodeCollection effectsNodes = node.SelectNodes("div/table/tr/td/table/tr/td/div[1]/table/tr[position() != 1 and position() != last()]");

            if (effectsNodes == null || effectsNodes.Count == 0)
            {
                effectsNodes = node.SelectNodes(".//div/tr/td/table/tr/td/div[1]/table/tr[position() != 1 and position() != last()]");
            }

            if (effectsNodes == null || effectsNodes.Count == 0)
            {
                return new List<string>();
            }

            List<string> effects = new List<string>();

            foreach (HtmlNode effectNode in effectsNodes)
            {
                string cleanEffect = WebUtility.HtmlDecode(effectNode.SelectSingleNode("td").InnerText.Trim());

                if (!String.IsNullOrWhiteSpace(cleanEffect))
                {
                    effects.Add(cleanEffect);
                }
            }

            return effects;
        }

        private List<string> GetItemConditions(HtmlNode node)
        {
            HtmlNodeCollection ConditionsNodes = node.SelectNodes("div/table/tr/td/table/tr/td/div[2]/table/tr[position() != 1 and position() != last()]");

            if (ConditionsNodes == null || ConditionsNodes.Count == 0)
            {
                ConditionsNodes = node.SelectNodes(".//div/tr/td/table/tr/td/div[2]/table/tr[position() != 1 and position() != last()]");
            }

            if (ConditionsNodes == null || ConditionsNodes.Count == 0)
            {
                return new List<string>();
            }

            List<string> conditions = new List<string>();

            foreach (HtmlNode conditionNode in ConditionsNodes)
            {
                string cleanCondition = WebUtility.HtmlDecode(conditionNode.SelectSingleNode("td").InnerText.Trim());

                if (StringHelper.HasBadCondition(cleanCondition))
                {
                    cleanCondition = StringHelper.CleanCondition(cleanCondition);
                }

                if (!String.IsNullOrWhiteSpace(cleanCondition))
                {
                    conditions.Add(cleanCondition);
                }
            }

            return conditions;
        }

        private ICollection<RessourceEffect> GetRessourceEffects(List<string> effects)
        {
            if (effects.Any())
            {
                List<RessourceEffect> reList = new List<RessourceEffect>();
                int count = 1;
                foreach (string eff in effects)
                {
                    RessourceEffect re = new RessourceEffect();
                    re.Effect = eff;
                    re.Order = count;
                    count++;

                    reList.Add(re);
                }
                return reList;
            }
            return new List<RessourceEffect>();
        }

        private void DisplayItem(DofusItem.DofusItem res)
        {
            Console.WriteLine($"{res.Label} ({res.Level})");
            Console.WriteLine(res.Description);
            Console.WriteLine("-");
            foreach (string effect in res.Effects)
            {
                Console.WriteLine($"Effet : {effect}");
            }

            if (res.Conditions != null)
            {
                if (res.Conditions.Any())
                {
                    Console.WriteLine("-");
                    foreach (string cdt in res.Conditions)
                    {
                        Console.WriteLine($"Condition : {cdt}");
                    }
                }
            }

            Console.WriteLine("--");
            Console.WriteLine();
        }
    }
}
