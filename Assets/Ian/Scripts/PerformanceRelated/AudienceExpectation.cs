using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AudienceExpectation : MonoBehaviour
{
    public StageManager stageManager;
    public List<AttributeReq> attributeRequirements = new List<AttributeReq>();

    //[HideInInspector]
    public List<AttributeReq> currentAttributes = new List<AttributeReq>();

    void Start()
    {
        for (int i=0; i<attributeRequirements.Count; i++)
        {
            AttributeReq ar = new AttributeReq();
            ar.name = attributeRequirements[i].name;
            ar.value = 0f;
            currentAttributes.Add(ar);
        }
    }

    public virtual void CalculateResult()
    {

    }

    public virtual void CheckForRequirement(int effectID)
    {

    }
}
