using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignInputManager : MonoBehaviour
{
    public LayerMask inputBoxLayer;
    public LayerMask keyLayer;
    public Transform panelTransform;

    public List<KeyMaterial> keyMats = new List<KeyMaterial>();

    // current hoverbox
    private GameObject hoverObject;

    // current box variables
    private GameObject currentBox;
    private Vector3 currentOffset;
    private float currentZ;
    private float localZ;

    private Plane plane;

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
        // parent the button and save default states

        //savedPos = box.transform.position;
        //savedRot = box.transform.eulerAngles;

        box.transform.Rotate(-75f - box.transform.eulerAngles.x, 0f - box.transform.eulerAngles.y, 0f, Space.Self);
        box.transform.SetParent(panelTransform, true);
        Vector3 localPos = box.transform.localPosition;
        box.transform.localPosition = new Vector3(localPos.x, 0.97f, localPos.z);
        box.transform.localEulerAngles = Vector3.zero;
        

        currentBox = box;
        currentZ = Camera.main.WorldToScreenPoint(box.transform.position).z;
        localZ = box.transform.localPosition.y;
        //localZ = box.transform.localPosition.z;
        currentOffset = GetMouseWorldPos() - box.transform.position;
        
        //currentOffset.z = 0f;
        prepRayMethod();

        for (int i=0; i<currentBox.transform.GetChild(1).childCount; i++)
        {
            currentBox.transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().material = getMat("none");
        }
        updateColors();
        currentBox.GetComponent<Interaction>().StopButtonAnim();
    }

    private void moveCurrentBox()
    {
        Vector3 newPos = GetMouseWorldPos() - currentOffset;
        //Vector3 newPos = GetMouseWorldPos();
        currentBox.transform.position = newPos;
        //Vector3 mouseWP = GetMouseWorldPos();
        //currentBox.transform.position = new Vector3(mouseWP.x, mouseWP.y, 0f);

        Vector3 localAdjust = currentBox.transform.localPosition;
        //currentBox.transform.localPosition = new Vector3(localAdjust.x, localZ, localAdjust.z);
        //currentBox.transform.localPosition = new Vector3(localAdjust.x, localAdjust.y, localZ);


        Ray r = new Ray(currentBox.transform.position, Vector3.forward);
        float d;
        plane.Raycast(r, out d);
        Debug.Log("d: " + d);
        currentBox.transform.position += Vector3.forward * d;


        //currentBox.transform.position = new Vector3(newPos.x, newPos.y, currentBox.transform.position.z);

        //rayMethod();
        //reverseScreenPointMethod();

    }

    private void releaseCurrentBox()
    {
        if (!SnapCurrentBox())
        {
            currentBox.transform.SetParent(null);
            currentBox.transform.position = currentBox.GetComponent<Interaction>().GetDefaultPos();
            currentBox.transform.eulerAngles = currentBox.GetComponent<Interaction>().GetDefaultRot();
        }

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
            if (Physics.Raycast(rayChild.position - rayChild.forward * 10f, rayChild.forward, out hit, Mathf.Infinity, keyLayer))
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
            for (int i=0; i<keys.Count; i++)
            {
                string key = keys[i];
                if (key.Equals("up")) keyCodes.Add(KeyCode.UpArrow);
                else if (key.Equals("down")) keyCodes.Add(KeyCode.DownArrow);
                else if (key.Equals("left")) keyCodes.Add(KeyCode.LeftArrow);
                else if (key.Equals("right")) keyCodes.Add(KeyCode.RightArrow);
                else if (key.Equals("")) keyCodes.Add(KeyCode.None);
                else keyCodes.Add((KeyCode)(int)key[0]);

                Material m = getMat(key);
                currentBox.transform.GetChild(1).GetChild(i).gameObject.GetComponent<MeshRenderer>().material = m;
            }
            updateColors();
            currentBox.GetComponent<Interaction>().PlayButtonAnim();
            currentBox.GetComponent<Interaction>().AssignKeys(keyCodes);
            //snapped = true;
            return true;
        }
        else
        {
            List<KeyCode> keyCodes = new List<KeyCode>();
            for (int i = 0; i < currentBox.transform.GetChild(0).childCount; i++)
            {
                keyCodes.Add(KeyCode.None);
            }

            currentBox.GetComponent<Interaction>().AssignKeys(keyCodes);
            //snapped = false;
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
        //screenPoint.z = currentZ;
        screenPoint.z = Camera.main.WorldToScreenPoint(currentBox.transform.position).z;
        return Camera.main.ScreenToWorldPoint(screenPoint);
    }


    private void prepRayMethod()
    {
        plane = new Plane(-currentBox.transform.up, currentBox.transform.position);
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        plane.Raycast(r, out planeDist);

        //currentOffset = currentBox.transform.position - r.GetPoint(planeDist);
    }

    private void rayMethod()
    {
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);

        float planeDist;
        plane.Raycast(r, out planeDist);
        currentBox.transform.position = r.GetPoint(planeDist) + currentOffset;
    }

    private void reverseScreenPointMethod()
    {
        Vector3 mouseScreenPos = Input.mousePosition;
        mouseScreenPos.z = 0f;

        Vector3 objScreenPos = Camera.main.WorldToScreenPoint(currentBox.transform.position);

        Debug.Log(mouseScreenPos.ToString() +", " +objScreenPos.ToString());

        bool xGood = false;
        bool yGood = false;

        while (!xGood || !yGood)
        {
            objScreenPos = Camera.main.WorldToScreenPoint(currentBox.transform.position);
            
            // x
            if (Mathf.Abs(mouseScreenPos.x - objScreenPos.x) < 10f)
            {
                // good
                xGood = true;
            }
            else if (objScreenPos.x < mouseScreenPos.x)
            {
                currentBox.transform.localPosition += Vector3.right * 0.02f;
            }
            else
            {
                currentBox.transform.localPosition -= Vector3.right * 0.02f;
            }

            // y
            if (Mathf.Abs(mouseScreenPos.y - objScreenPos.y) < 10f)
            {
                // good
                yGood = true;
            }
            else if (objScreenPos.y < mouseScreenPos.y)
            {
                currentBox.transform.localPosition += Vector3.forward * 0.02f;
            }
            else
            {
                currentBox.transform.localPosition -= Vector3.forward * 0.02f;
            }
        }
    }

    private Material getMat(string key)
    {
        for (int i=0; i<keyMats.Count; i++)
        {
            if (keyMats[i].key.Equals(key))
            {
                return keyMats[i].mat;
            }
        }

        return null;
    }

    private void updateColors()
    {
        for (int i=0; i<currentBox.transform.GetChild(1).childCount; i++)
        {
            Color c = currentBox.GetComponent<Interaction>().GetButtonColor();
            currentBox.transform.GetChild(1).GetChild(i).GetComponent<MeshRenderer>().material.SetColor("_BaseColor", c);
        }
    }
}

[System.Serializable]
public struct KeyMaterial
{
    public string key;
    public Material mat;
}
