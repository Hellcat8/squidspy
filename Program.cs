using System;
using squidspy.Core;
using HtmlAgilityPack;

namespace squidspy
{
    class Program
    {
        const string _RESSOURCESDIR = "/Users/amine/Downloads/Dofus Retro HTML files - Internet Archive/ressources/";
        const string _EQUIPEMENTDIR = "/Users/amine/Downloads/Dofus Retro HTML files - Internet Archive/equipement/";

        static void Main(string[] args)
        {
            try
            {
                Spy spy = new Spy();
                string item_type = Spy.ItemTypes.equipement.ToString();

                spy.ImportItems(_EQUIPEMENTDIR, item_type);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
