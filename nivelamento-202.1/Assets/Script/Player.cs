using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float[] lanes = new float[3] { -7f, 0f, 7f };
    public int currentLane = 1;
    public Singletron singletron;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    public void movement()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            currentLane++;
            if (currentLane >= lanes.Length)
            {

                currentLane = lanes.Length - 1;
            }
            float newX = lanes[currentLane];
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            currentLane--;
            if (currentLane < 0)
            {
                currentLane = 0;
            }
            float newX = lanes[currentLane];
            transform.position = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("coin"))
        {
            singletron.UpdateScore();
        }
        if (other.CompareTag("enemy"))
        {
            singletron.GameOver();

        }
        GameObject.Destroy(other.gameObject);
    }
}


