using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyInteraction : Interaction
{
    public KeyCode key;
    public Volcano volcano;

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
        volcano.Highlight();
    }

    public override void StopHighlightObject()
    {
        volcano.StopHighlight();
    }

    public void checkInput()
    {
        if (key == KeyCode.None) return;

        if (Input.GetKeyDown(key))
        {
            volcano.Erupt();
        }
    }

    public override List<KeyCode> GetKeys()
    {
        List<KeyCode> ret = new List<KeyCode>();
        ret.Add(key);
        return ret;
    }
}
