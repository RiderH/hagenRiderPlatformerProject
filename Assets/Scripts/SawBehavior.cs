using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawBehavior : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        
    }

    private void Update()
    {
        transform.Rotate(new Vector3(0, 0, Speed * Time.deltaTime));
    }
}
