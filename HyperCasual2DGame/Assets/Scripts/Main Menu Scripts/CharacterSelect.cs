using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    private GameObject[] characterList;
    private int index;

    void Awake()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];

        //Fill array with character models
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }


        if (SceneManager.GetActiveScene() == SceneManager.GetSceneByName("MainMenu") || SceneManager.GetActiveScene() == SceneManager.GetSceneByName("Gameplay"))
        {
            //We toggle off their renderer
            foreach (GameObject go in characterList)
            {
                go.SetActive(false);
            }

            //We toggle on selected character
            if (characterList[index])
            {
                characterList[index].SetActive(true);
            }
        }

    }

  

    public void SelectBtn()
    {
        PlayerPrefs.SetInt("CharacterSelected", index);
        SceneManager.LoadScene("MainMenu");
    }
    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
