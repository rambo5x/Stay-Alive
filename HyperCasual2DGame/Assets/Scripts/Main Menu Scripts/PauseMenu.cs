using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseBtn;

   

    public void pauseGame()
    {
        Time.timeScale = 0f;
        pauseBtn.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void resumeGame()
    {
        Time.timeScale = 1f;
        pauseBtn.SetActive(true);
        pauseMenu.SetActive(false);
    }

    public void Restart()
    {
        Time.timeScale = 1f;
        GameManager.instance.RestartGame();
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        GameManager.instance.ReturnToMainMenu();
    }
}
