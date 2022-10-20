using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltBehavior : MonoBehaviour
{
    public float Speed;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
        rb.velocity = Vector2.left * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
    }
}
