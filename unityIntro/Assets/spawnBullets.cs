using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBullets : MonoBehaviour
{

    //defining a bullet prefab from assets
    public GameObject bulletPrefab;

    //this is the time threshhold, basically a timer length
    public float spawnTime = 999999999.0f;

    //basically the "lifetime" or countdown of the bullet spawning.
    private float currentTime = 0.0f;


    //how fast it goes
    public float bulletForce = 5.0f;

    // Update is called once per frame
    void Update() {

        //add the time elapsed
        currentTime += Time.deltaTime;
        Debug.Log(currentTime);
        //if the time is past the threshhold, then spawn
        if (currentTime > spawnTime) {

            Debug.Log(currentTime + " is greater than " + spawnTime);
            //first arg is the object to spawn, second is the pos, third is the rotation
            GameObject bullet = GameObject.Instantiate(bulletPrefab, transform.position + transform.forward, Quaternion.identity);

            //now we add a force to the bullet
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * bulletForce, ForceMode.Impulse);

            //reset the timer
            currentTime = 0.0f;
        }


    }
}
