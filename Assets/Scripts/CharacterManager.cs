using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterManager : MonoBehaviour
{
    private List<GameObject> characters = new List<GameObject>();

    private List<string> randomNames = new List<string>()
    {
        "Joe", "John", "Sal", "Murray", "Quinn", "Oliver", "Erica", "Simone", "Nina", "Chris", "Elise", "Arthur",
        "Astrid", "Phara", "Lux", "Arina", "Elfa", "Rimbo", "Xayah"
    };
    private Characters charactersScript;
    private int randomNumber;
    
    private void Start()
    {
        StarQuestSystem();
        AssignRandomNames();
        CheckNames();
        
        GenerateRandomQuest();
    }
    
    private void StarQuestSystem() //Counts and adds all child Gameobjects characters to list
    {
        int numberOfChildren = transform.childCount;
        for (int i = 0; i < numberOfChildren; i++)
        {
            characters.Add(transform.GetChild(i).gameObject);
        }
    }
    
    private void AssignRandomNames() //Assigns random name to child GameObject
    {
        foreach (GameObject character in characters)
        {
            for (int i = 0; i < randomNames.Count; i++)
            {
                AssignRandomName(character);
            }
        }
    }


    private void CheckNames()
    {
        for (int i = 0; i < characters.Count; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (characters[i].GetComponent<Characters>().characterName == characters[j].GetComponent<Characters>().characterName)
                {
                    AssignRandomName(characters[i]);
                    i = 0; //Not sure if this is very efficient, but in theory it should eliminate all duplicates
                }
            }
        }
    }
    
    private void AssignRandomName(GameObject character)
    {
        randomNumber = Random.Range(0, randomNames.Count);
        character.GetComponent<Characters>().characterName = randomNames[randomNumber];
    }
    
    public void GenerateRandomQuest() //Generates a quest based on randomness
    {
        foreach (GameObject character in characters)
        {
            randomNumber = Random.Range(0, 3);
            charactersScript = character.GetComponentInChildren<Characters>();
            switch (randomNumber)
            {
                case 0:
                    charactersScript.state = Characters.State.Default;
                    break;
                case 1:
                    charactersScript.state = Characters.State.ObjectiveKill;
                    break;
                case 2:
                    charactersScript.state = Characters.State.ObjectiveSave;
                    break;
            }
        }
    }

}
