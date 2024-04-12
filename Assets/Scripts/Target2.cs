using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Target2 : MonoBehaviour
{
    // Animal name. Used to determine the animation state names.
    [SerializeField]
    private string targetname = "Target2";
    // Simple timer.
    private bool timeOn = false;
    private float countDown = 0;
    // The start position.
    private Vector3 home = new Vector3();
    // The player.
    private GameObject player;
    // Current Speed.
    private float currentSpeed = 3;

    // Start is called before the first frame update
    void Start()
    {
        home = transform.position;
        home.y = home.y + 1;
        player = GameObject.FindWithTag("Player");
        // Set an initial wait time between 1 and 6 seconds.
        timeOn = true;
        countDown = Random.Range(1.0f, 6.0f);
        currentSpeed = Random.Range(2.0f, 12.0f);
    }
    // Update is called once per frame
    void Update()
    {
        // Simple countdown timer to pause
        if (timeOn)
        {
            countDown = countDown - Time.deltaTime;
            if (countDown <= 0)
            {
                // End timer.
                timeOn = false;
                transform.position = home;
            }
            else
            {
                return;
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet"))
        {
            // Destory the projectile.
            Destroy(collision.gameObject);
            // hide the animal.
            transform.position = new Vector3(0, -1000, 0);
            // Set a wait time between 1 and 6 seconds.
            timeOn = true;
            countDown = Random.Range(2.0f, 8.0f);
            currentSpeed = Random.Range(2.0f, 12.0f);
        }
    }
}