using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Attribute
{
    joyful, sad
}

[System.Serializable]
public class AttributeReq
{
    public Attribute name;
    public float value;
}

[System.Serializable]
public class EffectAttributes
{
    public int effectID;
    public List<AttributeReq> attributes;
}
