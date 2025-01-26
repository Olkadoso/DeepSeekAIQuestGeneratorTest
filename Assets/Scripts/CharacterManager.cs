using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CharacterManager : MonoBehaviour
{
    private List<GameObject> characters = new List<GameObject>();
    private float randomNumber;
    private Characters characterState;

    private void Start()
    {
        GenerateQuest();
    }

    public void GenerateQuest()
    {
        int numberOfChildren = transform.childCount;
        //Debug.Log("number of Children"+numberOfChildren);
        for (int i = 0; i < numberOfChildren; i++)
        {
            Debug.Log(i);
            characters.Add(transform.GetChild(i).gameObject);
        }
        foreach (var character in characters)
        {
            randomNumber = Random.Range(0, 3);
            Debug.Log(randomNumber);
            characterState = character.GetComponentInChildren<Characters>();
            switch (randomNumber)
            {
                case 0:
                    characterState.state = Characters.State.Default;
                    break;
                case 1:
                    characterState.state = Characters.State.ObjectiveKill;
                    break;
                case 2:
                    characterState.state = Characters.State.ObjectiveSave;
                    break;
            }
        }
    }
}
