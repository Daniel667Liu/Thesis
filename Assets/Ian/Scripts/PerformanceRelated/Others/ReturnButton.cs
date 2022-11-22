using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnButton : MonoBehaviour
{
    public string mainSceneName;

    public void ReturnToMainScene()
    {
        SceneManager.LoadScene(mainSceneName);
    }
}
