using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneFade : MonoBehaviour
{
    public float fadeSpeed;
    public Material material;

    public void Awake()
    {
    }

    public void OnEnable()
    {
        FadeIn();
    }

    public void FadeIn()
    {
        StartCoroutine(IFadeIn());
    }

    public void FadeOut(string scenename)
    {
        StartCoroutine(IFadeOut(scenename));
    }

    IEnumerator IFadeIn()
    {
        float alpha = 1.0f;
        Color col = material.color;

        while(alpha > 0.0f)
        {
            alpha -= Time.deltaTime * fadeSpeed;
            col.a = alpha;
            material.color = col;
            yield return null;
        }
        col.a = 0;
        material.color = col;
    }

    IEnumerator IFadeOut(string scenename)
    {
        float alpha = 0.0f;
        Color col = material.color;

        while (alpha < 1.0f)
        {
            alpha += Time.deltaTime * fadeSpeed;
            col.a = alpha;
            material.color = col;
            yield return null;
        }
        col.a = 1;
        material.color = col;

        //scene change
        SceneManager.LoadScene(scenename);
    }
    

}
