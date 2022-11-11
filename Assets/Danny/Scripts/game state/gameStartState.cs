using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// this is the state for the main menu (which includes the game start UI)
public class gameStartState :gameBaseState
{
    public override void EnterState(GameStateManager stateManager)
    {
        stateManager.cameraManager.TransitToStart();
        stateManager.DisableInteraction();
        stateManager.gameStartUI.SetActive(true);
        stateManager.hamburgerUI.SetActive(false);
    }
    public override void UpdateState(GameStateManager stateManager)
    {
        
    }

    public override void ExitState(GameStateManager stateManager)
    {
        stateManager.gameStartUI.SetActive(false);
        stateManager.hamburgerUI.SetActive(true);
    }
}
