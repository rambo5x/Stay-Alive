using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformScript : MonoBehaviour
{

    public float move_Speed = 3;
    public float bound_Y = 6f;
    public GameObject player;

    public bool moving_Platform_Left, moving_Platform_Right, is_Breakable, is_Spike, is_Platform;

    private Animator anim;
   
    void Awake()
    {
        if (is_Breakable)
        {
            anim = GetComponent<Animator>();
        }
    }
   
    void Update()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = transform.position;
        temp.y += move_Speed * Time.deltaTime;
        transform.position = temp;

        if (temp.y >= bound_Y)
        {
            gameObject.SetActive(false);
        }
    }

    void BreakableDeactivate()
    {
        Invoke("DeactivateGameObject", 0.35f);
    }

    void DeactivateGameObject()
    {
        SoundManager.instance.IceBreakSound();
        gameObject.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "Player")
        {
            if (is_Spike)
            {
                //target.transform.position = new Vector2(1000f, 1000f);
                target.gameObject.SetActive(false);
                SoundManager.instance.DeathSound();
                GameManager.instance.isCounting = false;
                GameManager.instance.DisplayGameOverScreen();
            }
        }
    }

    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            PlayerMovement.instance.StopMoving();

            if (is_Breakable)
            {
                SoundManager.instance.LandSound();
                anim.Play("Break");
            }

            if (is_Platform)
            {
                SoundManager.instance.LandSound();
            }
        }
    }

    void OnCollisionStay2D(Collision2D target)
    {
        if(target.gameObject.tag == "Player")
        {
            if (moving_Platform_Left)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(-2f);
                //target.gameObject.GetComponent<PlayerMovement>().PlatformMoveNew(-2f);
            }
            if (moving_Platform_Right)
            {
                target.gameObject.GetComponent<PlayerMovement>().PlatformMove(2f);
                //target.gameObject.GetComponent<PlayerMovement>().PlatformMove(2f);
            }
        }
    }

}
