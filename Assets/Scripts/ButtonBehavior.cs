using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject ConnectedPlatform;
    public GameObject AdjustedPosition;
    public List<GameObject> CurrentlyTouchingButton;
    public Vector2 StartPostition;
    public SpriteRenderer ButtonSpriteRenderer;
    public Sprite PushedButtonSprite;
    public Sprite ButtonSprite;
    public AudioClip DoorSound;

    void Start()
    {
        CurrentlyTouchingButton = new List<GameObject>();

        StartPostition = ConnectedPlatform.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CurrentlyTouchingButton.Add(collision.gameObject);

        CheckIfButtonIsActive();

        AudioSource.PlayClipAtPoint(DoorSound, Camera.main.transform.position);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (CurrentlyTouchingButton.Contains(collision.gameObject))
        {
            CurrentlyTouchingButton.Remove(collision.gameObject);
        }

        CheckIfButtonIsActive();
    }

    private void CheckIfButtonIsActive()
    {
        if(CurrentlyTouchingButton.Count > 0)
        {
            ConnectedPlatform.transform.position = AdjustedPosition.transform.position;
            ButtonSpriteRenderer.sprite = PushedButtonSprite;
        }
        else
        {
            ConnectedPlatform.transform.position = StartPostition;
            ButtonSpriteRenderer.sprite = ButtonSprite;
        }
    }


}
