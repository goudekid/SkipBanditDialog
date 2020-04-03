using HarmonyLib;
using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.GameMenus;
using TaleWorlds.Core;

namespace SkipBanditDialog
{
    [HarmonyPatch(typeof(PlayerEncounter), "DoMeetingInternal")]
    public class SkipBanditDialogPatch
    {
        [HarmonyPrefix]
        static bool DoMeetingPrefix(PlayerEncounter __instance, PartyBase ____encounteredParty, 
            ref bool ____stateHandled, PartyBase ____defenderParty, ref bool ____meetingDone)
        {
            try
            {
                if (BanditToggle.SkipDialog && ____encounteredParty != null && ____encounteredParty.IsMobile)
                {
                    var party = ____encounteredParty.MobileParty;

                    if (party != null && party.IsBandit && !party.IsLordParty && !party.IsBanditBossParty && !party.IsCurrentlyUsedByAQuest)
                    {

                        Campaign.Current.CurrentConversationContext = ConversationContext.PartyEncounter;
                        Traverse.Create(__instance).Property<PlayerEncounterState>("EncounterState").Value = PlayerEncounterState.Begin;
                        ____stateHandled = true;
                        var _defenderParty = ____defenderParty;
                        if (PlayerEncounter.PlayerIsAttacker && _defenderParty.IsMobile && _defenderParty.MobileParty.Army != null && _defenderParty.MobileParty.Army.LeaderParty == _defenderParty.MobileParty && _defenderParty.MobileParty.Army.LeaderParty.MapFaction == MobileParty.MainParty.MapFaction && !_defenderParty.MobileParty.Army.LeaderParty.AttachedParties.Contains(MobileParty.MainParty))
                        {
                            GameMenu.SwitchToMenu("army_encounter");
                            return false;
                        }
                        ____meetingDone = true;
                        GameMenu.SwitchToMenu("army_encounter");

                        return false;
                    }
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