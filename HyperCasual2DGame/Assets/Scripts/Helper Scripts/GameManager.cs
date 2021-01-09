using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text GameScore;
    public Text displayScore;
    public Text BestScore;
    public float currentScore;
    public bool isCounting;
    public GameObject GameOverPanel;
    public GameObject pauseBtn;
    public float bestScore;
    public static int counter = 0;
    public GameObject deathEffect;

    void Awake()
    {
        if (instance == null)
            instance = this;

        currentScore = 0;
        isCounting = true;

        // SoundManager.instance.playMusic();
        Screen.SetResolution((int)Screen.width, (int)Screen.height, true);
    }

    void Update()
    {
        if (isCounting)
        {
            currentScore += Time.deltaTime;
            GameScore.text = Mathf.Floor(currentScore).ToString();
        }
    }

    public void DisplayGameOverScreen()
    {
        Instantiate(deathEffect, PlayerBounds.instance.player.transform.position, PlayerBounds.instance.player.transform.rotation);
        if (!PlayerPrefs.HasKey("AdFree"))
        {
            if (counter % 5 == 0)
            {
                //SoundManager.instance.stopMusic();
                StartCoroutine(CallAd());
            }
            counter++;
        }
       
        Invoke("GameOverScreen", 2f);
    }

    void GameOverScreen()
    {
        displayScore.text = "Score: " + Mathf.Floor(currentScore).ToString();

        if (PlayerPrefs.HasKey("BestScore"))
        {
            CalculateBestScore();
        }
        else
        {
            BestScore.text = "Best: " + Mathf.Floor(currentScore).ToString();
            PlayerPrefs.SetInt("BestScore", (int) Mathf.Floor(currentScore));
        }

        SoundManager.instance.GameOverSound();
       
        GameOverPanel.SetActive(true);
        pauseBtn.SetActive(false);

        //SceneManager.LoadScene("Gameplay");
    }

    public void CalculateBestScore()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");

        if (currentScore > bestScore)
        {
            BestScore.text = "Best: " + Mathf.Floor(currentScore).ToString();
            PlayerPrefs.SetInt("BestScore", (int)Mathf.Floor(currentScore));
        }
        else
        {
            BestScore.text = "Best: " + PlayerPrefs.GetInt("BestScore");
        }
    }

    IEnumerator CallAd()
    {
        yield return new WaitForSeconds(2f);

        AdController.instance.showVideoAD();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
  
}
