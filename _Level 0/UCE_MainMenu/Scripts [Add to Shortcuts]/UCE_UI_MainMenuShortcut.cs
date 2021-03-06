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

public class UCE_UI_MainMenuShortcut : MonoBehaviour
{
    #region Variables

    public Button mainMenuButton;       //Button used for activating the main menu.
    public GameObject mainMenuPanel;    //The main menu panel that will be shown when the button is clicked.

    #endregion Variables

    #region Functions

    // Update is called once per frame

    private void Update()
    {
        //Watch for the main menu button to be clicked when it is set the main menu to active, if it's active set it to not active.
        mainMenuButton.onClick.SetListener(() =>
{
    mainMenuPanel.SetActive(!mainMenuPanel.activeSelf);
});
    }

    #endregion Functions
}
