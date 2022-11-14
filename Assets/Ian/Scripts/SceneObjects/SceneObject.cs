using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SceneObject : MonoBehaviour
{
    public abstract void FinishedLoop();
    public abstract void Highlight();
    public abstract void StopHighlight();
}

public enum SceneObjectState
{
    DD,DDD
}