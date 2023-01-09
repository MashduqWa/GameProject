using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public Image image;
    public Sprite[] newimg;

    public void ImageChange(int btn)
    {
       image.sprite = newimg[btn];
       image.gameObject.SetActive(true);
    }

  
}
