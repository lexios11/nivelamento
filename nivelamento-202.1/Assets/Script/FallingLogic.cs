using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLogic : MonoBehaviour  
{
    float speed = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fall();
    }

    void fall()
    {
        //transform.Translate(0, Time.deltaTime *-speed,0, Space.World));
        transform.Translate(-transform.up * Time.deltaTime * speed);
    }
}
