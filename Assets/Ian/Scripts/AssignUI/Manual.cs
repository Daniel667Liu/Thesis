using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual : MonoBehaviour
{
    public bool shown;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if (anim == null) anim = transform.GetChild(0).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.U))
        {
            ManualUp();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ManualDown();
        }*/
        /*if (Input.GetKeyDown(KeyCode.G))
        {
            GetAllKeys();
        }*/
    }

    public void ManualDown()
    {
        anim.SetFloat("speed", 1f);
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.01f)
        {
            anim.Play("down", 0, 0f);
        }

        shown = false;
    }

    public void ManualUp()
    {
        anim.SetFloat("speed", -1f);
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.99f)
        {
            anim.Play("down", 0, 1f);
        }

        shown = true;
    }

    public void StartAnim()
    {
        if (anim == null) anim = GetComponent<Animator>();
        anim.SetTrigger("start");
        anim.SetFloat("speed", 0f);
    }

    public void ResetAnim()
    {
        if (anim == null) anim = GetComponent<Animator>();
        anim.SetTrigger("reset");
        anim.SetFloat("speed", 0f);
    }

    public List<List<KeyCode>> GetAllKeys()
    {
        List<List<KeyCode>> keyGroups = new List<List<KeyCode>>();

        for (int i=0; i<transform.GetChild(0).childCount; i++)
        {
            GameObject g = transform.GetChild(0).GetChild(i).gameObject;
            if (g.TryGetComponent(out Interaction interaction))
            {
                List<KeyCode> keys = interaction.GetKeys();
                keyGroups.Add(keys);
            }
        }

        // debug
        foreach (List<KeyCode> keys in keyGroups)
        {
            string s = "";
            foreach (KeyCode k in keys)
            {
                s += k.ToString() + ", ";
            }
            Debug.Log(s);
        }

        return keyGroups;
    }

    public void AssignAllKeys(List<List<KeyCode>> keyGroups)
    {
        int counter = 0;
        for (int i = 0; i < transform.GetChild(0).childCount; i++)
        {
            GameObject g = transform.GetChild(0).GetChild(i).gameObject;
            if (g.TryGetComponent(out Interaction interaction))
            {
                interaction.AssignKeys(keyGroups[counter]);
                counter++;
            }
        }
    }
}
