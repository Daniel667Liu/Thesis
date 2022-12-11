using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidInteraction : Interaction
{
    public KeyCode key;
    public Kid kid;
    private Color buttonColor;
    private Vector3 defaultPos;
    private Vector3 defaultRot;

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

    public override void AssignKeys(List<KeyCode> keys)
    {
        key = keys[0];
    }

    public override void HighlightObject()
    {
        kid.Highlight();
    }

    public override void StopHighlightObject()
    {
        kid.StopHighlight();
    }

    private void checkInput()
    {
        if (key == KeyCode.None) return;

        if (Input.GetKeyDown(key))
        {
            // raise hand
            kid.RaiseHand();
        }
        else if (Input.GetKeyUp(key))
        {
            // drop hand
            kid.DropHand();
        }
    }

    public override List<KeyCode> GetKeys()
    {
        List<KeyCode> ret = new List<KeyCode>();
        ret.Add(key);
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
