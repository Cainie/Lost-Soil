using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DialogueMenu : MonoBehaviour
{
    public TMP_Text TextBox;

    public GameObject NamePlayer;
    public GameObject NameAi;
    public GameObject NameComputer;

    public GameObject NextButton;
    public GameObject PlayButton;

    private int dialogueNumber = 0;

    private int[] whoIsTalking =
    {3,3,3,3,3,2,2,1,2,1,2,3,2,2,3,2,3,2,3,2,3,2,3,2,3,2,2,2,3,2,0};

    void Start()
    {
        NameComputer.SetActive(true);
        NextButton.SetActive(true);
        TextBox.text = dialogue[dialogueNumber];        
    }

    public void NextDialogue() 
    {     
        dialogueNumber += 1;
        TextBox.text = dialogue[dialogueNumber];

        if (whoIsTalking[dialogueNumber] == 0)
        {
            NamePlayer.SetActive(false);
            NameAi.SetActive(false);
            NameComputer.SetActive(false);
            NextButton.SetActive(false);
            PlayButton.SetActive(true);

        }

        if (whoIsTalking[dialogueNumber] == 1)
        {
            NamePlayer.SetActive(true);
            NameAi.SetActive(false);
            NameComputer.SetActive(false);
        }

        if (whoIsTalking[dialogueNumber] == 2)
        {
            NamePlayer.SetActive(false);
            NameAi.SetActive(true);
            NameComputer.SetActive(false);
        }

        if (whoIsTalking[dialogueNumber] == 3)
        {
            NamePlayer.SetActive(false);
            NameAi.SetActive(false);
            NameComputer.SetActive(true);
        }
    }

    public void PlayGame()
    {
        
        SceneManager.LoadScene("ResourcesMechanicTestScene");
    }



    private string[] dialogue =
        {
            "Booting sequence initiated. Regaining functionality after an unscheduled shutdown. Determining location. Location- Planet Earth, Solar System. Determining time. Error. Time undetermined.",
            "Running diagnostics. Core systems - online. Building systems - online. Transportation systems - destroyed. Weapon systems - offline. Power generators - offline. Power levels - critical. Urgent repairs required. Urgent recharging required.",
            "User scan commenced. Species - human. Current world population of species - 0. Logic error detected. Critical error. Force Rebooting. *shutdown*",
            "*booting*",
            "Booting sequence initiated. Regaining funct-",

            "Do you ever shut up?",
            "You need to excuse my friend here, little human. He’s kind of slow. That being said, you ARE an anomaly. Your species was supposed to be entirely wiped out after the invasion of 2137. Why are you here?",

            "*murmurs* Plot armor?",

            "What?",

            "What?",

            "I’m going to pretend I didn't hear that. Smartass.",

            "AI, what is the meaning of plo-",

            "Shut. up.",
            "Why did you restart the system, human? Is it some kind of perverse sadistic pleasure of yours, to watch me starve to death? Because we are running out of juice, and fast.",
            "Calculations completed. To ensure stability of the system, all measures must be undertaken. “The Error” determined as the only way to achieve necessary resources and repairs.",

            "The error? You even named him already? I’m speechless",

            "Enabling access to provisions and weaponry storage. Please, take the communication device from the table, and head to the storeroom to collect your equipment.",

            "That’s all that’s left. You’re lucky anyway, Comp deemed you worthy of supplies. The previous scavenger that couldn’t get access to food went insane and started chewing on cables. Unfortunately-",

            "(happily) I had to liquidate him!",

            "Way to scare your new friend off, Comp. Unfortunately that is how I came to be. And now I’m stuck with him until the debug. Which is, forever, judging by the circumstances.",

            "Error, your new directive is to ensure our survival. The system needs functioning power supplies, and urgent repairs. We can create weaponry, tools and machinery, in exchange for resources transformable into energy.",

            "He means wood and stone. Don’t think about it too hard. The technology he used to command is actually very advanced. Just don’t ask him how it works. And where the food comes from.",

            "Sharing that knowledge would be a violation of company directives, and warrant immediate termination. Just like that scientist in-",

            "Computer. Stop scaring him. What happened to your cognitive module anyways?",

            "Irreversibly damaged. Replacement required.",

            "Of course.",
            "(distant enemy sounds) Hey, human. Looks like your alien friends noticed you’ve survived the purge. The walls of this place are sturdy, but we’ve got no power to run the defense system. We need you to go out there, repel the attack and get our cannons back online. And the generators. We will help you, if you help us. Just go now",
            "And don’t die. Don’t you dare die and leave me alone with bird-brain. Please.",

            "Actually, studies have shown that certain species of birds have exceptional mental capabilities, comparable to-",

            "Be quick. Please.",

            "(Build Walls and Tower to lvl. 5 to win)",
            ""

        };
  
}
