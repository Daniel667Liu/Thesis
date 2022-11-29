using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerformBox : MonoBehaviour
{
    public int id;

    public GameObject manual;

    public List<EffectAttributes> effectAttributes = new List<EffectAttributes>();

    private void Awake()
    {
        manual = transform.GetChild(1).gameObject;

    }

    public void AssignAllKeys(List<List<KeyCode>> keyGroups)
    {
        Debug.Log(manual == null);
        manual.GetComponent<Manual>().AssignAllKeys(keyGroups);
    }

    public void DisableInput()
    {
        manual.SetActive(false);
    }

    public void EnableInput()
    {
        manual.SetActive(true);
    }

    public List<AttributeReq> GetAttribute(int effectID)
    {
        foreach (EffectAttributes effectA in effectAttributes)
        {
            if (effectA.effectID == effectID)
            {
                return effectA.attributes;
            }
        }
        return null;
    }
}
