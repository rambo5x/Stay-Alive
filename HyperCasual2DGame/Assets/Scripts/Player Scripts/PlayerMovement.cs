using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    private Rigidbody2D myBody;

    public float moveSpeed = 2f;

    private float? pressX;


    void Awake()
    {
        instance = this;
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetAxisRaw("Horizontal") > 0f)
        {
            MoveRight();
        }

        if (Input.GetAxisRaw("Horizontal") < 0f)
        {
            MoveLeft();
        }
        /* All uses of touch functions
            if(Input.touchCount > 0)
            {
                Touch t = Input.GetTouch(0);

                if(t.phase == TouchPhase.Began)
                {
                    print("Touch Began");
                }
                if (t.phase == TouchPhase.Ended)
                {
                    print("Touch Ended");
                }
                if (t.phase == TouchPhase.Moved)
                {
                    print("Touch Moved");
                }
            }

            for(int i = 0; i < Input.touchCount; i++)
            {
                print("The position of the touch is " + Input.touches[i]);
            }
         */
        //Press left or right to move

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touch_Pos = Camera.main.ScreenToWorldPoint(touch.position); //convert screen coords to unity world coords

            if(touch_Pos.x > 0)
            {
                MoveRight();
            }else if(touch_Pos.x < 0)
            {
                MoveLeft();
            }
        }
        else
        {
           // StopMoving();
        }
        /* If pressed with one finger
        if (Input.GetMouseButtonDown(0))
            pressX = Input.touches[0].position.x;
        else if (Input.GetMouseButtonUp(0))
            pressX = null;


        if (pressX != null)
        {
            float currentX = Input.touches[0].position.x;

            // The finger of initial press is now left of the press position
            if (currentX < pressX)
                MoveP(-moveSpeed);

            // The finger of initial press is now right of the press position
            else if (currentX > pressX)
                MoveP(moveSpeed);

            // else is not required as if you manage (somehow)
            // move you finger back to initial X coordinate
            // you should just be staying still
        }*/

}

   /* private void MoveP(float velocity)
    {
        transform.position += Vector3.right * velocity * Time.deltaTime;
    }*/

    public void MoveRight()
    {
        myBody.velocity = new Vector2(moveSpeed, myBody.velocity.y);
    }

    public void MoveLeft()
    {
        myBody.velocity = new Vector2(-moveSpeed, myBody.velocity.y);
    }

    public void StopMoving()
    {
        myBody.velocity = new Vector2(0f, myBody.velocity.y);
    }

    public void PlatformMove(float x)
    {
        myBody.velocity = new Vector2(x, myBody.velocity.y);
    }

    /*public void PlatformMoveNew(float velocity)
    {
        transform.position += Vector3.right * velocity * Time.deltaTime;
    }*/
}
