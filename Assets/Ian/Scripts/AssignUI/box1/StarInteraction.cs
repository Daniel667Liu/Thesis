using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInteraction : Interaction
{
    public List<KeyCode> keys = new List<KeyCode>(3);
    public StarParent starParent;

    private Color buttonColor;
    private Vector3 defaultPos;
    private Vector3 defaultRot;

    private int prevInd;
    private int accum;

    // Start is called before the first frame update
    void Start()
    {
        buttonColor = transform.GetChild(1).GetChild(0).GetComponent<MeshRenderer>().material.GetColor("_BaseColor");
        defaultPos = transform.position;
        defaultRot = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        //TODO?: if box is not active, return

        checkInput();
    }

    public override void AssignKeys(List<KeyCode> _keys)
    {
        keys = _keys;
    }

    public override void HighlightObject()
    {
        starParent.Highlight();
    }

    public override void StopHighlightObject()
    {
        starParent.StopHighlight();
    }

    private void checkInput()
    {
        if (keys.Count < 3) return;

        int currentInd = -1;
        if (Input.GetKeyDown(keys[0]))
        {
            currentInd = 0;
        }
        else if (Input.GetKeyDown(keys[1]))
        {
            currentInd = 1;
        }
        else if (Input.GetKeyDown(keys[2]))
        {
            currentInd = 2;
        }

        if (currentInd == -1) return;
        if (currentInd - prevInd == -1)
        {
            accum++;
            if (accum == 2)
            {
                starParent.ShootStar();
            }
        }
        else
        {
            accum = 0;
        }
        prevInd = currentInd;
    }

    public override List<KeyCode> GetKeys()
    {
        List<KeyCode> ret = new List<KeyCode>();
        for (int i=0; i<keys.Count; i++)
        {
            ret.Add(keys[i]);
        }
        return ret;
    }

    public override Color GetButtonColor()
    {
        return buttonColor;
    }

    public override Vector3 GetDefaultPos()
    {
        return defaultPos;
    }

    public override Vector3 GetDefaultRot()
    {
        return defaultRot;
    }
}
