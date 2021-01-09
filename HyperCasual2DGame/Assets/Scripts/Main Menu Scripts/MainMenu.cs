using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{ 
    private bool gameStarted;

    void Start()
    {
       Screen.SetResolution ((int)Screen.width, (int)Screen.height, true); 
        //  StartCoroutine(CallAd());
        // SoundManager.instance.playMusic();
    }

   /* IEnumerator CallAd()
    {
       yield return new WaitForSeconds(2f);

       AdController.instance.showBannerAD();
    }*/

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ChangeCharacter()
    {
        SceneManager.LoadScene("CharacterSelect");
    }

    public void NoAds()
    {
        if (PlayerPrefs.HasKey("AdFree"))
        {
            print("Ads already removed");
        }
        else
        {
            IAPManager.instance.BuyNoAds();
        } 
    }
}
