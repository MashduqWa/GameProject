using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public enum VegetableType { 
    Wheat,
    Tomato,
    Corn,
    Carrot,
    Potato
}

public enum VegetablePhase
{
    Growing,
    Ready
}

public class Seed : MonoBehaviour
{

    public VegetableType type;
    public VegetablePhase phase;
    public float waterHp;
    public float price;
    public GameObject mesh;
    public GameObject plant;
    //public float waterDuration;


    //float waterDurationCounter;
    //public bool needWatering;

    void Start()
    {
        CoinSystem();
        phase = VegetablePhase.Growing;
        DelaymeshActive(3);
        plant.SetActive(false);
        //waterDurationCounter = duration;
    }

    private void Update()
    {

        if (phase == VegetablePhase.Growing)
        {
                if (waterHp <= 0)
                {
                    waterHp = 0;
                    SetReady();
                }
            
        }

    }

    private void SetReady()
    {
        phase = VegetablePhase.Ready;
        DelaymeshDeactive(3);
        Delayplant(3);
    }

    private void CoinSystem()
    {
        if(Coin.coinSystem >= price)
        {
            Coin.coinSystem -= price;
        }
    }


    public async void DelaymeshActive(float time)
    {
        mesh.gameObject.SetActive(false);
        await Task.Delay((int)(time * 1000));
        mesh.gameObject.SetActive(true);
    }


    public async void DelaymeshDeactive(float time)
    {
        //mesh.gameObject.SetActive(true);
        await Task.Delay((int)(time * 1000));
        mesh.gameObject.SetActive(false);
    }

    public async void Delayplant(float time)
    {
        plant.gameObject.SetActive(false);
        await Task.Delay((int)(time * 1000));
        plant.gameObject.SetActive(true);
    }


    // Start is called before the first frame update
}
