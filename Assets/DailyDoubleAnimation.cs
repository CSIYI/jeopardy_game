using UnityEngine;
using System.Collections;
using System;



public class DailyDoubleAnimation : MonoBehaviour {


    Vector3 rotationEuler;
    RectTransform rectTransform;

    bool updateOn = true;
    // Use this for initialization

    void Start()
    {
        //FindObjectOfType<AudioManager>().Play("DailyDouble");
        //rectTransform = GetComponent<RectTransform>();
        //transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        //StartCoroutine(updateOff());
    }

    private void OnEnable()
    {
        updateOn = true;
        FindObjectOfType<AudioManager>().Play("DailyDouble");
        rectTransform = GetComponent<RectTransform>();
        transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        StartCoroutine(updateOff());
    }


    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);


    }

    // Update is called once per frame
    void Update()
    {

        if (updateOn == true)
        {


            rotationEuler += Vector3.left * 120 * Time.deltaTime;
            rectTransform.rotation = Quaternion.Euler(rotationEuler);

            if (transform.localScale.x <= 1)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.01f,
                                                                 transform.localScale.y + 0.01f,
                                                                 transform.localScale.z + 0.01f);//+ transform.localScale.z * scalingFactor * Time.deltaTime*/
            }

        }




    }

    IEnumerator updateOff()
    {
        yield return new WaitForSeconds(2.98f);
        updateOn = false;
    }
}
