using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkChildAnim : MonoBehaviour
{
    public void CheckHit()
    {
        // look for girl's hitbox
        GameObject[] girlHitBoxes = GameObject.FindGameObjectsWithTag("girlHitBox");
        Debug.Log(girlHitBoxes.Length);
        foreach (GameObject girlHitBox in girlHitBoxes)
        {
            if (Vector2.Distance(girlHitBox.transform.position, transform.position) < 4f)
            {
                // hit the girl
                girlHitBox.transform.parent.GetComponent<GirlAnim>().Boom();
            }
        }

        //TODO: other hits
    }
}
