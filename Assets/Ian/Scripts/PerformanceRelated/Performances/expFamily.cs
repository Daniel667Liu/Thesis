using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class expFamily : AudienceExpectation
{
    private void Awake()
    {
        Services.audienceExpectation = this;
    }

    /*public override void Start()
    {
        base.Start();
    }*/

    public override void CalculateResult()
    {
        base.CalculateResult();
    }

    public override void CheckForRequirement(int effectID)
    {
        base.CheckForRequirement(effectID);

        // find the attribute's name from performing box's list of effect attributes, then add the value to it
        PerformBox pb = stageManager.GetPerformingBox();
        foreach (EffectAttributes ea in pb.effectAttributes)
        {
            if (ea.effectID == effectID)
            {
                List<AttributeReq> effectAs = ea.attributes;

                // for each attribute in the effect, find the attribute in currentAttributes and add value to it
                foreach (AttributeReq ar in effectAs)
                {
                    for (int i = 0; i < currentAttributes.Count; i++)
                    {
                        if (currentAttributes[i].name == ar.name)
                        {
                            currentAttributes[i].value += ar.value;
                            break;
                        }
                    }
                }

                break;
            }
        }

        

        //TODO special checks
    }
}
