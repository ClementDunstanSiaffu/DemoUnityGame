using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rigidBody;
    public float fowardForce = 2000f;
    public float sideForce = 500f;
    public float upwardForce = 5000f;
    private Touch theTouch;
    private Vector2 touchStartPosition,touchEndPosition;
    private string direction;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
      
    }

    void FixedUpdate()
    {
        if(Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if(theTouch.phase == TouchPhase.Began)
            {
                touchStartPosition = theTouch.position;
            }else if(theTouch.phase == TouchPhase.Moved || theTouch.phase == TouchPhase.Ended)
            {
                touchEndPosition = theTouch.position;
            }
            float x = touchEndPosition.x - touchStartPosition.x;
            float y = touchEndPosition.y - touchStartPosition.y;

            if (Mathf.Abs(x) == 0 && Mathf.Abs(y) == 0)
            {
                direction = "tapped";
            }else if (Mathf.Abs(x) > Mathf.Abs(y)) 
            {
                direction = x > 0 ? "right" : "left";
            }
            else
            {
                direction = y > 0 ? "up" : "down";
            }
        }

        rigidBody.AddForce(0, 0, Time.deltaTime * fowardForce);
        if (Input.GetKey("right") || direction == "right")
        {
            rigidBody.AddForce(Time.deltaTime*sideForce,0,0,ForceMode.VelocityChange);
        }else if (Input.GetKey("left") || direction == "left")
        {
            rigidBody.AddForce(-1 * Time.deltaTime * sideForce, 0,0,ForceMode.VelocityChange);
        }

        if (rigidBody.position.y < -1.5f)
        {
            FindObjectOfType<GameManagerScript>().EndGame();
        }
    }
}
