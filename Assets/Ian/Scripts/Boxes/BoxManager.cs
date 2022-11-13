using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    public List<Box> AllBoxes = new List<Box>();
    public Vector3 StagePosition;
    public Vector3[] ShelfPositions;

    private Box currentBox;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            HideCurrentMusicBox();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ShowMusicBox(1);
        }
    }

    public void ShowMusicBox(int boxID)
    {
        Box box = null;
        foreach (Box b in AllBoxes)
        {
            if (b.id == boxID)
            {
                box = b;
                break;
            }
        }

        if (box == null)
        {
            Debug.LogWarning("no music box with id: " + boxID + " is found");
            return;
        }

        
        // hide previous box first
        if (currentBox != null)
        {
            currentBox.HideUI();
            int index = currentBox.id - 1;
            currentBox.gameObject.transform.position = ShelfPositions[index];
        }
        // then show box
        box.gameObject.transform.position = StagePosition;
        box.ShowUI();

        currentBox = box;
    }

    public void HideCurrentMusicBox()
    {
        if (currentBox != null)
        {
            currentBox.HideUI();
            int index = currentBox.id - 1;
            currentBox.gameObject.transform.position = ShelfPositions[index];
            currentBox = null;
        }
    }
}
