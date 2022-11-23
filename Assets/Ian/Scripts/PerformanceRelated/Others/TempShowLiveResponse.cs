using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TempShowLiveResponse : MonoBehaviour
{
    public GameObject tempLiveResposne;

    public void Show(string text)
    {
        GameObject r = Instantiate(tempLiveResposne);
        r.transform.position = new Vector3(Random.Range(14f, 26f), Random.Range(-5.7f, 17f), 50f);
        if (Random.Range(0f, 100f) < 50f)
        {
            r.transform.position = new Vector3(-r.transform.position.x, r.transform.position.y, r.transform.position.z);
            r.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(10f, 20f));
        }
        else
        {
            r.transform.eulerAngles = new Vector3(0f, 0f, Random.Range(-10f, -20f));
        }
        r.transform.position += new Vector3(6f, 0f, 0f);
        r.transform.GetChild(0).GetComponent<TMP_Text>().text = text;
    }
}
