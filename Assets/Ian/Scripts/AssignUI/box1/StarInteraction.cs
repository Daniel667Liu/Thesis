using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarInteraction : Interaction
{
    public List<KeyCode> keys = new List<KeyCode>(3);
    public StarParent starParent;

    private int prevInd;
    private int accum;

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
}
