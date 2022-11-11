using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this is the state when player is manupulating with the music box and recording 
public class gameIngameState : gameBaseState
{
   
    public override void EnterState(GameStateManager stateManager)
    {
        stateManager.cameraManager.TransitToIngame();
        stateManager.EnableInteraction();
       
    }
    public override void UpdateState(GameStateManager stateManager)
    {
        
    }

    public override void ExitState(GameStateManager stateManager)
    {
       
    }
}
