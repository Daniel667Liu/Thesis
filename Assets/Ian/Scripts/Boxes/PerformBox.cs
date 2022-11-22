using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformBox : MonoBehaviour
{
    public int id;

    private GameObject manual;

    private void Start()
    {
        manual = transform.GetChild(1).gameObject;

    }

    public void AssignAllKeys(List<List<KeyCode>> keyGroups)
    {
        manual.GetComponent<Manual>().AssignAllKeys(keyGroups);
    }

    public void DisableInput()
    {
        manual.SetActive(false);
    }

    public void EnableInput()
    {
        manual.SetActive(true);
    }
}
