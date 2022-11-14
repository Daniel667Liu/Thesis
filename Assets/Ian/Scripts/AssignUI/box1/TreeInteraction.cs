using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeInteraction : Interaction
{
    public List<KeyCode> keys = new List<KeyCode>();
    public AppleTree tree;

    private int prevInd;

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

    public override void AssignKeys(List<KeyCode> _keys)
    {
        keys = _keys;
    }

    public override void HighlightObject()
    {
        tree.Highlight();
    }

    public override void StopHighlightObject()
    {
        tree.StopHighlight();
    }

    public void checkInput()
    {
        if (keys.Count < 2) return;

        if (Input.GetKeyDown(keys[0]))
        {
            if (prevInd == 1) tree.Shake();
            prevInd = 0;
        }
        else if (Input.GetKeyDown(keys[1]))
        {
            if (prevInd == 0) tree.Shake();
            prevInd = 1;
        }
    }
}
