using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadPNG : MonoBehaviour
{
    public GameObject canvas;
    public GameObject button;

    public void PNGload()
    {
        Texture2D tex = null;
        byte[] fileData;

        string thepath = Path.Combine(Application.persistentDataPath, "images");

        DirectoryInfo d = new DirectoryInfo(thepath);

        FileInfo[] Files = d.GetFiles("*.png");

        string str;
        foreach (FileInfo file in Files)
        {
            str = Path.Combine(thepath, file.Name);

            Debug.Log(str);


            if (File.Exists(str))
            {
                fileData = File.ReadAllBytes(str);
                tex = new Texture2D(50, 50);
                tex.LoadImage(fileData); //..this will auto-resize the texture dimensions.

                GameObject newButton = Instantiate(button);
                newButton.GetComponent<Image>().sprite = Sprite.Create(tex, new Rect(0, 0, tex.width, tex.height), new Vector2(0, 0));
                newButton.transform.SetParent(canvas.transform, false);
            }
            else
            {
                Debug.Log(thepath);
            }

        }


    }
}