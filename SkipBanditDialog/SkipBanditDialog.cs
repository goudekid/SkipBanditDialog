using TaleWorlds.MountAndBlade;
using HarmonyLib;

namespace SkipBanditDialog
{
    internal class SkipBanditDialog : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            var harmony = new Harmony("com.goog.bannerlordmods.skipbanditdialog");
            harmony.PatchAll();
            base.OnSubModuleLoad();
        }
    }
}
