using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour
{
    public static PlayerBounds instance;
    public float min_X = -2.6f, max_X = 2.6f, min_Y = -5.6f;
    private bool out_Of_Bounds;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        CheckBounds();
    }

    void CheckBounds()
    {
        Vector2 temp = transform.position;

        if (temp.x > max_X) //not allow player go off screen on the left or right
            temp.x = max_X;

        if (temp.x < min_X)
            temp.x = min_X;

        transform.position = temp;

        if(temp.y <= min_Y)
        {
            if (!out_Of_Bounds)
            {
                out_Of_Bounds = true;

                player.SetActive(false);
                SoundManager.instance.DeathSound();
                GameManager.instance.isCounting = false;
                GameManager.instance.DisplayGameOverScreen();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "TopSpike")
        {
            //transform.position = new Vector2(1000f, 1000f);
            player.SetActive(false);
            SoundManager.instance.DeathSound();
            GameManager.instance.isCounting = false;
            GameManager.instance.DisplayGameOverScreen();
        }
    }
}
