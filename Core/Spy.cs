using System;
using System.Collections.Generic;
using System.IO;
using HtmlAgilityPack;
using System.Net;

namespace squidspy.Core
{
    public class Spy
    {
        public Spy() {}

        private HtmlDocument OpenHtmlFromFile(string path)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.Load(path);

            return doc;
        }

        public void ImportItem(string path, string item_type)
        {
            Logger logger = new Logger();
            logger.StartLogging(item_type);
            int success_count = 0;
            int total_count = 0;

            foreach (string dir in Directory.GetDirectories(path))
            {
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
                        logger.LogRessource(dofus_item, file, node.Line);

                        if (!dofus_item.HasError)
                        {
                            DisplayItem(dofus_item);
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

        private string GetItemLevel(HtmlNode node)
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

            return WebUtility.HtmlDecode(level.Trim());
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
                string cleanEffect = WebUtility.HtmlDecode(effectNode.SelectSingleNode("td").InnerText.Trim());

                if (!String.IsNullOrWhiteSpace(cleanEffect))
                {
                    effects.Add(cleanEffect);
                }
            }

            return effects;
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
            Console.WriteLine("--");
            Console.WriteLine();
        }

        private void SaveItem(DofusItem.DofusItem res)
        {
            // INSERT Ressource INTO DATABASE
        }
    }
}
