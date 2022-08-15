using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ResourcesSystem;
using Misc;
using GameController;

public class BuildingMenu : MonoBehaviour
{
    public GameObject ResourcesStorageController;
    ResourceType Wood = (ResourceType)System.Enum.Parse(typeof(ResourceType), "Wood");
    ResourceType Stone = (ResourceType)System.Enum.Parse(typeof(ResourceType), "Stone");
    ResourceType Food = (ResourceType)System.Enum.Parse(typeof(ResourceType), "Food");
    ResourceType Energy = (ResourceType)System.Enum.Parse(typeof(ResourceType), "Energy");

    private bool enoughResources = false;

    private int woodCurrentAmount, stoneCurrentAmount, foodCurrentAmount, energyCurrentAmount;

    public Image buildingImage; 

    public TMP_Text titleText;
    public TMP_Text woodNeeded, StoneNeeded, EnergyNeeded, FoodNeeded;
    public TMP_Text description;

    private int buidlingLevel;
    private int buildingId = 0;
   

    int[,] ResourceNeeded = 
    {
        {10, 10, 10, 10},
        {200, 200, 200, 200},
        {300, 300, 300, 300},
        {400, 400, 400, 400},
        {500, 500, 500, 500}

    };

    int[] BuildingLevels = 
    { 1, 1, 1, 1, 1, 1};


    string[] Descriptions =
    {
        "Pretty basic looking lumberyard",
        "Quarry, it looks like it came from the STONE age. HA!",
        "The one and only Granary",
        "Solar Panels means free energy. Yay!",
        "I can see the mountains from up here",
        "Walls are a necessity here, without them I would be already gone."
    };

    string[] BuildingNames =
    {
        "Lumberyard Lvl.",
        "Quarry Lvl.",
        "Granary Lvl.",
        "Solar Panels Lvl.",
        "Tower Lvl.",
        "Walls Lvl."
    };


    public Sprite[] spriteList =
    {
       
    };


    private void OpenLumberyard()
    {
        buildingId = 0;       
        UpdateUI();
    }

    private void OpenQuarry()
    {
        buildingId = 1;
        UpdateUI();
    }

    private void OpenGranary()
    {
        buildingId = 2;
        UpdateUI();
    }

    private void OpenSolarpanel()
    {
        buildingId = 3;
        UpdateUI();
    }

    private void OpenTower()
    {
        buildingId = 4;
        UpdateUI();
    }

    private void OpenWalls()
    {
        buildingId = 5;
        UpdateUI();
    }
       

    private void UpdateUI()
    {
        buidlingLevel = BuildingLevels[buildingId];

        buildingImage.GetComponent<Image>().sprite = spriteList[buildingId];

        titleText.text = BuildingNames[buildingId] + buidlingLevel;
        description.text = Descriptions[buildingId];

        woodNeeded.text = ResourceNeeded[(buidlingLevel - 1), 0].ToString();
        StoneNeeded.text = ResourceNeeded[(buidlingLevel - 1), 1].ToString();
        EnergyNeeded.text = ResourceNeeded[(buidlingLevel - 1), 2].ToString();
        FoodNeeded.text = ResourceNeeded[(buidlingLevel - 1), 3].ToString();
    }


    private void UpgradeBuilding()
    {
        switch (buildingId)
        {
            case 0:
                checkResources();
                if (enoughResources ==true)
                { BuildingLevels[0] += 1; }
                OpenLumberyard();
                break;
            case 1:
                checkResources();
                if (enoughResources == true)
                { BuildingLevels[1] += 1; }
                OpenQuarry();
                break;
            case 2:
                checkResources();
                if (enoughResources == true)
                { BuildingLevels[2] += 1; }
                OpenGranary();
                break;
            case 3:
                checkResources();
                if (enoughResources == true)
                { BuildingLevels[3] += 1; }
                OpenSolarpanel();
                break;
            case 4:
                checkResources();
                if (enoughResources == true)
                { BuildingLevels[4] += 1; }
                OpenTower();
                break;
            case 5:
                checkResources();
                if (enoughResources == true)
                { BuildingLevels[5] += 1; }
                OpenWalls();
                break;
        }
    }

    //Opening the Menu

    public static bool GameIsPaused = false;

    public GameObject buildingMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }

    public void Resume()
    {
        buildingMenuUI.SetActive(false);        
        Time.timeScale = 1f;
        GameIsPaused = false;        
    }

    void Pause()
    {
        buildingMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;       
    }

    //Resources Info

    
    private void checkResources()
    {
        buidlingLevel = BuildingLevels[buildingId];
        woodCurrentAmount = ResourcesStorageController.GetComponent<ResourcesStorageController>().GetStoredResourceAmount(Wood);
        stoneCurrentAmount = ResourcesStorageController.GetComponent<ResourcesStorageController>().GetStoredResourceAmount(Stone);
        foodCurrentAmount = ResourcesStorageController.GetComponent<ResourcesStorageController>().GetStoredResourceAmount(Food);
        energyCurrentAmount = ResourcesStorageController.GetComponent<ResourcesStorageController>().GetStoredResourceAmount(Energy);
        Debug.Log(woodCurrentAmount);
        Debug.Log(ResourceNeeded[(buidlingLevel - 1), 0]);

        if ((ResourceNeeded[(buidlingLevel - 1), 0])<= woodCurrentAmount &&
            (ResourceNeeded[(buidlingLevel - 1), 1])<= stoneCurrentAmount &&
            (ResourceNeeded[(buidlingLevel - 1), 2])<= foodCurrentAmount &&
            (ResourceNeeded[(buidlingLevel - 1), 3])<= energyCurrentAmount)
        {
            ResourcesStorageController.GetComponent<ResourcesStorageController>().UseResource(Wood, ResourceNeeded[(buidlingLevel - 1), 0]);
            ResourcesStorageController.GetComponent<ResourcesStorageController>().UseResource(Stone, ResourceNeeded[(buidlingLevel - 1), 1]);
            ResourcesStorageController.GetComponent<ResourcesStorageController>().UseResource(Food, ResourceNeeded[(buidlingLevel - 1), 2]);
            ResourcesStorageController.GetComponent<ResourcesStorageController>().UseResource(Energy, ResourceNeeded[(buidlingLevel - 1), 3]);
            enoughResources = true;
        }
        else
        {
            enoughResources = false;
        }
            
    }

    private void Start()
    {
        UpdateUI();
    }


}
