using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gun : MonoBehaviour
{
    public Transform bulletSpawnpoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 5;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
             Instantiate(bulletPrefab, bulletSpawnpoint.position, bulletSpawnpoint.rotation);
            //bullet.GetComponent<Rigidbody>().velocity = bulletSpawnpoint.forward * bulletSpeed;
        }
    }
}
