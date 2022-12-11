using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interaction : MonoBehaviour
{
    public abstract Color GetButtonColor();

    public abstract Vector3 GetDefaultPos();
    public abstract Vector3 GetDefaultRot();

    public abstract void AssignKeys(List<KeyCode> keys);

    public abstract List<KeyCode> GetKeys();

    public abstract void HighlightObject();

    public abstract void StopHighlightObject();

    public abstract void PlayButtonAnim();
    public abstract void StopButtonAnim();
}
