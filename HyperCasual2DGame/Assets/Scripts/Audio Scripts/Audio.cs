using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Audio : MonoBehaviour
{
    public GameObject soundControlbtn;
    public Sprite audioOffSprite;
    public Sprite audioOnSprite;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("pause"))
        {
            if (PlayerPrefs.GetInt("pause") == 0)
            {
                soundControlbtn.GetComponent<Image>().sprite = audioOffSprite;
                AudioListener.pause = true;
            }
            else if (PlayerPrefs.GetInt("pause") == 1)
            {
                soundControlbtn.GetComponent<Image>().sprite = audioOnSprite;
                AudioListener.pause = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SoundControl()
    {
        if (AudioListener.pause)
        {
            AudioListener.pause = false;
            soundControlbtn.GetComponent<Image>().sprite = audioOnSprite;
            PlayerPrefs.SetInt("pause", 1);
            //  PlayerPrefs.SetInt("sprite", 0);
        }
        else
        {
            AudioListener.pause = true;
            soundControlbtn.GetComponent<Image>().sprite = audioOffSprite;
            PlayerPrefs.SetInt("pause", 0);
            //   PlayerPrefs.SetInt("sprite", 1);
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RateUs()
    {

    }

}
