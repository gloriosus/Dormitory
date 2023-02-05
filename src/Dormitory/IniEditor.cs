using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Dormitory
{
    class IniEditor
    {
        public void InsertParametr(string path, string section, string parametr, string value)
        {
            string[] lines = File.ReadAllLines(path);

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(section))
                {
                    for (int v = i + 1; v < lines.Length; v++)
                    {
                        if (lines[v].Contains(parametr))
                        {
                            lines[v] = parametr + "=" + value;
                            break;
                        }
                    }
                    break;
                }
            }

            File.WriteAllLines(path, lines);
        }

        public string GetValue(string path, string section, string parametr)
        {
            string[] lines = File.ReadAllLines(path);
            string result = "";

            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Contains(section))
                {
                    for (int v = i + 1; v < lines.Length; v++)
                    {
                        if (lines[v].Contains(parametr))
                        {
                            result = lines[v].Split('=')[1];
                            break;
                        }
                    }
                    break;
                }
            }

            return result;
        }
    }
}
