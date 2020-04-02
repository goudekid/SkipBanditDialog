using HarmonyLib;
using System;
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
            try
            {
                FileLog.Reset();

                if (party != null && party.IsBandit && !party.IsLordParty && !party.IsBanditBossParty && !party.IsCurrentlyUsedByAQuest 
                    && agent != null && agent.Character != null && !agent.Character.IsHero && !agent.Character.StringId.Contains("tutorial"))
                {
                    return false;
                }

                return true;
            }
            catch(Exception ex)
            {
                FileLogExtension.Log("EXCEPTION OCCURED: " + ex.Message);
                return true;
            }
        }
    }
}