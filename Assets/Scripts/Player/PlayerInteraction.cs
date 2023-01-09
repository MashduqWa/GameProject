using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class PlayerInteraction : MonoBehaviour
{
    public List<Seed> seedList;

    public GameObject Joystick;
    public Button buttonSeed;
    public Button buttonHarvest;
    public Button buttonWatering;
    public GameObject scrollSeed;
    public GameObject previewSeed;


    PlayerMovement playerMovement;

    [SerializeField] Land selectedLand = null;
    [SerializeField] Seed selectedSeed = null;
    Seed seedToSpawn = null;
    Seed seedPrice;
    

    


    // Start is called before the first frame update
    void Start()
    {
        playerMovement = transform.parent.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1))
        {
            OnInteractableHit(hit);
        }


    }



    public void OnSeedSelected(int seed)
    {
        if (Coin.coinSystem > 0)
        {
            buttonSeed.enabled = true;
        }
        else if (Coin.coinSystem <= 0)
        {
            buttonSeed.enabled = false;
            Debug.Log("Koin Tidak Cukup");
        }

        seedToSpawn = SelectSeedToSpawn((VegetableType)seed);
        
    }

    void OnInteractableHit(RaycastHit hit)
    {
        Collider other = hit.collider;

        if (other.tag == "Land")
        {
            Land land = other.GetComponent<Land>();
            SelectLand(land);

            if (!selectedLand.plantedSeed)
            {
                //SetPlantButtonActive(true);
                SetWateringButtonActive(false);
                SetHarvestButtonActive(false);

            }
            else if (selectedLand.plantedSeed.waterHp > 0)
            {
                selectedSeed = selectedLand.plantedSeed;
                SetWateringButtonActive(true);
                SetPlantButtonActive(false);
                SetHarvestButtonActive(false);
                SetScrollActive(false);
                //SetPreviewActive(false);

            }
            else if (selectedLand.plantedSeed.waterHp <= 0)
            {
                selectedSeed = selectedLand.plantedSeed;
                SetHarvestButtonActive(true);
                SetPlantButtonActive(false);
                SetWateringButtonActive(false);
                SetScrollActive(false);
            }
            return;

        }

        if (selectedLand != null)
        {
            selectedLand.Select(false);
            SetScrollActive(false);
            SetPlantButtonActive(false);
            SetHarvestButtonActive(false);
            SetWateringButtonActive(false);
            selectedLand = null;
        }
    }

    void SetScrollActive(bool value)
    {
        scrollSeed.gameObject.SetActive(value);
    }

    void SetPreviewActive(bool value)
    {
        previewSeed.gameObject.SetActive(value);
    }

    void SetPlantButtonActive(bool value)
    {
        buttonSeed.gameObject.SetActive(value);
    }

    void SetHarvestButtonActive(bool value)
    {
        buttonHarvest.gameObject.SetActive(value);
    }
    void SetWateringButtonActive(bool value)
    {
        buttonWatering.gameObject.SetActive(value);
    }

    void SelectLand(Land land)
    {
        if (selectedLand != null)
        {
            selectedLand.Select(false);
            SetPlantButtonActive(false);
        }

        selectedLand = land;
        land.Select(true);
        SetPlantButtonActive(true);
        SetScrollActive(true);
    }

    Seed SelectSeedToSpawn(VegetableType seedType)
    {
        Seed seedToSpawn = null;
        foreach (var _seed in seedList)
        {
            if (_seed.type == seedType)
            {
                seedToSpawn = _seed;
            }
        }
        if (seedToSpawn)
        {
            seedToSpawn = Instantiate(seedToSpawn);
            seedToSpawn.gameObject.SetActive(false);
        }

        return seedToSpawn;

    }


    public void PlantSeed()
    {
        Delay(3);
        if (seedToSpawn && selectedLand)
        {
            seedToSpawn.gameObject.SetActive(true);
            seedToSpawn.transform.SetParent (selectedLand.transform);
            seedToSpawn.transform.localPosition = Vector3.zero;

            selectedLand.plantedSeed = seedToSpawn;
            seedToSpawn = null;
            
        }

    }

    public void WaterSeed()
    {
        Delay(5);
        if (selectedSeed)
        {
            selectedSeed.waterHp -= 10;
        }
    }

    public void HarvestSeed()
    {
        Delay(3);

        if (selectedSeed)
        {
            Destroy(selectedSeed.gameObject, 3f);
            //do further harvest functions
        }

    }


    public async void Delay(float duration)
    {
        Joystick.gameObject.SetActive(false);
        await Task.Delay((int)(duration * 1000));
        Joystick.gameObject.SetActive(true);
    }




}
