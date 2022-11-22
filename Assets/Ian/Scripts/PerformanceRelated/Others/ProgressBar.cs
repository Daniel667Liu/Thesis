using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBar : MonoBehaviour
{
    public float timer;

    private bool started;
    private float t;

    // Start is called before the first frame update
    void Start()
    {
        t = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
        {
            t += Time.deltaTime;

            // 0-timer to 0 to 1500
            float val = t * (1500f / timer);
            transform.GetChild(0).GetComponent<RectTransform>().anchoredPosition = new Vector2(-750f + val / 2, 0f);
            transform.GetChild(0).GetComponent<RectTransform>().sizeDelta = new Vector2(val, 20f);
            
            if (t > timer)
            {
                // ended
                started = false;
            }
        }
    }

    public void StartProgressBar()
    {
        started = true;
    }
}
