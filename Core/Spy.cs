using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;
using squidspy.DofusItem;

namespace squidspy.Core
{
    public class Spy
    {
        #region Common
        public Spy() {}

        private HtmlDocument OpenHtmlFromFile(string path)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(path);

            return doc;
        }
        #endregion

        #region Ressources
        public void ImportRessources(string path)
        {
            Logger logger = new Logger();
            logger.StartLogging("Ressources");
            int success_count = 0;
            int total_count = 0;

            foreach (string dir in Directory.GetDirectories(path))
            {
                foreach (string file in Directory.GetFiles(dir, "*.html"))
                {
                    HtmlDocument doc = this.OpenHtmlFromFile(file);
                    HtmlNodeCollection DataNodes = this.SelectRessourceDataNodes(doc);

                    foreach (HtmlNode node in DataNodes)
                    {
                        Ressource res = new Ressource()
                        {
                            Label = GetRessourceLabel(node),
                            Description = GetRessourceDescription(node),
                            Level = GetRessourceLevel(node),
                            Effects = GetRessourceEffects(node)
                        };
                        logger.LogRessource(res, file, node.Line);

                        if (!res.HasError)
                        {
                            DisplayRessource(res);
                            success_count++;
                        }
                        total_count++;
                    }
                }
            }
            Console.WriteLine($"{success_count} elements imported.");
            Console.WriteLine($"{(total_count - success_count)} elements NOT imported due to errors. (see '/Downloads/squidspy_log.txt')");
            logger.EndLogging();
        }

        private HtmlNodeCollection SelectRessourceDataNodes(HtmlDocument doc)
        {
            return doc.DocumentNode.SelectNodes("/html/body/div[@id=\"body\"]/div[@id=\"table\"]/div[@id=\"main\"]/div[position()>1]");
        }

        private string GetRessourceLabel(HtmlNode node)
        {
            string label = node.SelectSingleNode("div/table/tr/td/table/tr/td/div[1]")?.InnerText;

            if (String.IsNullOrWhiteSpace(label))
            {
                label = node.SelectSingleNode(".//div/tr/td/table/tr/td/div[1]")?.InnerText;
            }

            return label;
        }

        private string GetRessourceLevel(HtmlNode node)
        {
            string level = node.SelectSingleNode("div/table/tr/td/table/tr/td/div[3]")?.InnerText;

            if (String.IsNullOrWhiteSpace(level))
            {
                level = node.SelectSingleNode(".//div/tr/td/table/tr/td/div[3]")?.InnerText;
            }

            return level;
        }

        private string GetRessourceDescription(HtmlNode node)
        {
            string desc = node.SelectSingleNode("div/table/tr/td/table/tr[5]")?.InnerText;

            if (String.IsNullOrWhiteSpace(desc))
            {
                desc = node.SelectSingleNode(".//div/tr/td/table/tr[5]")?.InnerText;
            }

            return desc.Trim();
        }

        private List<string> GetRessourceEffects(HtmlNode node)
        {
            HtmlNodeCollection effectsNodes = node.SelectNodes("div/table/tr/td/table/tr/td/div/table/tr[position() != 1 and position() != last()]");

            if (effectsNodes == null || effectsNodes.Count == 0)
            {
                effectsNodes = node.SelectNodes(".//div/tr/td/table/tr/td/div/table/tr[position() != 1 and position() != last()]");
            }

            if (effectsNodes == null || effectsNodes.Count == 0)
            {
                return new List<string>();
            }

            List<string> effects = new List<string>();

            foreach (HtmlNode effectNode in effectsNodes)
            {
                string cleanEffect = StringHelper.CleanString(effectNode.SelectSingleNode("td").InnerText);

                if (!String.IsNullOrWhiteSpace(cleanEffect))
                {
                    effects.Add(cleanEffect);
                }
            }

            return effects;
        }

        private void DisplayRessource(Ressource res)
        {
            Console.WriteLine($"{res.Label} ({res.Level})");
            Console.WriteLine(res.Description);
            Console.WriteLine("-");
            foreach (string effect in res.Effects)
            {
                Console.WriteLine($"Effet : {effect}");
            }
            Console.WriteLine("--");
            Console.WriteLine();
        }

        private void SaveRessource(Ressource res)
        {
            // INSERT Ressource INTO DATABASE
        }
        #endregion
    }
}
