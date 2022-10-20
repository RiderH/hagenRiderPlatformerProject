using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehavior : MonoBehaviour
{
    public GameObject ConnectedPlatform;
    public GameObject AdjustedPosition;
    public List<GameObject> CurrentlyTouchingButton;
    public Vector2 StartPostition;
    // Start is called before the first frame update
    void Start()
    {
        CurrentlyTouchingButton = new List<GameObject>();

        StartPostition = ConnectedPlatform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CurrentlyTouchingButton.Add(collision.gameObject);

        CheckIfButtonIsActive();
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
        }
        else
        {
            ConnectedPlatform.transform.position = StartPostition;
        }
    }


}
