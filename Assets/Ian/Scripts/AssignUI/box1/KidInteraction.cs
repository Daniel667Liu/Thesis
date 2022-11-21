using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidInteraction : Interaction
{
    public KeyCode key;
    public Kid kid;

    // Start is called before the first frame update
    void Start()
    {
        
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
}
