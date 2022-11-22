using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Custom/LiveFeedback")]
public class LiveFeedback : ScriptableObject
{
    public string audience;
    public List<feedbackPair<int, string>> feedbackPairs;
}

[System.Serializable]
public class feedbackPair<Tkey, TVal>
{
    public Tkey key;
    public TVal val;
}
