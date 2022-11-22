using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    public float timer;
    private TMP_Text txt;

    private bool started;

    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            timer -= Time.deltaTime;
            txt.text = Mathf.RoundToInt(timer + 0.5f).ToString();
            if (timer <= -1f) transform.parent.gameObject.SetActive(false);
        }
    }

    public void StartCountdown()
    {
        started = true;
    }
}
