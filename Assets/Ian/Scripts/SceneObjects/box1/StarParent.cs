using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarParent : MonoBehaviour
{
    public List<Star> stars = new List<Star>();

    private int nextStarInd;

    private void Start()
    {
        /*for (int i=0; i<transform.childCount; i++)
        {
            stars.Add(transform.GetChild(i).gameObject.GetComponent<Star>());
        }*/
    }

    public void ShootStar()
    {
        if (stars[nextStarInd].GetComponent<Star>().ShootStar())
        {
            nextStarInd++;
            if (nextStarInd >= stars.Count)
            {
                nextStarInd = 0;
            }
        }
    }

    public void Highlight()
    {
        foreach (Star s in stars)
        {
            s.Highlight();
        }
    }

    public void StopHighlight()
    {
        foreach (Star s in stars)
        {
            s.StopHighlight();
        }
    }
}
