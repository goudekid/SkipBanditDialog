using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace SkipBanditDialog
{
    [HarmonyPatch(typeof(ViewModel), "ExecuteCommand")]
    class ExecuteCommandPatch
    {

        [HarmonyPostfix]
        public static void ExecuteCommandPostfix(string commandName)
        {
            if (commandName == "ExecuteToggleBandits")
            {
                if (BanditToggle.SkipDialog)
                {
                    BanditToggle.SkipDialog = false;
                    InformationManager.DisplayMessage(new InformationMessage("Bandit dialogs enabled"));
                }
                else
                {
                    BanditToggle.SkipDialog = true;
                    InformationManager.DisplayMessage(new InformationMessage("Bandit dialogs disabled"));
                }
            }
        }

    }
}
