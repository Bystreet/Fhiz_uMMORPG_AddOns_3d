// =======================================================================================
// Created and maintained by iMMO
// Usable for both personal and commercial projects, but no sharing or re-sale
// * Discord Support Server.............: https://discord.gg/YkMbDHs
// * Public downloads website...........: https://www.indie-mmo.net
// * Pledge on Patreon for VIP AddOns...: https://www.patreon.com/IndieMMO
// * Instructions.......................: https://indie-mmo.net/knowledge-base/
// =======================================================================================
using UnityEngine;
using UnityEngine.UI;

// UCE_UI_PlaceableObjectSpawn

public partial class UCE_UI_PlaceableObjectUpgrade : MonoBehaviour
{
    public GameObject panel;
    public Button acceptButton;
    public Button declineButton;

    // -----------------------------------------------------------------------------------
    // Update
    // -----------------------------------------------------------------------------------
    private void Update()
    {
        if (!panel.activeSelf) return;

        Player player = Player.localPlayer;
        if (!player) return;

        if (player.UCE_myPlaceableObject != null && player.UCE_myPlaceableObject.ownerCharacter == player.name)
        {
            // -- Upgrade Structure
            acceptButton.onClick.SetListener(() =>
            {
                player.Cmd_UCE_StartUpgradePlaceableObject(player.UCE_myPlaceableObject.netIdentity);
                panel.SetActive(false);
            });

            // -- Cancel Upgrade Structure
            declineButton.onClick.SetListener(() =>
            {
                panel.SetActive(false);
            });
        }
        else
        {
            panel.SetActive(false);
        }
    }

    // -----------------------------------------------------------------------------------
    // Show
    // -----------------------------------------------------------------------------------
    public void Show()
    {
        panel.SetActive(true);
    }

    // -----------------------------------------------------------------------------------
}
