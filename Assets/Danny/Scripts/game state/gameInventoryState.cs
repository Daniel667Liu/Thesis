using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//this is the state when player is browsing the inventory of all boxes
public class gameInventoryState : gameBaseState
{
    public override void EnterState(GameStateManager stateManager)
    {
        stateManager.cameraManager.TransitToInventory();
        stateManager.DisableInteraction();
        
    }
    public override void UpdateState(GameStateManager stateManager)
    {
        
    }

    public override void ExitState(GameStateManager stateManager)
    {
        
        
    }
}
