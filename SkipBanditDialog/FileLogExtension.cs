using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkipBanditDialog
{
    class FileLogExtension 
    {
        public static void Log(string s)
        {
            FileLog.Log(DateTime.Now.ToLocalTime().ToString() + "=>    " + s);
        }

    }
}
