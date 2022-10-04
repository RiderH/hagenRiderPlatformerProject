using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class PlayerBehavior : MonoBehaviour
{
    public float speed;
    public float jump;
    float moveVelocity;

    bool grounded = true;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jump);
            }
        }

        moveVelocity = 0;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

    }
    void OnTriggerEnter2D()
    {
        grounded = true;
    }

    void OnTriggerExit2D()
    {
        grounded = false;
    }
}
