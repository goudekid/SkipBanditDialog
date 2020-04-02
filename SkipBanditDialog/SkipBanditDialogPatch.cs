using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;

namespace SkipBanditDialog
{
    [HarmonyPatch(typeof(ConversationManager), "SetupAndStartMapConversation")]
    public class SkipBanditDialogPatch
    {
        [HarmonyPrefix]
        static bool SetupDialogPostfix(ConversationManager __instance, MobileParty party, IAgent agent, IAgent mainAgent)
        {
            if (party.IsBandit && !party.IsLordParty && !party.IsBanditBossParty && !party.IsCurrentlyUsedByAQuest)
            {
                return false;
            }

            return true;
        }
    }
}