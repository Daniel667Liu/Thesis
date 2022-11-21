using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Performance : MonoBehaviour
{
    public int id;
    public string sceneName;

    public string audience;
    [TextArea]
    public string audienceDescription;
    public int timeLimit;

    public virtual void StartPerformance()
    {

    }
}
