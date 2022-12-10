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
    bool HasDied;
    Animator m_Animator;
    public AudioClip DeathSound;
    public AudioClip JumpSound;
    public delegate void MyDelegate();


    private void Start()
    {
        CurrentlyTouchingPlayer = new List<GameObject>();

        m_Animator = gameObject.GetComponent<Animator>();
    }
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W))
        {
            if (grounded)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jump);
                AudioSource.PlayClipAtPoint(JumpSound, Camera.main.transform.position);
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
            m_Animator.SetBool("RunningLeft", true);
        }
        else
        {
            m_Animator.SetBool("RunningLeft", false);
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity += Speed;
            m_Animator.SetBool("RunningRight", true);
        }
        else
        {
            m_Animator.SetBool("RunningRight", false);
        }

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.GetComponent<SurfaceEffector2D>())
        {
            Conveyor = collision.transform.GetComponent<SurfaceEffector2D>();
        }

        if (collision.gameObject.tag == "DeathTrigger")
        {
            Dying();
        }
    }
    private void Dying()
    {
        AudioSource.PlayClipAtPoint(DeathSound, Camera.main.transform.position);

        if (HasDied == false)
        {
            Instantiate(Corpse, Player.transform.position, Quaternion.Euler(0, 0, 0));
            HasDied = true;
        }

        transform.position = RespawnPos.transform.position;
        GetComponent<Rigidbody2D>().velocity = Vector3.zero;

        CurrentlyTouchingPlayer.Clear();

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Coffin")
        {
            Controller.Win();
        }

        CurrentlyTouchingPlayer.Add(collision.gameObject);

        CheckIfPlayerIsGrounded();
    }
    void OnCollisionExit2D(Collision2D col)
    {
        if (col.transform.GetComponent<SurfaceEffector2D>())
        {
            Conveyor = null;
        }

        HasDied = false;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (CurrentlyTouchingPlayer.Contains(collision.gameObject))
        {
            CurrentlyTouchingPlayer.Remove(collision.gameObject);
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
