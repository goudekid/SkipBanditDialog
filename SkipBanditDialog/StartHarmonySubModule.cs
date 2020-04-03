using TaleWorlds.MountAndBlade;
using HarmonyLib;
using TaleWorlds.Core;

namespace SkipBanditDialog
{
    internal class StartHarmonySubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            var harmony = new Harmony("com.goog.bannerlordmods.skipbanditdialog");
            harmony.PatchAll();
            FileLog.Reset();
            base.OnSubModuleLoad();
        }

        
    }

    public class BanditToggle
    {
        public static bool SkipDialog = true;
    }
}
