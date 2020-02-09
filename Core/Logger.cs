using System;
using System.Collections.Generic;
using System.IO;
using squidspy.DofusItem;

namespace squidspy.Core
{
    public class Logger
    {
        const string _TOPBORDER = "***********************************";
        const string _BOTBORDER = "___________________________________";
        const string _SUBBORDER = "_________";
        string _path = "/Users/amine/Downloads/squidspy_log.txt";
        StreamWriter _logfile;
        int _countRessourcesErrors = 0;

        public Logger()
        {
            EraseContent();
            OpenStream();
        }

        private void OpenStream()
        {
            _logfile = new StreamWriter(_path);
        }

        private void CloseStream()
        {
            _logfile.Flush();
            _logfile.Close();
            _logfile.Dispose();
        }

        private void EraseContent()
        {
            File.WriteAllText(_path, String.Empty);
        }

        public void StartLogging(string category)
        {
            _logfile.WriteLine(_TOPBORDER);
            _logfile.WriteLine($"****** {category.ToUpper()} ******");
            _logfile.WriteLine(_TOPBORDER);
        }

        public void WriteFooter()
        {
            _logfile.WriteLine(_logfile.NewLine);
            _logfile.WriteLine(_TOPBORDER);
        }

        public void LogItem(DofusItem.DofusItem dofus_item, string path, int line)
        {
            string propError = String.Empty;

            if (String.IsNullOrEmpty(dofus_item.Label) || StringHelper.HasUnwantedString(dofus_item.Label))
            {
                propError = "LABEL";
            }

            if (dofus_item.Level == 0)
            {
                propError = "LEVEL";
            }

            if (String.IsNullOrEmpty(dofus_item.Description) || StringHelper.HasUnwantedString(dofus_item.Description))
            {
                propError = "DESCRIPTION";
            }

            foreach (string effect in dofus_item.Effects)
            {
                if (String.IsNullOrEmpty(effect) || StringHelper.HasUnwantedString(effect))
                {
                    propError = "EFFECT";
                    break;
                }
            }

            if (dofus_item.Conditions != null && dofus_item.Conditions.Count > 0)
            {
                foreach (string condition in dofus_item.Conditions)
                {
                    if (String.IsNullOrEmpty(condition) || StringHelper.HasBadCondition(condition))
                    {
                        propError = "CONDITION";
                        break;
                    }
                }
            }

            string reason;

            if (HasDataError(dofus_item.Description, out reason))
            {
                propError = "EXCLUDED";
            }

            if (NeedsVerification(dofus_item.Label) || Verify(dofus_item))
            {
                propError = "NEEDS VERIFICATION";
            }

            if (!String.IsNullOrEmpty(propError))
            {
                dofus_item.HasError = true;
                _countRessourcesErrors++;
                _logfile.WriteLine(_SUBBORDER);
                _logfile.WriteLine($"Error : {propError}.");
                if (propError == "EXCLUDED") { _logfile.WriteLine($"Reason : {reason}."); }
                _logfile.WriteLine($"File : {path}.");
                _logfile.WriteLine($"Line : {line}.");
                _logfile.WriteLine($"Label : {dofus_item.Label}");
                _logfile.WriteLine($"Level : {dofus_item.Level}");
                _logfile.WriteLine($"Description : {dofus_item.Description}");
                _logfile.WriteLine($"Effects : " + (dofus_item.Effects.Count > 0 ? "" : "None."));

                foreach (string effect in dofus_item.Effects)
                {
                    _logfile.WriteLine($"\t{effect}");
                }

                if (dofus_item.Conditions != null && dofus_item.Conditions.Count > 0)
                {
                    _logfile.WriteLine($"Conditions :");
                    foreach (string c in dofus_item.Conditions)
                    {
                        _logfile.WriteLine($"\t{c}");
                    }
                }
                
                _logfile.WriteLine(_BOTBORDER); 
                _logfile.WriteLine(_logfile.NewLine);
            }
        }

        public void LogCategories(List<string> categories)
        {
            _logfile.WriteLine(_SUBBORDER);
            _logfile.WriteLine("CATEGORIES :");

            foreach (string s in categories)
            {
                _logfile.WriteLine(s);
            }
            _logfile.WriteLine(_SUBBORDER);
        }

        public void EndLogging()
        {
            _logfile.WriteLine(_logfile.NewLine);
            _logfile.WriteLine($"{_countRessourcesErrors} error(s) occurred.");

            this.CloseStream();
        }

        public bool HasDataError(string data, out string reason)
        {
            if (data.Equals("..."))
            {
                reason = "Description equals \"...\"";
                return true;
            }
            reason = String.Empty;
            return false;
        }

        public bool NeedsVerification(string label)
        {
            List<string> items = new List<string>()
            {
                "le nom de l'item a check"
            };

            foreach (string s in items)
            {
                if (label.Equals(s))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Verify(DofusItem.DofusItem di)
        {
            foreach (string eff in di.Effects)
            {
                if (eff.ToLower().Contains("cequejeveux"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
