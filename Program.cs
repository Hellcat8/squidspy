using System;
using squidspy.Core;
using HtmlAgilityPack;

namespace squidspy
{
    class Program
    {
        const string _RESSOURCESDIR = "/Users/amine/Downloads/Dofus Retro HTML files - Internet Archive/ressources/";

        static void Main(string[] args)
        {
            //string path = "/Users/amine/Downloads/Dofus Retro HTML files - Internet Archive/ressources/potion de forgemagie/";
            //string path = "/Users/amine/Downloads/potion_1.html";

            Spy spy = new Spy();

            spy.ImportRessources(_RESSOURCESDIR);
        }
    }
}
