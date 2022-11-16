using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignInputManager : MonoBehaviour
{
    public LayerMask inputBoxLayer;
    public LayerMask keyLayer;

    // current hoverbox
    private GameObject hoverObject;

    // current box variables
    private GameObject currentBox;
    private Vector3 currentOffset;
    private float currentZ;
    private float localZ;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (transform.parent.gameObject.GetComponent<Manual>().shown == false) return;

        GameObject oldHover = hoverObject;
        hoverObject = raycast(inputBoxLayer);
        
        // highlight the object in the box
        if (oldHover != hoverObject && currentBox == null)
        {
            if (hoverObject != null) hoverObject.GetComponent<Interaction>().HighlightObject();
            if (oldHover != null) oldHover.GetComponent<Interaction>().StopHighlightObject();
        }

        if (transform.parent.parent.gameObject.GetComponent<Manual>().shown == true)
        {
            // UI drag and drop
            if (hoverObject != null)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    setCurrentBox(hoverObject);
                    hoverObject.GetComponent<Interaction>().HighlightObject();
                }
            }
            if (currentBox != null)
            {
                if (Input.GetMouseButton(0))
                {
                    moveCurrentBox();
                }
                if (Input.GetMouseButtonUp(0))
                {
                    releaseCurrentBox();
                }
            }
        }
    }

    private void setCurrentBox(GameObject box)
    {
        currentBox = box;
        currentZ = Camera.main.WorldToScreenPoint(box.transform.position).z;
        localZ = box.transform.localPosition.z;
        currentOffset = GetMouseWorldPos() - box.transform.position;
    }

    private void moveCurrentBox()
    {
        Vector3 newPos = GetMouseWorldPos() - currentOffset;
        currentBox.transform.position = newPos;

        Vector3 localAdjust = currentBox.transform.localPosition;
        currentBox.transform.localPosition = new Vector3(localAdjust.x, localAdjust.y, localZ);
    }

    private void releaseCurrentBox()
    {
        SnapCurrentBox();

        // TODO: reset currentBox to initial position if it's outside the paper

        currentBox = null;
        currentZ = 0f;
        localZ = 0f;
        currentOffset = Vector3.zero;
    }

    private bool SnapCurrentBox()
    {
        List<string> keys = new List<string>();
        Vector3 offset = Vector3.zero;

        for (int i=0; i<currentBox.transform.GetChild(0).childCount; i++)
        {
            Transform rayChild = currentBox.transform.GetChild(0).GetChild(i);
            RaycastHit hit;
            if (Physics.Raycast(rayChild.position - rayChild.forward * 2f, rayChild.forward, out hit, Mathf.Infinity, keyLayer))
            {
                Debug.Log(hit.collider.name);
                keys.Add(hit.collider.name);

                offset = rayChild.position - hit.collider.gameObject.transform.position;
            }
        }

        // success
        if (keys.Count == currentBox.transform.GetChild(0).childCount)
        {
            // snap
            currentBox.transform.position -= offset;

            List<KeyCode> keyCodes = new List<KeyCode>();
            foreach (string key in keys)
            {
                if (key.Equals("up")) keyCodes.Add(KeyCode.UpArrow);
                else if (key.Equals("down")) keyCodes.Add(KeyCode.DownArrow);
                else if (key.Equals("left")) keyCodes.Add(KeyCode.LeftArrow);
                else if (key.Equals("right")) keyCodes.Add(KeyCode.RightArrow);
                else keyCodes.Add((KeyCode)(int)key[0]);
            }
            // TODO: assign key function
            currentBox.GetComponent<Interaction>().AssignKeys(keyCodes);

            return true;
        }
        else
        {
            return false;
        }
    }

    private GameObject raycast(LayerMask layer)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer))
        {
            return hit.collider.gameObject;
        }
        else
        {
            return null;
        }
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = currentZ;
        return Camera.main.ScreenToWorldPoint(screenPoint);
    }
}
