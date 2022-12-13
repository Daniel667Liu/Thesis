using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarParent : MonoBehaviour
{
    public List<Star> stars = new List<Star>();

    public int nextStarInd;

    private void Start()
    {
        /*for (int i=0; i<transform.childCount; i++)
        {
            stars.Add(transform.GetChild(i).gameObject.GetComponent<Star>());
        }*/
    }

    public void ShootStar()
    {
        if ((stars[0] == null || stars[0].gameObject.activeSelf == false) && 
            (stars[1] == null || stars[1].gameObject.activeSelf == false) && 
            (stars[2] == null || stars[2].gameObject.activeSelf == false)) return;

        if (stars[0].transform.GetChild(1).GetComponent<Animator>().enabled == false &&
            stars[1].transform.GetChild(1).GetComponent<Animator>().enabled == false &&
            stars[2].transform.GetChild(1).GetComponent<Animator>().enabled == false) return;
        
        while (stars[nextStarInd] == null || stars[nextStarInd].gameObject.activeSelf == false || stars[nextStarInd].transform.GetChild(1).GetComponent<Animator>().enabled == false)
        {
            nextStarInd++;
            if (nextStarInd >= stars.Count)
            {
                nextStarInd = 0;
            }
        }
        //if (stars[nextStarInd].GetComponent<Star>().ShootStar())
        //{
        stars[nextStarInd].GetComponent<Star>().ShootStar();
            nextStarInd++;
            if (nextStarInd >= stars.Count)
            {
                nextStarInd = 0;
            }
        //}
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
