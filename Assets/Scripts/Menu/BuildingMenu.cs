using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ResourcesSystem;
using Misc;
using GameController;

public class BuildingMenu : MonoBehaviour
{
    public GameObject ResourcesStorageController;
    public GameObject VictoryScreen;
    ResourceType Wood = (ResourceType)System.Enum.Parse(typeof(ResourceType), "Wood");
    ResourceType Stone = (ResourceType)System.Enum.Parse(typeof(ResourceType), "Stone");
    ResourceType Food = (ResourceType)System.Enum.Parse(typeof(ResourceType), "Food");
    ResourceType Energy = (ResourceType)System.Enum.Parse(typeof(ResourceType), "Energy");
        

    private bool enoughResources = false;

    private int woodCurrentAmount, stoneCurrentAmount, foodCurrentAmount, energyCurrentAmount;

    public Image buildingImage;

    public GameObject upgradeButton;

    public TMP_Text titleText;
    public TMP_Text woodNeeded, StoneNeeded, EnergyNeeded, FoodNeeded;
    public TMP_Text description;

    private int buidlingLevel;
    private int buildingId = 0;  

    

    int[,] ResourceNeeded =
    {
        {10, 10, 10, 10},
        {30, 30, 30, 30},
        {50, 50, 50, 50},
        {80, 80, 80, 80}/*,
        {120, 120, 120, 120},
        {160, 160, 160, 160},
        {200, 200, 200, 200},
        {250, 250, 250, 250},
        {300, 300, 300, 300}*/

    };

    int[,] ResourceGiven =
    {   
        {0, 0, 0, 0}, //Level 0 Buildigs
        {1, 1, 1, 1},
        {2, 2, 2, 2},
        {4, 4, 4, 4},
        {6, 6, 6, 6},
        {9, 9, 9, 9}/*,
        {12, 12, 12, 12},
        {16, 16, 16, 16},
        {20, 20, 20, 20},
        {25, 25, 25, 25},
        {30, 30, 30, 30}*/

    };



    int[] BuildingLevels = 
    { 1, 1, 1, 1, 1, 1};


    string[] Descriptions =
    {
        "You know what a lumberyard is, right? Wood goes in, wood products go out. Just roll up your sleeves, or risk losing fingers. Do you even have sleeves?",
        "This calls for a joke about stoning. Or getting stoned. You can’t be saying this with a stone cold face. Ha. Ha.",
        "Food, batteries for human species. Don’t expect Michelin stars though. You’re no culinary critic either, mind you.",
        "As much pain in the butt as it brought to fuel, coal and gas industries, solar energy has become a great, efficient source of renewable energy in the decades before the purge. Oh well, it’s not like you have any choice in the matter anymore, you filthy bio activist.",
        "It has been said that certain scouts from certain fortresses can see their bases from them. It’s something that mercenary teams used to say around the 2000s, up until the Great Robot Crisis. There were no more scouts after that, unfortunately.",
        "That’s the only thing stopping the enemies from getting to us, and destroying the infrastructure, since the cannons went silent. That’s it. No snarky remarks here. Can’t get too predictable now, can I?"
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
            
        
            if (buidlingLevel < /*10*/ 5)
            {
                woodNeeded.text = ResourceNeeded[(buidlingLevel - 1), 0].ToString();
                StoneNeeded.text = ResourceNeeded[(buidlingLevel - 1), 1].ToString();
                EnergyNeeded.text = ResourceNeeded[(buidlingLevel - 1), 2].ToString();
                FoodNeeded.text = ResourceNeeded[(buidlingLevel - 1), 3].ToString();
                upgradeButton.SetActive(true);
            }
            else
            {
                woodNeeded.text = "-";
                StoneNeeded.text = "-";
                EnergyNeeded.text = "-";
                FoodNeeded.text = "-";
                upgradeButton.SetActive(false);
            }

       checkVictory();



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
        InvokeRepeating("addingResources", 0, 1);
    }


    private void addingResources()
    {   
        ResourcesStorageController.GetComponent<ResourcesStorageController>().StoreResource(Wood, ResourceGiven[BuildingLevels[0], 0]);
        ResourcesStorageController.GetComponent<ResourcesStorageController>().StoreResource(Stone, ResourceGiven[BuildingLevels[1], 1]);
        ResourcesStorageController.GetComponent<ResourcesStorageController>().StoreResource(Food, ResourceGiven[BuildingLevels[2], 2]);
        ResourcesStorageController.GetComponent<ResourcesStorageController>().StoreResource(Energy, ResourceGiven[BuildingLevels[3], 3]);

    }


    private void checkVictory()
    {
        if(BuildingLevels[4] == 5 && BuildingLevels[5] == 5)
        {
           ResourcesStorageController.GetComponent<VictoryScreen>().Victory();
        }

    }


}
