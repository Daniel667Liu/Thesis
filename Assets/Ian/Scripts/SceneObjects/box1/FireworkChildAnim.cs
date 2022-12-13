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

        // look for stars
        GameObject[] star2Ds = GameObject.FindGameObjectsWithTag("star2D");
        foreach (GameObject star2D in star2Ds)
        {
            if (Vector2.Distance(star2D.transform.position, transform.position) < 1.8f && star2D.activeSelf == true)
            {
                star2D.GetComponent<StarAnim>().HitByFirework();
            }
        }

        //TODO: other hits
    }
}
