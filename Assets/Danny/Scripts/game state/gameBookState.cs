using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameBookState : gameBaseState
{
    public override void EnterState(GameStateManager stateManager)
    {
        stateManager.cameraManager.TransitToBook();
        //stateManager.DisableInteraction();
        stateManager.EnableInteraction();
    }

    public override void UpdateState(GameStateManager stateManager)
    {

    }

    public override void ExitState(GameStateManager stateManager)
    {

    }
}
