using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireworkChildAnim : MonoBehaviour
{
    public void CheckHit()
    {
        // look for girl's hitbox
        GameObject[] girlHitBoxes = GameObject.FindGameObjectsWithTag("girlHitBox");
        foreach (GameObject girlHitBox in girlHitBoxes)
        {
            if (Vector2.Distance(girlHitBox.transform.position, transform.position) < 4f)
            {
                // hit the girl
                girlHitBox.transform.parent.GetComponent<GirlAnim>().Boom();
            }
        }

        // look for boy
        GameObject[] boyHitBoxes = GameObject.FindGameObjectsWithTag("boyHitBox");
        foreach (GameObject boyHitBox in boyHitBoxes)
        {
            if (Vector2.Distance(boyHitBox.transform.position, transform.position) < 2f)
            {
                // hit the boy
                boyHitBox.transform.parent.GetComponent<KidAnim>().Wa();
            }
        }

        //TODO: other hits
    }
}
