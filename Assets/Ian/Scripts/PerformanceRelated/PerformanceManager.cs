using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PerformanceManager : MonoBehaviour
{
    public List<Performance> AllPerformance;
    public Performance nextPerformance;

    public int selectedBoxId;
    public List<List<KeyCode>> selectedBoxKeyGroups = new List<List<KeyCode>>();

    [Header("UIReferences")]
    public GameObject InfoUI;
    public TMP_Text audience;
    public TMP_Text desc;
    public TMP_Text time;

    [Space(5f)]
    public SocialMediaManager socialMediaManager;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (Services.performanceManager == null) Services.performanceManager = this;
        else Destroy(this.gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
    }

    // update the performance info ui to be about the upcoming performance
    public void UpdatePerformanceInfo()
    {
        audience.text = nextPerformance.audience;
        desc.text = nextPerformance.audienceDescription;
        time.text = nextPerformance.timeLimit.ToString() + " seconds";
    }

    // start the next performance
    public void StartPerformance()
    {
        // save the selected box id
        selectedBoxId = Services.boxManager.currentBox.id;

        // save the selected box input group
        List<List<KeyCode>> _keygroups = Services.boxManager.currentBox.GetKeyGroups();
        selectedBoxKeyGroups.Clear();
        for (int i=0; i<_keygroups.Count; i++)
        {
            selectedBoxKeyGroups.Add(_keygroups[i]);
        }

        // hide the performance info ui
        HideInfo();
        socialMediaManager.HideFollowerUI();

        // load the performance scene
        string sceneName = nextPerformance.sceneName;
        SceneManager.LoadScene(sceneName);
    }

    public void HideInfo()
    {
        InfoUI.SetActive(false);
    }

    public void ShowInfo()
    {
        InfoUI.SetActive(true);
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "MoonHe")
        {
            ShowInfo();
            socialMediaManager.DisplayFollowerUI();
        }
    }
}
