using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float Speed;
    public float Jump;
    float moveVelocity;
    public GameObject RespawnPos;
    public GameObject Corpse;
    public GameObject Player;
    public SurfaceEffector2D Conveyor;
    public GameController Controller;
    bool grounded = true;
    public List<GameObject> CurrentlyTouchingPlayer;


    private void Start()
    {
        CurrentlyTouchingPlayer = new List<GameObject>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jump);
            }
        }

        moveVelocity = 0;

        if (Conveyor != null)
        {
            moveVelocity = Conveyor.speed;

        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVelocity += -Speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity += Speed;
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.transform.GetComponent<SurfaceEffector2D>())
        {
            Conveyor = col.transform.GetComponent<SurfaceEffector2D>();
        }

        if (col.gameObject.tag == "DeathTrigger")
        {
            Instantiate(Corpse, Player.transform.position, Quaternion.Euler(0, 0, 90));

            transform.position = RespawnPos.transform.position;
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        }

        if (col.gameObject.name == "Coffin")
        {
            Controller.Win();
        }

        CurrentlyTouchingPlayer.Add(col.gameObject);

        CheckIfPlayerIsGrounded();
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.GetComponent<SurfaceEffector2D>())
        {
            Conveyor = null;
        }

        if (CurrentlyTouchingPlayer.Contains(col.gameObject))
        {
            CurrentlyTouchingPlayer.Remove(col.gameObject);
        }

        CheckIfPlayerIsGrounded();
    }

    private void CheckIfPlayerIsGrounded()
    {
        if (CurrentlyTouchingPlayer.Count > 0)
        {
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

}
