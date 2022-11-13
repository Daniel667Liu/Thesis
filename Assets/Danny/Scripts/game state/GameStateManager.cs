using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameStateManager : MonoBehaviour
{



    //get the reference of every game states
    gameBaseState lastState;
    gameBaseState currentState;
    gameStartState gameStartState = new gameStartState();
    gameIngameState gameIngameState = new gameIngameState();
    gameInventoryState gameInventoryState = new gameInventoryState();
    gamePrepareState gamePrepareState = new gamePrepareState();
    gameBookState gameBookState = new gameBookState();

    //declare the refrences of the objects in the scene
    [HideInInspector]
    public CameraManager cameraManager;
    public GameObject gameStartUI;
    public GameObject hamburgerUI;
    public GameObject backUI;
    public Button inventoryButton;

    //initialize the game, get all refrences
    void GameIni()
    {
        cameraManager = FindObjectOfType<CameraManager>();
        gameStartUI.SetActive(false);
        hamburgerUI.SetActive(false);
        backUI.SetActive(false);
    }


    void Start()
    {
        GameIni();

        //change current state for test
        currentState = gameStartState;
        currentState.EnterState(this);
        
    }

    // Update is called once per frame
    void Update()
    {
        
        currentState.UpdateState(this);
        Test();
    }

    public void TransitState( gameBaseState next) //used for transit into next game state
    {
        lastState = currentState;
        currentState.ExitState(this);
        next.EnterState(this);
        currentState = next;
    }

    public void BackToLastState() 
    {
        TransitState(lastState);
    }

    public void ToInGameState() 
    {
        if (currentState != gameIngameState) 
        {
            TransitState(gameIngameState);
        }
    }
    //call when click box and paper at start scene
    public void ToPrepareState() 
    {
        if (currentState != gamePrepareState)
        {
            TransitState(gamePrepareState);
        }
    }

    //call when click inventory at the start scene
    public void ToInventoryState() 
    {
        if (currentState != gameInventoryState) 
        {
            TransitState(gameInventoryState);
        }
    }

    public void ToBookState() 
    {
        if (currentState != gameBookState) 
        {
            TransitState(gameBookState);
        }
    }

    public void ToStartState() 
    {
        if (currentState != gameStartState) 
        {
            TransitState(gameStartState);
        }
    }


    public void GameRestart() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void EnableInteraction() 
    {

    }

    public void DisableInteraction() 
    {

    }


    void Test()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            ToInGameState();
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            ToPrepareState();
        }
        if (Input.GetKeyDown(KeyCode.K)) 
        {
            ToBookState();
        }
    }
}
