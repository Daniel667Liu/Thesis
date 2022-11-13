using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireflyInteraction : Interaction
{
    public KeyCode key;
    public Firefly firefly;

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
        firefly.Highlight();
    }

    public override void StopHighlightObject()
    {
        firefly.StopHighlight();
    }

    public void checkInput()
    {
        if (key == KeyCode.None) return;

        if (Input.GetKeyDown(key))
        {
            firefly.Fly();
        }
    }
}
