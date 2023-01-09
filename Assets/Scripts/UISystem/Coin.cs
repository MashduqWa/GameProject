using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Coin : MonoBehaviour
{
    TMP_Text text;
    public static float coinSystem = 200;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = coinSystem.ToString();
    }
}
