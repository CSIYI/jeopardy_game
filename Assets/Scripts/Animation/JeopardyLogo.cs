using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JeopardyLogo : MonoBehaviour {

    public float rotateRate;
    public float approachRate;

   	void Start () {
        StartCoroutine("Rotate");
    }

    /*
     * Translates the gameobject closer to the camera
     */

    IEnumerator Approach()
    {
        while(transform.position.z > -6)
        {
            transform.position += new Vector3(0, 0, -approachRate * Time.deltaTime);
            yield return null;
        }
        transform.position = new Vector3(transform.position.x,
                                         transform.position.y,
                                         -6);
    }

    /*
     * Rotates the gameobject around its vertical
     */
    IEnumerator Rotate()
    {
        while(true)
        {
            transform.Rotate(new Vector3(0, -rotateRate * Time.deltaTime, 0));
            yield return null;
        }
    }
}
