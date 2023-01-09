using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Land : MonoBehaviour
{
    public Seed plantedSeed;
    public GameObject select;
    public GameObject btnSeed;

    void Start()
    {
        Select(false);
        BtnSeed(false);
        
    }

    // Start is called before the first frame update
   public void Select(bool toggle)
    {
        select.SetActive(toggle);
    }

    public void BtnSeed(bool toggle)
    {
        btnSeed.SetActive(toggle);
    }

    
}
