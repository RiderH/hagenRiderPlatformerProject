using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBehavior : MonoBehaviour
{
    public float Interval = 5;
    float timer;
    public GameObject Bolt;
    
        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= Interval)
        {
            Instantiate(Bolt, this.transform.position, Quaternion.identity);
            timer = 0;
        }
    }
}
